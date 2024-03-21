using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Main
{
	public class MainPage_ViewLabel_Data : BindableObject
	{
		// Title 속성은 라벨의 텍스트 값을 나타냅니다.
		public string Title { get => (string)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }
		public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(MainPage_ViewLabel_Data));

		// TextColor 속성은 라벨 텍스트의 색상을 나타냅니다.
		public Color TextColor { get => (Color)GetValue(TextColorProperty); set => SetValue(TextColorProperty, value); }
		public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MainPage_ViewLabel_Data), defaultValue: Color.Black);
	}
}
