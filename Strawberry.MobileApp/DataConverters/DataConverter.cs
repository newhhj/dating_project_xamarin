using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.DataConverters
{
    public class DataConverter : IValueConverter, IMultiValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "Menu0IconSource":
                {
                    return (int)value == 0 ? "icon_menu0_on" : "icon_menu0_off";
                }
                case "Menu1IconSource":
                {
                    return (int)value == 1 ? "icon_menu1_on" : "icon_menu1_off";
                }
                case "Menu2IconSource":
                {
                    return (int)value == 2 ? "icon_menu2_on" : "icon_menu2_off";
                }
                case "Menu3IconSource":
                {
                    return (int)value == 3 ? "icon_menu3_on" : "icon_menu3_off";
                }
                case "Menu4IconSource":
                {
                    return (int)value == 4 ? "icon_menu4_on" : "icon_menu4_off";
                }
                default:
                    break;
            }

            if (value is string && targetType == typeof(bool) && (string)parameter == "IsVisible")
            {
                return !string.IsNullOrWhiteSpace((string)value);
            }
            throw new NotImplementedException();
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                switch (parameter)
                {
                    case "CarouselViewIndicatorWidth":
                    {
                        var data1 = (string)values[0];
                        var data2 = (string)values[1];

                        return data1 == data2 ? 20 : 10;
                    }
                    default:
                        throw new NotImplementedException();
                }
            }
            catch
            {
                return null;
            }
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
