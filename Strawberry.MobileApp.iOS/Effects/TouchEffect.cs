using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.PlatformConfiguration;

[assembly: ResolutionGroupName("Strawberry")]
[assembly: ExportEffect(typeof(Strawberry.MobileApp.iOS.Effects.TouchEffect), "TouchEffect")]
namespace Strawberry.MobileApp.iOS.Effects
{
    public class TouchEffect : PlatformEffect
    {
        public UIView View { get; private set; }
        private UITouchRecognizer TouchRecognizer { get; set; }

        protected override void OnAttached()
        {
            this.View = this.Control == null ? this.Container : this.Control;
            this.View.UserInteractionEnabled = true;
            this.TouchRecognizer = new UITouchRecognizer(this.Element);
            this.View.AddGestureRecognizer(this.TouchRecognizer);
        }

        protected override void OnDetached()
        {
            if (this.View != null)
                this.View.RemoveGestureRecognizer(this.TouchRecognizer);
        }

        private class UITouchRecognizer : UIGestureRecognizer
        {
            private Element Element { get; set; }

            public UITouchRecognizer(Element element)
            {
                this.Element = element;
            }

            public override void TouchesBegan(NSSet touches, UIEvent evt)
            {
                base.TouchesBegan(touches, evt);
                var effect = (MobileApp.Effects.TouchEffect)this.Element.Effects.FirstOrDefault(x => x is MobileApp.Effects.TouchEffect);
                effect?.OnTouchAction(this.Element, MobileApp.Effects.TouchEffect.TouchActionType.Pressed);
            }

            public override void TouchesEnded(NSSet touches, UIEvent evt)
            {
                base.TouchesEnded(touches, evt);
                var effect = (MobileApp.Effects.TouchEffect)this.Element.Effects.FirstOrDefault(x => x is MobileApp.Effects.TouchEffect);
                effect?.OnTouchAction(this.Element, MobileApp.Effects.TouchEffect.TouchActionType.Released);
            }

            protected override void Dispose(bool disposing)
            {
                this.Element = null;
                base.Dispose(disposing);
            }
        }
    }
}