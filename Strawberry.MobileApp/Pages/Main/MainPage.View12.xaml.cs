using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Chatting;
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
	public partial class MainPage_View12 : DataTemplate
	{
		private bool IsMoving { get; set; } = false;
		private LockDataModel LockData { get; set; } = new LockDataModel();

		public MainPage_View12()
		{
			InitializeComponent();
		}

		// 패닝 동작 이벤트 핸들러입니다.
		private async void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
		{
			var view = sender as View;

			switch (e.StatusType)
			{
				case GestureStatus.Running:
					{
						if (e.TotalX < -10)
						{
							if (IsMoving)
								return;
							IsMoving = true;
							await view.TranslateTo(-80, 0);
							IsMoving = false;
						}

						if (e.TotalX > 10)
						{
							if (IsMoving)
								return;
							IsMoving = true;
							await view.TranslateTo(0, 0);
							IsMoving = false;
						}
					}
					break;
				default:
					break;
			}
		}

		// 대화 목록 항목 삭제 버튼 클릭 이벤트 핸들러입니다.
		private async void RemoveChattingRoom_Clicked(object sender, EventArgs e)
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
				var data = view.BindingContext as MainPage_View12_Data;

				// 대화방 삭제 API 호출
				using (var api = new ApiHelper())
				{
					await api.ExcuteRemoveChattingRoom(data.Id);
				}

				// 대화 목록에서 항목 제거
				var mainPage = (MainPage)App.Instance.MainPage.Navigation.NavigationStack.FirstOrDefault(x => x is MainPage);
				var mainPageData = mainPage.BindingContext as MainPage_Data;
				mainPageData.Items.Remove(data);
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

		// 대화 목록 항목 클릭 이벤트 핸들러입니다.
		private async void Item_Clicked(object sender, EventArgs e)
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
				var data = view.BindingContext as MainPage_View12_Data;

				// 대화 페이지로 이동
				var page = new ChattingPage();
				await page.ShowPageAsync(data.Id);

				// 읽지 않은 메시지 개수 초기화
				data.NotReadCount = 0;
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
