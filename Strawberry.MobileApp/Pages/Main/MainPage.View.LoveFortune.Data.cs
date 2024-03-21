using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Main
{
	public class MainPage_View_LoveFortune_Data : BindableObject
	{
		// 현재 단계를 바인딩하기 위한 속성
		public int Step { get => (int)GetValue(StepProperty); set => SetValue(StepProperty, value); }
		public static readonly BindableProperty StepProperty = BindableProperty.Create(nameof(Step), typeof(int), typeof(MainPage_View_LoveFortune_Data));

		// 파트너의 ID를 바인딩하기 위한 속성
		public int PartnerId { get => (int)GetValue(PartnerIdProperty); set => SetValue(PartnerIdProperty, value); }
		public static readonly BindableProperty PartnerIdProperty = BindableProperty.Create(nameof(PartnerId), typeof(int), typeof(MainPage_View_LoveFortune_Data));

		// 파트너의 프로필 이미지를 바인딩하기 위한 속성
		public ImageSource PartnerProfileImage { get => (ImageSource)GetValue(PartnerProfileImageProperty); set => SetValue(PartnerProfileImageProperty, value); }
		public static readonly BindableProperty PartnerProfileImageProperty = BindableProperty.Create(nameof(PartnerProfileImage), typeof(ImageSource), typeof(MainPage_View_LoveFortune_Data));

		// 메시지를 바인딩하기 위한 속성
		public string Message { get => (string)GetValue(MessageProperty); set => SetValue(MessageProperty, value); }
		public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(MainPage_View_LoveFortune_Data));

		// 뷰 01의 가시성을 결정하는 속성
		public bool View01Visible
		{
			get
			{
				return this.Step == 0 || this.Step == 1;
			}
		}

		// 뷰 02의 가시성을 결정하는 속성
		public bool View02Visible
		{
			get
			{
				return this.Step == 1;
			}
		}

		// 뷰 03의 가시성을 결정하는 속성
		public bool View03Visible
		{
			get
			{
				return this.Step == 2;
			}
		}

		// 터치 이미지의 소스를 결정하는 속성
		public string TouchImageSource
		{
			get
			{
				return this.Step == 0 ? "img_lovefortune_touch" : "img_lovefortune_touch02";
			}
		}

		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);

			switch (propertyName)
			{
				case nameof(this.Step):
					// Step 속성이 변경되면 View01Visible, View02Visible, View03Visible, TouchImageSource 속성도 변경됨을 알림
					base.OnPropertyChanged(nameof(this.View01Visible));
					base.OnPropertyChanged(nameof(this.View02Visible));
					base.OnPropertyChanged(nameof(this.View03Visible));
					base.OnPropertyChanged(nameof(this.TouchImageSource));
					break;
				default:
					break;
			}
		}
	}
}
