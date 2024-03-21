using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Option;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	public partial class MainPage_View14 : DataTemplate
	{
		public LockDataModel LockData { get; set; } = new LockDataModel();

		public MainPage_View14()
		{
			InitializeComponent();
		}

		// 프로필 수정 메뉴 클릭 시
		private async void Profile_Clicked(object sender, EventArgs e)
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

		// 프로필 보기 메뉴 클릭 시
		private async void ViewProfile_Clicked(object sender, EventArgs e)
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
				var page = new Profile.ProfilePage_Partner();
				await page.ShowAsync(App.Instance.Member.Id, true);
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

		// 메뉴 01 클릭 시
		private async void Menu01_Clicked(object sender, EventArgs e)
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
				var page = new ProfileLevelPage();
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

		// 메뉴 02 클릭 시
		private async void Menu02_Clicked(object sender, EventArgs e)
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
				var page = new PaymentStorePage();
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

		// 메뉴 03 클릭 시
		private async void Menu03_Clicked(object sender, EventArgs e)
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
				var page = new RoyalCenterPage();
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

		// 메뉴 04 클릭 시
		private async void Menu04_Clicked(object sender, EventArgs e)
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
				var page = new VIPCenterPage();
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

		// 메뉴 05 클릭 시
		private async void Menu05_Clicked(object sender, EventArgs e)
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
				var page = new UpdatePreferencePage();
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

		// 메뉴 06 클릭 시
		private async void Menu06_Clicked(object sender, EventArgs e)
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
				var page = new FirstMessagePage();
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

		// 메뉴 07 클릭 시
		private async void Menu07_Clicked(object sender, EventArgs e)
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

		// 메뉴 08 클릭 시
		private async void Menu08_Clicked(object sender, EventArgs e)
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
				var page = new SendChoicesPage();
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

		// 메뉴 09 클릭 시
		private async void Menu09_Clicked(object sender, EventArgs e)
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
				var page = new ServiceCenterPage();
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

		// 광고 배너 클릭 시
		private async void ADBanner_Clicked(object sender, EventArgs e)
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
				var data = view.BindingContext as MainPage_View14_Data;
				if (string.IsNullOrWhiteSpace(data.ADLink))
					return;

				DependencyService.Get<IDeviceHelper>().Vibrate();
				await Browser.OpenAsync(data.ADLink);
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
}
