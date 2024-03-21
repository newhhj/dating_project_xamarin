using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Near
{
    public class NearPagePartnerViewData : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(NearPagePartnerViewData));

        public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
        public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(NearPagePartnerViewData));

        public ImageSource ProfileImageSource { get => (ImageSource)GetValue(ProfileImageSourceProperty); set => SetValue(ProfileImageSourceProperty, value); }
        public static readonly BindableProperty ProfileImageSourceProperty = BindableProperty.Create(nameof(ProfileImageSource), typeof(ImageSource), typeof(NearPagePartnerViewData));

        public double Range { get => (double)GetValue(RangeProperty); set => SetValue(RangeProperty, value); }
        public static readonly BindableProperty RangeProperty = BindableProperty.Create(nameof(Range), typeof(double), typeof(NearPagePartnerViewData));

        public bool IsLive { get => (bool)GetValue(IsLiveProperty); set => SetValue(IsLiveProperty, value); }
        public static readonly BindableProperty IsLiveProperty = BindableProperty.Create(nameof(IsLive), typeof(bool), typeof(NearPagePartnerViewData));

        public double Scale { get => (double)GetValue(ScaleProperty); set => SetValue(ScaleProperty, value); }
        public static readonly BindableProperty ScaleProperty = BindableProperty.Create(nameof(Scale), typeof(double), typeof(NearPagePartnerViewData));

        protected override async void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.ProfileImage):
                {
                    if (string.IsNullOrWhiteSpace(this.ProfileImage))
                        return;
                    using (var http = new HttpClient())
                    {
                        var buffer = await http.GetByteArrayAsync(this.ProfileImage);
                        this.ProfileImageSource = ImageSource.FromStream(() => { return new MemoryStream(buffer); });
                    }
                    break;
                }
                default:
                    break;
            }
        }
    }
}
