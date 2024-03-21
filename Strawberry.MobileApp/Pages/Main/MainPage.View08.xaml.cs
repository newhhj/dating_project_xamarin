using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using System;
using System.Collections.Generic;
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
	public partial class MainPage_View08 : DataTemplate
	{
		private LockDataModel LockData { get; set; } = new LockDataModel();

		public MainPage_View08()
		{
			InitializeComponent();
		}

		// 프로필 클릭 이벤트 핸들러
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
				var view = sender as View;
				var data = view.BindingContext as MainPage_View08_Data;

				var page = new Profile.ProfilePage_Partner();
				await page.ShowAsync(data.MemberId, true);
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

		// 목록보기 버튼 클릭 이벤트 핸들러
		private void ShowList_Clicked(object sender, EventArgs e)
		{
			// 목록보기 버튼 클릭 시 수행할 동작 작성
		}
	}
}
