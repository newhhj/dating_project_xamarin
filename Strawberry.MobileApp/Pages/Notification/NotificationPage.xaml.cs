using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Option;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Notification
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationPage : BasePage
    {
        public NotificationPageData PageData
        {
            get => (NotificationPageData)this.BindingContext;
            private set => this.BindingContext = value;
        }

        public NotificationPage()
        {
            InitializeComponent();
        }

        public async Task ShowPageAsync()
        {
            this.PageData = new NotificationPageData();
            await this.GetPageDataAsync();
            await App.Instance.MainPage.Navigation.PushAsync(this);
        }

        public async Task GetPageDataAsync()
        {
            using (var api = new ApiHelper())
            {
                var result = await api.GetNotifications(new
                {
                    Items = default(string[])
                });

                if (result.Items != null)
                {
                    for (int i = 0; i < result.Items.Length; i++)
                    {
                        var item = result.Items[i];

                        this.PageData.Items.Add(new NotificationPageItemData
                        {
                            IsVisibleSplitBar = i > 0,
                            Message = item
                        });
                    }
                }
            }
        }

        private void ClosePage_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
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
                await InappBillingHelper.SubscriptionAsync("item15", async (item) =>
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
                await InappBillingHelper.SubscriptionAsync("item16", async (item) =>
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

        private async void PaymentStore_Clicked(object sender, EventArgs e)
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
                var page = new PaymentStorePage();
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

    public class NotificationPageData : BindableObject
    {
        public ObservableCollection<NotificationPageItemData> Items { get => (ObservableCollection<NotificationPageItemData>)GetValue(ItemsProperty); set => SetValue(ItemsProperty, value); }
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<NotificationPageItemData>), typeof(NotificationPageData));

        public NotificationPageData()
        {
            this.Items = new ObservableCollection<NotificationPageItemData>();
        }
    }

    public class NotificationPageItemData : BindableObject
    {
        public bool IsVisibleSplitBar { get => (bool)GetValue(IsVisibleSplitBarProperty); set => SetValue(IsVisibleSplitBarProperty, value); }
        public static readonly BindableProperty IsVisibleSplitBarProperty = BindableProperty.Create(nameof(IsVisibleSplitBar), typeof(bool), typeof(NotificationPageItemData), true);

        public string Message { get => (string)GetValue(MessageProperty); set => SetValue(MessageProperty, value); }
        public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(NotificationPageItemData));
    }
}