using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage_View06 : DataTemplate
	{
		private LockDataModel LockData { get; set; }

		public MainPage_View06()
		{
			// LockDataModel 인스턴스 생성
			this.LockData = new LockDataModel();
			InitializeComponent();
		}

		private async void ViewProfile_Clicked(object sender, EventArgs e)
		{
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				// 클릭된 요소와 해당 요소의 데이터 가져오기
				var element = (Element)sender;
				var data = (MainPage_View06_Data)element.BindingContext;

				// 프로필 페이지로 이동하여 데이터 가져오기
				var profilePage = new Profile.ProfilePage_Partner();
				await profilePage.GetDataAsync(data.Id, true);
				await App.Instance.MainPage.Navigation.PushAsync(profilePage);
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
