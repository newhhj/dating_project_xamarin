using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Near
{
    public class NearPageData : BindableObject
    {
        public ObservableCollection<NearPagePartnerViewData> Items { get => (ObservableCollection<NearPagePartnerViewData>)GetValue(ItemsProperty); set => SetValue(ItemsProperty, value); }
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<NearPagePartnerViewData>), typeof(NearPageData));

        public NearPageData()
        {
            this.Items = new ObservableCollection<NearPagePartnerViewData>();
        }
    }
}
