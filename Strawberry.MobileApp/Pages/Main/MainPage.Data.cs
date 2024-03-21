using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Main
{
	public class MainPage_Data : BindableObject
	{
		// 현재 메뉴 인덱스를 나타내는 속성
		public int MenuIndex { get => (int)GetValue(MenuIndexProperty); set => SetValue(MenuIndexProperty, value); }
		public static readonly BindableProperty MenuIndexProperty = BindableProperty.Create(nameof(MenuIndex), typeof(int), typeof(MainPage_Data));

		// 페이지를 나타내는 속성
		public int Page { get => (int)GetValue(PageProperty); set => SetValue(PageProperty, value); }
		public static readonly BindableProperty PageProperty = BindableProperty.Create(nameof(Page), typeof(int), typeof(MainPage_Data));

		// 항목 컬렉션을 나타내는 속성
		public ObservableCollection<object> Items { get => (ObservableCollection<object>)GetValue(ItemsProperty); set => SetValue(ItemsProperty, value); }
		public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<object>), typeof(MainPage_Data));

		// 알림 버튼의 가시성 여부를 나타내는 속성
		public bool IsVisibleNotiButton { get => (bool)GetValue(IsVisibleNotiButtonProperty); set => SetValue(IsVisibleNotiButtonProperty, value); }
		public static readonly BindableProperty IsVisibleNotiButtonProperty = BindableProperty.Create(nameof(IsVisibleNotiButton), typeof(bool), typeof(MainPage_Data), true);

		// 설정 버튼의 가시성 여부를 나타내는 속성
		public bool IsVisibleSettingButton { get => (bool)GetValue(IsVisibleSettingButtonProperty); set => SetValue(IsVisibleSettingButtonProperty, value); }
		public static readonly BindableProperty IsVisibleSettingButtonProperty = BindableProperty.Create(nameof(IsVisibleSettingButton), typeof(bool), typeof(MainPage_Data), false);

		// 생성자
		public MainPage_Data()
		{
			// Items 속성을 ObservableCollection<object>의 인스턴스로 초기화
			this.Items = new ObservableCollection<object>();
		}

		// 속성이 변경될 때 호출되는 메서드
		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);

			// MenuIndex 속성이 변경되었을 때 액션바 버튼의 가시성을 설정하는 메서드 호출
			switch (propertyName)
			{
				case nameof(this.MenuIndex):
					this.SetIsVisibleActionBarButton();
					break;
				default:
					break;
			}
		}

		// 액션바 버튼의 가시성을 설정하는 메서드
		private void SetIsVisibleActionBarButton()
		{
			this.IsVisibleNotiButton = this.MenuIndex != 4;
			this.IsVisibleSettingButton = this.MenuIndex == 4;
		}
	}
}
