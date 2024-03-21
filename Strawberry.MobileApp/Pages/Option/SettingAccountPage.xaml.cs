using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Option
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingAccountPage : BasePage
    {
        public SettingAccountPageData PageData
        {
            get => (SettingAccountPageData)this.BindingContext;
            private set => this.BindingContext = value;
        }

        public SettingAccountPage()
        {
            InitializeComponent();
        }

        private async Task GetPageDataAsync()
        {
            using (var api = new ApiHelper())
            {
                var result = await api.GetSettingAccountPageData(new
                {
                    PageData = default(SettingAccountPageData)
                });

                if (result.PageData != null)
                {
                    this.PageData.Email = result.PageData.Email;
                    this.PageData.HasPassword = result.PageData.HasPassword;
                    this.PageData.PhoneNumber = result.PageData.PhoneNumber;
                }
            }
        }

        public async Task ShowPageAcync()
        {
            await this.GetPageDataAsync();
            await App.Instance.MainPage.Navigation.PushAsync(this);
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.Navigation.PopAsync();
        }
    }

    public class SettingAccountPageData : BindableObject
    {
        public string Email { get => (string)GetValue(EmailProperty); set => SetValue(EmailProperty, value); }
        public static readonly BindableProperty EmailProperty = BindableProperty.Create(nameof(Email), typeof(string), typeof(SettingAccountPageData));

        public bool HasPassword { get => (bool)GetValue(HasPasswordProperty); set => SetValue(HasPasswordProperty, value); }
        public static readonly BindableProperty HasPasswordProperty = BindableProperty.Create(nameof(HasPassword), typeof(bool), typeof(SettingAccountPageData));

        public string PhoneNumber { get => (string)GetValue(PhoneNumberProperty); set => SetValue(PhoneNumberProperty, value); }
        public static readonly BindableProperty PhoneNumberProperty = BindableProperty.Create(nameof(PhoneNumber), typeof(string), typeof(SettingAccountPageData));

        public string EmailText
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Email) ? "미설정" : this.Email;
            }
        }

        public Color EmailTextColor
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Email) ? Color.FromHex("7B7B7B") : Color.FromHex("4A9CFF");
            }
        }

        public string HasPasswordText
        {
            get
            {
                return this.HasPassword ? "설정됨" : "미설정";
            }
        }

        public Color HasPasswordTextColor
        {
            get
            {
                return !this.HasPassword ? Color.FromHex("7B7B7B") : Color.FromHex("4A9CFF");
            }
        }

        public string PhoneNumberText
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.PhoneNumber) ? "미설정" : this.PhoneNumber;
            }
        }

        public Color PhoneNumberTextColor
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.PhoneNumber) ? Color.FromHex("7B7B7B") : Color.FromHex("4A9CFF");
            }
        }



        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.Email):
                    base.OnPropertyChanged(nameof(this.EmailText));
                    base.OnPropertyChanged(nameof(this.EmailTextColor));
                    break;
                case nameof(this.HasPassword):
                    base.OnPropertyChanged(nameof(this.HasPasswordText));
                    base.OnPropertyChanged(nameof(this.HasPasswordTextColor));
                    break;
                case nameof(this.PhoneNumber):
                    base.OnPropertyChanged(nameof(this.PhoneNumberText));
                    base.OnPropertyChanged(nameof(this.PhoneNumberTextColor));
                    break;
                default:
                    break;
            }
        }
    }
}