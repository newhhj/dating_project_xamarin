using Strawberry.MobileApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Shares
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasePage : ContentPage
    {
        protected LockDataModel LockData { get; set; } = new LockDataModel();
        public bool IsActive { get; private set; }

        public BasePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            this.IsActive = true;
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            this.IsActive = false;
            base.OnDisappearing();
        }
    }
}