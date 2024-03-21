using SkiaSharp;
using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Chatting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage_View07 : DataTemplate
	{
		private LockDataModel LockData { get; set; } = new LockDataModel();

		public MainPage_View07()
		{
			InitializeComponent();
		}

		// SKCanvasView의 PaintSurface 이벤트 핸들러
		private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
		{
			try
			{
				// 이미지 리소스 로드
				var resource = (StreamImageSource)ImageSource.FromResource("Strawberry.MobileApp.Images.img_msgbox_sendsmartchoice.png", this.GetType().Assembly);

				using (var stream = resource.Stream(CancellationToken.None).Result)
				using (var bitmap = SKBitmap.Decode(stream))
				using (var resizeBitmap = bitmap.Resize(e.Info.Rect.AspectFill(bitmap.Info.Size).Size, SKFilterQuality.High))
				{
					// 이미지를 그리기 위한 사각형 좌표 계산
					var rect = new SKRectI(
						resizeBitmap.Width * 120 / bitmap.Width,
						resizeBitmap.Height * 100 / bitmap.Height,
						resizeBitmap.Width * 2200 / bitmap.Width,
						resizeBitmap.Height * 120 / bitmap.Height);

					// Canvas를 지우고 이미지를 그림
					e.Surface.Canvas.Clear();
					e.Surface.Canvas.DrawBitmapNinePatch(resizeBitmap, rect, e.Info.Rect);
				}
			}
			catch (Exception ex)
			{
				while (ex.InnerException != null)
					ex = ex.InnerException;

				Console.WriteLine(ex);
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
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
				var data = view.BindingContext as MainPage_View07_Data;

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

		// 확인 버튼 클릭 이벤트 핸들러
		private async void Confirm_Clicked(object sender, EventArgs e)
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
				var data = view.BindingContext as MainPage_View07_Data;

				if (!data.IsConfirm)
				{
					using (var api = new ApiHelper())
					{
						await api.ExcuteChoiceConfirm(data.Id);
					}

					data.IsConfirm = true;
				}
				else
				{
					using (var api = new ApiHelper())
					{
						var result = await api.ExcuteCreateChattingRoom(
							data.MemberId,
							new
							{
								RoomId = default(int)
							});

						var page = new ChattingPage();
						await page.ShowPageAsync(result.RoomId);
					}
				}
			}
			catch (Exception ex)
			{
				while (ex.InnerException != null)
					ex = ex.InnerException;

				Console.WriteLine(ex);
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
			finally
			{
				this.LockData.IsLocked = false;
			}
		}

		// 패스 버튼 클릭 이벤트 핸들러
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
				var data = view.BindingContext as MainPage_View07_Data;

				using (var api = new ApiHelper())
				{
					await api.ExcuteChoicePass(data.Id);
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
