using SkiaSharp;
using SkiaSharp.Views.Forms;
using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Option
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentStorePage : BasePage
    {
        public PaymentStorePage()
        {
            InitializeComponent();
        }

        public Task ShowPageAsync()
        {
            return App.Instance.MainPage.Navigation.PushAsync(this);
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            await this.Navigation.PopAsync();
        }

        private async void PointLog_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var page = new PointLogPage();
                await page.ShowPageAsync();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;
                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Item01_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                await InappBillingHelper.InAppPurchaseAsync("item01", async (item) =>
                {
                    using (var api = new ApiHelper())
                    {
                        await api.ExcutePurchase(
                            DeviceInfo.Platform.ToString(),
                            item.ProductId,
                            item.Id,
                            item.PurchaseToken,
                            item.TransactionDateUtc);
                    }
                });
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Item02_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                await InappBillingHelper.InAppPurchaseAsync("item02", async (item) =>
                {
                    using (var api = new ApiHelper())
                    {
                        await api.ExcutePurchase(
                            DeviceInfo.Platform.ToString(),
                            item.ProductId,
                            item.Id,
                            item.PurchaseToken,
                            item.TransactionDateUtc);
                    }
                });
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Item03_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                await InappBillingHelper.InAppPurchaseAsync("item03", async (item) =>
                {
                    using (var api = new ApiHelper())
                    {
                        await api.ExcutePurchase(
                            DeviceInfo.Platform.ToString(),
                            item.ProductId,
                            item.Id,
                            item.PurchaseToken,
                            item.TransactionDateUtc);
                    }
                });
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Item04_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                await InappBillingHelper.InAppPurchaseAsync("item04", async (item) =>
                {
                    using (var api = new ApiHelper())
                    {
                        await api.ExcutePurchase(
                            DeviceInfo.Platform.ToString(),
                            item.ProductId,
                            item.Id,
                            item.PurchaseToken,
                            item.TransactionDateUtc);
                    }
                });
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Item05_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                await InappBillingHelper.InAppPurchaseAsync("item05", async (item) =>
                {
                    using (var api = new ApiHelper())
                    {
                        await api.ExcutePurchase(
                            DeviceInfo.Platform.ToString(),
                            item.ProductId,
                            item.Id,
                            item.PurchaseToken,
                            item.TransactionDateUtc);
                    }
                });
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Item06_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                await InappBillingHelper.SubscriptionAsync("item15", async (item) =>
                {
                    using (var api = new ApiHelper())
                    {
                        await api.ExcutePurchase(
                            DeviceInfo.Platform.ToString(),
                            item.ProductId,
                            item.Id,
                            item.PurchaseToken,
                            item.TransactionDateUtc);
                    }
                });
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Item07_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                await InappBillingHelper.SubscriptionAsync("item16", async (item) =>
                {
                    using (var api = new ApiHelper())
                    {
                        await api.ExcutePurchase(
                            DeviceInfo.Platform.ToString(),
                            item.ProductId,
                            item.Id,
                            item.PurchaseToken,
                            item.TransactionDateUtc);
                    }
                });
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Item08_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var page = new CallFriendsPage();
                await page.ShowPageAsync();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }
    }

    public class SliderBackground : SKCanvasView
    {
        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear();

            using (var paint = new SKPaint())
            {
                paint.IsAntialias = true;
                paint.Style = SKPaintStyle.Fill;
                paint.Color = SKColors.White;

                var rect = new SKRect(0, e.Info.Height - (e.Info.Width / 2), e.Info.Width, e.Info.Height + (e.Info.Width / 2));
                canvas.DrawArc(rect, 0, -180, true, paint);
            }

            base.OnPaintSurface(e);
        }
    }

    public class PaymentStoreData : BindableObject
    {
        public int SelectedIndex { get => (int)GetValue(SelectedIndexProperty); set => SetValue(SelectedIndexProperty, value); }
        public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(PaymentStoreData));

        public double Indicator01Width { get => (double)GetValue(Indicator01WidthProperty); set => SetValue(Indicator01WidthProperty, value); }
        public static readonly BindableProperty Indicator01WidthProperty = BindableProperty.Create(nameof(Indicator01Width), typeof(double), typeof(PaymentStoreData), 20d);

        public double Indicator02Width { get => (double)GetValue(Indicator02WidthProperty); set => SetValue(Indicator02WidthProperty, value); }
        public static readonly BindableProperty Indicator02WidthProperty = BindableProperty.Create(nameof(Indicator02Width), typeof(double), typeof(PaymentStoreData), 10d);

        public double Indicator03Width { get => (double)GetValue(Indicator03WidthProperty); set => SetValue(Indicator03WidthProperty, value); }
        public static readonly BindableProperty Indicator03WidthProperty = BindableProperty.Create(nameof(Indicator03Width), typeof(double), typeof(PaymentStoreData), 10d);

        public double Indicator04Width { get => (double)GetValue(Indicator04WidthProperty); set => SetValue(Indicator04WidthProperty, value); }
        public static readonly BindableProperty Indicator04WidthProperty = BindableProperty.Create(nameof(Indicator04Width), typeof(double), typeof(PaymentStoreData), 10d);

        public Color Indicator01Color { get => (Color)GetValue(Indicator01ColorProperty); set => SetValue(Indicator01ColorProperty, value); }
        public static readonly BindableProperty Indicator01ColorProperty = BindableProperty.Create(nameof(Indicator01Color), typeof(Color), typeof(PaymentStoreData), Color.FromHex("805C5C"));

        public Color Indicator02Color { get => (Color)GetValue(Indicator02ColorProperty); set => SetValue(Indicator02ColorProperty, value); }
        public static readonly BindableProperty Indicator02ColorProperty = BindableProperty.Create(nameof(Indicator02Color), typeof(Color), typeof(PaymentStoreData), Color.FromHex("A3805C5C"));

        public Color Indicator03Color { get => (Color)GetValue(Indicator03ColorProperty); set => SetValue(Indicator03ColorProperty, value); }
        public static readonly BindableProperty Indicator03ColorProperty = BindableProperty.Create(nameof(Indicator03Color), typeof(Color), typeof(PaymentStoreData), Color.FromHex("A3805C5C"));

        public Color Indicator04Color { get => (Color)GetValue(Indicator04ColorProperty); set => SetValue(Indicator04ColorProperty, value); }
        public static readonly BindableProperty Indicator04ColorProperty = BindableProperty.Create(nameof(Indicator04Color), typeof(Color), typeof(PaymentStoreData), Color.FromHex("A3805C5C"));


        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.SelectedIndex):
                    this.SetIndicatorWidth();
                    this.SetIndicatorColor();
                    break;
                default:
                    break;
            }
        }

        private void SetIndicatorColor()
        {
            this.Indicator01Color = this.SelectedIndex == 0 ? Color.FromHex("805C5C") : Color.FromHex("A3805C5C");
            this.Indicator02Color = this.SelectedIndex == 1 ? Color.FromHex("805C5C") : Color.FromHex("A3805C5C");
            this.Indicator03Color = this.SelectedIndex == 2 ? Color.FromHex("805C5C") : Color.FromHex("A3805C5C");
            this.Indicator04Color = this.SelectedIndex == 3 ? Color.FromHex("805C5C") : Color.FromHex("A3805C5C");
        }

        private void SetIndicatorWidth()
        {
            this.Indicator01Width = this.SelectedIndex == 0 ? 20d : 10d;
            this.Indicator02Width = this.SelectedIndex == 1 ? 20d : 10d;
            this.Indicator03Width = this.SelectedIndex == 2 ? 20d : 10d;
            this.Indicator04Width = this.SelectedIndex == 3 ? 20d : 10d;
        }
    }
}