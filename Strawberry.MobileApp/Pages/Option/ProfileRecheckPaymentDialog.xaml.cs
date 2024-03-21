using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Option
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileRecheckPaymentDialog : PopupPage
    {
        private ProfileRecheckPaymentDialogData PageData
        {
            get => (ProfileRecheckPaymentDialogData)this.BindingContext;
            set => this.BindingContext = value;
        }

        private LockDataModel LockData { get; set; } = new LockDataModel();

        public ProfileRecheckPaymentDialog()
        {
            InitializeComponent();
        }

        public Task ShowDialogAsync()
        {
            return App.Instance.MainPage.Navigation.PushPopupAsync(this);
        }

        private void Item01_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.PageData.SelectedItemId = 0;
        }

        private void Item02_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.PageData.SelectedItemId = 1;
        }

        private void Item03_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.PageData.SelectedItemId = 2;
        }

        private async void Payment_Clicked(object sender, EventArgs e)
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
                var itemid = default(string);
                switch (this.PageData.SelectedItemId)
                {
                    default:
                    case 0:
                        itemid = "item01";
                        break;
                    case 1:
                        itemid = "item02";
                        break;
                    case 2:
                        itemid = "item03";
                        break;
                }

                await InappBillingHelper.InAppPurchaseAsync(itemid, async (item) =>
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

        private void Close_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopPopupAsync();
        }
    }

    public class ProfileRecheckPaymentDialogData : BindableObject
    {
        public int SelectedItemId { get => (int)GetValue(SelectedItemIdProperty); set => SetValue(SelectedItemIdProperty, value); }
        public static readonly BindableProperty SelectedItemIdProperty = BindableProperty.Create(nameof(SelectedItemId), typeof(int), typeof(ProfileRecheckPaymentDialogData), 1);

        public Color Item01BackgroundColor { get => (Color)GetValue(Item01BackgroundColorProperty); set => SetValue(Item01BackgroundColorProperty, value); }
        public static readonly BindableProperty Item01BackgroundColorProperty = BindableProperty.Create(nameof(Item01BackgroundColor), typeof(Color), typeof(ProfileRecheckPaymentDialogData), Color.Transparent);

        public Color Item02BackgroundColor { get => (Color)GetValue(Item02BackgroundColorProperty); set => SetValue(Item02BackgroundColorProperty, value); }
        public static readonly BindableProperty Item02BackgroundColorProperty = BindableProperty.Create(nameof(Item02BackgroundColor), typeof(Color), typeof(ProfileRecheckPaymentDialogData), Color.FromHex("#1F4A9CFF"));

        public Color Item03BackgroundColor { get => (Color)GetValue(Item03BackgroundColorProperty); set => SetValue(Item03BackgroundColorProperty, value); }
        public static readonly BindableProperty Item03BackgroundColorProperty = BindableProperty.Create(nameof(Item03BackgroundColor), typeof(Color), typeof(ProfileRecheckPaymentDialogData), Color.Transparent);

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.SelectedItemId):
                    this.SetItemBackgroundColor();
                    break;
                default:
                    break;
            }
        }

        private void SetItemBackgroundColor()
        {
            this.Item01BackgroundColor = this.SelectedItemId == 0 ? Color.FromHex("#1F4A9CFF") : Color.Transparent;
            this.Item02BackgroundColor = this.SelectedItemId == 1 ? Color.FromHex("#1F4A9CFF") : Color.Transparent;
            this.Item03BackgroundColor = this.SelectedItemId == 2 ? Color.FromHex("#1F4A9CFF") : Color.Transparent;
        }
    }
}