using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Strawberry.MobileApp.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(Entry), typeof(EntrysRenderer))]
namespace Strawberry.MobileApp.Droid.Renderers
{
    public class EntrysRenderer : EntryRenderer
    {
        public EntrysRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
                this.Control.Background = null;
        }
    }
}