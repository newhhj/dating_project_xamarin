using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Join
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Join_Terms : BasePage
    {
        public Page_Join_Terms()
        {
            InitializeComponent();
        }

        private void Term_Tapped(object sender, EventArgs e)
        {
            this.PageData.IsTermChecked = !this.PageData.IsTermChecked;
        }

        private void Privacy_Tapped(object sender, EventArgs e)
        {
            this.PageData.IsPrivacyChecked = !this.PageData.IsPrivacyChecked;
        }

        private void Location_Tapped(object sender, EventArgs e)
        {
            this.PageData.IsLocationChecked = !this.PageData.IsLocationChecked;
        }

        private void Sensitive_Tapped(object sender, EventArgs e)
        {
            this.PageData.IsSensitiveChecked = !this.PageData.IsSensitiveChecked;
        }

        private void Content_Tapped(object sender, EventArgs e)
        {
            this.PageData.IsContentChecked = !this.PageData.IsContentChecked;
        }

        private void Marketing_Tapped(object sender, EventArgs e)
        {
            this.PageData.IsMarketingChecked = !this.PageData.IsMarketingChecked;
        }

        private void All_Tapped(object sender, EventArgs e)
        {
            this.PageData.IsTermChecked = true;
            this.PageData.IsPrivacyChecked = true;
            this.PageData.IsLocationChecked = true;
            this.PageData.IsSensitiveChecked = true;
            this.PageData.IsContentChecked = true;
            this.PageData.IsMarketingChecked = true;
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (!this.PageData.UseNextButton)
                    return;

                App.Instance.Member.ConsentMarketing = this.PageData.IsMarketingChecked;

                this.Navigation.PushAsync(new Page_Join_Profile());
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private void ViewTerm_Tapped(object sender, EventArgs e)
        {
            Browser.OpenAsync($"{Settings.ServerUrl}/System/UseTerm", BrowserLaunchMode.SystemPreferred);
        }

        private void ViewPrivacy_Tapped(object sender, EventArgs e)
        {
            Browser.OpenAsync($"{Settings.ServerUrl}/System/PrivacyTerm", BrowserLaunchMode.SystemPreferred);
        }

        private void ViewLocation_Tapped(object sender, EventArgs e)
        {
            Browser.OpenAsync($"{Settings.ServerUrl}/System/LocationTerm", BrowserLaunchMode.SystemPreferred);
        }

        private void ViewSensitive_Tapped(object sender, EventArgs e)
        {
            Browser.OpenAsync($"{Settings.ServerUrl}/System/SensitiveTerm", BrowserLaunchMode.SystemPreferred);
        }

        private void ViewContent_Tapped(object sender, EventArgs e)
        {
            Browser.OpenAsync($"{Settings.ServerUrl}/System/ContentTerm", BrowserLaunchMode.SystemPreferred);
        }

        private void ViewMarketing_Tapped(object sender, EventArgs e)
        {
            Browser.OpenAsync($"{Settings.ServerUrl}/System/MarketingTerm", BrowserLaunchMode.SystemPreferred);
        }
    }
}