using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Appeal
{
    public class AppealPage_Top5_DataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                switch (parameter)
                {
                    case "TopIconOpacity":
                    {
                        var data = (int)value;
                        return data == 0 ? 1 : 0;
                    }
                    case "HarfRadius":
                    {
                        var data = (double)value;
                        return data <= 0 ? 0 : data / 2d;
                    }
                    case "TopFramePadding":
                    {
                        var data = (int)value;
                        return data == 0 ? 6 : 0;
                    }
                    case "Top5LabelText":
                    {
                        var data = (int)value;
                        return $"{data + 1}위";
                    }
                    default:
                        return null;
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
    }
}
