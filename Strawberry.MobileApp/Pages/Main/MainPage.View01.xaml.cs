using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Option;
using Strawberry.MobileApp.Pages.Profile;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage_View01 : DataTemplate
	{
		private LockDataModel LockData { get; set; } = new LockDataModel();

		public MainPage_View01()
		{
			InitializeComponent();
		}

		// 배경 애니메이션을 위한 메소드
		private void AnimationBackground()
		{
			// 구현 내용
		}

		// ViewCell이 나타날 때 호출되는 이벤트 핸들러
		private void ViewCell_Appearing(object sender, EventArgs e)
		{
			((ViewCell)sender).On<Android>().Element.ForceUpdateSize();
		}

		// 프로필 정보를 보기 위한 버튼 클릭 이벤트 핸들러
		private async void Info_Clicked(object sender, EventArgs e)
		{
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				var view = sender as View;
				var data = view.BindingContext as MainPage_View01_Data;

				var page = new ProfilePage_Partner();
				await page.ShowAsync(data.Id, true);
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

		// 배경 애니메이션을 위한 메소드
		private void Background_MeasureInvalidated(object sender, EventArgs e)
		{
			var view = sender as View;

			view.Animate("AnimationBackground", (interval) =>
			{
				view.AnchorX = interval;
			}, 0, 1, length: 5000, repeat: () => true);
		}

		// 이전 슬라이드 버튼 클릭 이벤트 핸들러
		private async void PrevSlide_Clicked(object sender, EventArgs e)
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
				var element = sender as Element;
				var slide = element.Parent as PanCardView.CarouselView;
				while (slide == null)
				{
					element = element.Parent;
					if (element == null)
						throw new Exception();

					slide = element.Parent as PanCardView.CarouselView;
				}

				if (slide.SelectedIndex > 0)
				{
					slide.SelectedIndex--;
				}
				else
				{
					while (slide.SelectedIndex < slide.ItemsCount - 1)
					{
						slide.SelectedIndex++;
						await Task.Delay(100);
					}
				}
			}
			catch
			{
				// 예외 처리 내용
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// 다음 슬라이드 버튼 클릭 이벤트 핸들러
		private async void NextSlide_Clicked(object sender, EventArgs e)
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
				var element = sender as Element;
				var slide = element.Parent as PanCardView.CarouselView;
				while (slide == null)
				{
					element = element.Parent;
					if (element == null)
						throw new Exception();

					slide = element.Parent as PanCardView.CarouselView;
				}

				if (slide.SelectedIndex < slide.ItemsCount - 1)
				{
					slide.SelectedIndex++;
				}
				else
				{
					while (slide.SelectedIndex > 0)
					{
						slide.SelectedIndex--;
						await Task.Delay(100);
					}
				}
			}
			catch
			{
				// 예외 처리 내용
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// 프로필 이동 버튼 클릭 이벤트 핸들러
		private async void MoveProfile_Clicked(object sender, EventArgs e)
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
				var page = new UpdateProfilePage();
				await page.ShowPageAsync();
			}
			catch
			{
				// 예외 처리 내용
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}
	}

	// MainPage_View01의 다양한 변환 작업을 위한 멀티바인딩 컨버터 클래스
	public class MainPage_View01_Converter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			switch (parameter)
			{
				case "IndicatorWidth":
					{
						var data1 = (string)values[0];
						var data2 = (string)values[1];

						return data1 == data2 ? 20 : 10;
					}
				default:
					break;
			}

			throw new NotImplementedException();
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
