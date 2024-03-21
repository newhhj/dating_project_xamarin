using Strawberry.MobileApp.DataModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Main
{
	public class MainPage_View04_Data : BindableObject
	{
		// ID 속성
		public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
		public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(MainPage_View04_Data));

		// 제목 속성
		public string Title { get => (string)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }
		public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(MainPage_View04_Data));

		// 프로필 이미지 배열 속성
		public string[] ProfileImages { get => (string[])GetValue(ProfileImagesProperty); set => SetValue(ProfileImagesProperty, value); }
		public static readonly BindableProperty ProfileImagesProperty = BindableProperty.Create(nameof(ProfileImages), typeof(string[]), typeof(MainPage_View04_Data));

		// 닉네임 속성
		public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
		public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(MainPage_View04_Data));

		// 나이 속성
		public int Age { get => (int)GetValue(AgeProperty); set => SetValue(AgeProperty, value); }
		public static readonly BindableProperty AgeProperty = BindableProperty.Create(nameof(Age), typeof(int), typeof(MainPage_View04_Data));

		// 직업 속성
		public string Job { get => (string)GetValue(JobProperty); set => SetValue(JobProperty, value); }
		public static readonly BindableProperty JobProperty = BindableProperty.Create(nameof(Job), typeof(string), typeof(MainPage_View04_Data));

		// 선택된 인덱스 속성
		public int SelectedIndex { get => (int)GetValue(SelectedIndexProperty); set => SetValue(SelectedIndexProperty, value); }
		public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(MainPage_View04_Data));

		// 로열 회원 여부 속성
		public bool IsRoyal { get => (bool)GetValue(IsRoyalProperty); set => SetValue(IsRoyalProperty, value); }
		public static readonly BindableProperty IsRoyalProperty = BindableProperty.Create(nameof(IsRoyal), typeof(bool), typeof(MainPage_View04_Data));

		// VIP 회원 여부 속성
		public bool IsVIP { get => (bool)GetValue(IsVIPProperty); set => SetValue(IsVIPProperty, value); }
		public static readonly BindableProperty IsVIPProperty = BindableProperty.Create(nameof(IsVIP), typeof(bool), typeof(MainPage_View04_Data));

		// 보이스 속성
		public bool HasVoice { get => (bool)GetValue(HasVoiceProperty); set => SetValue(HasVoiceProperty, value); }
		public static readonly BindableProperty HasVoiceProperty = BindableProperty.Create(nameof(HasVoice), typeof(bool), typeof(MainPage_View04_Data));

		// 별표 뱃지 속성
		public bool HasStarBadge { get => (bool)GetValue(HasStarBadgeProperty); set => SetValue(HasStarBadgeProperty, value); }
		public static readonly BindableProperty HasStarBadgeProperty = BindableProperty.Create(nameof(HasStarBadge), typeof(bool), typeof(MainPage_View04_Data));

		// 첫 번째 메시지 속성
		public string FirstMessage { get => (string)GetValue(FirstMessageProperty); set => SetValue(FirstMessageProperty, value); }
		public static readonly BindableProperty FirstMessageProperty = BindableProperty.Create(nameof(FirstMessage), typeof(string), typeof(MainPage_View04_Data));

		// 두 번째 메시지 속성
		public string SecondMessage { get => (string)GetValue(SecondMessageProperty); set => SetValue(SecondMessageProperty, value); }
		public static readonly BindableProperty SecondMessageProperty = BindableProperty.Create(nameof(SecondMessage), typeof(string), typeof(MainPage_View04_Data));

		// 우선순위 속성
		public PriorityTypes Preference_Priority { get => (PriorityTypes)GetValue(Preference_PriorityProperty); set => SetValue(Preference_PriorityProperty, value); }
		public static readonly BindableProperty Preference_PriorityProperty = BindableProperty.Create(nameof(Preference_Priority), typeof(PriorityTypes), typeof(MainPage_View04_Data));

		// 범위 속성
		public int Range { get => (int)GetValue(RangeProperty); set => SetValue(RangeProperty, value); }
		public static readonly BindableProperty RangeProperty = BindableProperty.Create(nameof(Range), typeof(int), typeof(MainPage_View04_Data));

		// 현재 참여 중 여부 속성
		public bool IsNowJoin { get => (bool)GetValue(IsNowJoinProperty); set => SetValue(IsNowJoinProperty, value); }
		public static readonly BindableProperty IsNowJoinProperty = BindableProperty.Create(nameof(IsNowJoin), typeof(bool), typeof(MainPage_View04_Data));

		// 라이브 중 여부 속성
		public bool IsLive { get => (bool)GetValue(IsLiveProperty); set => SetValue(IsLiveProperty, value); }
		public static readonly BindableProperty IsLiveProperty = BindableProperty.Create(nameof(IsLive), typeof(bool), typeof(MainPage_View04_Data));

		// 매력 포인트 배열 속성
		public string[] CharmingPoints { get => (string[])GetValue(CharmingPointsProperty); set => SetValue(CharmingPointsProperty, value); }
		public static readonly BindableProperty CharmingPointsProperty = BindableProperty.Create(nameof(CharmingPoints), typeof(string[]), typeof(MainPage_View04_Data));

		// 관심사 배열 속성
		public string[] Interests { get => (string[])GetValue(InterestsProperty); set => SetValue(InterestsProperty, value); }
		public static readonly BindableProperty InterestsProperty = BindableProperty.Create(nameof(Interests), typeof(string[]), typeof(MainPage_View04_Data));

		// 별점 속성
		public int StarPoint { get => (int)GetValue(StarPointProperty); set => SetValue(StarPointProperty, value); }
		public static readonly BindableProperty StarPointProperty = BindableProperty.Create(nameof(StarPoint), typeof(int), typeof(MainPage_View04_Data));

		// 별점 02 아이콘 속성
		public string StarPoint02_Icon { get => (string)GetValue(StarPoint02_IconProperty); set => SetValue(StarPoint02_IconProperty, value); }
		public static readonly BindableProperty StarPoint02_IconProperty = BindableProperty.Create(nameof(StarPoint02_Icon), typeof(string), typeof(MainPage_View04_Data), "icon_star_off");

		// 별점 04 아이콘 속성
		public string StarPoint04_Icon { get => (string)GetValue(StarPoint04_IconProperty); set => SetValue(StarPoint04_IconProperty, value); }
		public static readonly BindableProperty StarPoint04_IconProperty = BindableProperty.Create(nameof(StarPoint04_Icon), typeof(string), typeof(MainPage_View04_Data), "icon_star_off");

		// 별점 06 아이콘 속성
		public string StarPoint06_Icon { get => (string)GetValue(StarPoint06_IconProperty); set => SetValue(StarPoint06_IconProperty, value); }
		public static readonly BindableProperty StarPoint06_IconProperty = BindableProperty.Create(nameof(StarPoint06_Icon), typeof(string), typeof(MainPage_View04_Data), "icon_star_off");

		// 별점 08 아이콘 속성
		public string StarPoint08_Icon { get => (string)GetValue(StarPoint08_IconProperty); set => SetValue(StarPoint08_IconProperty, value); }
		public static readonly BindableProperty StarPoint08_IconProperty = BindableProperty.Create(nameof(StarPoint08_Icon), typeof(string), typeof(MainPage_View04_Data), "icon_star_off");

		// 별점 10 아이콘 속성
		public string StarPoint10_Icon { get => (string)GetValue(StarPoint10_IconProperty); set => SetValue(StarPoint10_IconProperty, value); }
		public static readonly BindableProperty StarPoint10_IconProperty = BindableProperty.Create(nameof(StarPoint10_Icon), typeof(string), typeof(MainPage_View04_Data), "icon_star_off");

		// 제목 표시 여부 속성
		public bool IsVisibleTitle { get => !string.IsNullOrWhiteSpace(Title); }

		// View 0 표시 여부 속성
		public bool IsVisibleView0 { get => this.SelectedIndex == 0; }

		// View 1 표시 여부 속성
		public bool IsVisibleView1 { get => this.SelectedIndex == 1; }

		// View 2 표시 여부 속성
		public bool IsVisibleView2 { get => this.SelectedIndex == 2; }

		// View 3 표시 여부 속성
		public bool IsVisibleView3 { get => this.SelectedIndex == 3; }

		// 자유 선택 여부 표시 속성
		public bool IsVisibleFreeChoice { get => App.Instance.Member.FreeChoiceCount == 0; }

		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);

			switch (propertyName)
			{
				case nameof(Title):
					base.OnPropertyChanged(nameof(IsVisibleTitle));
					break;
				case nameof(SelectedIndex):
					base.OnPropertyChanged(nameof(IsVisibleView0));
					base.OnPropertyChanged(nameof(IsVisibleView1));
					base.OnPropertyChanged(nameof(IsVisibleView2));
					base.OnPropertyChanged(nameof(IsVisibleView3));
					break;
				default:
					break;
			}
		}
	}
}
