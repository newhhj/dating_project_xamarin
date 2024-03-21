using Newtonsoft.Json;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Main;
using Strawberry.MobileApp.Pages.Profile;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Near
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NearPage : BasePage
    {
        public NearPageData PageData
        {
            get
            {
                return (NearPageData)this.BindingContext;
            }
            set
            {
                this.BindingContext = value;
            }
        }

        private bool EnableAnimation { get; set; }

        public NearPage()
        {
            InitializeComponent();
            this.PageData = new NearPageData();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.StartAnimation();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.StopAnimation();
        }

        public async Task ShowAsync()
        {
            await App.Instance.MainPage.Navigation.PushAsync(this);
            await this.GetPartners();
        }

        private async Task GetPartners()
        {
            var items = await Task.Run(async () =>
            {
                using (var api = new ApiHelper())
                {
                    var result = await api.GetNearPartnets(new
                    {
                        Items = default(NearPagePartnerViewData[])
                    });

                    return result.Items;
                }
            });

            if (items == null || items.Length == 0)
                return;

            var r = new Random();

            foreach (var item in items)
            {
                item.Scale = r.Next(0, 101) / 100d;

                var view = new NearPagePartnerView()
                {
                    BindingContext = item
                };
                view.Tapped += this.PartnerItem_Tapped;

                this.relativeLayout01.Children.Add(
                    view,
                    view.GetXConstraint(),
                    view.GetYConstraint());
            }
        }

        private async void PartnerItem_Tapped(object sender, NearPagePartnerViewData e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var page = new ProfilePage_Partner();
                await page.ShowAsync(e.Id, true);
            }
            catch (Exception ex)
            {
                await this.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private void StartAnimation()
        {
            this.EnableAnimation = true;

            Task.Run(() =>
            {
                Dispatcher.BeginInvokeOnMainThread(async () =>
                {
                    while (this.EnableAnimation)
                    {
                        this.roundView01.Opacity = 1.0d;
                        this.roundView01.Scale = 1;
                        _ = this.roundView01.ScaleTo(14, 2000);
                        _ = this.roundView01.FadeTo(0, 2000);

                        await Task.Delay(1000);

                        this.roundView02.Opacity = 1.0d;
                        this.roundView02.Scale = 1;
                        _ = this.roundView02.ScaleTo(14, 2000);
                        _ = this.roundView02.FadeTo(0, 2000);

                        await Task.Delay(1000);
                    }
                });
            });
        }

        private void StopAnimation()
        {
            this.EnableAnimation = false;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }

        private async void Refresh_Clicked(object sender, EventArgs e)
        {
            this.relativeLayout01.Children.Clear();
            await GetPartners();
        }
    }
}