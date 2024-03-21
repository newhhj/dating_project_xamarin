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
	public partial class MainPage_View04 : DataTemplate
	{
		private MainPage MainPage { get => (MainPage)App.Instance.MainPage.Navigation.NavigationStack.FirstOrDefault(x => x is MainPage); }
		private LockDataModel LockData { get; set; } = new LockDataModel();

		public MainPage_View04()
		{
			InitializeComponent();
		}

		// 별점 1 클릭 이벤트 핸들러
		private async void StarPoint01_Clicked(object sender, EventArgs e)
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
				var data = (MainPage_View04_Data)((Element)sender).BindingContext;
				data.StarPoint = 2;
				if (data.StarPoint02_Icon != "icon_star_on")
					data.StarPoint02_Icon = "icon_star_on";
				if (data.StarPoint04_Icon != "icon_star_off")
					data.StarPoint04_Icon = "icon_star_off";
				if (data.StarPoint06_Icon != "icon_star_off")
					data.StarPoint06_Icon = "icon_star_off";
				if (data.StarPoint08_Icon != "icon_star_off")
					data.StarPoint08_Icon = "icon_star_off";
				if (data.StarPoint10_Icon != "icon_star_off")
					data.StarPoint10_Icon = "icon_star_off";
				await this.MainPage?.ExcuteStarPoint(data);

				await Task.Delay(1000);

				data.StarPoint = 0;
				data.StarPoint02_Icon = "icon_star_off";
				data.StarPoint04_Icon = "icon_star_off";
				data.StarPoint06_Icon = "icon_star_off";
				data.StarPoint08_Icon = "icon_star_off";
				data.StarPoint10_Icon = "icon_star_off";
			}
			catch { }
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// 별점 2 클릭 이벤트 핸들러
		private async void StarPoint02_Clicked(object sender, EventArgs e)
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
				var data = (MainPage_View04_Data)((Element)sender).BindingContext;
				data.StarPoint = 4;
				if (data.StarPoint02_Icon != "icon_star_on")
					data.StarPoint02_Icon = "icon_star_on";
				if (data.StarPoint04_Icon != "icon_star_on")
					data.StarPoint04_Icon = "icon_star_on";
				if (data.StarPoint06_Icon != "icon_star_off")
					data.StarPoint06_Icon = "icon_star_off";
				if (data.StarPoint08_Icon != "icon_star_off")
					data.StarPoint08_Icon = "icon_star_off";
				if (data.StarPoint10_Icon != "icon_star_off")
					data.StarPoint10_Icon = "icon_star_off";
				await this.MainPage?.ExcuteStarPoint(data);

				await Task.Delay(1000);

				data.StarPoint = 0;
				data.StarPoint02_Icon = "icon_star_off";
				data.StarPoint04_Icon = "icon_star_off";
				data.StarPoint06_Icon = "icon_star_off";
				data.StarPoint08_Icon = "icon_star_off";
				data.StarPoint10_Icon = "icon_star_off";
			}
			catch { }
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// 별점 3 클릭 이벤트 핸들러
		private async void StarPoint03_Clicked(object sender, EventArgs e)
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
				var data = (MainPage_View04_Data)((Element)sender).BindingContext;
				data.StarPoint = 6;
				if (data.StarPoint02_Icon != "icon_star_on")
					data.StarPoint02_Icon = "icon_star_on";
				if (data.StarPoint04_Icon != "icon_star_on")
					data.StarPoint04_Icon = "icon_star_on";
				if (data.StarPoint06_Icon != "icon_star_on")
					data.StarPoint06_Icon = "icon_star_on";
				if (data.StarPoint08_Icon != "icon_star_off")
					data.StarPoint08_Icon = "icon_star_off";
				if (data.StarPoint10_Icon != "icon_star_off")
					data.StarPoint10_Icon = "icon_star_off";
				await this.MainPage?.ExcuteStarPoint(data);

				await Task.Delay(1000);

				data.StarPoint = 0;
				data.StarPoint02_Icon = "icon_star_off";
				data.StarPoint04_Icon = "icon_star_off";
				data.StarPoint06_Icon = "icon_star_off";
				data.StarPoint08_Icon = "icon_star_off";
				data.StarPoint10_Icon = "icon_star_off";
			}
			catch { }
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// 별점 4 클릭 이벤트 핸들러
		private async void StarPoint04_Clicked(object sender, EventArgs e)
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
				var data = (MainPage_View04_Data)((Element)sender).BindingContext;
				data.StarPoint = 8;
				if (data.StarPoint02_Icon != "icon_star_on")
					data.StarPoint02_Icon = "icon_star_on";
				if (data.StarPoint04_Icon != "icon_star_on")
					data.StarPoint04_Icon = "icon_star_on";
				if (data.StarPoint06_Icon != "icon_star_on")
					data.StarPoint06_Icon = "icon_star_on";
				if (data.StarPoint08_Icon != "icon_star_on")
					data.StarPoint08_Icon = "icon_star_on";
				if (data.StarPoint10_Icon != "icon_star_off")
					data.StarPoint10_Icon = "icon_star_off";
				await this.MainPage?.ExcuteStarPoint(data);

				await Task.Delay(1000);

				data.StarPoint = 0;
				data.StarPoint02_Icon = "icon_star_off";
				data.StarPoint04_Icon = "icon_star_off";
				data.StarPoint06_Icon = "icon_star_off";
				data.StarPoint08_Icon = "icon_star_off";
				data.StarPoint10_Icon = "icon_star_off";
			}
			catch { }
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// 별점 5 클릭 이벤트 핸들러
		private async void StarPoint05_Clicked(object sender, EventArgs e)
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
				var data = (MainPage_View04_Data)((Element)sender).BindingContext;
				data.StarPoint = 10;
				if (data.StarPoint02_Icon != "icon_star_on")
					data.StarPoint02_Icon = "icon_star_on";
				if (data.StarPoint04_Icon != "icon_star_on")
					data.StarPoint04_Icon = "icon_star_on";
				if (data.StarPoint06_Icon != "icon_star_on")
					data.StarPoint06_Icon = "icon_star_on";
				if (data.StarPoint08_Icon != "icon_star_on")
					data.StarPoint08_Icon = "icon_star_on";
				if (data.StarPoint10_Icon != "icon_star_on")
					data.StarPoint10_Icon = "icon_star_on";
				await this.MainPage?.ExcuteStarPoint(data);

				await Task.Delay(1000);

				data.StarPoint = 0;
				data.StarPoint02_Icon = "icon_star_off";
				data.StarPoint04_Icon = "icon_star_off";
				data.StarPoint06_Icon = "icon_star_off";
				data.StarPoint08_Icon = "icon_star_off";
				data.StarPoint10_Icon = "icon_star_off";
			}
			catch { }
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// 정보 버튼 클릭 이벤트 핸들러
		private async void Info_Clicked(object sender, EventArgs e)
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
				var view = sender as View;
				var data = view.BindingContext as MainPage_View04_Data;

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

			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}
	}

	public class MainPage_View04_Converter : IMultiValueConverter
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
