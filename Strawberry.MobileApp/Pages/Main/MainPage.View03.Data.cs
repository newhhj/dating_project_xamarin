using Strawberry.MobileApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Main
{
	public class MainPage_View03_Data : BindableObject
	{
		// 아이디 속성
		public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
		public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(MainPage_View03_Data));

		// 핫 딸기 시작 시간 속성
		public DateTime? HotStrawberryStartTime { get => (DateTime?)GetValue(HotStrawberryStartTimeProperty); set => SetValue(HotStrawberryStartTimeProperty, value); }
		public static readonly BindableProperty HotStrawberryStartTimeProperty = BindableProperty.Create(nameof(HotStrawberryStartTime), typeof(DateTime?), typeof(MainPage_View03_Data));

		// 조회 수 속성
		public int ViewCount { get => (int)GetValue(ViewCountProperty); set => SetValue(ViewCountProperty, value); }
		public static readonly BindableProperty ViewCountProperty = BindableProperty.Create(nameof(ViewCount), typeof(int), typeof(MainPage_View03_Data));

		// 실행 중인 백분율 계산 속성
		public int RunningPercent
		{
			get
			{
				if (!HotStrawberryStartTime.HasValue)
					return 0;

				var time = DateTime.Now - HotStrawberryStartTime.Value;
				var calc = 100d * time.TotalSeconds / 3600;
				var percent = Math.Max(1, Math.Min(100, (int)Math.Floor(calc)));
				return percent;
			}
		}

		// 핫 딸기 시작 시간 텍스트 속성
		public string HotStrawberryStartTimeText
		{
			get
			{
				if (!this.HotStrawberryStartTime.HasValue)
					return "00:00";

				var time = TimeSpan.FromHours(1) - (DateTime.Now - this.HotStrawberryStartTime.Value);
				if (time.TotalSeconds >= 0)
					return $"{time.Minutes:00}:{time.Seconds:00}";
				else
					return "00:00";
			}
		}

		// 타입 0 가시성 속성
		public bool IsVisibleType0
		{
			get
			{
				return !this.HotStrawberryStartTime.HasValue;
			}
		}

		// 타입 1 가시성 속성
		public bool IsVisibleType1
		{
			get
			{
				if (this.HotStrawberryStartTime.HasValue)
				{
					if ((DateTime.Now - this.HotStrawberryStartTime.Value).TotalMinutes <= 60)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
		}

		// 타입 2 가시성 속성
		public bool IsVisibleType2
		{
			get
			{
				if (this.HotStrawberryStartTime.HasValue)
				{
					if ((DateTime.Now - this.HotStrawberryStartTime.Value).TotalMinutes > 60)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
		}

		// 애니메이션 실행 중인지 여부 속성
		public bool IsAminRunning { get; set; }

		// 속성 변경 이벤트 발생 시 호출되는 메서드
		protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			switch (propertyName)
			{
				case nameof(HotStrawberryStartTime):
					base.OnPropertyChanged(nameof(IsVisibleType0));
					base.OnPropertyChanged(nameof(IsVisibleType1));
					base.OnPropertyChanged(nameof(IsVisibleType2));
					break;
				default:
					break;
			}

			base.OnPropertyChanged(propertyName);
		}

		// 데이터 업데이트 메서드
		public void UpdateData()
		{
			base.OnPropertyChanged(nameof(HotStrawberryStartTime));
			base.OnPropertyChanged(nameof(RunningPercent));
			base.OnPropertyChanged(nameof(HotStrawberryStartTimeText));
			base.OnPropertyChanged(nameof(IsVisibleType0));
			base.OnPropertyChanged(nameof(IsVisibleType1));
			base.OnPropertyChanged(nameof(IsVisibleType2));
		}
	}
}
