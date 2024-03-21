using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Join
{
    public class Data_Join_Email : BindableObject, IValueConverter
    {
        public bool IsNextConfirm { get; set; }

        private bool CheckEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, @"^[a-zA-Z0-9_\-\.]{4,}\@[a-zA-Z0-9_\-]{2,}(\.[a-zA-Z]{2,3})?\.[a-zA-Z]{2,3}$");
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "NextButtonColor":
                    if (this.CheckEmail((string)value))
                    {
                        this.IsNextConfirm = true;
                        return Color.FromHex("#4A9CFF");
                    }
                    else
                    {
                        this.IsNextConfirm = false;
                        return Color.FromHex("#C5C5C5");
                    }
                case "EntryBorderColor":
                    if (value != null && !this.CheckEmail((string)value))
                        return Color.FromHex("#FF0000");
                    else
                        return Color.FromHex("#C5C5C5");
                case "IsVisibleErrorMessage":
                    return value != null && !this.CheckEmail((string)value);
                default:
                    return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
