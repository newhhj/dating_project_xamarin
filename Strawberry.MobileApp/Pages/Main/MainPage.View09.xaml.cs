using Rg.Plugins.Popup.Extensions;
using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Shares;
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
	public partial class MainPage_View09 : DataTemplate
	{
		// 잠금 데이터 모델
		private LockDataModel LockData { get; set; } = new LockDataModel();

		public MainPage_View09()
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
				var data = view.BindingContext as MainPage_View09_Data;

				// 무료 좋아요 이용권 및 딸기 포인트 확인
				if (App.Instance.Member.FreeChoiceCount == 0 && App.Instance.Member.Point < 5)
				{
					// 결제 다이얼로그 표시
					var dialog = new MainPage_Dialog_Payment(data.ProfileImage, data.Nickname);
					await App.Instance.MainPage.Navigation.PushPopupAsync(dialog);
					return;
				}

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

		// 좋아요 버튼 클릭 이벤트 처리
		private async void Choice_Clicked(object sender, EventArgs e)
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
				var data = view.BindingContext as MainPage_View09_Data;

				var isConfirm = false;
				if (App.Instance.Member.FreeChoiceCount > 0)
				{
					// 무료 좋아요 이용권 사용 여부 확인
					var dialog = new ConfirmDialog("알림", "무료 좋아요 이용권을 소모합니다.");
					isConfirm = await dialog.ShowDialog();
				}
				else
				{
					if (App.Instance.Member.Point >= 5)
					{
						// 딸기 포인트 사용 여부 확인
						var dialog = new ConfirmDialog("알림", "보유 딸기 5개를 소모합니다.");
						isConfirm = await dialog.ShowDialog();
					}
					else
					{
						// 결제 다이얼로그 표시
						var dialog = new MainPage_Dialog_Payment(data.ProfileImage, data.Nickname);
						await App.Instance.MainPage.Navigation.PushPopupAsync(dialog);
					}
				}

				if (!isConfirm)
					return;

				using (var api = new ApiHelper())
				{
					// 좋아요 선택 실행
					var result = await api.ExcuteFeedbackChoice(
						data.Id,
						data.MemberId,
						new
						{
							FreeChoiceCount = default(int),
							Point = default(int)
						});

					// 무료 좋아요 이용권 및 딸기 포인트 업데이트
					App.Instance.Member.FreeChoiceCount = result.FreeChoiceCount;
					App.Instance.Member.Point = result.Point;
				}

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

		// 패스 버튼 클릭 이벤트 처리
		private async void Pass_Clicked(object sender, EventArgs e)
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
				var data = view.BindingContext as MainPage_View09_Data;

				using (var api = new ApiHelper())
				{
					// 패스 실행
					await api.ExcuteStarPointPass(data.Id);
				}

				var parent = view.Parent;
				while (!(parent is FlexLayout))
					parent = parent.Parent;

				var items = (ObservableCollection<object>)BindableLayout.GetItemsSource(parent);
				items.Remove(data);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}
	}
}
