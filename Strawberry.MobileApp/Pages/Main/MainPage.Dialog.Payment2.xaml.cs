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
	public partial class MainPage_Dialog_Payment2 : PopupPage, IValueConverter
	{
		// 선택된 아이템의 ID를 바인딩하는 속성
		public string SelectedItemId { get => (string)GetValue(SelectedItemIdProperty); set => SetValue(SelectedItemIdProperty, value); }
		public static readonly BindableProperty SelectedItemIdProperty = BindableProperty.Create(nameof(SelectedItemId), typeof(string), typeof(MainPage_Dialog_Payment2), defaultValue: "item02");

		// 잠금 상태를 관리하는 데이터 모델
		private LockDataModel LockData { get; set; } = new LockDataModel();

		public MainPage_Dialog_Payment2()
		{
			InitializeComponent();
		}

		// 아이템 01 클릭 이벤트 핸들러
		private void Item01_Clicked(object sender, EventArgs e)
		{
			this.SelectedItemId = "item01";
		}

		// 아이템 02 클릭 이벤트 핸들러
		private void Item02_Clicked(object sender, EventArgs e)
		{
			this.SelectedItemId = "item02";
		}

		// 아이템 03 클릭 이벤트 핸들러
		private void Item03_Clicked(object sender, EventArgs e)
		{
			this.SelectedItemId = "item03";
		}

		// 닫기 버튼 클릭 이벤트 핸들러
		private void Close_Clicked(object sender, EventArgs e)
		{
			Navigation.PopPopupAsync();
		}

		// 결제하기 버튼 클릭 이벤트 핸들러
		private async void Payment_Clicked(object sender, EventArgs e)
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
				await InappBillingHelper.InAppPurchaseAsync(this.SelectedItemId, async (item) =>
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

		// 값 변환을 위한 IValueConverter 인터페이스 구현

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
	}
}
