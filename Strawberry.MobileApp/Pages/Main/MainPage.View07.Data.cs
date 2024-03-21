using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Main
{
	public class MainPage_View07_Data : BindableObject
	{
		// 아이디 속성
		public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
		public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(MainPage_View07_Data));

		// 멤버 아이디 속성
		public int MemberId { get => (int)GetValue(MemberIdProperty); set => SetValue(MemberIdProperty, value); }
		public static readonly BindableProperty MemberIdProperty = BindableProperty.Create(nameof(MemberId), typeof(int), typeof(MainPage_View07_Data));

		// 닉네임 속성
		public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
		public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(MainPage_View07_Data));

		// 프로필 이미지 속성
		public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
		public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(MainPage_View07_Data));

		// 나이 속성
		public int Age { get => (int)GetValue(AgeProperty); set => SetValue(AgeProperty, value); }
		public static readonly BindableProperty AgeProperty = BindableProperty.Create(nameof(Age), typeof(int), typeof(MainPage_View07_Data));

		// 직업 속성
		public string Job { get => (string)GetValue(JobProperty); set => SetValue(JobProperty, value); }
		public static readonly BindableProperty JobProperty = BindableProperty.Create(nameof(Job), typeof(string), typeof(MainPage_View07_Data));

		// 범위 속성
		public double Range { get => (double)GetValue(RangeProperty); set => SetValue(RangeProperty, value); }
		public static readonly BindableProperty RangeProperty = BindableProperty.Create(nameof(Range), typeof(double), typeof(MainPage_View07_Data));

		// 확인 여부 속성
		public bool IsConfirm { get => (bool)GetValue(IsConfirmProperty); set => SetValue(IsConfirmProperty, value); }
		public static readonly BindableProperty IsConfirmProperty = BindableProperty.Create(nameof(IsConfirm), typeof(bool), typeof(MainPage_View07_Data));

		// 메시지 속성
		public string Message { get => (string)GetValue(MessageProperty); set => SetValue(MessageProperty, value); }
		public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(MainPage_View07_Data));

		// 생성 시간 속성
		public DateTime CreateTime { get => (DateTime)GetValue(CreateTimeProperty); set => SetValue(CreateTimeProperty, value); }
		public static readonly BindableProperty CreateTimeProperty = BindableProperty.Create(nameof(CreateTime), typeof(DateTime), typeof(MainPage_View07_Data));

		// 메시지 가시성 속성
		public bool IsVisibleMessage { get => (bool)GetValue(IsVisibleMessageProperty); set => SetValue(IsVisibleMessageProperty, value); }
		public static readonly BindableProperty IsVisibleMessageProperty = BindableProperty.Create(nameof(IsVisibleMessage), typeof(bool), typeof(MainPage_View07_Data));

		// 확인 버튼 텍스트 속성
		public string ConfirmButtonText { get => (string)GetValue(ConfirmButtonTextProperty); set => SetValue(ConfirmButtonTextProperty, value); }
		public static readonly BindableProperty ConfirmButtonTextProperty = BindableProperty.Create(nameof(ConfirmButtonText), typeof(string), typeof(MainPage_View07_Data), "연결하기");

		// 건너뛰기 버튼 가시성 속성
		public bool IsVisiblePassButton { get => (bool)GetValue(IsVisiblePassButtonProperty); set => SetValue(IsVisiblePassButtonProperty, value); }
		public static readonly BindableProperty IsVisiblePassButtonProperty = BindableProperty.Create(nameof(IsVisiblePassButton), typeof(bool), typeof(MainPage_View07_Data), true);

		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);

			// 속성 변경에 따라 추가적인 동작 수행
			switch (propertyName)
			{
				case nameof(Message):
					{
						// 메시지 속성이 변경될 때 메시지 가시성 설정
						this.IsVisibleMessage = !string.IsNullOrWhiteSpace(this.Message);
						break;
					}
				case nameof(IsConfirm):
					{
						// 확인 여부 속성이 변경될 때 확인 버튼 텍스트와 건너뛰기 버튼 가시성 설정
						this.ConfirmButtonText = this.IsConfirm ? "채팅하기" : "연결하기";
						this.IsVisiblePassButton = !this.IsConfirm;
						break;
					}
				default:
					break;
			}
		}
	}
}
