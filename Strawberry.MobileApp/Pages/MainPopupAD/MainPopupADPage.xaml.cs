using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.MainPopupAD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPopupADPage : PopupPage
    {
        public static Task ShowPageAsync(MainPopupADPageData data)
        {
            var page = new MainPopupADPage(data);
            App.Instance.MainPage.Navigation.PushPopupAsync(page);
            return page.TaskCompletionSource.Task;
        }

        private TaskCompletionSource<bool> TaskCompletionSource { get; set; }

        private MainPopupADPageData PageData { get => (MainPopupADPageData)this.BindingContext; set => this.BindingContext = value; }

        public MainPopupADPage(MainPopupADPageData data)
        {
            InitializeComponent();

            this.TaskCompletionSource = new TaskCompletionSource<bool>();
            this.PageData = data;
        }

        private void ADImage_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.PageData.Link))
                return;

            Browser.OpenAsync(this.PageData.Link);
        }

        protected override bool OnBackButtonPressed()
        {
            var result = base.OnBackButtonPressed();
            this.TaskCompletionSource.SetResult(true);
            return result;
        }

        protected override bool OnBackgroundClicked()
        {
            var result = base.OnBackgroundClicked();
            this.TaskCompletionSource.SetResult(true);
            return result;
        }

        private void cachedImage_SizeChanged(object sender, EventArgs e)
        {
            var view = sender as View;
            this.PageData.Width = view.Width;
        }

        private void BlockAD_Clicked(object sender, EventArgs e)
        {
            var ids = JsonConvert.DeserializeObject<List<int>>(Preferences.Get("skipmainpopupids", "[]"));
            ids.Add(this.PageData.Id);
            Preferences.Set("skipmainpopupids", JsonConvert.SerializeObject(ids));

            this.Navigation.PopPopupAsync();
            this.TaskCompletionSource.SetResult(true);
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopPopupAsync();
            this.TaskCompletionSource.SetResult(true);
        }
    }

    public class MainPopupADPageData : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(MainPopupADPageData));
        public string ImageUrl { get => (string)GetValue(ImageUrlProperty); set => SetValue(ImageUrlProperty, value); }
        public static readonly BindableProperty ImageUrlProperty = BindableProperty.Create(nameof(ImageUrl), typeof(string), typeof(MainPopupADPageData));
        public string Link { get => (string)GetValue(LinkProperty); set => SetValue(LinkProperty, value); }
        public static readonly BindableProperty LinkProperty = BindableProperty.Create(nameof(Link), typeof(string), typeof(MainPopupADPageData));
        public ImageSource ImageSource { get => (ImageSource)GetValue(ImageSourceProperty); set => SetValue(ImageSourceProperty, value); }
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(MainPopupADPageData));
        public double Width { get => (double)GetValue(WidthProperty); set => SetValue(WidthProperty, value); }
        public static readonly BindableProperty WidthProperty = BindableProperty.Create(nameof(Width), typeof(double), typeof(MainPopupADPageData), -1d);
        public double Height { get => (double)GetValue(HeightProperty); set => SetValue(HeightProperty, value); }
        public static readonly BindableProperty HeightProperty = BindableProperty.Create(nameof(Height), typeof(double), typeof(MainPopupADPageData), -1d);

        private int width { get; set; }
        private int height { get; set; }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(ImageUrl):
                    Task.Run(DownloadImage);
                    break;
                case nameof(Width):
                    UpdateSize();
                    break;
                default:
                    break;
            }

            base.OnPropertyChanged(propertyName);
        }

        private async void DownloadImage()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.ImageUrl))
                    return;

                using (var http = new HttpClient())
                {
                    var buffer = await http.GetByteArrayAsync(this.ImageUrl);
                    using (var skStream = new SkiaSharp.SKMemoryStream(buffer))
                    using (var skCodec = SkiaSharp.SKCodec.Create(skStream))
                    {
                        this.width = skCodec.Info.Width;
                        this.height = skCodec.Info.Height;

                        this.ImageSource = ImageSource.FromStream(() => { return new MemoryStream(buffer); });
                        Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(UpdateSize);
                    }
                }
            }
#if DEBUG
            catch (Exception ex)
            {
                Console.WriteLine("[MainPopupADPageData.DownloadImage]");
                Console.WriteLine(ex);
            }
#else
            catch { }
#endif
        }

        private void UpdateSize()
        {
            if (this.Width > 0 && width > 0)
            {
                this.Height = this.Width * height / width;
            }
        }
    }
}