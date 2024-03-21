using Strawberry.MobileApp.Helpers;
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
    public partial class ServiceCenterPage : BasePage
    {
        public ServiceCenterPage()
        {
            InitializeComponent();
        }

        public async Task ShowPageAsync()
        {
            await App.Instance.MainPage.Navigation.PushAsync(this);
        }

        private async void ClosePage_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }

        private async void Patent_Clicked(object sender, EventArgs e)
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
                await TermsPage.ShowPageAsync("특허저작권경고", $"{Settings.ServerUrl}/system/patentterm");
                //await Browser.OpenAsync($"{Settings.ServerUrl}/system/patentterm", BrowserLaunchMode.SystemPreferred);
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

        private async void UseTerm_Clicked(object sender, EventArgs e)
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
                await TermsPage.ShowPageAsync("이용약관", $"{Settings.ServerUrl}/system/useterm");
                //await Browser.OpenAsync($"{Settings.ServerUrl}/system/useterm", BrowserLaunchMode.SystemPreferred);
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

        private async void LocationTerm_Clicked(object sender, EventArgs e)
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
                await TermsPage.ShowPageAsync("위치기반 서비스 이용약관", $"{Settings.ServerUrl}/system/locationterm");
                //await Browser.OpenAsync($"{Settings.ServerUrl}/system/locationterm", BrowserLaunchMode.SystemPreferred);
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

        private async void PrivacyTerm_Clicked(object sender, EventArgs e)
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
                await TermsPage.ShowPageAsync("개인정보 처리방침", $"{Settings.ServerUrl}/system/privacyterm");
                //await Browser.OpenAsync($"{Settings.ServerUrl}/system/privacyterm", BrowserLaunchMode.SystemPreferred);
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

        private async void ContentTerm_Clicked(object sender, EventArgs e)
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
                await TermsPage.ShowPageAsync("사용자 제작 컨텐츠 약관", $"{Settings.ServerUrl}/system/contentterm");
                //await Browser.OpenAsync($"{Settings.ServerUrl}/system/contentterm", BrowserLaunchMode.SystemPreferred);
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

        private async void Email_Clicked(object sender, EventArgs e)
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
                var email = default(string);
                using (var api = new ApiHelper())
                {
                    var result = await api.GetManagerEmail(
                        new
                        {
                            ManagerEmail = default(string)
                        });

                    email = result.ManagerEmail;
                }

                if (string.IsNullOrWhiteSpace(email))
                    throw new Exception("아직 운영되지 않습니다.");

                var message = new EmailMessage
                {
                    To = new List<string> { email },
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                Console.WriteLine(ex);
                await App.Instance.MainPage.DisplayToastAsync("이메일 발송이 지원되지 않는 기기입니다.");
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

        private async void Help_Clicked(object sender, EventArgs e)
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
                var page = new HelpPage();
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
}