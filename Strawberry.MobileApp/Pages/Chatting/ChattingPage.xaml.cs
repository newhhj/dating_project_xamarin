using FFImageLoading;
using Rg.Plugins.Popup.Extensions;
using SkiaSharp;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Main;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Chatting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChattingPage : BasePage
    {
        public int RoomId { get; private set; }

        public ChattingPageData PageData { get => (ChattingPageData)this.BindingContext; private set => this.BindingContext = value; }

        public ChattingPage()
        {
            InitializeComponent();
        }

        private async Task GetChattingInfo()
        {
            using (var api = new ApiHelper())
            {
                var result = await api.GetChattingInfo(
                    this.RoomId,
                    new
                    {
                        item = default(ChattingPageData)
                    });

                this.PageData = result.item;
            }

            if (this.PageData.Messages != null && this.PageData.Messages.Count > 0)
            {
                var count = this.PageData.Messages.Count(x => !x.IsMyMsg);
                if (this.PageData.Room.OpenMemberId == App.Instance.Member.Id && count == 0)
                {
                    var firstMsg = this.PageData.Messages?
                        .FirstOrDefault(x => x.IsMyMsg);

                    if (firstMsg?.CreateTime.AddHours(24) < DateTime.Now && this.PageData.Room.UsePoint)
                    {
                        this.PageData.Messages.Add(new ChattingPageData_Message
                        {
                            Type = DataModels.MessageTypes.Wait
                        });
                    }
                }
            }

            if (this.PageData.Room.Member1.Id == App.Instance.Member.Id ? this.PageData.Room.IsCloseMember2 : this.PageData.Room.IsCloseMember1)
            {
                this.PageData.Messages.Add(new ChattingPageData_Message
                {
                    Type = DataModels.MessageTypes.Close
                });
            }
        }

        public async Task ShowPageAsync(int roomId)
        {
            this.RoomId = roomId;
            await this.GetChattingInfo();
            await App.Instance.MainPage.Navigation.PushAsync(this);
            await Task.Delay(500);
            await this.scrollView1.ScrollToAsync(0, this.scrollView1.ContentSize.Height, false);
        }

        public async Task AppendMessageAsync(ChattingPageData_Message message)
        {
            this.PageData.Messages.Add(message);
            await Task.Delay(30);
            await this.scrollView1.ScrollToAsync(0, this.scrollView1.ContentSize.Height, false);

            if (message.Id > 0)
            {
                _ = Task.Run(async () =>
                {
                    using (var api = new ApiHelper())
                    {
                        await api.ExcuteShowChattingMessage(message.Id);
                    }
                });
            }
        }

        private void PartnerBalloon_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            try
            {
                var resource = (StreamImageSource)ImageSource.FromResource("Strawberry.MobileApp.Images.img_balloon_partner.png", this.GetType().Assembly);
                var density = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density;
                var sizeRect = new SKRectI(0, 0, (int)(100 * density), (int)(100 * density));

                using (var stream = resource.Stream(CancellationToken.None).Result)
                using (var bitmap = SKBitmap.Decode(stream))
                using (var resizeBitmap = bitmap.Resize(sizeRect.AspectFit(bitmap.Info.Size).Size, SKFilterQuality.High))
                {
                    var rect = new SKRectI(
                        resizeBitmap.Width * 250 / bitmap.Width,
                        resizeBitmap.Height * 150 / bitmap.Height,
                        resizeBitmap.Width * 600 / bitmap.Width,
                        resizeBitmap.Height * 160 / bitmap.Height);

                    e.Surface.Canvas.Clear();
                    e.Surface.Canvas.DrawBitmapNinePatch(resizeBitmap, rect, e.Info.Rect);
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                Console.WriteLine(ex);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void MemberBalloon_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            try
            {
                var resource = (StreamImageSource)ImageSource.FromResource("Strawberry.MobileApp.Images.img_balloon_member.png", this.GetType().Assembly);
                var density = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density;
                var sizeRect = new SKRectI(0, 0, (int)(100 * density), (int)(100 * density));

                using (var stream = resource.Stream(CancellationToken.None).Result)
                using (var bitmap = SKBitmap.Decode(stream))
                using (var resizeBitmap = bitmap.Resize(sizeRect.AspectFit(bitmap.Info.Size).Size, SKFilterQuality.High))
                {
                    var rect = new SKRectI(
                        resizeBitmap.Width * 200 / bitmap.Width,
                        resizeBitmap.Height * 150 / bitmap.Height,
                        resizeBitmap.Width * 550 / bitmap.Width,
                        resizeBitmap.Height * 160 / bitmap.Height);

                    e.Surface.Canvas.Clear();
                    e.Surface.Canvas.DrawBitmapNinePatch(resizeBitmap, rect, e.Info.Rect);
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                Console.WriteLine(ex);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void Image_SizeChanged(object sender, EventArgs e)
        {
            var view = sender as Image;
            if (view.Width <= 50)
                return;

            var data = view.BindingContext as ChattingPageData_Message;
            view.WidthRequest = 200;
            view.HeightRequest = 200 * data.Ratio;
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.Navigation.PopAsync();
        }

        private async void Message_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(500);
            await this.scrollView1.ScrollToAsync(0, this.scrollView1.ContentSize.Height, false);
        }

        private async void OpenChatting_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                using (var api = new ApiHelper())
                {
                    var result = await api.GetPointInfo(new
                    {
                        Point = default(int),
                        FreeChoiceCount = default(int),
                        FreeChattingCount = default(int),
                        FreeChattingTime = default(DateTime?),
                        FreeChoiceTime = default(DateTime?),
                        FreeSmartChoiceTime = default(DateTime?),
                    });

                    if (result.FreeChattingTime.HasValue && result.FreeChattingTime >= DateTime.Now)
                    {
                        await api.ExcuteOpenChatting(this.PageData.Room.Id);
                        this.PageData.Room.IsPayPoint = true;
                    }
                    else if (result.FreeChattingCount > 0)
                    {
                        await api.ExcuteOpenChatting(this.PageData.Room.Id);
                        this.PageData.Room.IsPayPoint = true;
                    }
                    else if (result.Point >= 5)
                    {
                        var confirmDialog = new ConfirmDialog("알림", "딸기 5개를 소모하여 대화를 시작합니다.");
                        if (!await confirmDialog.ShowDialog())
                            return;

                        await api.ExcuteOpenChatting(this.PageData.Room.Id);
                        this.PageData.Room.IsPayPoint = true;
                    }
                    else
                    {
                        var paymentDialog = new MainPage_Dialog_Payment2();
                        await this.Navigation.PushPopupAsync(paymentDialog);
                    }
                }
            }
            catch (Exception ex)
            {
                await this.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Message_Completed(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            var item = default(ChattingPageData_Message);

            try
            {
                if (string.IsNullOrWhiteSpace(this.PageData.Message))
                    return;

                item = new ChattingPageData_Message
                {
                    Content = this.PageData.Message,
                    CreateTime = DateTime.Now,
                    IsMyMsg = true,
                    IsShow = false,
                    Type = DataModels.MessageTypes.Text
                };

                await this.AppendMessageAsync(item);

                using (var api = new ApiHelper())
                {
                    var result = await api.ExcuteSendTextMessage(
                        this.PageData.Room.Id,
                        this.PageData.Room.Partner.Id,
                        this.PageData.Message,
                        new
                        {
                            MessageId = default(int)
                        });

                    item.Id = result.MessageId;
                }

                this.PageData.Message = null;

                if (!this.PageData.Messages.Any(x => x.Type == DataModels.MessageTypes.StarPoint)
                    && this.PageData.Room.OpenMemberId == App.Instance.Member.Id
                    && this.PageData.Room.StarPoint == 0
                    && this.PageData.Messages.Any(x => !x.IsMyMsg)
                    && this.PageData.Messages.Count >= 10)
                {
                    await this.AppendMessageAsync(new ChattingPageData_Message
                    {
                        Type = DataModels.MessageTypes.StarPoint
                    });
                }
            }
            catch (Exception ex)
            {
                if (item != null)
                    this.PageData.Messages.Remove(item);

                await this.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Image_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            var item = default(ChattingPageData_Message);

            try
            {
                var data = await this.TakeImageAsync();
                if (data.buffer == null)
                    return;

                item = new ChattingPageData_Message
                {
                    Content = null,
                    CreateTime = DateTime.Now,
                    IsMyMsg = true,
                    IsShow = false,
                    Type = DataModels.MessageTypes.Image
                };

                await this.AppendMessageAsync(item);

                using (var api = new ApiHelper())
                {
                    var result = await api.ExcuteSendImageMessage(
                        this.PageData.Room.Id,
                        this.PageData.Room.Partner.Id,
                        data.filename,
                        data.buffer,
                        new
                        {
                            MessageId = default(int),
                            Url = default(string)
                        });

                    item.Id = result.MessageId;
                    item.Content = result.Url;
                }

                if (!this.PageData.Messages.Any(x => x.Type == DataModels.MessageTypes.StarPoint)
                    && this.PageData.Room.OpenMemberId == App.Instance.Member.Id
                    && this.PageData.Room.StarPoint == 0
                    && this.PageData.Messages.Any(x => !x.IsMyMsg)
                    && this.PageData.Messages.Count >= 10)
                {
                    await this.AppendMessageAsync(new ChattingPageData_Message
                    {
                        Type = DataModels.MessageTypes.StarPoint
                    });
                }
            }
            catch (Exception ex)
            {
                if (item != null)
                    this.PageData.Messages.Remove(item);

                await this.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void ChattingClose_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                using (var api = new ApiHelper())
                {
                    await api.ExcuteRemoveChattingRoom(this.PageData.Room.Id);
                }

                var mainPage = (MainPage)App.Instance.MainPage.Navigation.NavigationStack
                    .FirstOrDefault(x => x is MainPage);

                var mainPageData = mainPage.BindingContext as MainPage_Data;
                var item = mainPageData.Items
                    .Where(x => x is MainPage_View12_Data)
                    .Where(x => ((MainPage_View12_Data)x).Id == this.PageData.Room.Id)
                    .FirstOrDefault();

                if (item != null)
                {
                    mainPageData.Items.Remove(item);
                }

                await this.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await this.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Star1_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (this.PageData.Room.StarPoint > 0)
                    return;

                this.PageData.Room.StarPoint = 1;

                using (var api = new ApiHelper())
                {
                    await api.ExcuteRoomStarPoint(
                        this.PageData.Room.Id,
                        this.PageData.Room.StarPoint);
                }

                await App.Instance.MainPage.DisplayToastAsync("딸기 1개가 적립되었습니다.");
            }
            catch (Exception ex)
            {
                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Star2_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (this.PageData.Room.StarPoint > 0)
                    return;

                this.PageData.Room.StarPoint = 2;

                using (var api = new ApiHelper())
                {
                    await api.ExcuteRoomStarPoint(
                        this.PageData.Room.Id,
                        this.PageData.Room.StarPoint);
                }

                await App.Instance.MainPage.DisplayToastAsync("딸기 1개가 적립되었습니다.");
            }
            catch (Exception ex)
            {
                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Star3_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (this.PageData.Room.StarPoint > 0)
                    return;

                this.PageData.Room.StarPoint = 3;

                using (var api = new ApiHelper())
                {
                    await api.ExcuteRoomStarPoint(
                        this.PageData.Room.Id,
                        this.PageData.Room.StarPoint);
                }

                await App.Instance.MainPage.DisplayToastAsync("딸기 1개가 적립되었습니다.");
            }
            catch (Exception ex)
            {
                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Star4_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (this.PageData.Room.StarPoint > 0)
                    return;

                this.PageData.Room.StarPoint = 4;

                using (var api = new ApiHelper())
                {
                    await api.ExcuteRoomStarPoint(
                        this.PageData.Room.Id,
                        this.PageData.Room.StarPoint);
                }

                await App.Instance.MainPage.DisplayToastAsync("딸기 1개가 적립되었습니다.");
            }
            catch (Exception ex)
            {
                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Star5_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (this.PageData.Room.StarPoint > 0)
                    return;

                this.PageData.Room.StarPoint = 5;

                using (var api = new ApiHelper())
                {
                    await api.ExcuteRoomStarPoint(
                        this.PageData.Room.Id,
                        this.PageData.Room.StarPoint);
                }

                await App.Instance.MainPage.DisplayToastAsync("딸기 1개가 적립되었습니다.");
            }
            catch (Exception ex)
            {
                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Alert_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var dialog = new ChattingAlertDialog();
                await dialog.ShowDialogAsync(this.PageData);
            }
            catch (Exception ex)
            {
                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void WaitPartner_Click(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var view = sender as View;
                var data = view.BindingContext as ChattingPageData_Message;

                this.PageData.Messages.Remove(data);
            }
            catch (Exception ex)
            {
                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void RefeelPoint_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var view = sender as View;
                var data = view.BindingContext as ChattingPageData_Message;

                using (var api = new ApiHelper())
                {
                    await api.ExcuteRefeelPoint(this.PageData.Room.Id);
                }

                var mainPage = (MainPage)App.Instance.MainPage.Navigation.NavigationStack
                    .FirstOrDefault(x => x is MainPage);

                var mainPageData = mainPage.BindingContext as MainPage_Data;
                var item = mainPageData.Items
                    .Where(x => x is MainPage_View12_Data)
                    .Where(x => ((MainPage_View12_Data)x).Id == this.PageData.Room.Id)
                    .FirstOrDefault();

                if (item != null)
                {
                    mainPageData.Items.Remove(item);
                }

                await this.Navigation.PopAsync();

                await App.Instance.MainPage.DisplayToastAsync("딸기 5개를 회수했습니다.");
            }
            catch (Exception ex)
            {
                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }
    }
}