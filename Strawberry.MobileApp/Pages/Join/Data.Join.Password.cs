using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Join
{
    public class Data_Join_Password : BindableObject, IValueConverter
    {
        public bool IsNextConfirm { get; set; }

        private bool CheckPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;
            else
                return Regex.IsMatch(password, "^[a-zA-Z0-9\\`\\~\\!\\@\\#\\$\\%\\^\\&\\*\\(\\)\\-_\\=\\+\\[\\{\\]\\}\\\\|\\;\\:\\'\"\\,\\<\\.\\>\\/\\?]{8,}$");
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "EntryBorderColor":
                    if (value != null && !this.CheckPassword((string)value))
                        return Color.FromHex("#FF0000");
                    else
                        return Color.FromHex("#C5C5C5");
                case "NextButtonColor":
                    if (this.CheckPassword((string)value))
                    {
                        this.IsNextConfirm = true;
                        return Color.FromHex("#4A9CFF");
                    }
                    else
                    {
                        this.IsNextConfirm = false;
                        return Color.FromHex("#C5C5C5");
                    }
                case "IsVisibleErrorMessage":
                    return value != null && !CheckPassword((string)value);
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
