using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Effects
{
    public class TouchEffect : RoutingEffect
    {
        public enum TouchActionType
        {
            Pressed,
            Released,
        }

        public event EventHandler<TouchActionType> TouchAction;

        public TouchEffect() : base("Strawberry.TouchEffect")
        {

        }

        public void OnTouchAction(Element element, TouchActionType e)
        {
            this.TouchAction?.Invoke(element, e);
        }
    }
}
