using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Main
{
	public class MainPage_View02_Data : BindableObject
	{
		// Id 속성
		public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
		public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(MainPage_View02_Data));

		// ProfileImage 속성
		public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
		public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(MainPage_View02_Data));

		// Nickname 속성
		public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
		public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(MainPage_View02_Data));

		// Age 속성
		public int Age { get => (int)GetValue(AgeProperty); set => SetValue(AgeProperty, value); }
		public static readonly BindableProperty AgeProperty = BindableProperty.Create(nameof(Age), typeof(int), typeof(MainPage_View02_Data));

		// Job 속성
		public string Job { get => (string)GetValue(JobProperty); set => SetValue(JobProperty, value); }
		public static readonly BindableProperty JobProperty = BindableProperty.Create(nameof(Job), typeof(string), typeof(MainPage_View02_Data));

		// Range 속성
		public int Range { get => (int)GetValue(RangeProperty); set => SetValue(RangeProperty, value); }
		public static readonly BindableProperty RangeProperty = BindableProperty.Create(nameof(Range), typeof(int), typeof(MainPage_View02_Data));

		// HasVoice 속성
		public bool HasVoice { get => (bool)GetValue(HasVoiceProperty); set => SetValue(HasVoiceProperty, value); }
		public static readonly BindableProperty HasVoiceProperty = BindableProperty.Create(nameof(HasVoice), typeof(bool), typeof(MainPage_View02_Data));

		// IsNowJoin 속성
		public bool IsNowJoin { get => (bool)GetValue(IsNowJoinProperty); set => SetValue(IsNowJoinProperty, value); }
		public static readonly BindableProperty IsNowJoinProperty = BindableProperty.Create(nameof(IsNowJoin), typeof(bool), typeof(MainPage_View02_Data));

		// IsVIP 속성
		public bool IsVIP { get => (bool)GetValue(IsVIPProperty); set => SetValue(IsVIPProperty, value); }
		public static readonly BindableProperty IsVIPProperty = BindableProperty.Create(nameof(IsVIP), typeof(bool), typeof(MainPage_View01_Data));

		// ShowProfileCommand 속성
		public ICommand ShowProfileCommand { get; set; }

		public MainPage_View02_Data()
		{
			// ShowProfileCommand의 생성자
			this.ShowProfileCommand = new Command(ShowProfileCommandAction);
		}

		// ShowProfileCommand 실행 시 동작하는 메소드
		public void ShowProfileCommandAction()
		{
			var page = (MainPage)App.Instance.MainPage.Navigation.NavigationStack
				.FirstOrDefault(x => x is MainPage);
			page?.ExcuteShowProfile(this);
		}
	}
}
