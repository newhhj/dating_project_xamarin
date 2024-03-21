using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage_Dialog_AlertSelector : PopupPage
    {
        public enum AlertTypes
        {
            Block,
            Alert
        }

        private TaskCompletionSource<AlertTypes?> TaskCompletionSource { get; set; }

        public ProfilePage_Dialog_AlertSelector()
        {
            this.TaskCompletionSource = new TaskCompletionSource<AlertTypes?>();
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            var result = base.OnBackButtonPressed();
            this.TaskCompletionSource.SetResult(null);
            return result;
        }

        protected override bool OnBackgroundClicked()
        {
            var result = base.OnBackgroundClicked();
            this.TaskCompletionSource.SetResult(null);
            return result;
        }

        private void Block_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopPopupAsync();
            this.TaskCompletionSource.SetResult(AlertTypes.Block);
        }

        private void Alert_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopPopupAsync();
            this.TaskCompletionSource.SetResult(AlertTypes.Alert);
        }

        public Task<AlertTypes?> ShowDialog()
        {
            this.TaskCompletionSource = new TaskCompletionSource<AlertTypes?>();
            this.Navigation.PushPopupAsync(this);
            return this.TaskCompletionSource.Task;
        }
    }
}