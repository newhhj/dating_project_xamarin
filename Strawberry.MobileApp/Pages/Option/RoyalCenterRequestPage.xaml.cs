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
    public partial class RoyalCenterRequestPage : BasePage
    {
        public RoyalCenterRequestPage()
        {
            InitializeComponent();
        }

        private async Task GetPageDataAsync()
        {
            using (var api = new ApiHelper())
            {
                var result = await api.GetRoyalCenterRequestPageData(
                    new
                    {
                        ManagerEmail = default(string)
                    });

                this.PageData.ManagerEmail = result.ManagerEmail;
            }
        }

        public async Task ShowPageAsync(string productId)
        {
            this.PageData.ProductId = productId;
            await this.GetPageDataAsync();
            await App.Instance.MainPage.Navigation.PushAsync(this);
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.Navigation.PopAsync();
        }

        private void EmailAddress_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            Clipboard.SetTextAsync(this.PageData.ManagerEmail ?? "strawberryroyalinc@gmail.com");
            App.Instance.MainPage.DisplayToastAsync("이메일 주소가 복사되었습니다.");
        }

        private async void Request_Clicked(object sender, EventArgs e)
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
                if (string.IsNullOrWhiteSpace(this.PageData.Name))
                    throw new Exception("이름을 입력하세요");
                if (string.IsNullOrWhiteSpace(this.PageData.Nickname))
                    throw new Exception("닉네임을 입력하세요");
                if (string.IsNullOrWhiteSpace(this.PageData.PhoneNumber))
                    throw new Exception("연락처를 입력하세요");
                if (string.IsNullOrWhiteSpace(this.PageData.Email))
                    throw new Exception("이메일을 입력하세요");

                using (var api = new ApiHelper())
                {
                    var result = await api.GetHasRequestRoyal(
                        new
                        {
                            HasItem = default(bool)
                        });

                    if (result.HasItem)
                        throw new Exception("이미 신청되어 처리중입니다.");
                }


                await InappBillingHelper.InAppPurchaseAsync(this.PageData.ProductId, async (item) =>
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

                    await App.Instance.MainPage.DisplayToastAsync("신청되었습니다.");
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

    public class RoyalCenterRequestPageData : BindableObject
    {
        public string ProductId { get => (string)GetValue(ProductIdProperty); set => SetValue(ProductIdProperty, value); }
        public static readonly BindableProperty ProductIdProperty = BindableProperty.Create(nameof(ProductId), typeof(string), typeof(RoyalCenterRequestPageData));

        public string ManagerEmail { get => (string)GetValue(ManagerEmailProperty); set => SetValue(ManagerEmailProperty, value); }
        public static readonly BindableProperty ManagerEmailProperty = BindableProperty.Create(nameof(ManagerEmail), typeof(string), typeof(RoyalCenterRequestPageData));

        public string Name { get => (string)GetValue(NameProperty); set => SetValue(NameProperty, value); }
        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(RoyalCenterRequestPageData));

        public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
        public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(RoyalCenterRequestPageData));

        public string PhoneNumber { get => (string)GetValue(PhoneNumberProperty); set => SetValue(PhoneNumberProperty, value); }
        public static readonly BindableProperty PhoneNumberProperty = BindableProperty.Create(nameof(PhoneNumber), typeof(string), typeof(RoyalCenterRequestPageData));

        public string Email { get => (string)GetValue(EmailProperty); set => SetValue(EmailProperty, value); }
        public static readonly BindableProperty EmailProperty = BindableProperty.Create(nameof(Email), typeof(string), typeof(RoyalCenterRequestPageData));
    }
}