using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Appeal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppealWriteDialog : PopupPage
    {
        private TaskCompletionSource<AppealPage_Data.ContentTypes?> TaskCompletionSource { get; set; }

        public AppealWriteDialog()
        {
            InitializeComponent();
            this.TaskCompletionSource = new TaskCompletionSource<AppealPage_Data.ContentTypes?>();
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

        public Task<AppealPage_Data.ContentTypes?> ShowAsync()
        {
            this.Navigation.PushPopupAsync(this);
            return this.TaskCompletionSource.Task;
        }

        private async void Menu01_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopPopupAsync();
            this.TaskCompletionSource.SetResult(AppealPage_Data.ContentTypes.Boast);
        }

        private async void Menu02_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopPopupAsync();
            this.TaskCompletionSource.SetResult(AppealPage_Data.ContentTypes.Metting);
        }

        private async void Menu03_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopPopupAsync();
            this.TaskCompletionSource.SetResult(AppealPage_Data.ContentTypes.Sell);
        }

        private async void Menu04_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopPopupAsync();
            this.TaskCompletionSource.SetResult(AppealPage_Data.ContentTypes.Talk);
        }
    }
}