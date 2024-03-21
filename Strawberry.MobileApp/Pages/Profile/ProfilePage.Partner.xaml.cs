using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Appeal;
using Strawberry.MobileApp.Pages.Main;
using Strawberry.MobileApp.Pages.RecommandPartner;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage_Partner : BasePage, IValueConverter, IMultiValueConverter
    {
        public ProfilePage_Partner_Data PageData
        {
            get => (ProfilePage_Partner_Data)this.BindingContext;
            private set => this.BindingContext = value;
        }

        public ProfilePage_Partner()
        {
            InitializeComponent();
        }

        public async Task ShowAsync(int id, bool isFreeView)
        {
            await this.GetDataAsync(id, isFreeView);

            if (id == App.Instance.Member.Id)
            {
                this.specialcomment.IsVisible = false;
                this.starpoints.IsVisible = false;
                this.buttons.IsVisible = false;
            }

            await App.Instance.MainPage.Navigation.PushAsync(this);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "MenuIndex0ToVisible":
                    return (int)value == 0;
                case "MenuIndex1ToVisible":
                    return (int)value == 1;
                case "MenuIndex0ToTextColor":
                    return (int)value == 0 ? Color.FromHex("000000") : Color.Gray;
                case "MenuIndex1ToTextColor":
                    return (int)value == 1 ? Color.FromHex("000000") : Color.Gray;
                case "0001":
                    return (int)value == 0;
                case "0002":
                    return (int)value != 0;
                case "0003":
                    return (int)value < 2 ? "icon_star2_off" : "icon_star_on";
                case "0004":
                    return (int)value < 4 ? "icon_star2_off" : "icon_star_on";
                case "0005":
                    return (int)value < 6 ? "icon_star2_off" : "icon_star_on";
                case "0006":
                    return (int)value < 8 ? "icon_star2_off" : "icon_star_on";
                case "0007":
                    return (int)value < 10 ? "icon_star2_off" : "icon_star_on";
                case "FreeChoiceCountToVisible":
                    return (int)value == 0;
                case "BirthDayVisible":
                    {
                        var data = (ObservableCollection<ProfilePage_Partner_Data_BirthDay>)value;
                        return data != null && data.Count > 0;
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "SelectedItemToWidth":
                    {
                        if (values[0] == values[1])
                            return 20;
                        else
                            return 10;
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

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public async Task GetDataAsync(int id, bool isFreeView)
        {
            using (var api = new ApiHelper())
            {
                if (isFreeView)
                {
                    var result = await api.GetFreeViewPartnerProfile(id, new
                    {
                        ProfilePagePartnerData = default(ProfilePage_Partner_Data),
                        BirthdayMembers = default(ProfilePage_Partner_Data_BirthDay[])
                    });

                    this.PageData = result.ProfilePagePartnerData;

                    if (result.BirthdayMembers != null && result.BirthdayMembers.Length > 0)
                    {
                        this.PageData.BirthdayMembers = new ObservableCollection<ProfilePage_Partner_Data_BirthDay>();
                        foreach (var item in result.BirthdayMembers)
                            this.PageData.BirthdayMembers.Add(item);
                    }
                }
                else
                {
                    var result = await api.GetPartnerProfile(id, new
                    {
                        Point = default(int),
                        ProfilePagePartnerData = default(ProfilePage_Partner_Data),
                        BirthdayMembers = default(ProfilePage_Partner_Data_BirthDay[])
                    });

                    App.Instance.Member.Point = result.Point;

                    this.PageData = result.ProfilePagePartnerData;

                    if (result.BirthdayMembers != null && result.BirthdayMembers.Length > 0)
                    {
                        this.PageData.BirthdayMembers = new ObservableCollection<ProfilePage_Partner_Data_BirthDay>();
                        foreach (var item in result.BirthdayMembers)
                            this.PageData.BirthdayMembers.Add(item);
                    }
                }
            }
        }

        public async Task GetAppealAsync(int id)
        {
            using (var api = new ApiHelper())
            {
                var result = await api.GetAppealOnPartnerProfile(
                    id,
                    this.PageData.Appeals.Count,
                    new
                    {
                        items = default(ProfilePage_Partner_Data_Appeal[])
                    });

                if (result.items == null || result.items.Length == 0)
                    return;

                foreach (var item in result.items)
                {
                    this.PageData.Appeals.Add(item);
                }
            }
        }

        private void Menu0_Clicked(object sender, EventArgs e)
        {
            this.PageData.MenuIndex = 0;
        }

        private async void Menu1_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (this.PageData.MenuIndex == 1)
                    return;

                this.PageData.MenuIndex = 1;
                this.PageData.Appeals.Clear();
                await this.GetAppealAsync(this.PageData.Id);
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

        private async void StarPoint02_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                this.PageData.StarPoint = 2;
                await this.ExcuteStarPoint();
            }
            catch (Exception ex)
            {
                this.PageData.StarPoint = 0;
                await this.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void StarPoint04_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                this.PageData.StarPoint = 4;
                await this.ExcuteStarPoint();
            }
            catch (Exception ex)
            {
                this.PageData.StarPoint = 0;
                await this.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void StarPoint06_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                this.PageData.StarPoint = 6;
                await this.ExcuteStarPoint();
            }
            catch (Exception ex)
            {
                this.PageData.StarPoint = 0;
                await this.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void StarPoint08_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                this.PageData.StarPoint = 8;
                await this.ExcuteStarPoint();
            }
            catch (Exception ex)
            {
                this.PageData.StarPoint = 0;
                await this.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void StarPoint10_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                this.PageData.StarPoint = 10;
                await this.ExcuteStarPoint();
            }
            catch (Exception ex)
            {
                this.PageData.StarPoint = 0;
                await this.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async Task ExcuteStarPoint()
        {
            using (var http = new HttpClient())
            {
                var apikey = await Settings.GetApiKey();
                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(apikey), "apikey");
                formData.Add(new StringContent(this.PageData.Id.ToString()), "partnerid");
                formData.Add(new StringContent(this.PageData.StarPoint.ToString()), "starpoint");
                var res = await http.PostAsync($"{Settings.ServerUrl}/Main/ExcuteStarPoint", formData);
                if (!res.IsSuccessStatusCode)
                    throw new Exception("잠시 후에 다시 시도해 주세요.");

                var resData = JsonConvert.DeserializeAnonymousType(await res.Content.ReadAsStringAsync(), new
                {
                    Message = default(string),
                });

                if (!string.IsNullOrWhiteSpace(resData.Message))
                    throw new Exception(resData.Message);
            }
        }

        private async void Choice_Clicked(object sender, EventArgs e)
        {
            if (this.PageData.IsReciveChoice)
            {
                await this.DisplayToastAsync("이미 좋아요를 보냈습니다.");
                return;
            }

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (App.Instance.Member.FreeChoiceCount == 0 && App.Instance.Member.Point < 5)
                {
                    var id = this.PageData.Id;
                    var profile = ((UriImageSource)this.PageData.ProfileImages[0].ProfileImageSource).Uri.AbsoluteUri;
                    var nickname = this.PageData.Nickname;
                    var dialog = new MainPage_Dialog_Payment(profile, nickname);
                    await this.Navigation.PushPopupAsync(dialog);
                    return;
                }

                using (var api = new ApiHelper())
                {
                    var result = await api.ExcuteChoice(this.PageData.Id, new
                    {
                        FreeChoiceCount = default(int),
                        Point = default(int)
                    });

                    App.Instance.Member.FreeChoiceCount = result.FreeChoiceCount;
                    App.Instance.Member.Point = result.Point;
                    this.PageData.IsReciveChoice = true;

                    await this.DisplayToastAsync("좋아요를 보냈습니다.");
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

        private async void SmartChoice_Clicked(object sender, EventArgs e)
        {
            if (this.PageData.IsReciveChoice)
            {
                await this.DisplayToastAsync("이미 좋아요를 보냈습니다.");
                return;
            }

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var id = this.PageData.Id;
                var profile = ((UriImageSource)this.PageData.ProfileImages[0].ProfileImageSource).Uri.AbsoluteUri;
                var nickname = this.PageData.Nickname;

                if (App.Instance.Member.FreeChoiceCount == 0 && App.Instance.Member.Point < 10)
                {
                    var dialog = new MainPage_Dialog_Payment(profile, nickname);
                    await this.Navigation.PushPopupAsync(dialog);
                    return;
                }

                var messageDialog = new MainPage_Dialog_SendSmartChoice(nickname, profile);
                await this.Navigation.PushPopupAsync(messageDialog);
                var message = await messageDialog.TaskCompletionSource.Task;

                if (string.IsNullOrWhiteSpace(message))
                    return;

                using (var api = new ApiHelper())
                {
                    var result = await api.ExcuteSmartChoice(id, message, new
                    {
                        Point = default(int)
                    });

                    App.Instance.Member.Point = result.Point;
                    this.PageData.IsReciveChoice = true;
                    await this.DisplayToastAsync("좋아요를 보냈습니다.");
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

        private async void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var oldScroll = (double)topbar01.Resources["oldScroll"];
                var maxDv = topbar01.BackgroundColor.A;
                Console.WriteLine(maxDv);

                if (oldScroll == 0 && e.ScrollY > 0)
                {
                    topbar01.Resources["oldScroll"] = e.ScrollY;

                    var animation = new Animation((dv) =>
                    {
                        topbar01.BackgroundColor = Color.FromRgba(0, 0, 0, dv);
                    }, 0, 0.31);
                    this.topbar01.Animate("topbaropacity", animation);
                }

                if (oldScroll > 0 && e.ScrollY == 0)
                {
                    topbar01.Resources["oldScroll"] = e.ScrollY;

                    var animation = new Animation((dv) =>
                    {
                        topbar01.BackgroundColor = Color.FromRgba(0, 0, 0, dv);
                    }, 0.31, 0);
                    this.topbar01.Animate("topbaropacity", animation);
                }

                var view = sender as ScrollView;

                var vHeight = view.Height;
                var cHeight = view.ContentSize.Height;
                var maxScroll = cHeight - vHeight;

                if (e.ScrollY + 100 > maxScroll)
                {
                    await this.GetAppealAsync(this.PageData.Id);
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

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
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
                var alertSelectorDialog = new ProfilePage_Dialog_AlertSelector();
                var type = await alertSelectorDialog.ShowDialog();
                switch (type)
                {
                    case ProfilePage_Dialog_AlertSelector.AlertTypes.Block:
                        {
                            using (var api = new ApiHelper())
                            {
                                await api.ExcuteProfileBlock(
                                    this.PageData.Id);

                                await this.DisplayToastAsync("차단되었습니다.");
                            }
                            break;
                        }
                    case ProfilePage_Dialog_AlertSelector.AlertTypes.Alert:
                        {
                            var dialog = new ProfilePage_Dialog_Alert();
                            dialog.Init(this.PageData.Nickname);
                            var result = await dialog.ShowDialog();
                            if (result == null)
                                return;

                            using (var api = new ApiHelper())
                            {
                                await api.ExcuteProfileAlert(
                                    this.PageData.Id,
                                    result.AlertType,
                                    result.AlertMessage,
                                    result.BlockChecked);

                                await this.DisplayToastAsync("신고되었습니다.");
                            }
                            break;
                        }
                    default:
                        return;
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

        private async void ViewProfile_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var element = (Element)sender;
                var data = (ProfilePage_Partner_Data_BirthDay)element.BindingContext;

                var profilePage = new ProfilePage_Partner();
                await profilePage.GetDataAsync(data.Id, true);
                await this.Navigation.PushAsync(profilePage);
                this.Navigation.RemovePage(this);
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

        private async void AppealItem_Clicked(object sender, EventArgs e)
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
                var data = element.BindingContext as ProfilePage_Partner_Data_Appeal;

                var page = new AppealDetailPage();
                await page.ShowAsync(data.Id);
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
                var element = sender as Element;
                var data = element.BindingContext as ProfilePage_Partner_Data_Appeal;

                var dialog = new AppealDetailAlertDialog();
                var result = await dialog.ShowDialogAsync();
                if (string.IsNullOrWhiteSpace(result.title))
                    return;

                using (var api = new ApiHelper())
                {
                    await api.ExcuteAlertPoomPoom(
                        result.title,
                        result.message,
                        data.Id,
                        data.MemberId);

                    await App.Instance.MainPage.DisplayToastAsync("신고되었습니다.");
                }
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

        private async void ProfileImage_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;

                this.LockData.IsLocked = true;
            }

            try
            {
                var view = sender as View;
                var data = view.BindingContext as Member_ProfileImage;

                if (data == null)
                    return;

                var imageUrl = ((UriImageSource)data.ProfileImageSource).Uri.AbsoluteUri;
                await ProfilePage_DetailImage.ShowPageAsync(imageUrl);
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
    }
}