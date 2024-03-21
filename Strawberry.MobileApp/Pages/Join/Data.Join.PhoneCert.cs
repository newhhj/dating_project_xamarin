using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Join
{
    public class Data_Join_PhoneCert : BindableObject
    {
        public string Number1 { get => (string)GetValue(Number1Property); set => SetValue(Number1Property, value); }
        public static readonly BindableProperty Number1Property = BindableProperty.Create(nameof(Number1), typeof(string), typeof(Data_Join_PhoneCert));

        public string Number2 { get => (string)GetValue(Number2Property); set => SetValue(Number2Property, value); }
        public static readonly BindableProperty Number2Property = BindableProperty.Create(nameof(Number2), typeof(string), typeof(Data_Join_PhoneCert));

        public string Number3 { get => (string)GetValue(Number3Property); set => SetValue(Number3Property, value); }
        public static readonly BindableProperty Number3Property = BindableProperty.Create(nameof(Number3), typeof(string), typeof(Data_Join_PhoneCert));

        public string Number4 { get => (string)GetValue(Number4Property); set => SetValue(Number4Property, value); }
        public static readonly BindableProperty Number4Property = BindableProperty.Create(nameof(Number4), typeof(string), typeof(Data_Join_PhoneCert));

        public string Code { get => Number1 + Number2 + Number3 + Number4; }

        public bool UseNextButton { get => Code.Length == 4; }

        public Color NextButtonColor
        {
            get
            {
                var number = Number1 + Number2 + Number3 + Number4;

                if (string.IsNullOrWhiteSpace(number) || !Regex.IsMatch(number, "^[0-9]{4}$"))
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
                case nameof(Number1):
                case nameof(Number2):
                case nameof(Number3):
                case nameof(Number4):
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
