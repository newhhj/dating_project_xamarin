using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Join
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Join_Location : BasePage
    {
        public Position SelectPosition { get; set; }

        public Page_Join_Location()
        {
            InitializeComponent();
            _ = this.SetLocation();
        }

        private async Task SetLocation()
        {
            var location = await Geolocation.GetLocationAsync();
            var position = new Position(location.Latitude, location.Longitude);
            this.MapControl.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(1)));
            if (!this.MapControl.IsVisible)
                this.MapControl.IsVisible = true;

            this.SelectPosition = position;

            this.MapControl.Pins.Clear();
            this.MapControl.Pins.Add(new Pin()
            {
                Label = "내 위치",
                Position = position,
                Type = PinType.SearchResult
            });
        }

        private async void MyLocation_Clicked(object sender, EventArgs e)
        {
            await SetLocation();
        }

        private async void SearchLocation_Complete(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;

                this.LockData.IsLocked = true;
            }

            try
            {
                var address = (sender as Entry)?.Text;
                if (string.IsNullOrWhiteSpace(address))
                    return;

                var positions = await new Geocoder().GetPositionsForAddressAsync(address);
                var position = positions?.FirstOrDefault();

                if (position.HasValue)
                {
                    this.MapControl.Pins.Clear();
                    this.MapControl.Pins.Add(new Pin()
                    {
                        Label = "검색 위치",
                        Position = position.Value,
                        Type = PinType.SearchResult
                    });
                    this.MapControl.MoveToRegion(MapSpan.FromCenterAndRadius(position.Value, Distance.FromKilometers(1)));
                    this.SelectPosition = position.Value;
                }
                else
                {
                    await DisplayAlert("알림", "위치를 찾을 수 없습니다.", "확인");
                }
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private void Next_Clicked(object sender, EventArgs e)
        {
            App.Instance.Member.Lat = this.SelectPosition.Latitude;
            App.Instance.Member.Lng = this.SelectPosition.Longitude;

            this.Navigation.PushAsync(new Page_Join_Preference());
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}