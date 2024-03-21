using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Main;
using Strawberry.MobileApp.Pages.Near;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Login
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : BasePage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		// 페이지를 보여주는 비동기 메서드
		public async Task ShowPageAsync()
		{
			await App.Instance.MainPage.Navigation.PushAsync(this);
		}

		// 닫기 버튼 클릭 시 호출되는 이벤트 핸들러
		private async void ClosePage_Clicked(object sender, EventArgs e)
		{
			DependencyService.Get<IDeviceHelper>().Vibrate();
			await this.Navigation.PopAsync();
		}

		// 로그인 버튼 클릭 시 호출되는 이벤트 핸들러
		private async void Login_Clicked(object sender, EventArgs e)
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
				// 이메일과 비밀번호를 입력했는지 확인
				if (string.IsNullOrWhiteSpace(this.pageData.Email))
					throw new Exception("이메일을 입력하세요");
				if (string.IsNullOrWhiteSpace(this.pageData.Password))
					throw new Exception("비밀번호를 입력하세요");

				using (var api = new ApiHelper())
				{
					// 로그인 작업 수행
					var result1 = await api.ExcuteLogin(
						this.pageData.Email,
						this.pageData.Password,
						new
						{
							ApiKey = default(string)
						});

					await Settings.SetApiKey(result1.ApiKey);

					var result2 = await api.GetMemberFromApiKey(new
					{
						Member = default(DataModels.Member)
					});

					App.Instance.Member = result2.Member;

					switch (result2.Member.MemberState)
					{
						case DataModels.MemberStateTypes.Normal:
							{
								var nextPage = new Main.MainPage();
								await nextPage.InitAsync();
								MainThread.BeginInvokeOnMainThread(async () =>
								{
									await this.Navigation.PushAsync(nextPage);
									var removePages = this.Navigation.NavigationStack
										.Where(x => x != nextPage)
										.ToArray();
									foreach (var page in removePages)
									{
										this.Navigation.RemovePage(page);
									}
								});
								break;
							}
						case DataModels.MemberStateTypes.Block:
							break;
						case DataModels.MemberStateTypes.JoinWait:
						case DataModels.MemberStateTypes.JoinConfirm:
						case DataModels.MemberStateTypes.JoinDeny:
							{
								MainThread.BeginInvokeOnMainThread(async () =>
								{
									var nextPage = new Pages.Join.Page_Join_Confirm();
									await this.Navigation.PushAsync(nextPage);
									var removePages = this.Navigation.NavigationStack
										.Where(x => x != nextPage)
										.ToArray();
									foreach (var page in removePages)
									{
										this.Navigation.RemovePage(page);
									}
									this.Navigation.RemovePage(this);
								});
								break;
							}
						default:
							throw new Exception("앱을 실행할 수 없습니다.");
					}
				}
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

		// 추가적인 버튼 클릭 시 호출되는 이벤트 핸들러
		private void Button_Clicked(object sender, EventArgs e)
		{
			// 구현 필요
		}

		// 추가적인 버튼 클릭 시 호출되는 이벤트 핸들러
		private void Button_Clicked_1(object sender, EventArgs e)
		{
			// 구현 필요
		}
	}

	// 로그인 페이지 데이터 모델
	public class LoginPageData : BindableObject
	{
		public string Email { get => (string)GetValue(EmailProperty); set => SetValue(EmailProperty, value); }
		public static readonly BindableProperty EmailProperty = BindableProperty.Create(nameof(Email), typeof(string), typeof(LoginPageData));

		public string Password { get => (string)GetValue(PasswordProperty); set => SetValue(PasswordProperty, value); }
		public static readonly BindableProperty PasswordProperty = BindableProperty.Create(nameof(Password), typeof(string), typeof(LoginPageData));
	}
}
