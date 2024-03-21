using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Appeal;
using Strawberry.MobileApp.Pages.Near;
using Strawberry.MobileApp.Pages.Notification;
using Strawberry.MobileApp.Pages.Option;
using Strawberry.MobileApp.Pages.Profile;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : BasePage
	{
		private bool isCheckedMainPopupAds = false;
		private MainPage_View03_Data View03_Data { get; set; }

		public MainPage()
		{
			InitializeComponent();
		}

		public async Task InitAsync()
		{
			// 서버로 초기화 요청을 보냅니다.
			using (var http = new HttpClient())
			{
				var formData = new MultipartFormDataContent();
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(Xamarin.Essentials.DeviceInfo.Platform.ToString()), "platform");
				formData.Add(new StringContent(await DependencyService.Get<IDeviceHelper>().GetPushToken()), "pushtoken");
				var res = await http.PostAsync($"{Settings.ServerUrl}/Main/InitState", formData);
			}

			await this.GetMenu00Items();
		}

		public async Task CheckMainPopupAds()
		{
			if (isCheckedMainPopupAds)
				return;
			isCheckedMainPopupAds = true;

			// 메인 팝업 광고를 확인합니다.
			using (var api = new ApiHelper())
			{
				var result = await api.GetMainPopupAds(new
				{
					datas = new[]
					{
						new
						{
							Id = default(int),
							ADName = default(string),
							Link = default(string),
							JsonData = default(string)
						}
					}
				});

				if (result.datas != null && result.datas.Length > 0)
				{
					var ids = JsonConvert.DeserializeObject<List<int>>(Preferences.Get("skipmainpopupids", "[]"));

					foreach (var item in result.datas.Where(x => !ids.Any(z => z == x.Id)))
					{
						var data = JsonConvert.DeserializeAnonymousType(item.JsonData, new
						{
							ImageUrl = default(string)
						});

						await MainPopupAD.MainPopupADPage.ShowPageAsync(new MainPopupAD.MainPopupADPageData
						{
							Id = item.Id,
							ImageUrl = data.ImageUrl,
							Link = item.Link
						});
					}
				}
			}
		}

		public async Task CheckNotisAsync()
		{
			// 새 알림이 있는지 확인합니다.
			using (var api = new ApiHelper())
			{
				var result = await api.GetHasNewNotifications(new
				{
					HasValue = default(bool)
				});
				if (result.HasValue)
				{
					Device.StartTimer(TimeSpan.FromSeconds(3), () =>
					{
						Device.BeginInvokeOnMainThread(async () =>
						{
							for (int i = 0; i < 5; i++)
							{
								await this.icon_noti.RotateTo(-20, 30, Easing.Linear);
								await this.icon_noti.RotateTo(0, 30, Easing.Linear);
							}
						});

						return this.IsActive;
					});
				}
			}
		}

		private async Task CheckOptionPateDataAsync()
		{
			// 옵션 페이지 데이터를 확인합니다.
			if (this.PageData.MenuIndex == 4)
			{
				using (var api = new ApiHelper())
				{
					var result = await api.GetOptionData(new
					{
						Item = default(MainPage_View14_Data)
					});

					this.PageData.Items.Clear();
					this.PageData.Items.Add(result.Item);
				}
			}
		}

		private async Task GetMenu00Items()
		{
			// 메뉴 00 항목들을 가져옵니다.
			using (var http = new HttpClient())
			{
				var formData = new MultipartFormDataContent();
				formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
				formData.Add(new StringContent(this.PageData.Page.ToString()), "page");
				var res = await http.PostAsync($"{Settings.ServerUrl}/Main/GetMainItems", formData);
				var resText = await res.Content.ReadAsStringAsync();
				var resData = JsonConvert.DeserializeAnonymousType(resText, new
				{
					View01Items = default(List<MainPage_View01_Data>),
					View02Items = default(MainPage_View02_Data[]),
					View03Items = default(MainPage_View03_Data),
					View04Items = default(MainPage_View04_Data),
					View06Items = default(MainPage_View06_Data[]),
					Message = default(string)
				});

				if (!string.IsNullOrWhiteSpace(resData.Message))
					throw new Exception(resData.Message);

				if (resData.View01Items != null && resData.View01Items.Count > 0)
				{
					if (PageData.Page == 0)
					{
						this.PageData.Items.Add(new MainPage_ViewLabel_Data
						{
							Title = "오늘의 추천메이트",
							TextColor = Xamarin.Forms.Color.White
						});
					}
					else if (PageData.Page == 1)
					{
						this.PageData.Items.Add(new MainPage_ViewLabel_Data
						{
							Title = "더 많은 메이트",
							TextColor = Xamarin.Forms.Color.White
						});
					}

					if (PageData.Page == 0)
					{
						var view01json = Xamarin.Essentials.Preferences.Get("view01json", null);
						var view01Data = new
						{
							Date = DateTime.Today,
							Items = new List<MainPage_View01_Data>()
						};

						if (view01json != null)
						{
							view01Data = JsonConvert.DeserializeAnonymousType(view01json, view01Data);
						}

						if (view01Data.Date < DateTime.Today)
						{
							view01Data = new
							{
								Date = DateTime.Today,
								Items = new List<MainPage_View01_Data>()
							};
						}

						if (view01Data.Items.Count < 10)
						{
							var showCount = view01Data.Items.Count(x => !x.IsDeleted);
							for (int i = 0; i < resData.View01Items.Count - showCount; i++)
							{
								view01Data.Items.Add(resData.View01Items[i]);
							}
							view01json = JsonConvert.SerializeObject(view01Data);
							Xamarin.Essentials.Preferences.Set("view01json", view01json);
						}

						var items = view01Data.Items.Where(x => !x.IsDeleted).ToArray();
						items = items
							.Skip(items.Length - 2)
							.Take(2)
							.ToArray();

						resData.View01Items.Clear();
						foreach (var item in items)
						{
							resData.View01Items.Add(item);
						}
					}

					foreach (var item in resData.View01Items)
					{
						this.PageData.Items.Add(item);
					}
				}

				if (resData.View02Items != null && resData.View02Items.Length > 0)
				{
					foreach (var item in resData.View02Items)
					{
						this.PageData.Items.Add(item);
					}
				}

				if (this.PageData.Page == 0)
				{
					if (resData.View03Items != null)
					{
						this.PageData.Items.Add(resData.View03Items);
						if (resData.View03Items.HotStrawberryStartTime?.AddHours(1) > DateTime.Now)
							this.StartHotStrawberry();
					}
					else
					{
						this.PageData.Items.Add(new MainPage_View03_Data());
					}
				}

				if (resData.View04Items != null)
				{
					this.PageData.Items.Add(new MainPage_ViewLabel_Data
					{
						Title = "실시간",
						TextColor = Xamarin.Forms.Color.White
					});
					this.PageData.Items.Add(resData.View04Items);
				}

				if (this.PageData.Page == 0)
				{
					this.PageData.Items.Add(new MainPage_ViewLabel_Data
					{
						Title = "초고속 이상형 찾기",
						TextColor = Xamarin.Forms.Color.White
					});
					this.PageData.Items.Add(new MainPage_View05_Data());
				}

				if (this.PageData.Page == 0)
				{
					if (resData.View06Items != null && resData.View06Items.Length > 0)
					{
						this.PageData.Items.Add(new MainPage_ViewLabel_Data
						{
							Title = "이번주 생일인 메이트",
							TextColor = Xamarin.Forms.Color.White
						});
						this.PageData.Items.Add(resData.View06Items);
					}
				}
			}
		}

		private async Task GetMenu01Items()
		{
			// 채팅방 목록을 가져오는 비동기 메서드입니다.
			// 현재 페이지 데이터의 아이템 개수를 기준으로 채팅방 목록을 조회합니다.
			using (var api = new ApiHelper())
			{
				var result = await api.GetChattingRooms(
					this.PageData.Items.Count,
					new
					{
						Items = default(MainPage_View12_Data[])
					});

				if (result.Items?.Length > 0)
				{
					// 가져온 채팅방 목록이 있을 경우
					// 채팅방 목록 아이템을 추가합니다.
					this.PageData.Items.Add(new MainPage_View11_Data());

					foreach (var item in result.Items)
					{
						// 가져온 각 채팅방 아이템을 페이지 데이터의 아이템에 추가합니다.
						this.PageData.Items.Add(item);
					}
				}
				else
				{
					// 가져온 채팅방 목록이 없을 경우
					// 빈 상태를 나타내는 아이템을 추가합니다.
					this.PageData.Items.Add(new MainPage_View13_Data());
				}
			}
		}

		private async Task GetMenu02Items()
		{
			// 선택한 아이템들을 가져오는 비동기 메서드입니다.
			using (var api = new ApiHelper())
			{
				var result = await api.GetChoiceItems(new
				{
					Items01 = default(MainPage_View07_Data[]),
					Items02 = default(MainPage_View08_Data),
					Items03 = default(MainPage_View09_Data[]),
					Items04 = default(MainPage_View10_Data[])
				});

				if (result?.Items01 != null && result?.Items01.Length > 0)
				{
					// 받은 좋아요 아이템이 있을 경우
					// 받은 좋아요를 나타내는 레이블 아이템을 추가합니다.
					this.PageData.Items.Add(new MainPage_ViewLabel_Data
					{
						Title = "받은 좋아요",
						TextColor = Xamarin.Forms.Color.Black
					});

					foreach (var item in result.Items01)
					{
						// 각 받은 좋아요 아이템을 페이지 데이터의 아이템에 추가합니다.
						this.PageData.Items.Add(item);
					}
				}

				if (result?.Items02 != null || (result?.Items03 != null && result?.Items03.Length > 0))
				{
					// 받은 진심 아이템이 있을 경우
					// 받은 진심을 나타내는 레이블 아이템을 추가합니다.
					this.PageData.Items.Add(new MainPage_ViewLabel_Data
					{
						Title = "받은 진심",
						TextColor = Xamarin.Forms.Color.Black
					});

					if (result?.Items02 != null)
					{
						// 받은 진심 아이템이 단일 아이템인 경우
						// 해당 아이템을 페이지 데이터의 아이템에 추가합니다.
						this.PageData.Items.Add(result.Items02);
					}

					if (result?.Items03 != null && result?.Items03.Length > 0)
					{
						foreach (var item in result.Items03)
						{
							// 받은 진심 아이템들을 페이지 데이터의 아이템에 추가합니다.
							this.PageData.Items.Add(item);
						}
					}
				}

				if (result?.Items04 != null && result?.Items04.Length > 0)
				{
					// 마이 찜 아이템이 있을 경우
					// 마이 찜을 나타내는 레이블 아이템을 추가합니다.
					this.PageData.Items.Add(new MainPage_ViewLabel_Data
					{
						Title = "마이 찜",
						TextColor = Xamarin.Forms.Color.Black
					});

					foreach (var item in result.Items04)
					{
						// 각 마이 찜 아이템을 페이지 데이터의 아이템에 추가합니다.
						this.PageData.Items.Add(item);
					}
				}
			}
		}

		private async Task GetMenu04Items()
		{
			// 옵션 데이터를 가져오는 비동기 메서드입니다.
			using (var api = new ApiHelper())
			{
				var result = await api.GetOptionData(new
				{
					Item = default(MainPage_View14_Data)
				});

				// 가져온 옵션 데이터를 페이지 데이터의 아이템에 추가합니다.
				this.PageData.Items.Add(result.Item);
			}
		}

		private async Task CloseApp()
		{
			// 앱을 종료하는 비동기 메서드입니다.
			var result = await this.DisplayAlert("알림", "앱을 종료하시겠습니까?", "예", "아니오");
			if (result)
				Process.GetCurrentProcess().Kill();
		}

		protected override void OnAppearing()
		{
			// 화면이 나타나면 실행되는 메서드입니다.
			base.OnAppearing();

			try
			{
				// 알림 체크, 옵션 페이지 데이터 체크, 메인 팝업 광고 체크를 비동기적으로 실행합니다.
				_ = this.CheckNotisAsync();
				_ = this.CheckOptionPateDataAsync();
				_ = this.CheckMainPopupAds();
			}
			catch (Exception ex)
			{
				// 발생한 예외를 처리합니다.
				while (ex.InnerException != null)
					ex = ex.InnerException;

				Console.WriteLine(ex);
			}
		}

		protected override bool OnBackButtonPressed()
		{
			// 뒤로 가기 버튼을 눌렀을 때 실행되는 메서드입니다.
			_ = this.CloseApp();
			return true;
		}

		public async void Menu00_Clicked(object sender, EventArgs e)
		{
			// 메뉴 00이 클릭되었을 때 실행되는 이벤트 핸들러입니다.
			if (this.PageData.MenuIndex == 0)
			{
				// 현재 선택된 메뉴가 00인 경우, 스크롤 뷰를 최상단으로 스크롤합니다.
				await this.scrollView01.ScrollToAsync(0, 0, true);
				return;
			}

			// 페이지 데이터의 메뉴 인덱스와 페이지를 초기화하고, 아이템을 지우고, 스크롤 뷰의 배경색을 변경합니다.
			this.PageData.MenuIndex = 0;
			this.PageData.Page = 0;
			this.PageData.Items.Clear();
			this.scrollView01.BackgroundColor = Xamarin.Forms.Color.Black;
			await this.GetMenu00Items();
		}

		public async void Menu01_Clicked(object sender, EventArgs e)
		{
			// 메뉴 01이 클릭되었을 때 실행되는 이벤트 핸들러입니다.
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				if (this.PageData.MenuIndex == 1)
				{
					// 현재 선택된 메뉴가 01인 경우, 스크롤 뷰를 최상단으로 스크롤합니다.
					await this.scrollView01.ScrollToAsync(0, 0, true);
					return;
				}

				// 페이지 데이터의 메뉴 인덱스와 페이지를 초기화하고, 아이템을 지우고, 스크롤 뷰의 배경색을 변경합니다.
				this.PageData.MenuIndex = 1;
				this.PageData.Page = 0;
				this.PageData.Items.Clear();
				this.scrollView01.BackgroundColor = Xamarin.Forms.Color.White;
				await this.GetMenu01Items();
			}
			catch (Exception ex)
			{
				// 발생한 예외를 처리합니다.
				while (ex.InnerException != null)
					ex = ex.InnerException;

				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		public async void Menu02_Clicked(object sender, EventArgs e)
		{
			// 메뉴 02이 클릭되었을 때 실행되는 이벤트 핸들러입니다.
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				if (this.PageData.MenuIndex == 2)
				{
					// 현재 선택된 메뉴가 02인 경우, 스크롤 뷰를 최상단으로 스크롤합니다.
					await this.scrollView01.ScrollToAsync(0, 0, true);
					return;
				}

				// 페이지 데이터의 메뉴 인덱스와 페이지를 초기화하고, 아이템을 지우고, 스크롤 뷰의 배경색을 변경합니다.
				this.PageData.MenuIndex = 2;
				this.PageData.Page = 0;
				this.PageData.Items.Clear();
				this.scrollView01.BackgroundColor = Xamarin.Forms.Color.White;
				await this.GetMenu02Items();
			}
			catch (Exception ex)
			{
				// 발생한 예외를 처리합니다.
				while (ex.InnerException != null)
					ex = ex.InnerException;

				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		public void Menu03_Clicked(object sender, EventArgs e)
		{
			// 메뉴 03이 클릭되었을 때 실행되는 이벤트 핸들러입니다.
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				if (this.PageData.MenuIndex == 3)
				{
					// 현재 선택된 메뉴가 03인 경우, 스크롤 뷰를 최상단으로 스크롤합니다.
					this.scrollView01.ScrollToAsync(0, 0, true);
					return;
				}

				// 페이지 데이터의 메뉴 인덱스와 페이지를 초기화하고, 아이템을 지우고, 스크롤 뷰의 배경색을 변경합니다.
				this.PageData.MenuIndex = 3;
				this.PageData.Page = 0;
				this.PageData.Items.Clear();
				this.scrollView01.BackgroundColor = Xamarin.Forms.Color.White;
				this.PageData.Items.Add(new MainPage_View_LoveFortune_Data());
			}
			catch (Exception ex)
			{
				// 발생한 예외를 처리합니다.
				while (ex.InnerException != null)
					ex = ex.InnerException;

				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		public async void Menu04_Clicked(object sender, EventArgs e)
		{
			// 메뉴 04이 클릭되었을 때 실행되는 이벤트 핸들러입니다.
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				if (this.PageData.MenuIndex == 4)
				{
					// 현재 선택된 메뉴가 04인 경우, 스크롤 뷰를 최상단으로 스크롤합니다.
					await this.scrollView01.ScrollToAsync(0, 0, true);
					return;
				}

				// 페이지 데이터의 메뉴 인덱스와 페이지를 초기화하고, 아이템을 지우고, 스크롤 뷰의 배경색을 변경합니다.
				this.PageData.MenuIndex = 4;
				this.PageData.Page = 0;
				this.PageData.Items.Clear();
				this.scrollView01.BackgroundColor = Xamarin.Forms.Color.White;
				await this.GetMenu04Items();
			}
			catch (Exception ex)
			{
				// 발생한 예외를 처리합니다.
				while (ex.InnerException != null)
					ex = ex.InnerException;

				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		public async void ExcuteNotShowMember(MainPage_View01_Data data)
		{
			// 표시하지 않는 회원으로 설정하는 이벤트 핸들러입니다.
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				var dialog = new MainPage_Dialog_RemovePartner();
				await this.Navigation.PushPopupAsync(dialog);
				if (!await dialog.TaskCompletionSource.Task)
					return;

				using (var http = new HttpClient())
				{
					var formData = new MultipartFormDataContent();
					formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
					formData.Add(new StringContent(data.Id.ToString()), "partnerid");
					var res = await http.PostAsync($"{Settings.ServerUrl}/Main/UpdateNowShowMember", formData);
					var resData = JsonConvert.DeserializeAnonymousType(await res.Content.ReadAsStringAsync(), new
					{
						Message = default(string)
					});

					if (!res.IsSuccessStatusCode)
						throw new Exception("잠시 후에 다시 시도해 주세요.");
				}

				this.PageData.Items.Remove(data);

				var view01json = Xamarin.Essentials.Preferences.Get("view01json", null);
				if (view01json != null)
				{
					var view01Data = JsonConvert.DeserializeAnonymousType(view01json, new
					{
						Date = default(DateTime),
						Items = default(List<MainPage_View01_Data>)
					});

					var item = view01Data.Items.FirstOrDefault(x => x.Id == data.Id);
					if (item != null)
					{
						item.IsDeleted = true;
					}

					view01json = JsonConvert.SerializeObject(view01Data);
					Xamarin.Essentials.Preferences.Set("view01json", view01json);
				}
			}
			catch (Exception ex)
			{
				await this.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		public async void ExcuteChoice(MainPage_View01_Data data)
		{
			// 좋아요를 보내는 이벤트 핸들러입니다.
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				if (App.Instance.Member.FreeChoiceCount == 0 && App.Instance.Member.Point < 5)
				{
					var dialog = new MainPage_Dialog_Payment(data.Thumbails[0], data.Nickname);
					await this.Navigation.PushPopupAsync(dialog);
					return;
				}

				using (var api = new ApiHelper())
				{
					var result = await api.ExcuteChoice(data.Id, new
					{
						FreeChoiceCount = default(int),
						Point = default(int)
					});

					App.Instance.Member.FreeChoiceCount = result.FreeChoiceCount;
					App.Instance.Member.Point = result.Point;

					this.PageData.Items.Remove(data);
					await this.DisplayToastAsync("좋아요를 보냈습니다.");
				}
			}
			catch (Exception ex)
			{
				await this.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		public async void ExcuteSmartChoice(MainPage_View01_Data data)
		{
			// 스마트 좋아요를 보내는 이벤트 핸들러입니다.
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				if (App.Instance.Member.Point < 10)
				{
					var paymentDialog = new MainPage_Dialog_Payment(data.Thumbails[0], data.Nickname);
					await this.Navigation.PushPopupAsync(paymentDialog);
					return;
				}

				var messageDialog = new MainPage_Dialog_SendSmartChoice(data.Nickname, data.Thumbails[0]);
				await this.Navigation.PushPopupAsync(messageDialog);
				var message = await messageDialog.TaskCompletionSource.Task;

				if (string.IsNullOrWhiteSpace(message))
					return;

				using (var api = new ApiHelper())
				{
					var result = await api.ExcuteSmartChoice(data.Id, message, new
					{
						Point = default(int)
					});

					App.Instance.Member.Point = result.Point;

					this.PageData.Items.Remove(data);
					await this.DisplayToastAsync("좋아요를 보냈습니다.");
				}
			}
			catch (Exception ex)
			{
				await this.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		public async void ExcuteShowProfile(MainPage_View02_Data data)
		{
			// 프로필을 보는 이벤트 핸들러입니다.
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				if (App.Instance.Member.Point < 5)
				{
					var dialog = new MainPage_Dialog_Payment(data.ProfileImage, data.Nickname);
					await this.Navigation.PushPopupAsync(dialog);
					return;
				}

				var profilePage = new ProfilePage_Partner();
				await profilePage.GetDataAsync(data.Id, false);
				await this.Navigation.PushAsync(profilePage);
			}
			catch (Exception ex)
			{
				await this.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		public async void ExcuteHotStrawberry(MainPage_View03_Data data)
		{
			// 핫딸기를 실행하는 이벤트 핸들러입니다.
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				if (App.Instance.Member.Point < 15)
				{
					var dialog = new MainPage_Dialog_Payment2();
					await this.Navigation.PushPopupAsync(dialog);
					return;
				}

				var view = flexLayout01.Children.FirstOrDefault(x => x.BindingContext is MainPage_View03_Data);
				if (view == null)
					return;

				using (var http = new HttpClient())
				{
					var formData = new MultipartFormDataContent();
					formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
					var res = await http.PostAsync($"{Settings.ServerUrl}/Main/ExecuteHotstrawberry", formData);
					var resText = await res.Content.ReadAsStringAsync();
					if (!res.IsSuccessStatusCode)
						throw new Exception("잠시 후에 다시 시도해 주세요.");

					var resData = JsonConvert.DeserializeAnonymousType(resText, new
					{
						Message = default(string),
						Id = default(int),
						StartTime = default(DateTime)
					});

					if (!string.IsNullOrWhiteSpace(resData.Message))
						throw new Exception(resData.Message);

					data.Id = resData.Id;
					data.HotStrawberryStartTime = resData.StartTime;
				}

				this.StartHotStrawberry();
			}
			catch (Exception ex)
			{
				await this.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}


		public async Task ExcuteStarPoint(MainPage_View04_Data data)
		{
			// StarPoint를 실행하는 이벤트 핸들러입니다.
			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				using (var http = new HttpClient())
				{
					var apikey = await Settings.GetApiKey();
					var formData = new MultipartFormDataContent();
					formData.Add(new StringContent(apikey), "apikey");
					formData.Add(new StringContent(data.Id.ToString()), "partnerid");
					formData.Add(new StringContent(data.StarPoint.ToString()), "starpoint");
					var res = await http.PostAsync($"{Settings.ServerUrl}/Main/ExcuteStarPoint", formData);
					if (!res.IsSuccessStatusCode)
						throw new Exception("잠시 후에 다시 시도해 주세요.");

					var resData = JsonConvert.DeserializeAnonymousType(await res.Content.ReadAsStringAsync(), new
					{
						Message = default(string),
						View04Item = default(MainPage_View04_Data),
					});

					if (!string.IsNullOrWhiteSpace(resData.Message))
						throw new Exception(resData.Message);

					if (resData.View04Item == null)
					{
						var item = this.PageData.Items.FirstOrDefault(x => (x as MainPage_ViewLabel_Data)?.Title == "실시간");
						if (item != null)
							this.PageData.Items.Remove(item);
						if (data != null)
							this.PageData.Items.Remove(data);
					}
					else
					{
						data.Id = resData.View04Item.Id;
						data.Title = resData.View04Item.Title;
						data.ProfileImages = resData.View04Item.ProfileImages;
						data.Nickname = resData.View04Item.Nickname;
						data.Age = resData.View04Item.Age;
						data.Job = resData.View04Item.Job;
						data.SelectedIndex = resData.View04Item.SelectedIndex;
						data.IsRoyal = resData.View04Item.IsRoyal;
						data.IsVIP = resData.View04Item.IsVIP;
						data.HasVoice = resData.View04Item.HasVoice;
						data.HasStarBadge = resData.View04Item.HasStarBadge;
						data.FirstMessage = resData.View04Item.FirstMessage;
						data.SecondMessage = resData.View04Item.SecondMessage;
						data.Preference_Priority = resData.View04Item.Preference_Priority;
						data.Range = resData.View04Item.Range;
						data.IsNowJoin = resData.View04Item.IsNowJoin;
						data.IsLive = resData.View04Item.IsLive;
						data.CharmingPoints = resData.View04Item.CharmingPoints;
						data.Interests = resData.View04Item.Interests;
						data.StarPoint = 0;
					}
				}
			}
			catch (Exception ex)
			{
				await this.DisplayToastAsync(ex.Message);
				data.StarPoint = 0;
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		public void StartHotStrawberry()
		{
			// HotStrawberry를 시작하는 메서드입니다.
			Task.Run(() =>
			{
				Dispatcher.BeginInvokeOnMainThread(async () =>
				{
					var view = flexLayout01.Children.FirstOrDefault(x => x.BindingContext is MainPage_View03_Data);
					if (view == null)
						return;

					this.View03_Data = view.BindingContext as MainPage_View03_Data;

					var roundView01 = view.FindByName<BoxView>("roundView01");
					var roundView02 = view.FindByName<BoxView>("roundView02");

					this.View03_Data.IsAminRunning = true;
					while (this.View03_Data.IsAminRunning)
					{
						if (this.View03_Data.IsVisibleType2)
							this.View03_Data.IsAminRunning = false;

						this.View03_Data.UpdateData();
						roundView01.Opacity = 1.0d;
						roundView01.Scale = 1;
						_ = roundView01.ScaleTo(3, 2000);
						_ = roundView01.FadeTo(0, 2000);

						await Task.Delay(1000);

						this.View03_Data.UpdateData();
						roundView02.Opacity = 1.0d;
						roundView02.Scale = 1;
						_ = roundView02.ScaleTo(3, 2000);
						_ = roundView02.FadeTo(0, 2000);

						await Task.Delay(1000);
					}

					using (var http = new HttpClient())
					{
						var formData = new MultipartFormDataContent();
						formData.Add(new StringContent(await Settings.GetApiKey()), "apikey");
						var res = await http.PostAsync($"{Settings.ServerUrl}/Main/CheckHotStrawberry", formData);
						if (!res.IsSuccessStatusCode)
						{
							await this.DisplayToastAsync("잠시 후에 다시 시도해 주세요.");
							return;
						}

						var resData = JsonConvert.DeserializeAnonymousType(await res.Content.ReadAsStringAsync(), new
						{
							Message = default(string),
							ViewCount = default(int)
						});

						if (!string.IsNullOrWhiteSpace(resData.Message))
						{
							await this.DisplayToastAsync(resData.Message);
							return;
						}

						View03_Data.ViewCount = resData.ViewCount;
					}
				});
			});
		}

		public void StopHotStrawberry()
		{
			// HotStrawberry를 중지하는 메서드입니다.
			this.View03_Data.IsAminRunning = false;
		}

		public void MoveMenu(int menuIndex)
		{
			// 메뉴를 이동하는 메서드입니다.
			switch (menuIndex)
			{
				case 0:
					this.Menu00_Clicked(this, EventArgs.Empty);
					break;
				case 1:
					this.Menu01_Clicked(this, EventArgs.Empty);
					break;
				case 2:
					this.Menu02_Clicked(this, EventArgs.Empty);
					break;
				case 3:
					this.Menu03_Clicked(this, EventArgs.Empty);
					break;
				case 4:
					this.Menu04_Clicked(this, EventArgs.Empty);
					break;
				default:
					break;
			}
		}

		private async void PoomPoom_Clicked(object sender, EventArgs e)
		{
			// PoomPoom 버튼을 클릭했을 때의 이벤트 핸들러입니다.
			//HapticFeedback.Perform(HapticFeedbackType.LongPress);
			DependencyService.Get<IDeviceHelper>().Vibrate();

			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				var page = new AppealPage();
				await page.GetItems();
				await this.Navigation.PushAsync(page);
			}
			catch (Exception ex)
			{
				await this.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		private async void Near_Clicked(object sender, EventArgs e)
		{
			HapticFeedback.Perform(HapticFeedbackType.LongPress);

			var page = new NearPage();
			await page.ShowAsync();
		}

		private async void scrollView01_Scrolled(object sender, ScrolledEventArgs e)
		{
			// ScrollView가 스크롤될 때의 이벤트 핸들러입니다.
			var view = sender as ScrollView;

			var vHeight = view.Height;
			var cHeight = view.ContentSize.Height;
			var maxScroll = cHeight - vHeight;

			if (e.ScrollY + 100 > maxScroll)
			{
				lock (this.LockData)
				{
					if (this.LockData.IsLocked)
						return;
					this.LockData.IsLocked = true;
				}

				try
				{
					switch (this.PageData.MenuIndex)
					{
						case 0:
							this.PageData.Page++;
							await this.GetMenu00Items();
							break;
						case 1:
							await this.GetMenu01Items();
							break;
						default:
							break;
					}
				}
				catch (Exception ex)
				{
					await this.DisplayToastAsync(ex.Message);
				}
				finally
				{
					this.LockData.IsLocked = false;
				}
			}
		}

		private async void Setting_Clicked(object sender, EventArgs e)
		{
			HapticFeedback.Perform(HapticFeedbackType.LongPress);

			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				var page = new SettingPage();
				await page.ShowPageAsync();
			}
			catch (Exception ex)
			{
				while (ex.InnerException != null)
					ex = ex.InnerException;

				await this.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		private async void Noti_Clicked(object sender, EventArgs e)
		{
			HapticFeedback.Perform(HapticFeedbackType.LongPress);

			lock (this.LockData)
			{
				if (this.LockData.IsLocked)
					return;
				this.LockData.IsLocked = true;
			}

			try
			{
				var page = new NotificationPage();
				await page.ShowPageAsync();
			}
			catch (Exception ex)
			{
				while (ex.InnerException != null)
					ex = ex.InnerException;

				await this.DisplayToastAsync(ex.Message);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		private async void RefreshView_Refreshing(object sender, EventArgs e)
		{
			// 새로고침 뷰가 새로고침될 때의 이벤트 핸들러입니다.
			try
			{
				lock (this.LockData)
				{
					if (this.LockData.IsLocked)
						return;
					this.LockData.IsLocked = true;
				}

				this.PageData.Page = 0;
				this.PageData.Items.Clear();

				switch (this.PageData.MenuIndex)
				{
					case 0:
						this.PageData.Page = 0;
						this.PageData.Items.Clear();
						this.scrollView01.BackgroundColor = Xamarin.Forms.Color.Black;
						await this.GetMenu00Items();
						break;
					case 1:
						this.PageData.Page = 0;
						this.PageData.Items.Clear();
						this.scrollView01.BackgroundColor = Xamarin.Forms.Color.White;
						await this.GetMenu01Items();
						break;
					case 2:
						this.PageData.Page = 0;
						this.PageData.Items.Clear();
						this.scrollView01.BackgroundColor = Xamarin.Forms.Color.White;
						await this.GetMenu02Items();
						break;
					case 3:
						this.PageData.Page = 0;
						this.PageData.Items.Clear();
						this.scrollView01.BackgroundColor = Xamarin.Forms.Color.White;
						this.PageData.Items.Add(new MainPage_View_LoveFortune_Data());
						break;
					case 4:
						this.PageData.Page = 0;
						this.PageData.Items.Clear();
						this.scrollView01.BackgroundColor = Xamarin.Forms.Color.White;
						await this.GetMenu04Items();
						break;
					default:
						break;
				}
			}
			catch (Exception ex)
			{
				while (ex.InnerException != null)
					ex = ex.InnerException;

				await this.DisplayToastAsync(ex.Message);
			}
			finally
			{
				var view = sender as RefreshView;
				view.IsRefreshing = false;
				this.LockData.IsLocked = false;
			}
		}

	}
}