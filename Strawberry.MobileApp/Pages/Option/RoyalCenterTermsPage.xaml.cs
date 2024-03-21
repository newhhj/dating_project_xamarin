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
    public partial class RoyalCenterTermsPage : BasePage
    {
        public RoyalCenterTermsPage()
        {
            InitializeComponent();
        }

        public Task ShowPageAsync(string productId)
        {
            this.PageData.ProductId = productId;
            return App.Instance.MainPage.Navigation.PushAsync(this);
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.Navigation.PopAsync();
        }

        private void Confirm01_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.PageData.IsVisibleConfirm01 = !this.PageData.IsVisibleConfirm01;
        }

        private void Confirm02_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.PageData.IsVisibleConfirm02 = !this.PageData.IsVisibleConfirm02;
        }

        private void Confirm03_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.PageData.IsVisibleConfirm03 = !this.PageData.IsVisibleConfirm03;
        }

        private void Confirm04_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.PageData.IsVisibleConfirm04 = !this.PageData.IsVisibleConfirm04;
        }

        private void Confirm05_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.PageData.IsVisibleConfirm05 = !this.PageData.IsVisibleConfirm05;
        }

        private void Confirm06_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.PageData.IsVisibleConfirm06 = !this.PageData.IsVisibleConfirm06;
        }

        private void Confirm07_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.PageData.IsVisibleConfirm07 = !this.PageData.IsVisibleConfirm07;
        }

        private void Confirm08_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.PageData.IsVisibleConfirm08 = !this.PageData.IsVisibleConfirm08;
        }

        private void Confirm09_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.PageData.IsVisibleConfirm09 = !this.PageData.IsVisibleConfirm09;
        }

        private async void Next_Clicked(object sender, EventArgs e)
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
                if (!this.PageData.IsVisibleConfirm01
                 || !this.PageData.IsVisibleConfirm02
                 || !this.PageData.IsVisibleConfirm03
                 || !this.PageData.IsVisibleConfirm04
                 || !this.PageData.IsVisibleConfirm05
                 || !this.PageData.IsVisibleConfirm06
                 || !this.PageData.IsVisibleConfirm07
                 || !this.PageData.IsVisibleConfirm08
                 || !this.PageData.IsVisibleConfirm09)
                {
                    throw new Exception("모든 내용에 동의해야 합니다.");
                }

                var page = new RoyalCenterRequestPage();
                await page.ShowPageAsync(this.PageData.ProductId);
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

    public class RoyalCenterTermsPageData : BindableObject
    {
        public string ProductId { get => (string)GetValue(ProductIdProperty); set => SetValue(ProductIdProperty, value); }
        public static readonly BindableProperty ProductIdProperty = BindableProperty.Create(nameof(ProductId), typeof(string), typeof(RoyalCenterTermsPageData));

        public bool IsVisibleConfirm01 { get => (bool)GetValue(IsVisibleConfirm01Property); set => SetValue(IsVisibleConfirm01Property, value); }
        public static readonly BindableProperty IsVisibleConfirm01Property = BindableProperty.Create(nameof(IsVisibleConfirm01), typeof(bool), typeof(RoyalCenterTermsPageData));

        public bool IsVisibleConfirm02 { get => (bool)GetValue(IsVisibleConfirm02Property); set => SetValue(IsVisibleConfirm02Property, value); }
        public static readonly BindableProperty IsVisibleConfirm02Property = BindableProperty.Create(nameof(IsVisibleConfirm02), typeof(bool), typeof(RoyalCenterTermsPageData));

        public bool IsVisibleConfirm03 { get => (bool)GetValue(IsVisibleConfirm03Property); set => SetValue(IsVisibleConfirm03Property, value); }
        public static readonly BindableProperty IsVisibleConfirm03Property = BindableProperty.Create(nameof(IsVisibleConfirm03), typeof(bool), typeof(RoyalCenterTermsPageData));

        public bool IsVisibleConfirm04 { get => (bool)GetValue(IsVisibleConfirm04Property); set => SetValue(IsVisibleConfirm04Property, value); }
        public static readonly BindableProperty IsVisibleConfirm04Property = BindableProperty.Create(nameof(IsVisibleConfirm04), typeof(bool), typeof(RoyalCenterTermsPageData));

        public bool IsVisibleConfirm05 { get => (bool)GetValue(IsVisibleConfirm05Property); set => SetValue(IsVisibleConfirm05Property, value); }
        public static readonly BindableProperty IsVisibleConfirm05Property = BindableProperty.Create(nameof(IsVisibleConfirm05), typeof(bool), typeof(RoyalCenterTermsPageData));

        public bool IsVisibleConfirm06 { get => (bool)GetValue(IsVisibleConfirm06Property); set => SetValue(IsVisibleConfirm06Property, value); }
        public static readonly BindableProperty IsVisibleConfirm06Property = BindableProperty.Create(nameof(IsVisibleConfirm06), typeof(bool), typeof(RoyalCenterTermsPageData));

        public bool IsVisibleConfirm07 { get => (bool)GetValue(IsVisibleConfirm07Property); set => SetValue(IsVisibleConfirm07Property, value); }
        public static readonly BindableProperty IsVisibleConfirm07Property = BindableProperty.Create(nameof(IsVisibleConfirm07), typeof(bool), typeof(RoyalCenterTermsPageData));

        public bool IsVisibleConfirm08 { get => (bool)GetValue(IsVisibleConfirm08Property); set => SetValue(IsVisibleConfirm08Property, value); }
        public static readonly BindableProperty IsVisibleConfirm08Property = BindableProperty.Create(nameof(IsVisibleConfirm08), typeof(bool), typeof(RoyalCenterTermsPageData));

        public bool IsVisibleConfirm09 { get => (bool)GetValue(IsVisibleConfirm09Property); set => SetValue(IsVisibleConfirm09Property, value); }
        public static readonly BindableProperty IsVisibleConfirm09Property = BindableProperty.Create(nameof(IsVisibleConfirm09), typeof(bool), typeof(RoyalCenterTermsPageData));
    }
}