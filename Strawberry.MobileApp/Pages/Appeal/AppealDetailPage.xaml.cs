using FFImageLoading;
using FFImageLoading.Forms;
using SkiaSharp;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Profile;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Strawberry.MobileApp.Pages.Appeal.AppealDetailPageData;

namespace Strawberry.MobileApp.Pages.Appeal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppealDetailPage : BasePage, IValueConverter
    {
        public AppealDetailPage()
        {
            InitializeComponent();
        }

        public async Task ShowAsync(int contentId)
        {
            await this.GetData(contentId);
            await App.Instance.MainPage.Navigation.PushAsync(this);
        }

        private async Task GetData(int contentId)
        {
            using (var api = new ApiHelper())
            {
                var result = await api.GetPoomPoom(
                    contentId,
                    new
                    {
                        item = default(AppealDetailPageData)
                    });

                this.BindingContext = result.item;
            }
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.Navigation.PopAsync();
        }

        private void Image_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                var view = sender as Image;
                var data = view.BindingContext as AppealDetailPageData.ImageData;
                data.ViewWidth = view.Width;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private async void ProfileImage_Clicked(object sender, EventArgs e)
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
                var element = sender as Element;
                var data = element.BindingContext as AppealDetailPageData;

                var page = new ProfilePage_Partner();
                await page.ShowAsync(data.MemberId, true);
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

        private async void CommentProfileImage_Clicked(object sender, EventArgs e)
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
                var element = sender as Element;
                var data = element.BindingContext as AppealDetailPageData.CommentData;

                var page = new ProfilePage_Partner();
                await page.ShowAsync(data.MemberId, true);
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

        private async void AppealAlert_Clicked(object sender, EventArgs e)
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
                var dialog = new AppealDetailAlertDialog();
                var result = await dialog.ShowDialogAsync();
                if (string.IsNullOrWhiteSpace(result.title))
                    return;

                var element = sender as Element;
                var data = element.BindingContext as AppealDetailPageData;

                using (var api = new ApiHelper())
                {
                    await api.ExcuteAlertPoomPoom(
                        result.title,
                        result.message,
                        data.Id,
                        data.MemberId);
                }

                await this.DisplayToastAsync("신고되었습니다.");
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

        private async void ToggleLike_Clicked(object sender, EventArgs e)
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
                    var data = this.BindingContext as AppealDetailPageData;
                    var result = await api.ExcutePoomPoomLike(
                        data.Id,
                        new
                        {
                            count = default(int),
                            isLike = default(bool)
                        });

                    data.Likes = result.count;
                    data.UseLike = result.isLike;
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

        private async void NewComment_Clicked(object sender, EventArgs e)
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
                var data = this.BindingContext as AppealDetailPageData;
                if (string.IsNullOrWhiteSpace(data.NewComment))
                    return;

                using (var api = new ApiHelper())
                {
                    var result = await api.ExcutePoomPoomComment(
                        data.Id, 
                        data.NewComment, 
                        data.ReplyMemberId, 
                        new
                        {
                            Comment = default(AppealDetailPageData.CommentData)
                        });

                    if (data.Comments == null)
                        data.Comments = new ObservableCollection<AppealDetailPageData.CommentData>();

                    data.Comments.Add(result.Comment);
                    data.InvokePropertyChanged(nameof(data.CommentsVisible));

                    data.ReplyMemberId = null;
                    data.ReplyNickname = null;
                    data.NewComment = null;

                    await Task.Delay(1);

                    var item = this.element_Comments.Children.LastOrDefault();
                    if (item != null)
                        await scrollView.ScrollToAsync(item, ScrollToPosition.MakeVisible, false);
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

        private void CommentReply_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();

            var pageData = this.BindingContext as AppealDetailPageData;
            var element = sender as Element;
            var data = element.BindingContext as AppealDetailPageData.CommentData;

            pageData.ReplyMemberId = data.MemberId;
            pageData.ReplyNickname = data.Nickname;

            this.entry_Comment.Focus();
        }

        private async void CommentAlert_Clicked(object sender, EventArgs e)
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
                var dialog = new AppealDetailAlertCommentDialog();
                var result = await dialog.ShowAsync();
                if (string.IsNullOrWhiteSpace(result))
                    return;

                var element = sender as Element;
                var data = element.BindingContext as AppealDetailPageData.CommentData;

                using (var api = new ApiHelper())
                {
                    await api.ExcuteAlertPoomPoomComment(
                        data.CommentId,
                        data.MemberId,
                        result);
                }

                await this.DisplayToastAsync("해당 댓글이 신고되었습니다.");
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

        private async void CommentRemove_Clicked(object sender, EventArgs e)
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
                var dialog = new ConfirmDialog("알림", "해당 댓글을 삭제하시겠습니까?");
                var result = await dialog.ShowDialog();
                if (!result)
                    return;

                using (var api = new ApiHelper())
                {
                    var element = sender as Element;
                    var data = element.BindingContext as AppealDetailPageData.CommentData;
                    await api.RemovePoomPoomComment(data.CommentId);

                    var pageData = this.BindingContext as AppealDetailPageData;
                    pageData.Comments.Remove(data);
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

        private void StackLayout_SizeChanged(object sender, EventArgs e)
        {
            var stackLayout = sender as StackLayout;
            if (stackLayout.Width <= 0)
                return;

            foreach (var imageView in stackLayout.Children)
            {
                var data = imageView.BindingContext as ImageData;
                data.ViewWidth = stackLayout.Width;
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "ScrollViewMargin":
                {
                    var height = (double)value;
                    return new Thickness(0, 50, 0, height);
                }
                default:
                    break;
            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}