using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Join
{
    public class Data_Join_Phone : BindableObject
    {
        public string PhoneNumber { get => (string)GetValue(PhoneNumberProperty); set => SetValue(PhoneNumberProperty, value); }
        public static readonly BindableProperty PhoneNumberProperty = BindableProperty.Create(nameof(PhoneNumber), typeof(string), typeof(Data_Join_Phone));

        public bool UseNext { get => !string.IsNullOrWhiteSpace(this.PhoneNumber) && Regex.IsMatch(this.PhoneNumber, "^010[0-9]{7,8}$"); }

        public Color NextButtonColor
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.PhoneNumber) || !Regex.IsMatch(this.PhoneNumber, "^010[0-9]{7,8}$"))
                    return Color.FromHex("#C5C5C5");
                else
                    return Color.FromHex("#4A9CFF");
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(PhoneNumber):
                {
                    base.OnPropertyChanged(nameof(NextButtonColor));
                    break;
                }
                default:
                    break;
            }
        }
    }
}
