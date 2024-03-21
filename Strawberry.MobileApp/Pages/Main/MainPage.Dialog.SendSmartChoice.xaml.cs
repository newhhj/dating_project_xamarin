using Rg.Plugins.Popup.Pages;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using Entry = Xamarin.Forms.Entry;
using Rg.Plugins.Popup.Extensions;

namespace Strawberry.MobileApp.Pages.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage_Dialog_SendSmartChoice : PopupPage
	{
		// 닉네임을 바인딩하기 위한 속성
		public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
		public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(MainPage_Dialog_SendSmartChoice));

		// 섬네일을 바인딩하기 위한 속성
		public string Thumbnail { get => (string)GetValue(ThumbnailProperty); set => SetValue(ThumbnailProperty, value); }
		public static readonly BindableProperty ThumbnailProperty = BindableProperty.Create(nameof(Thumbnail), typeof(string), typeof(MainPage_Dialog_SendSmartChoice));

		// 메시지를 바인딩하기 위한 속성
		public string Message { get => (string)GetValue(MessageProperty); set => SetValue(MessageProperty, value); }
		public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(MainPage_Dialog_SendSmartChoice));

		// 작업 완료를 알리기 위한 TaskCompletionSource
		public TaskCompletionSource<string> TaskCompletionSource { get; set; }

		public MainPage_Dialog_SendSmartChoice(string nickname, string thumbnail)
		{
			InitializeComponent();
			this.TaskCompletionSource = new TaskCompletionSource<string>();
			this.Nickname = nickname;
			this.Thumbnail = thumbnail;
		}

		// SKCanvasView의 PaintSurface 이벤트 핸들러
		private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
		{
			var canvas = e.Surface.Canvas;
			canvas.Clear();

			var imageSource = (StreamImageSource)ImageSource.FromResource("Strawberry.MobileApp.Images.img_msgbox_sendsmartchoice.png", this.GetType().Assembly);
			var stream = imageSource.Stream(CancellationToken.None).Result;
			var bitmap = SKBitmap.Decode(stream);
			var bitmap2 = new SKBitmap(bitmap.Width * e.Info.Height / bitmap.Height, e.Info.Height);
			var canvas2 = new SKCanvas(bitmap2);
			canvas2.DrawBitmap(bitmap, bitmap2.Info.Rect);
			var scale = (int)(bitmap2.Height * 23d / 55d);

			canvas.DrawBitmapNinePatch(bitmap2, new SKRectI(scale, scale, bitmap2.Width - scale, bitmap2.Height - scale), e.Info.Rect);
		}

		// Entry가 포커스를 받았을 때 호출되는 이벤트 핸들러
		private async void Entry_Focused(object sender, FocusEventArgs e)
		{
			var entry = sender as Entry;
			var text = entry.Text;
			await Task.Delay(300);
			entry.Text = $"{text}.";
			await Task.Delay(1);
			entry.Text = text;
		}

		// Entry가 포커스를 잃었을 때 호출되는 이벤트 핸들러
		private async void Entry_Unfocused(object sender, FocusEventArgs e)
		{
			var entry = sender as Entry;
			var text = entry.Text;
			await Task.Delay(300);
			entry.Text = $"{text}.";
			await Task.Delay(1);
			entry.Text = text;
		}

		// 하드웨어 Back 버튼을 눌렀을 때 호출되는 메서드
		protected override bool OnBackButtonPressed()
		{
			var result = base.OnBackButtonPressed();
			this.TaskCompletionSource.SetResult(null);
			return result;
		}

		// 배경을 클릭했을 때 호출되는 메서드
		protected override bool OnBackgroundClicked()
		{
			var result = base.OnBackgroundClicked();
			this.TaskCompletionSource.SetResult(null);
			return result;
		}

		// "보내기" 버튼을 클릭했을 때 호출되는 이벤트 핸들러
		private void Send_Clicked(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(this.Message))
				return;

			this.Navigation.PopPopupAsync();
			this.TaskCompletionSource.SetResult(this.Message.Trim());
		}
	}
}
