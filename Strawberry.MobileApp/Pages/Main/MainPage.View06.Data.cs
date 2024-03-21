using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Main
{
	// Data model class for MainPage_View06
	public class MainPage_View06_Data : BindableObject
	{
		// Id property
		public int Id
		{
			get => (int)GetValue(IdProperty);
			set => SetValue(IdProperty, value);
		}
		public static readonly BindableProperty IdProperty = BindableProperty.Create(
			nameof(Id), typeof(int), typeof(MainPage_View06_Data));

		// ProfileImage property
		public string ProfileImage
		{
			get => (string)GetValue(ProfileImageProperty);
			set => SetValue(ProfileImageProperty, value);
		}
		public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(
			nameof(ProfileImage), typeof(string), typeof(MainPage_View06_Data));

		// Nickname property
		public string Nickname
		{
			get => (string)GetValue(NicknameProperty);
			set => SetValue(NicknameProperty, value);
		}
		public static readonly BindableProperty NicknameProperty = BindableProperty.Create(
			nameof(Nickname), typeof(string), typeof(MainPage_View06_Data));

		// Age property
		public int Age
		{
			get => (int)GetValue(AgeProperty);
			set => SetValue(AgeProperty, value);
		}
		public static readonly BindableProperty AgeProperty = BindableProperty.Create(
			nameof(Age), typeof(int), typeof(MainPage_View06_Data));
	}
}
