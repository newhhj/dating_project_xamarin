using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Near
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NearPagePartnerView : Grid
    {
        public event EventHandler<NearPagePartnerViewData> Tapped;

        public NearPagePartnerView()
        {
            InitializeComponent();
        }

        public Constraint GetXConstraint()
        {
            return Constraint.RelativeToParent(parent =>
            {
                var index = parent.Children.IndexOf(this);

                var scale = ((NearPagePartnerViewData)this.BindingContext).Scale;

                switch (index)
                {
                    case 0:
                        return (parent.Width * 0.5 - 80) * scale + 30;
                    case 1:
                        return ((parent.Width * 0.5 - 80 - 30) * scale) + (parent.Width * 0.5 + 30);
                    case 2:
                        return (parent.Width * 0.5 - 80 - 30) * scale;
                    case 3:
                        return ((parent.Width * 0.5 - 80 - 30) * scale) + (parent.Width * 0.5 + 30);
                    case 4:
                        return (parent.Width * 0.5 - 80) * scale + 30;
                    default:
                        return 0;
                }
            });
        }

        public Constraint GetYConstraint()
        {
            return Constraint.RelativeToParent(parent =>
            {
                var index = parent.Children.IndexOf(this);
                var count = parent.Children.Count;
                var height = parent.Height / count;

                var scale = ((NearPagePartnerViewData)this.BindingContext).Scale;

                return (height - 100) * scale + (height * index);
            });
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            this.Tapped?.Invoke(this, (NearPagePartnerViewData)this.BindingContext);
        }
    }
}