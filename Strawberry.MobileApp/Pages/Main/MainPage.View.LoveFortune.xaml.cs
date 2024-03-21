using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage_View_LoveFortune : DataTemplate
	{
		private int ActionCount { get; set; } // 생체인증 액션 횟수를 저장하는 변수
		private Timer Timer { get; set; } // 생체인증 타이머
		private MainPage_View_LoveFortune_Data Data { get; set; } // 데이터 바인딩을 위한 데이터 객체

		public MainPage_View_LoveFortune()
		{
			this.InitializeComponent();
			this.Init();
		}

		private void Init()
		{
			this.Timer = new Timer
			{
				AutoReset = true,
				Interval = 1000,
			};
			this.Timer.Elapsed += this.Timer_Elapsed;
		}

		// 터치 이벤트 처리
		private void TouchEffect_TouchAction(object sender, Effects.TouchEffect.TouchActionType e)
		{
			var view = sender as View;
			this.Data = view.BindingContext as MainPage_View_LoveFortune_Data;

			switch (e)
			{
				case Effects.TouchEffect.TouchActionType.Pressed: // 터치 시작
					this.Data.Step = 1; // View02로 전환
					this.ActionCount = 0; // 액션 횟수 초기화
					this.Timer.Start(); // 타이머 시작
					break;
				case Effects.TouchEffect.TouchActionType.Released: // 터치 종료
					this.Timer.Stop(); // 타이머 정지
					break;
				default:
					break;
			}
		}

		// 타이머 경과 이벤트 처리
		private void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			this.ActionCount++; // 액션 횟수 증가
			DependencyService.Get<IDeviceHelper>().Vibrate(); // 진동 실행

			if (this.ActionCount == 5) // 액션 횟수가 5회인 경우
			{
				Task.Run(this.GetFortunePartnet); // 파트너 정보 가져오기 실행
			}
		}

		// 파트너 정보 가져오기
		private async void GetFortunePartnet()
		{
			try
			{
				using (var api = new ApiHelper())
				{
					var result = await api.GetFortunePartnet(new
					{
						partner = new
						{
							Id = default(int),
							ProfileImage = default(string)
						},
						message = default(string)
					});

					if (result.partner == null)
						throw new Exception("오늘의 기운에 맞는 파트너가 없습니다.");

					var partnerId = result.partner.Id;
					var partnerProfileImage = default(ImageSource);
					var message = result.message;

					if (!string.IsNullOrWhiteSpace(result.partner.ProfileImage))
					{
						using (var http = new HttpClient())
						{
							var buffer = await http.GetByteArrayAsync(result.partner.ProfileImage);

							if (buffer != null && buffer.Length > 0)
							{
								partnerProfileImage = ImageSource.FromStream(() => { return new MemoryStream(buffer); });
							}
						}
					}

					MainThread.BeginInvokeOnMainThread(() =>
					{
						this.Data.PartnerId = partnerId;
						this.Data.PartnerProfileImage = partnerProfileImage;
						this.Data.Message = message;
						this.Data.Step = 2;
					});
				}
			}
			catch (Exception ex)
			{
				MainThread.BeginInvokeOnMainThread(() =>
				{
					App.Instance.MainPage.DisplayToastAsync(ex.Message);
				});
			}

			this.ActionCount = 0;
			this.Timer.Stop();
		}

		private async void Partner_Clicked(object sender, EventArgs e)
		{
			try
			{
				var page = new Profile.ProfilePage_Partner();
				await page.ShowAsync(this.Data.PartnerId, true);
			}
			catch (Exception ex)
			{
				await App.Instance.MainPage.DisplayToastAsync(ex.Message);
			}
		}
	}
}
