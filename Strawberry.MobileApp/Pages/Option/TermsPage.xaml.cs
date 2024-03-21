using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Option
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermsPage : BasePage
    {
        public static async Task ShowPageAsync(string title, string url)
        {
            var page = new TermsPage(title, url);
            await App.Instance.MainPage.Navigation.PushAsync(page);
        }

        public TermsPage(string title, string url)
        {
            InitializeComponent();

            this.title.Text = title;
            this.webView.Source = new UrlWebViewSource
            {
                Url = url
            };
        }

        private void ClosePage_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}