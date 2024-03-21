using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FFImageLoading.Forms.Platform;
using Foundation;
using StoreKit;
using UIKit;

namespace Strawberry.MobileApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            this.CheckReferrer();

            Rg.Plugins.Popup.Popup.Init();
            global::Xamarin.Forms.Forms.Init();
            CachedImageRenderer.Init();
            CachedImageRenderer.InitImageSourceHandler();
            global::Xamarin.FormsMaps.Init();
            LoadApplication(new App());

            Plugin.InAppBilling.InAppBillingImplementation.OnShouldAddStorePayment = OnShouldAddStorePayment;
            var current = Plugin.InAppBilling.CrossInAppBilling.Current;

            return base.FinishedLaunching(app, options);
        }

        private bool OnShouldAddStorePayment(SKPaymentQueue queue, SKPayment payment, SKProduct product)
        {
            return true;
        }

        private async Task CheckReferrer()
        {
            if (Xamarin.Essentials.Preferences.ContainsKey("referrer"))
                return;

            if (Xamarin.Essentials.Clipboard.HasText)
            {
                var referrer = await Xamarin.Essentials.Clipboard.GetTextAsync();
                if (Regex.IsMatch(referrer, "[0-9a-z]{32}"))
                {
                    Xamarin.Essentials.Preferences.Set("referrer", referrer);
                }
            }
        }
    }
}
