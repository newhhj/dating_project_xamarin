//using Com.Kakao.Sdk.Xamarin.Forms;
using FFImageLoading.Work;
using Newtonsoft.Json;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Join;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Intro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Intro : BasePage
    {
        private SKBitmap[] bitmaps;
        private int[] durations;
        private int[] accumulatedDurations;
        private int totalDuration;
        private Stopwatch stopwatch = new Stopwatch();
        private bool isAnimating;
        private int currentFrame;
		private IAuthenticationService authenticationService;

		public Page_Intro()
        {
            InitializeComponent();
            InitIntroGIF();
			authenticationService = new AuthenticationService();

			MessagingInit();

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            isAnimating = true;
            stopwatch.Start();
            Device.StartTimer(TimeSpan.FromMilliseconds(100), OnTimerTick);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            stopwatch.Stop();
            isAnimating = false;
        }

        private void InitIntroGIF()
        {
            using (var stream = this.GetType().Assembly.GetManifestResourceStream("Strawberry.MobileApp.Images.intro.gif"))
            using (var skStream = new SKManagedStream(stream))
            using (SKCodec codec = SKCodec.Create(skStream))
            {
                int frameCount = codec.FrameCount;
                bitmaps = new SKBitmap[frameCount];
                durations = new int[frameCount];
                accumulatedDurations = new int[frameCount];

                // Note: There's also a RepetitionCount property of SKCodec not used here

                // Loop through the frames
                for (int frame = 0; frame < frameCount; frame++)
                {
                    // From the FrameInfo collection, get the duration of each frame
                    durations[frame] = codec.FrameInfo[frame].Duration;

                    // Create a full-color bitmap for each frame
                    SKImageInfo imageInfo = new SKImageInfo(codec.Info.Width, codec.Info.Height);
                    bitmaps[frame] = new SKBitmap(imageInfo);

                    // Get the address of the pixels in that bitmap
                    IntPtr pointer = bitmaps[frame].GetPixels();

                    // Create an SKCodecOptions value to specify the frame
                    SKCodecOptions codecOptions = new SKCodecOptions(frame);

                    // Copy pixels from the frame into the bitmap
                    var result = codec.GetPixels(imageInfo, pointer, codecOptions);
                }

                // Sum up the total duration
                for (int frame = 0; frame < durations.Length; frame++)
                {
                    totalDuration += durations[frame];
                }

                // Calculate the accumulated durations
                for (int frame = 0; frame < durations.Length; frame++)
                {
                    accumulatedDurations[frame] = durations[frame] +
                        (frame == 0 ? 0 : accumulatedDurations[frame - 1]);
                }
            }
        }

        private bool OnTimerTick()
        {
            if (currentFrame + 1 >= bitmaps.Length)
            {
                isAnimating = false;
                Init();
            }
            else
            {
                currentFrame++;
                canvasView.InvalidateSurface();
            }

            return isAnimating;
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(SKColors.White);

            // Get the bitmap and center it
            SKBitmap bitmap = bitmaps[currentFrame];
            canvas.DrawBitmap(bitmap, bitmap.Info.Rect, info.Rect.AspectFit(bitmap.Info.Size));
        }


        private async void Init()
        {
            await Task.Run(async () =>
            {
                var apikey = await Settings.GetApiKey();
                if (string.IsNullOrWhiteSpace(apikey))
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        ButtonsArea.IsVisible = true;
                    });
                    return;
                }

                using (var http = new HttpClient())
                {
                    var formDataContent = new MultipartFormDataContent();
                    formDataContent.Add(new StringContent(apikey), "ApiKey");
                    var res = await http.PostAsync($"{Settings.ServerUrl}/Authentication/GetMemberFromApiKey", formDataContent);
                    var resText = await res.Content.ReadAsStringAsync();
                    if (res.IsSuccessStatusCode)
                    {
                        MainThread.BeginInvokeOnMainThread(async () =>
                        {
                            var resData = JsonConvert.DeserializeAnonymousType(resText, new
                            {
                                Message = default(string),
                                Member = default(DataModels.Member)
                            });

                            if (!string.IsNullOrWhiteSpace(resData.Message))
                                throw new Exception(resData.Message);

                            if (resData.Member == null)
                            {
                                await Settings.SetApiKey(null);
                                ButtonsArea.IsVisible = true;
                                return;
                            }

                            App.Instance.Member = resData.Member;

                            switch (resData.Member.MemberState)
                            {
                                case DataModels.MemberStateTypes.Normal:
                                {
                                    var nextPage = new Main.MainPage();
                                    await nextPage.InitAsync();
                                    await this.Navigation.PushAsync(nextPage);
                                    this.Navigation.RemovePage(this);
                                    break;
                                }
                                case DataModels.MemberStateTypes.Block:
                                    break;
                                case DataModels.MemberStateTypes.JoinWait:
                                case DataModels.MemberStateTypes.JoinConfirm:
                                case DataModels.MemberStateTypes.JoinDeny:
                                {
                                    await this.Navigation.PushAsync(new Pages.Join.Page_Join_Confirm());
                                    this.Navigation.RemovePage(this);
                                    break;
                                }
                                default:
                                    throw new Exception("앱을 실행할 수 없습니다.");
                            }
                        });
                        
                    }
                    else
                    {
                        throw new Exception("서버와의 통신에 실패했습니다.");
                    }
                }
            });
        }

        private async void Phone_Clicked(object sender, EventArgs e)
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
                await Navigation.PushAsync(new Join.Page_Join_Phone());
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

		private async void KakaoLogin_Clicked(object sender, EventArgs e)
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
				await authenticationService.LoginWithSNSAsync(SNSProvider.Kakao);

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

		void MessagingInit()
		{
			MessagingCenter.Subscribe<User, bool>(this, MessengerKeys.AuthenticationRequested, OnAuthenticationChanged);
		}

		private async void OnAuthenticationChanged(User user, bool isLogin)
		{
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			if (isLogin)
			{
				using (var api = new ApiHelper())
				{
					var apikey = default(string);

					{
						var result = await api.ExcuteKakaoLogin(
							long.Parse(user.Id.ToString()),
							new
							{
								ApiKey = default(string)
							});

						if (!string.IsNullOrWhiteSpace(result.ApiKey))
							apikey = result.ApiKey;
					}


					if (string.IsNullOrWhiteSpace(apikey))
					{
						App.Instance.Member.KakaoKey = long.Parse(user.Id.ToString());
						await this.Navigation.PushAsync(new Page_Join_Terms());
					}
					else
					{
						await Settings.SetApiKey(apikey);

						var result = await api.GetMemberFromApiKey(new
						{
							Member = default(DataModels.Member)
						});

						App.Instance.Member = result.Member;

						switch (result.Member.MemberState)
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

					//var p = new NavigationParameters();
					//p.Add("user", user);

					//await NavigationService.NavigateAsync("NavigationPage/MainPage", p);
				}
			}
		}

		//private async void KakaoLogin_Clicked(object sender, EventArgs e)
		//{
		//    DependencyService.Get<IDeviceHelper>().Vibrate();

		//    lock (this.LockData)
		//    {
		//        if (this.LockData.IsLocked)
		//            return;
		//        this.LockData.IsLocked = true;
		//    }

		//    try
		//    {
		//        var userInfo = await KakaoHelper.Login(AuthTypes.KakaoLoginAll);
		//        using (var api = new ApiHelper())
		//        {
		//            var apikey = default(string);

		//            {
		//                var result = await api.ExcuteKakaoLogin(
		//                    userInfo.Id,
		//                    new
		//                    {
		//                        ApiKey = default(string)
		//                    });

		//                if (!string.IsNullOrWhiteSpace(result.ApiKey))
		//                    apikey = result.ApiKey;
		//            }


		//            if (string.IsNullOrWhiteSpace(apikey))
		//            {
		//                App.Instance.Member.KakaoKey = userInfo.Id;
		//                await this.Navigation.PushAsync(new Page_Join_Terms());
		//            }
		//            else
		//            {
		//                await Settings.SetApiKey(apikey);

		//                var result = await api.GetMemberFromApiKey(new
		//                {
		//                    Member = default(DataModels.Member)
		//                });

		//                App.Instance.Member = result.Member;

		//                switch (result.Member.MemberState)
		//                {
		//                    case DataModels.MemberStateTypes.Normal:
		//                    {
		//                        var nextPage = new Main.MainPage();
		//                        await nextPage.InitAsync();
		//                        MainThread.BeginInvokeOnMainThread(async () =>
		//                        {
		//                            await this.Navigation.PushAsync(nextPage);
		//                            var removePages = this.Navigation.NavigationStack
		//                                .Where(x => x != nextPage)
		//                                .ToArray();
		//                            foreach (var page in removePages)
		//                            {
		//                                this.Navigation.RemovePage(page);
		//                            }
		//                        });                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
		//                        break;
		//                    }
		//                    case DataModels.MemberStateTypes.Block:
		//                        break;
		//                    case DataModels.MemberStateTypes.JoinWait:
		//                    case DataModels.MemberStateTypes.JoinConfirm:
		//                    case DataModels.MemberStateTypes.JoinDeny:
		//                    {
		//                        MainThread.BeginInvokeOnMainThread(async () =>
		//                        {
		//                            var nextPage = new Pages.Join.Page_Join_Confirm();
		//                            await this.Navigation.PushAsync(nextPage);
		//                            var removePages = this.Navigation.NavigationStack
		//                                .Where(x => x != nextPage)
		//                                .ToArray();
		//                            foreach (var page in removePages)
		//                            {
		//                                this.Navigation.RemovePage(page);
		//                            }
		//                            this.Navigation.RemovePage(this);
		//                        });
		//                        break;
		//                    }
		//                    default:
		//                        throw new Exception("앱을 실행할 수 없습니다.");
		//                }
		//            }


		//        }
		//    }
		//    catch (Exception ex)
		//    {
		//        while (ex.InnerException != null)
		//            ex = ex.InnerException;

		//        await App.Instance.MainPage.DisplayToastAsync(ex.Message);
		//    }
		//    finally
		//    {
		//        this.LockData.IsLocked = false;
		//    }
		//}

		private async void EmailLogin_Clicked(object sender, EventArgs e)
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
                var page = new Login.LoginPage();
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
    }
}