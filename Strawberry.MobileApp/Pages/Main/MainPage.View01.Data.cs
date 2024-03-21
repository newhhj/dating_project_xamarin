using Rg.Plugins.Popup.Extensions;
using Strawberry.MobileApp.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Main
{
	public class MainPage_View01_Data : BindableObject
	{
		// 데이터 바인딩을 위한 속성들
		public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
		public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(MainPage_View01_Data));

		public string Title { get => (string)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }
		public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(MainPage_View01_Data));

		public string[] Thumbails { get => (string[])GetValue(ThumbailsProperty); set => SetValue(ThumbailsProperty, value); }
		public static readonly BindableProperty ThumbailsProperty = BindableProperty.Create(nameof(Thumbails), typeof(string[]), typeof(MainPage_View01_Data));

		public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
		public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(MainPage_View01_Data));

		public int Age { get => (int)GetValue(AgeProperty); set => SetValue(AgeProperty, value); }
		public static readonly BindableProperty AgeProperty = BindableProperty.Create(nameof(Age), typeof(int), typeof(MainPage_View01_Data));

		public string Job { get => (string)GetValue(JobProperty); set => SetValue(JobProperty, value); }
		public static readonly BindableProperty JobProperty = BindableProperty.Create(nameof(Job), typeof(string), typeof(MainPage_View01_Data));

		public int SelectedIndex { get => (int)GetValue(SelectedIndexProperty); set => SetValue(SelectedIndexProperty, value); }
		public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(MainPage_View01_Data));

		public bool IsRoyal { get => (bool)GetValue(IsRoyalProperty); set => SetValue(IsRoyalProperty, value); }
		public static readonly BindableProperty IsRoyalProperty = BindableProperty.Create(nameof(IsRoyal), typeof(bool), typeof(MainPage_View01_Data));

		public bool IsVIP { get => (bool)GetValue(IsVIPProperty); set => SetValue(IsVIPProperty, value); }
		public static readonly BindableProperty IsVIPProperty = BindableProperty.Create(nameof(IsVIP), typeof(bool), typeof(MainPage_View01_Data));

		public bool HasVoice { get => (bool)GetValue(HasVoiceProperty); set => SetValue(HasVoiceProperty, value); }
		public static readonly BindableProperty HasVoiceProperty = BindableProperty.Create(nameof(HasVoice), typeof(bool), typeof(MainPage_View01_Data));

		public bool HasStarBadge { get => (bool)GetValue(HasStarBadgeProperty); set => SetValue(HasStarBadgeProperty, value); }
		public static readonly BindableProperty HasStarBadgeProperty = BindableProperty.Create(nameof(HasStarBadge), typeof(bool), typeof(MainPage_View01_Data));

		public string FirstMessage { get => (string)GetValue(FirstMessageProperty); set => SetValue(FirstMessageProperty, value); }
		public static readonly BindableProperty FirstMessageProperty = BindableProperty.Create(nameof(FirstMessage), typeof(string), typeof(MainPage_View01_Data));

		public string SecondMessage { get => (string)GetValue(SecondMessageProperty); set => SetValue(SecondMessageProperty, value); }
		public static readonly BindableProperty SecondMessageProperty = BindableProperty.Create(nameof(SecondMessage), typeof(string), typeof(MainPage_View01_Data));

		public PriorityTypes Preference_Priority { get => (PriorityTypes)GetValue(Preference_PriorityProperty); set => SetValue(Preference_PriorityProperty, value); }
		public static readonly BindableProperty Preference_PriorityProperty = BindableProperty.Create(nameof(Preference_Priority), typeof(PriorityTypes), typeof(MainPage_View01_Data));

		public int Range { get => (int)GetValue(RangeProperty); set => SetValue(RangeProperty, value); }
		public static readonly BindableProperty RangeProperty = BindableProperty.Create(nameof(Range), typeof(int), typeof(MainPage_View01_Data));

		public bool IsNowJoin { get => (bool)GetValue(IsNowJoinProperty); set => SetValue(IsNowJoinProperty, value); }
		public static readonly BindableProperty IsNowJoinProperty = BindableProperty.Create(nameof(IsNowJoin), typeof(bool), typeof(MainPage_View01_Data));

		public bool IsLive { get => (bool)GetValue(IsLiveProperty); set => SetValue(IsLiveProperty, value); }
		public static readonly BindableProperty IsLiveProperty = BindableProperty.Create(nameof(IsLive), typeof(bool), typeof(MainPage_View01_Data));

		public string[] CharmingPoints { get => (string[])GetValue(CharmingPointsProperty); set => SetValue(CharmingPointsProperty, value); }
		public static readonly BindableProperty CharmingPointsProperty = BindableProperty.Create(nameof(CharmingPoints), typeof(string[]), typeof(MainPage_View01_Data));

		public string[] Interests { get => (string[])GetValue(InterestsProperty); set => SetValue(InterestsProperty, value); }
		public static readonly BindableProperty InterestsProperty = BindableProperty.Create(nameof(Interests), typeof(string[]), typeof(MainPage_View01_Data));

		public ICommand NotShowMemberCommand { get; private set; }
		public ICommand ChoiceCommand { get; set; }
		public ICommand SmartChoiceCommand { get; set; }

		// UI 관련 속성들
		public bool IsVisibleTitle { get => !string.IsNullOrWhiteSpace(Title); }
		public bool IsVisibleView0 { get => this.SelectedIndex == 0; }
		public bool IsVisibleView1 { get => this.SelectedIndex == 1; }
		public bool IsVisibleView2 { get => this.SelectedIndex == 2; }
		public bool IsVisibleView3 { get => this.SelectedIndex == 3; }
		public bool IsVisibleFreeChoice { get => App.Instance.Member.FreeChoiceCount == 0; }

		public bool IsDeleted { get; set; } = false;

		public MainPage_View01_Data()
		{
			// 커맨드 초기화
			this.NotShowMemberCommand = new Command(NotShowMember_Action);
			this.ChoiceCommand = new Command(Choice_Action);
			this.SmartChoiceCommand = new Command(SmartChoice_Action);
		}

		private void NotShowMember_Action(object obj)
		{
			// 회원 숨김 기능 실행
			var page = (MainPage)App.Instance.MainPage.Navigation.NavigationStack
				.FirstOrDefault(x => x is MainPage);
			page?.ExcuteNotShowMember(this);
		}

		private void Choice_Action(object obj)
		{
			// 회원 선택 기능 실행
			var page = (MainPage)App.Instance.MainPage.Navigation.NavigationStack
				.FirstOrDefault(x => x is MainPage);
			page?.ExcuteChoice(this);
		}

		private void SmartChoice_Action(object obj)
		{
			// 스마트 선택 기능 실행
			var page = (MainPage)App.Instance.MainPage.Navigation.NavigationStack
				.FirstOrDefault(x => x is MainPage);
			page?.ExcuteSmartChoice(this);
		}

		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			// 속성 값 변경 시 호출되는 이벤트 핸들러
			// UI 관련 속성에 대한 변경 사항을 처리
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

			base.OnPropertyChanged(propertyName);
		}
	}
}
