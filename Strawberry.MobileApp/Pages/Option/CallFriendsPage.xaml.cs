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
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Option
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CallFriendsPage : BasePage
    {
        public CallFriendsPage()
        {
            InitializeComponent();
        }

        public Task ShowPageAsync()
        {
            return App.Instance.MainPage.Navigation.PushAsync(this);
        }

        private void ClosePage_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private void Image_SizeChanged(object sender, EventArgs e)
        {
            var view = sender as View;
            view.HeightRequest = view.Width * 671d / 720d;
        }

        private async void Accept_Clicked(object sender, EventArgs e)
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
                    var result = await api.GetShareCode(new
                    {
                        Code = default(string)
                    });

                    var uri = default(string);
                    if (DeviceInfo.Platform == DevicePlatform.Android)
                    {
                        uri = $"https://play.google.com/store/apps/details?id={AppInfo.PackageName}&referrer={result.Code}";
                    }
                    else
                    {
                        uri = $"{Settings.ServerUrl}/iosinstall.html?id={AppInfo.PackageName}&referrer={result.Code}";
                    }

                    var msg = $@"[딸기]

{uri}";

                    await Share.RequestAsync(msg);
                }
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