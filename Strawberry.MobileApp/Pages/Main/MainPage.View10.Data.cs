using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Main
{
	public class MainPage_View10_Data : BindableObject
	{
		// 회원 정보 식별자
		public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
		public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(MainPage_View10_Data));

		// 파트너 정보 식별자
		public int PartnerId { get => (int)GetValue(PartnerIdProperty); set => SetValue(PartnerIdProperty, value); }
		public static readonly BindableProperty PartnerIdProperty = BindableProperty.Create(nameof(PartnerId), typeof(int), typeof(MainPage_View10_Data));

		// 닉네임
		public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
		public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(MainPage_View10_Data));

		// 프로필 이미지 경로
		public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
		public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(MainPage_View10_Data));

		// 나이
		public int Age { get => (int)GetValue(AgeProperty); set => SetValue(AgeProperty, value); }
		public static readonly BindableProperty AgeProperty = BindableProperty.Create(nameof(Age), typeof(int), typeof(MainPage_View10_Data));

		// 직업
		public string Job { get => (string)GetValue(JobProperty); set => SetValue(JobProperty, value); }
		public static readonly BindableProperty JobProperty = BindableProperty.Create(nameof(Job), typeof(string), typeof(MainPage_View10_Data));

		// 거리
		public double Range { get => (double)GetValue(RangeProperty); set => SetValue(RangeProperty, value); }
		public static readonly BindableProperty RangeProperty = BindableProperty.Create(nameof(Range), typeof(double), typeof(MainPage_View10_Data));

		// 생성 시간
		public DateTime CreateTime { get => (DateTime)GetValue(CreateTimeProperty); set => SetValue(CreateTimeProperty, value); }
		public static readonly BindableProperty CreateTimeProperty = BindableProperty.Create(nameof(CreateTime), typeof(DateTime), typeof(MainPage_View10_Data));
	}
}
