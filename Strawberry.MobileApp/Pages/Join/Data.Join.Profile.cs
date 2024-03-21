using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Join
{
    public class Data_Join_Profile : BindableObject, IValueConverter, IMultiValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "GenderText":
                {
                    if (value == null)
                        return value;
                    return (DataModels.GenderTypes)value == DataModels.GenderTypes.Male ? "남자" : "여자";
                }
                case "HasValueColor":
                {
                    if (value == null)
                        return Color.FromHex("#7A7A7A");
                    else
                        return Color.FromHex("#4A9CFF");
                }
                case "BirthTextColor":
                {
                    if (value == null)
                        return Color.FromHex("#7A7A7A");
                    else
                        return Color.FromHex("#4A9CFF");
                }
                case "TallText":
                {
                    var tall = (int?)value;
                    if (!tall.HasValue)
                        return null;
                    if (tall.Value <= 190)
                        return $"{tall.Value}cm";
                    else
                        return $"190cm 이상";
                }
                default:
                    return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "NextButtonColor":
                {
                    var returnValue = Color.FromHex("#4A9CFF");

                    if (values == null || values.Length == 0)
                        returnValue = Color.FromHex("#C5C5C5");

                    foreach (var item in values)
                    {
                        if (item == null)
                        {
                            returnValue = Color.FromHex("#C5C5C5");
                            break;
                        }
                    }

                    return returnValue;
                }
                default:
                    return values;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
