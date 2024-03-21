using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Appeal
{
    public class AppealPage_Menu02_DataConverter : IValueConverter, IMultiValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "CarouselViewHeight":
                {
                    var data = (double)value;
                    var returnValue = data * 0.59d;
                    return returnValue < 10 ? -1 : returnValue;
                }
                case "IsLikeIcon":
                {
                    var data = (bool)value;
                    return data ? "resource://Strawberry.MobileApp.Images.icon_like01_on.svg" : "resource://Strawberry.MobileApp.Images.icon_like01_off.svg";
                }
                case "CreateTimeText":
                {
                    var data = (DateTime)value;
                    var time = DateTime.Now - data;

                    if (time.TotalDays > 1)
                        return (int)Math.Floor(time.TotalDays) + "일전";
                    if (time.TotalHours > 1)
                        return (int)Math.Floor(time.TotalHours) + "시간전";
                    if (time.TotalMinutes > 1)
                        return (int)Math.Floor(time.TotalMinutes) + "분전";
                    if (time.TotalSeconds > 1)
                        return (int)Math.Floor(time.TotalSeconds) + "초전";
                    return "???";
                }
                default:
                    break;
            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
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

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
