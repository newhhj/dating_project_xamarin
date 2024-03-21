using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
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
	public partial class MainPage_View10 : DataTemplate
	{
		private LockDataModel LockData { get; set; } = new LockDataModel();

		public MainPage_View10()
		{
			InitializeComponent();
		}

		// 프로필 클릭 이벤트 처리
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
				var data = view.BindingContext as MainPage_View10_Data;

				// 프로필 페이지로 이동하여 파트너 정보를 표시
				var page = new Profile.ProfilePage_Partner();
				await page.ShowAsync(data.PartnerId, true);
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

		// 삭제 버튼 클릭 이벤트 처리
		private async void Remove_Clicked(object sender, EventArgs e)
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
				var data = view.BindingContext as MainPage_View10_Data;

				using (var api = new ApiHelper())
				{
					await api.RemoveMyStarPoint(data.Id);
				}

				// 삭제한 항목을 FlexLayout에서 제거
				var parent = view.Parent;
				while (!(parent is FlexLayout))
					parent = parent.Parent;

				var items = (ObservableCollection<object>)BindableLayout.GetItemsSource(parent);
				items.Remove(data);
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
