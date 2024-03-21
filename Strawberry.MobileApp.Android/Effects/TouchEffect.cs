using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ResolutionGroupName("Strawberry")]
[assembly: ExportEffect(typeof(Strawberry.MobileApp.Droid.Effects.TouchEffect), "TouchEffect")]
namespace Strawberry.MobileApp.Droid.Effects
{
    public class TouchEffect : PlatformEffect
    {
        public Android.Views.View View { get; private set; }

        protected override void OnAttached()
        {
            this.View = this.Control == null ? this.Container : this.Control;
            this.View.Touch += this.View_Touch;
        }

        protected override void OnDetached()
        {
            if (this.View != null)
                this.View.Touch -= this.View_Touch;
        }

        private void View_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            Console.WriteLine(e.Event.ActionMasked);

            switch (e.Event.ActionMasked)
            {
                case MotionEventActions.Down:
                {
                    var effect = (MobileApp.Effects.TouchEffect)this.Element.Effects.FirstOrDefault(x => x is MobileApp.Effects.TouchEffect);
                    effect?.OnTouchAction(this.Element, MobileApp.Effects.TouchEffect.TouchActionType.Pressed);
                    break;
                }
                case MotionEventActions.Up:
                case MotionEventActions.ButtonRelease:
                case MotionEventActions.Cancel:
                {
                    var effect = (MobileApp.Effects.TouchEffect)this.Element.Effects.FirstOrDefault(x => x is MobileApp.Effects.TouchEffect);
                    effect?.OnTouchAction(this.Element, MobileApp.Effects.TouchEffect.TouchActionType.Released);
                    break;
                }
                default:
                    break;
            }
        }
    }
}