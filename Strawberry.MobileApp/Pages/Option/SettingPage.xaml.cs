using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Intro;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Option
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : BasePage
    {
        public SettingPageData PageData { get => (SettingPageData)this.BindingContext; set => this.BindingContext = value; }

        public SettingPage()
        {
            InitializeComponent();
        }

        public async Task ShowPageAsync()
        {
            await this.GetPageDataAsync();
            await App.Instance.MainPage.Navigation.PushAsync(this);
        }

        private async Task GetPageDataAsync()
        {
            using (var api = new ApiHelper())
            {
                var result = await api.GetSettingPageData(new
                {
                    Item = default(SettingPageData)
                });

                this.PageData = result.Item;
            }
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void UseNotiRecommand_Toggled(object sender, ToggledEventArgs e)
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
                    await api.ExcuteToggleUseNotiRecommand(e.Value);
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await this.DisplayToastAsync(ex.Message);
                this.PageData.UseNotiRecommand = !e.Value;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void UseNotiReceiveChoice_Toggled(object sender, ToggledEventArgs e)
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
                    await api.ExcuteToggleUseNotiReceiveChoice(e.Value);
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await this.DisplayToastAsync(ex.Message);
                this.PageData.UseNotiRecommand = !e.Value;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void UseNotiSendChoiceConfirm_Toggled(object sender, ToggledEventArgs e)
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
                    await api.ExcuteToggleUseNotiSendChoiceConfirm(e.Value);
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await this.DisplayToastAsync(ex.Message);
                this.PageData.UseNotiRecommand = !e.Value;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void UseNotiReceiveFavorite_Toggled(object sender, ToggledEventArgs e)
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
                    await api.ExcuteToggleUseNotiReceiveFavorite(e.Value);
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await this.DisplayToastAsync(ex.Message);
                this.PageData.UseNotiRecommand = !e.Value;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void UseNotiConnect_Toggled(object sender, ToggledEventArgs e)
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
                    await api.ExcuteToggleUseNotiConnect(e.Value);
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await this.DisplayToastAsync(ex.Message);
                this.PageData.UseNotiRecommand = !e.Value;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void UseNotiChattingMessage_Toggled(object sender, ToggledEventArgs e)
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
                    await api.ExcuteToggleUseNotiChattingMessage(e.Value);
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await this.DisplayToastAsync(ex.Message);
                this.PageData.UseNotiRecommand = !e.Value;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void UseNotiAppeal_Toggled(object sender, ToggledEventArgs e)
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
                    await api.ExcuteToggleUseNotiAppeal(e.Value);
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await this.DisplayToastAsync(ex.Message);
                this.PageData.UseNotiRecommand = !e.Value;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void UseNotiMarketing_Toggled(object sender, ToggledEventArgs e)
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
                    await api.ExcuteToggleUseNotiMarketing(e.Value);
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await this.DisplayToastAsync(ex.Message);
                this.PageData.UseNotiRecommand = !e.Value;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void SettingAccount_Clicked(object sender, EventArgs e)
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
                var page = new SettingAccountPage();
                await page.ShowPageAcync();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await this.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Logout_Clicked(object sender, EventArgs e)
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
                await Settings.SetApiKey(null);

                var introPage = new Page_Intro();
                await this.Navigation.PushAsync(introPage);

                var removePages = this.Navigation.NavigationStack
                    .Where(x => x != introPage)
                    .ToArray();
                foreach (var removePage in removePages)
                    this.Navigation.RemovePage(removePage);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await this.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void MemberCenter_Clicked(object sender, EventArgs e)
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
                var page = new ServiceCenterPage();
                await page.ShowPageAsync();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }
    }

    public class SettingPageData : BindableObject
    {
        public bool UseNotiRecommand { get => (bool)GetValue(UseNotiRecommandProperty); set => SetValue(UseNotiRecommandProperty, value); }
        public static readonly BindableProperty UseNotiRecommandProperty = BindableProperty.Create(nameof(UseNotiRecommand), typeof(bool), typeof(SettingPageData));

        public bool UseNotiReceiveChoice { get => (bool)GetValue(UseNotiReceiveChoiceProperty); set => SetValue(UseNotiReceiveChoiceProperty, value); }
        public static readonly BindableProperty UseNotiReceiveChoiceProperty = BindableProperty.Create(nameof(UseNotiReceiveChoice), typeof(bool), typeof(SettingPageData));

        public bool UseNotiSendChoiceConfirm { get => (bool)GetValue(UseNotiSendChoiceConfirmProperty); set => SetValue(UseNotiSendChoiceConfirmProperty, value); }
        public static readonly BindableProperty UseNotiSendChoiceConfirmProperty = BindableProperty.Create(nameof(UseNotiSendChoiceConfirm), typeof(bool), typeof(SettingPageData));

        public bool UseNotiReceiveFavorite { get => (bool)GetValue(UseNotiReceiveFavoriteProperty); set => SetValue(UseNotiReceiveFavoriteProperty, value); }
        public static readonly BindableProperty UseNotiReceiveFavoriteProperty = BindableProperty.Create(nameof(UseNotiReceiveFavorite), typeof(bool), typeof(SettingPageData));

        public bool UseNotiConnect { get => (bool)GetValue(UseNotiConnectProperty); set => SetValue(UseNotiConnectProperty, value); }
        public static readonly BindableProperty UseNotiConnectProperty = BindableProperty.Create(nameof(UseNotiConnect), typeof(bool), typeof(SettingPageData));

        public bool UseNotiChattingMessage { get => (bool)GetValue(UseNotiChattingMessageProperty); set => SetValue(UseNotiChattingMessageProperty, value); }
        public static readonly BindableProperty UseNotiChattingMessageProperty = BindableProperty.Create(nameof(UseNotiChattingMessage), typeof(bool), typeof(SettingPageData));

        public bool UseNotiAppeal { get => (bool)GetValue(UseNotiAppealProperty); set => SetValue(UseNotiAppealProperty, value); }
        public static readonly BindableProperty UseNotiAppealProperty = BindableProperty.Create(nameof(UseNotiAppeal), typeof(bool), typeof(SettingPageData));

        public bool UseNotiMarketing { get => (bool)GetValue(UseNotiMarketingProperty); set => SetValue(UseNotiMarketingProperty, value); }
        public static readonly BindableProperty UseNotiMarketingProperty = BindableProperty.Create(nameof(UseNotiMarketing), typeof(bool), typeof(SettingPageData));
    }
}