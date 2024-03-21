using SkiaSharp;
using Strawberry.MobileApp.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Main
{
	public class MainPage_View14_Data : BindableObject
	{
		// 프로필 이미지 속성
		public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
		public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(MainPage_View14_Data));

		// 프로필 이미지 소스 속성
		public ImageSource ProfileImageSource { get => (ImageSource)GetValue(ProfileImageSourceProperty); set => SetValue(ProfileImageSourceProperty, value); }
		public static readonly BindableProperty ProfileImageSourceProperty = BindableProperty.Create(nameof(ProfileImageSource), typeof(ImageSource), typeof(MainPage_View14_Data));

		// 로열 회원 여부 속성
		public bool IsRoyal { get => (bool)GetValue(IsRoyalProperty); set => SetValue(IsRoyalProperty, value); }
		public static readonly BindableProperty IsRoyalProperty = BindableProperty.Create(nameof(IsRoyal), typeof(bool), typeof(MainPage_View14_Data));

		// 닉네임 속성
		public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
		public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(MainPage_View14_Data));

		// 나이 속성
		public int Age { get => (int)GetValue(AgeProperty); set => SetValue(AgeProperty, value); }
		public static readonly BindableProperty AgeProperty = BindableProperty.Create(nameof(Age), typeof(int), typeof(MainPage_View14_Data));

		// 레벨 유형 속성
		public LevelTypes LevelType { get { return (LevelTypes)GetValue(LevelTypeProperty); } set { SetValue(LevelTypeProperty, value); } }
		public static readonly BindableProperty LevelTypeProperty = BindableProperty.Create(nameof(LevelType), typeof(LevelTypes), typeof(MainPage_View14_Data));

		// 레벨 유형 텍스트 속성
		public string LevelTypeText { get { return (string)GetValue(LevelTypeTextProperty); } set { SetValue(LevelTypeTextProperty, value); } }
		public static readonly BindableProperty LevelTypeTextProperty = BindableProperty.Create(nameof(LevelTypeText), typeof(string), typeof(MainPage_View14_Data), "실버");

		// VIP 여부 속성
		public bool IsVIP { get => (bool)GetValue(IsVIPProperty); set => SetValue(IsVIPProperty, value); }
		public static readonly BindableProperty IsVIPProperty = BindableProperty.Create(nameof(IsVIP), typeof(bool), typeof(MainPage_View14_Data));

		// 10성 여부 속성
		public bool Is10Star { get => (bool)GetValue(Is10StarProperty); set => SetValue(Is10StarProperty, value); }
		public static readonly BindableProperty Is10StarProperty = BindableProperty.Create(nameof(Is10Star), typeof(bool), typeof(MainPage_View14_Data));

		// 직업 속성
		public string Job { get => (string)GetValue(JobProperty); set => SetValue(JobProperty, value); }
		public static readonly BindableProperty JobProperty = BindableProperty.Create(nameof(Job), typeof(string), typeof(MainPage_View14_Data));

		// 스텝1 확인 여부 속성
		public bool IsConfirmStep1 { get => (bool)GetValue(IsConfirmStep1Property); set => SetValue(IsConfirmStep1Property, value); }
		public static readonly BindableProperty IsConfirmStep1Property = BindableProperty.Create(nameof(IsConfirmStep1), typeof(bool), typeof(MainPage_View14_Data));

		// 스텝2 확인 여부 속성
		public bool IsConfirmStep2 { get => (bool)GetValue(IsConfirmStep2Property); set => SetValue(IsConfirmStep2Property, value); }
		public static readonly BindableProperty IsConfirmStep2Property = BindableProperty.Create(nameof(IsConfirmStep2), typeof(bool), typeof(MainPage_View14_Data));

		// 스텝3 확인 여부 속성
		public bool IsConfirmStep3 { get => (bool)GetValue(IsConfirmStep3Property); set => SetValue(IsConfirmStep3Property, value); }
		public static readonly BindableProperty IsConfirmStep3Property = BindableProperty.Create(nameof(IsConfirmStep3), typeof(bool), typeof(MainPage_View14_Data));

		// 스텝4 확인 여부 속성
		public bool IsConfirmStep4 { get => (bool)GetValue(IsConfirmStep4Property); set => SetValue(IsConfirmStep4Property, value); }
		public static readonly BindableProperty IsConfirmStep4Property = BindableProperty.Create(nameof(IsConfirmStep4), typeof(bool), typeof(MainPage_View14_Data));

		// 포인트 속성
		public int Point { get => (int)GetValue(PointProperty); set => SetValue(PointProperty, value); }
		public static readonly BindableProperty PointProperty = BindableProperty.Create(nameof(Point), typeof(int), typeof(MainPage_View14_Data));

		// 광고 ID 속성
		public int ADId { get => (int)GetValue(ADIdProperty); set => SetValue(ADIdProperty, value); }
		public static readonly BindableProperty ADIdProperty = BindableProperty.Create(nameof(ADId), typeof(int), typeof(MainPage_View14_Data));

		// 광고 이미지 URL 속성
		public string ADImageUrl { get => (string)GetValue(ADImageUrlProperty); set => SetValue(ADImageUrlProperty, value); }
		public static readonly BindableProperty ADImageUrlProperty = BindableProperty.Create(nameof(ADImageUrl), typeof(string), typeof(MainPage_View14_Data));

		// 광고 링크 속성
		public string ADLink { get => (string)GetValue(ADLinkProperty); set => SetValue(ADLinkProperty, value); }
		public static readonly BindableProperty ADLinkProperty = BindableProperty.Create(nameof(ADLink), typeof(string), typeof(MainPage_View14_Data));

		// 광고 배너 표시 여부 속성
		public bool IsVisibleAdBanner { get => (bool)GetValue(IsVisibleAdBannerProperty); set => SetValue(IsVisibleAdBannerProperty, value); }
		public static readonly BindableProperty IsVisibleAdBannerProperty = BindableProperty.Create(nameof(IsVisibleAdBanner), typeof(bool), typeof(MainPage_View14_Data), false);

		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			switch (propertyName)
			{
				case nameof(ADImageUrl):
					this.IsVisibleAdBanner = !string.IsNullOrWhiteSpace(this.ADImageUrl);
					break;
				case nameof(LevelType):
					// 레벨 유형이 변경되면 LevelTypeText를 업데이트합니다.
					switch (this.LevelType)
					{
						case LevelTypes.Silver:
							this.LevelTypeText = "실버";
							break;
						case LevelTypes.Gold:
							this.LevelTypeText = "골드";
							break;
						case LevelTypes.Platinum:
							this.LevelTypeText = "플래티넘";
							break;
						case LevelTypes.Diamond:
							this.LevelTypeText = "다이아몬드";
							break;
						default:
							break;
					}
					break;
				default:
					break;
			}

			base.OnPropertyChanged(propertyName);
		}

		private void SetProfileImageSource()
		{
			if (string.IsNullOrWhiteSpace(this.ProfileImage))
			{
				this.ProfileImageSource = null;
			}
			else
			{
				Task.Run(async () =>
				{
					using (var http = new HttpClient())
					{
						var buffer = await http.GetByteArrayAsync(this.ProfileImage);
					}
				});
			}
		}
	}
}
