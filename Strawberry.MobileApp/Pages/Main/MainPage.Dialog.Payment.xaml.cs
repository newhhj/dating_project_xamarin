using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage_Dialog_Payment : PopupPage, IValueConverter
	{
		// 결제 관련 정보 속성들
		public string Thumbnail { get => (string)GetValue(ThumbnailProperty); set => SetValue(ThumbnailProperty, value); }
		public static readonly BindableProperty ThumbnailProperty = BindableProperty.Create(nameof(Thumbnail), typeof(string), typeof(MainPage_Dialog_Payment));

		public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
		public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(MainPage_Dialog_Payment));

		public string TimeText { get => (string)GetValue(TimeTextProperty); set => SetValue(TimeTextProperty, value); }
		public static readonly BindableProperty TimeTextProperty = BindableProperty.Create(nameof(TimeText), typeof(string), typeof(MainPage_Dialog_Payment), defaultValue: "00:00:00");

		public string SelectedItemId { get => (string)GetValue(SelectedItemIdProperty); set => SetValue(SelectedItemIdProperty, value); }
		public static readonly BindableProperty SelectedItemIdProperty = BindableProperty.Create(nameof(SelectedItemId), typeof(string), typeof(MainPage_Dialog_Payment), defaultValue: "item02");

		private LockDataModel LockData { get; set; } = new LockDataModel();
		private System.Timers.Timer Timer { get; set; }

		public MainPage_Dialog_Payment(string thumbnail, string nickname)
		{
			InitializeComponent();
			this.Thumbnail = thumbnail;
			this.Nickname = nickname;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (this.Timer == null)
			{
				this.Timer = new System.Timers.Timer
				{
					AutoReset = true,
					Enabled = false,
					Interval = 1000,
				};
				this.Timer.Elapsed += this.Timer_Elapsed;
			}

			this.Timer.Start();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			if (this.Timer != null)
			{
				this.Timer.Stop();
			}
		}

		private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			var time = DateTime.Today.AddDays(1) - DateTime.Now;
			this.TimeText = $"{time.Hours:00}:{time.Minutes:00}:{time.Seconds:00}";
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch (parameter)
			{
				case "Item01ToBackgroundColor":
					return (string)value == "item01" ? Color.FromHex("1F4A9CFF") : Color.Transparent;
				case "Item02ToBackgroundColor":
					return (string)value == "item02" ? Color.FromHex("1F4A9CFF") : Color.Transparent;
				case "Item03ToBackgroundColor":
					return (string)value == "item03" ? Color.FromHex("1F4A9CFF") : Color.Transparent;
				default:
					throw new NotImplementedException();
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		// 아이템 클릭 이벤트 핸들러들
		private void Item01_Clicked(object sender, EventArgs e)
		{
			DependencyService.Get<IDeviceHelper>().Vibrate();
			this.SelectedItemId = "item01";
		}

		private void Item02_Clicked(object sender, EventArgs e)
		{
			DependencyService.Get<IDeviceHelper>().Vibrate();
			this.SelectedItemId = "item02";
		}

		private void Item03_Clicked(object sender, EventArgs e)
		{
			DependencyService.Get<IDeviceHelper>().Vibrate();
			this.SelectedItemId = "item03";
		}

		private void Close_Clicked(object sender, EventArgs e)
		{
			DependencyService.Get<IDeviceHelper>().Vibrate();
			this.Navigation.PopPopupAsync();
		}

		private async void Payment_Clicked(object sender, EventArgs e)
		{
			DependencyService.Get<IDeviceHelper>().Vibrate();

			// 결제 중복 방지를 위한 LockData 활용
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				// InappBillingHelper를 사용하여 인앱 구매 처리
				await InappBillingHelper.InAppPurchaseAsync(this.SelectedItemId, async (item) =>
				{
					using (var api = new ApiHelper())
					{
						// 구매 정보를 서버로 전송
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

				// 오류 메시지를 토스트 형태로 표시
				await App.Instance.MainPage.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}
	}
}