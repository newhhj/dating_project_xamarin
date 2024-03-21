using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AutoSizeImageView : ContentView
    {
        public string ImageUrl { get => (string)GetValue(ImageUrlProperty); set => SetValue(ImageUrlProperty, value); }
        public static readonly BindableProperty ImageUrlProperty = BindableProperty.Create(nameof(ImageUrl), typeof(string), typeof(AutoSizeImageView));

        private byte[] _buffer;
        private int _width;
        private int _height;

        public AutoSizeImageView()
        {
            InitializeComponent();
        }

        private async void DownloadImageAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.ImageUrl))
                    return;

                using (var http = new HttpClient())
                {
                    this._buffer = await http.GetByteArrayAsync(this.ImageUrl);

                    using (var stream = new SkiaSharp.SKMemoryStream(this._buffer))
                    using (var codec = SkiaSharp.SKCodec.Create(stream))
                    {
                        this._width = codec.Info.Width;
                        this._height = codec.Info.Height;
                    }

                    Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(SetImageSource);
                    Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(CheckViewSize);
                }
            }
            catch { }
        }

        private void SetImageSource()
        {
            this.image01.Source = ImageSource.FromStream(() =>
            {
                return new MemoryStream(this._buffer);
            });
        }

        private void CheckViewSize()
        {
            if (this.Width > 0 && this._width > 0 && this.HeightRequest == -1)
            {
                this.HeightRequest = this.Width * this._height / _width;
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            this.CheckViewSize();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(ImageUrl):
                    Task.Run(DownloadImageAsync);
                    break;
                default:
                    break;
            }
        }
    }
}