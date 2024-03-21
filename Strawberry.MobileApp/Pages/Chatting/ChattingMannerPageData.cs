using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Chatting
{
    public class ChattingMannerPageData : BindableObject
    {
        public ObservableCollection<string> SelectedItems { get => (ObservableCollection<string>)GetValue(SelectedItemsProperty); set => SetValue(SelectedItemsProperty, value); }
        public static readonly BindableProperty SelectedItemsProperty = BindableProperty.Create(nameof(SelectedItems), typeof(ObservableCollection<string>), typeof(ChattingMannerPageData));

        public bool Item01Selected { get => (bool)GetValue(Item01SelectedProperty); set => SetValue(Item01SelectedProperty, value); }
        public static readonly BindableProperty Item01SelectedProperty = BindableProperty.Create(nameof(Item01Selected), typeof(bool), typeof(ChattingMannerPageData));

        public bool Item02Selected { get => (bool)GetValue(Item02SelectedProperty); set => SetValue(Item02SelectedProperty, value); }
        public static readonly BindableProperty Item02SelectedProperty = BindableProperty.Create(nameof(Item02Selected), typeof(bool), typeof(ChattingMannerPageData));

        public bool Item03Selected { get => (bool)GetValue(Item03SelectedProperty); set => SetValue(Item03SelectedProperty, value); }
        public static readonly BindableProperty Item03SelectedProperty = BindableProperty.Create(nameof(Item03Selected), typeof(bool), typeof(ChattingMannerPageData));

        public ChattingMannerPageData()
        {
            this.SelectedItems = new ObservableCollection<string>();
        }
    }
}
