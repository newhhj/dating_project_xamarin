using Newtonsoft.Json;
using Strawberry.MobileApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage_View05 : DataTemplate
	{
		private LockDataModel LockData { get; set; }

		public MainPage_View05()
		{
			InitializeComponent();
			this.LockData = new LockDataModel();
		}

		// Item01 클릭 이벤트 핸들러
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
				var page = new RecommandPartner.RecommendPartnersPage(1);
				await page.GetItems();
				await App.Instance.MainPage.Navigation.PushAsync(page);
			}
			catch (Exception ex)
			{
				await App.Instance.MainPage.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// Item02 클릭 이벤트 핸들러
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
				var page = new RecommandPartner.RecommendPartnersPage(2);
				await page.GetItems();
				await App.Instance.MainPage.Navigation.PushAsync(page);
			}
			catch (Exception ex)
			{
				await App.Instance.MainPage.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// Item03 클릭 이벤트 핸들러
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
				var page = new RecommandPartner.RecommendPartnersPage(3);
				await page.GetItems();
				await App.Instance.MainPage.Navigation.PushAsync(page);
			}
			catch (Exception ex)
			{
				await App.Instance.MainPage.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// Item04 클릭 이벤트 핸들러
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
				var page = new RecommandPartner.RecommendPartnersPage(4);
				await page.GetItems();
				await App.Instance.MainPage.Navigation.PushAsync(page);
			}
			catch (Exception ex)
			{
				await App.Instance.MainPage.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// Item05 클릭 이벤트 핸들러
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
				var page = new RecommandPartner.RecommendPartnersPage(5);
				await page.GetItems();
				await App.Instance.MainPage.Navigation.PushAsync(page);
			}
			catch (Exception ex)
			{
				await App.Instance.MainPage.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// Item06 클릭 이벤트 핸들러
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
				var page = new RecommandPartner.RecommendPartnersPage(6);
				await page.GetItems();
				await App.Instance.MainPage.Navigation.PushAsync(page);
			}
			catch (Exception ex)
			{
				await App.Instance.MainPage.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// Item07 클릭 이벤트 핸들러
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
				var page = new RecommandPartner.RecommendPartnersPage(7);
				await page.GetItems();
				await App.Instance.MainPage.Navigation.PushAsync(page);
			}
			catch (Exception ex)
			{
				await App.Instance.MainPage.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// Item08 클릭 이벤트 핸들러
		private async void Item08_Clicked(object sender, EventArgs e)
		{
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				var page = new RecommandPartner.RecommendPartnersPage(8);
				await page.GetItems();
				await App.Instance.MainPage.Navigation.PushAsync(page);
			}
			catch (Exception ex)
			{
				await App.Instance.MainPage.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// Item09 클릭 이벤트 핸들러
		private async void Item09_Clicked(object sender, EventArgs e)
		{
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				var page = new RecommandPartner.RecommendPartnersPage(9);
				await page.GetItems();
				await App.Instance.MainPage.Navigation.PushAsync(page);
			}
			catch (Exception ex)
			{
				await App.Instance.MainPage.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// Item10 클릭 이벤트 핸들러
		private async void Item10_Clicked(object sender, EventArgs e)
		{
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				var page = new RecommandPartner.RecommendPartnersPage(10);
				await page.GetItems();
				await App.Instance.MainPage.Navigation.PushAsync(page);
			}
			catch (Exception ex)
			{
				await App.Instance.MainPage.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// Item11 클릭 이벤트 핸들러
		private async void Item11_Clicked(object sender, EventArgs e)
		{
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				var page = new RecommandPartner.RecommendPartnersPage(11);
				await page.GetItems();
				await App.Instance.MainPage.Navigation.PushAsync(page);
			}
			catch (Exception ex)
			{
				await App.Instance.MainPage.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// Item12 클릭 이벤트 핸들러
		private async void Item12_Clicked(object sender, EventArgs e)
		{
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				var page = new RecommandPartner.RecommendPartnersPage(12);
				await page.GetItems();
				await App.Instance.MainPage.Navigation.PushAsync(page);
			}
			catch (Exception ex)
			{
				await App.Instance.MainPage.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}
	}
}
