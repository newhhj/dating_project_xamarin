using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages;
using Strawberry.MobileApp.Pages.Chatting;
using Strawberry.MobileApp.Pages.Join;
using Strawberry.MobileApp.Pages.Login;
using Strawberry.MobileApp.Pages.Notification;
using Strawberry.MobileApp.Pages.Option;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp
{
    public partial class App : Application
    {
        public static App Instance { get => (App)Current; }

        public Member Member { get => (Member)this.Resources["Member"]; set => this.Resources["Member"] = value; }

        public App()
        {
            InitializeComponent();

#if DEBUG
            //Settings.SetApiKey("f2435b06-2cb7-464d-9077-7466dd355ed3").Wait();
            MainPage = new NavigationPage(new Pages.Intro.Page_Intro());
            //MainPage = new NavigationPage(new TestPage());
#else                        
            MainPage = new NavigationPage(new Pages.Intro.Page_Intro());
#endif
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
