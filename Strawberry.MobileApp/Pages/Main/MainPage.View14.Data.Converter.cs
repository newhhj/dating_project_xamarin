using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Main
{
	public class MainPage_View14_Data_Converter : IValueConverter, IMultiValueConverter
	{
		// 단일 값 변환 메서드
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch (parameter)
			{
				case "IsFillStep01":
					return !((int)value >= 1);
				case "IsFillStep02":
					return !((int)value >= 2);
				case "IsFillStep03":
					return !((int)value >= 2);
				case "IsFillStep04":
					return !((int)value >= 4);
				case "ColorStep01":
					return (int)value >= 1 ? Color.FromHex("#4D9AFF") : Color.FromHex("#7A7A7A");
				case "ColorStep02":
					return (int)value >= 2 ? Color.FromHex("#4D9AFF") : Color.FromHex("#7A7A7A");
				case "ColorStep03":
					return (int)value >= 3 ? Color.FromHex("#4D9AFF") : Color.FromHex("#7A7A7A");
				case "ColorStep04":
					return (int)value >= 4 ? Color.FromHex("#4D9AFF") : Color.FromHex("#7A7A7A");
				default:
					break;
			}

			throw new NotImplementedException();
		}

		// 다중 값 변환 메서드
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (values == null)
				return null;

			switch (parameter)
			{
				case "IsFillStep01":
					return !(values.Count(x => x != null && (bool)x) >= 1);
				case "IsFillStep02":
					return !(values.Count(x => x != null && (bool)x) >= 2);
				case "IsFillStep03":
					return !(values.Count(x => x != null && (bool)x) >= 2);
				case "IsFillStep04":
					return !(values.Count(x => x != null && (bool)x) >= 4);
				case "IsVisibleSpliterStep02":
					return values.Count(x => x != null && (bool)x) >= 2;
				case "IsVisibleSpliterStep03":
					return values.Count(x => x != null && (bool)x) >= 3;
				case "IsVisibleSpliterStep04":
					return values.Count(x => x != null && (bool)x) >= 4;
				case "ColorStep01":
					return values.Count(x => x != null && (bool)x) >= 1 ? Color.FromHex("#4D9AFF") : Color.FromHex("#7A7A7A");
				case "ColorStep02":
					return values.Count(x => x != null && (bool)x) >= 2 ? Color.FromHex("#4D9AFF") : Color.FromHex("#7A7A7A");
				case "ColorStep03":
					return values.Count(x => x != null && (bool)x) >= 3 ? Color.FromHex("#4D9AFF") : Color.FromHex("#7A7A7A");
				case "ColorStep04":
					return values.Count(x => x != null && (bool)x) >= 4 ? Color.FromHex("#4D9AFF") : Color.FromHex("#7A7A7A");
				default:
					break;
			}

			throw new NotImplementedException();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
