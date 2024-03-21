using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Join
{
    public class Data_Join_Interest : BindableObject, IValueConverter
    {
        public ObservableCollection<ItemData> Items { get => (ObservableCollection<ItemData>)GetValue(ItemsProperty); set => SetValue(ItemsProperty, value); }
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<ItemData>), typeof(Data_Join_Interest));

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                switch (parameter)
                {
                    case "BackgroundColor":
                    {
                        return (bool)value ? "#194A9CFF" : "#E9E9E9";
                    }
                    case "TextColor":
                    {
                        return (bool)value ? "#4A9CFF" : "#707070";
                    }
                    default:
                        throw new Exception();
                }
            }
            catch
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public class ItemData : BindableObject
        {
            public string Name { get => (string)GetValue(NameProperty); set => SetValue(NameProperty, value); }
            public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(ItemData));

            public bool IsSelected { get => (bool)GetValue(IsSelectedProperty); set => SetValue(IsSelectedProperty, value); }
            public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(ItemData));
        }
    }
}
