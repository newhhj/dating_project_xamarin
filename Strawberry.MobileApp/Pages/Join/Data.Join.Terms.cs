using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Join
{
    public class Data_Join_Terms : BindableObject, IValueConverter, IMultiValueConverter
    {
        public bool IsTermChecked { get => (bool)GetValue(IsTermCheckedProperty); set => SetValue(IsTermCheckedProperty, value); }
        public static readonly BindableProperty IsTermCheckedProperty = BindableProperty.Create(nameof(IsTermChecked), typeof(bool), typeof(Data_Join_Terms));

        public bool IsPrivacyChecked { get => (bool)GetValue(IsPrivacyCheckedProperty); set => SetValue(IsPrivacyCheckedProperty, value); }
        public static readonly BindableProperty IsPrivacyCheckedProperty = BindableProperty.Create(nameof(IsPrivacyChecked), typeof(bool), typeof(Data_Join_Terms));

        public bool IsLocationChecked { get => (bool)GetValue(IsLocationCheckedProperty); set => SetValue(IsLocationCheckedProperty, value); }
        public static readonly BindableProperty IsLocationCheckedProperty = BindableProperty.Create(nameof(IsLocationChecked), typeof(bool), typeof(Data_Join_Terms));

        public bool IsSensitiveChecked { get => (bool)GetValue(IsSensitiveCheckedProperty); set => SetValue(IsSensitiveCheckedProperty, value); }
        public static readonly BindableProperty IsSensitiveCheckedProperty = BindableProperty.Create(nameof(IsSensitiveChecked), typeof(bool), typeof(Data_Join_Terms));

        public bool IsContentChecked { get => (bool)GetValue(IsContentCheckedProperty); set => SetValue(IsContentCheckedProperty, value); }
        public static readonly BindableProperty IsContentCheckedProperty = BindableProperty.Create(nameof(IsContentChecked), typeof(bool), typeof(Data_Join_Terms));

        public bool IsMarketingChecked { get => (bool)GetValue(IsMarketingCheckedProperty); set => SetValue(IsMarketingCheckedProperty, value); }
        public static readonly BindableProperty IsMarketingCheckedProperty = BindableProperty.Create(nameof(IsMarketingChecked), typeof(bool), typeof(Data_Join_Terms));

        public bool UseNextButton
        {
            get => this.IsTermChecked && this.IsPrivacyChecked && this.IsLocationChecked && this.IsSensitiveChecked && this.IsContentChecked;
        }

        public Color NextButtonColor
        {
            get
            {
                if (!this.UseNextButton)
                    return Color.FromHex("#C5C5C5");
                else
                    return Color.FromHex("#4A9CFF");
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(this.IsTermChecked):
                case nameof(this.IsPrivacyChecked):
                case nameof(this.IsLocationChecked):
                case nameof(this.IsSensitiveChecked):
                case nameof(this.IsContentChecked):
                    base.OnPropertyChanged(nameof(UseNextButton));
                    base.OnPropertyChanged(nameof(NextButtonColor));
                    break;
                default:
                    break;
            }

            base.OnPropertyChanged(propertyName);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isChecked = (bool)value;
            if (isChecked)
            {
                return "icon_cbox_checked";
            }
            else
            {
                return "icon_cbox";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0 || values.Any(x => x == null))
                return "icon_cbox";

            var isChecked = true;
            foreach (var item in values)
            {
                if (!(bool)item)
                {
                    isChecked = false;
                    break;
                }
            }

            if (isChecked)
            {
                return "icon_cbox_checked";
            }
            else
            {
                return "icon_cbox";
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
