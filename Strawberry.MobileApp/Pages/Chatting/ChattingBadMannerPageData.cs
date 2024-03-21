using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Chatting
{
    public class ChattingBadMannerPageData : BindableObject
    {
        public ObservableCollection<string> SelectedType01Items { get => (ObservableCollection<string>)GetValue(SelectedType01ItemsProperty); set => SetValue(SelectedType01ItemsProperty, value); }
        public static readonly BindableProperty SelectedType01ItemsProperty = BindableProperty.Create(nameof(SelectedType01Items), typeof(ObservableCollection<string>), typeof(ChattingBadMannerPageData));

        public ObservableCollection<string> SelectedType02Items { get => (ObservableCollection<string>)GetValue(SelectedType02ItemsProperty); set => SetValue(SelectedType02ItemsProperty, value); }
        public static readonly BindableProperty SelectedType02ItemsProperty = BindableProperty.Create(nameof(SelectedType02Items), typeof(ObservableCollection<string>), typeof(ChattingBadMannerPageData));

        public bool Item01Selected { get => (bool)GetValue(Item01SelectedProperty); set => SetValue(Item01SelectedProperty, value); }
        public static readonly BindableProperty Item01SelectedProperty = BindableProperty.Create(nameof(Item01Selected), typeof(bool), typeof(ChattingBadMannerPageData));

        public bool Item02Selected { get => (bool)GetValue(Item02SelectedProperty); set => SetValue(Item02SelectedProperty, value); }
        public static readonly BindableProperty Item02SelectedProperty = BindableProperty.Create(nameof(Item02Selected), typeof(bool), typeof(ChattingBadMannerPageData));

        public bool Item03Selected { get => (bool)GetValue(Item03SelectedProperty); set => SetValue(Item03SelectedProperty, value); }
        public static readonly BindableProperty Item03SelectedProperty = BindableProperty.Create(nameof(Item03Selected), typeof(bool), typeof(ChattingBadMannerPageData));

        public bool Item04Selected { get => (bool)GetValue(Item04SelectedProperty); set => SetValue(Item04SelectedProperty, value); }
        public static readonly BindableProperty Item04SelectedProperty = BindableProperty.Create(nameof(Item04Selected), typeof(bool), typeof(ChattingBadMannerPageData));

        public bool Item05Selected { get => (bool)GetValue(Item05SelectedProperty); set => SetValue(Item05SelectedProperty, value); }
        public static readonly BindableProperty Item05SelectedProperty = BindableProperty.Create(nameof(Item05Selected), typeof(bool), typeof(ChattingBadMannerPageData));

        public bool Item06Selected { get => (bool)GetValue(Item06SelectedProperty); set => SetValue(Item06SelectedProperty, value); }
        public static readonly BindableProperty Item06SelectedProperty = BindableProperty.Create(nameof(Item06Selected), typeof(bool), typeof(ChattingBadMannerPageData));

        public bool Item07Selected { get => (bool)GetValue(Item07SelectedProperty); set => SetValue(Item07SelectedProperty, value); }
        public static readonly BindableProperty Item07SelectedProperty = BindableProperty.Create(nameof(Item07Selected), typeof(bool), typeof(ChattingBadMannerPageData));

        public bool Item08Selected { get => (bool)GetValue(Item08SelectedProperty); set => SetValue(Item08SelectedProperty, value); }
        public static readonly BindableProperty Item08SelectedProperty = BindableProperty.Create(nameof(Item08Selected), typeof(bool), typeof(ChattingBadMannerPageData));

        public bool Item09Selected { get => (bool)GetValue(Item09SelectedProperty); set => SetValue(Item09SelectedProperty, value); }
        public static readonly BindableProperty Item09SelectedProperty = BindableProperty.Create(nameof(Item09Selected), typeof(bool), typeof(ChattingBadMannerPageData));

        public bool Item10Selected { get => (bool)GetValue(Item10SelectedProperty); set => SetValue(Item10SelectedProperty, value); }
        public static readonly BindableProperty Item10SelectedProperty = BindableProperty.Create(nameof(Item10Selected), typeof(bool), typeof(ChattingBadMannerPageData));

        public bool Item11Selected { get => (bool)GetValue(Item11SelectedProperty); set => SetValue(Item11SelectedProperty, value); }
        public static readonly BindableProperty Item11SelectedProperty = BindableProperty.Create(nameof(Item11Selected), typeof(bool), typeof(ChattingBadMannerPageData));

        public bool Item12Selected { get => (bool)GetValue(Item12SelectedProperty); set => SetValue(Item12SelectedProperty, value); }
        public static readonly BindableProperty Item12SelectedProperty = BindableProperty.Create(nameof(Item12Selected), typeof(bool), typeof(ChattingBadMannerPageData));

        public bool Item13Selected { get => (bool)GetValue(Item13SelectedProperty); set => SetValue(Item13SelectedProperty, value); }
        public static readonly BindableProperty Item13SelectedProperty = BindableProperty.Create(nameof(Item13Selected), typeof(bool), typeof(ChattingBadMannerPageData));

        public bool Item14Selected { get => (bool)GetValue(Item14SelectedProperty); set => SetValue(Item14SelectedProperty, value); }
        public static readonly BindableProperty Item14SelectedProperty = BindableProperty.Create(nameof(Item14Selected), typeof(bool), typeof(ChattingBadMannerPageData));

        public bool Item15Selected { get => (bool)GetValue(Item15SelectedProperty); set => SetValue(Item15SelectedProperty, value); }
        public static readonly BindableProperty Item15SelectedProperty = BindableProperty.Create(nameof(Item15Selected), typeof(bool), typeof(ChattingBadMannerPageData));

        public bool Item16Selected { get => (bool)GetValue(Item16SelectedProperty); set => SetValue(Item16SelectedProperty, value); }
        public static readonly BindableProperty Item16SelectedProperty = BindableProperty.Create(nameof(Item16Selected), typeof(bool), typeof(ChattingBadMannerPageData));

        public string Item17Text { get => (string)GetValue(Item17TextProperty); set => SetValue(Item17TextProperty, value); }
        public static readonly BindableProperty Item17TextProperty = BindableProperty.Create(nameof(Item17Text), typeof(string), typeof(ChattingBadMannerPageData));

        public ChattingBadMannerPageData()
        {
            this.SelectedType01Items = new ObservableCollection<string>();
            this.SelectedType02Items = new ObservableCollection<string>();
        }
    }
}
