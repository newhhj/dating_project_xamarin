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
    public partial class RoyalCenterPage : BasePage
    {
        public RoyalCenterPage()
        {
            InitializeComponent();
        }

        public Task ShowPageAsync()
        {
            return App.Instance.MainPage.Navigation.PushAsync(this);
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void Item01_Clicked(object sender, EventArgs e)
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
                var page = new RoyalCenterTermsPage();
                await page.ShowPageAsync("item06");
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

        private async void Item02_Clicked(object sender, EventArgs e)
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
                var page = new RoyalCenterTermsPage();
                await page.ShowPageAsync("item07");
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

        private async void Item03_Clicked(object sender, EventArgs e)
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
                var page = new RoyalCenterTermsPage();
                await page.ShowPageAsync("item08");
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

        private async void Item04_Clicked(object sender, EventArgs e)
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
                await InappBillingHelper.SubscriptionAsync("item09", async (item) =>
                {
                    using (var api = new ApiHelper())
                    {
                        await api.ExcutePurchase(
                            DeviceInfo.Platform.ToString(),
                            item.ProductId,
                            item.Id,
                            item.PurchaseToken,
                            item.TransactionDateUtc);
                    }
                });
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

        private async void Item05_Clicked(object sender, EventArgs e)
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
                await InappBillingHelper.SubscriptionAsync("item10", async (item) =>
                {
                    using (var api = new ApiHelper())
                    {
                        await api.ExcutePurchase(
                            DeviceInfo.Platform.ToString(),
                            item.ProductId,
                            item.Id,
                            item.PurchaseToken,
                            item.TransactionDateUtc);
                    }
                });
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

        private async void Item06_Clicked(object sender, EventArgs e)
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
                await InappBillingHelper.SubscriptionAsync("item11", async (item) =>
                {
                    using (var api = new ApiHelper())
                    {
                        await api.ExcutePurchase(
                            DeviceInfo.Platform.ToString(),
                            item.ProductId,
                            item.Id,
                            item.PurchaseToken,
                            item.TransactionDateUtc);
                    }
                });
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

    public class RoyalCenterPageData : BindableObject
    {
        public bool IsVisibleMaleContent { get => (bool)GetValue(IsVisibleMaleContentProperty); set => SetValue(IsVisibleMaleContentProperty, value); }
        public static readonly BindableProperty IsVisibleMaleContentProperty = BindableProperty.Create(nameof(IsVisibleMaleContent), typeof(bool), typeof(RoyalCenterPageData), true);

        public bool IsVisibleFemaleContent { get => (bool)GetValue(IsVisibleFemaleContentProperty); set => SetValue(IsVisibleFemaleContentProperty, value); }
        public static readonly BindableProperty IsVisibleFemaleContentProperty = BindableProperty.Create(nameof(IsVisibleFemaleContent), typeof(bool), typeof(RoyalCenterPageData), false);

        public RoyalCenterPageData()
        {
            this.IsVisibleMaleContent = App.Instance.Member?.Gender == DataModels.GenderTypes.Male;
            this.IsVisibleFemaleContent = App.Instance.Member?.Gender == DataModels.GenderTypes.Female;
        }
    }
}