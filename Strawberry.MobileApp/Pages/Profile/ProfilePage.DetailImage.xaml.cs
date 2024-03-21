using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage_DetailImage : Shares.BasePage
    {
        public static Task ShowPageAsync(string imageUrl)
        {
            var page = new ProfilePage_DetailImage();
            page.Init(imageUrl);
            return App.Instance.MainPage.Navigation.PushAsync(page);
        }

        public ProfilePage_DetailImage()
        {
            InitializeComponent();
        }

        public void Init(string url)
        {
            var html = ""
                + "<!DOCTYPE html>"
                + "<html lang='kr' xmlns='http://www.w3.org/1999/xhtml'>"
                + "<head>"
                + "    <meta charset='utf-8' />"
                + "    <meta name='viewport' content='width=device-width' />"
                + "    <title></title>"
                + "    <style type='text/css'>"
                + "        html, body {"
                + "            margin: 0;"
                + "            width: 100%;"
                + "            height: 100%;"
                + "            background-color: black;"
                + "        }"
                + "        body {"
                + "            display: flex;"
                + "            justify-content: center;"
                + "            align-items: center;"
                + "        }"
                + "        img {"
                + "            width: 100%;"
                + "            vertical-align: middle;"
                + "        }"
                + "    </style>"
                + "</head>"
                + "<body>"
                + $"    <img src='{url}'/>"
                + "</body>"
                + "</html>";


            this.webView.Source = new HtmlWebViewSource()
            {
                Html = html
            };
        }

        private void ClosePage_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}