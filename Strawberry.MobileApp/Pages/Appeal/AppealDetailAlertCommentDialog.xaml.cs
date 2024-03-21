using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Strawberry.MobileApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Appeal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppealDetailAlertCommentDialog : PopupPage
    {
        private TaskCompletionSource<string> TaskCompletionSource { get; set; }

        public AppealDetailAlertCommentDialog()
        {
            InitializeComponent();
            this.TaskCompletionSource = new TaskCompletionSource<string>();
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

        public Task<string> ShowAsync()
        {
            this.Navigation.PushPopupAsync(this);
            return this.TaskCompletionSource.Task;
        }

        private async void Menu01_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            await this.Navigation.PopPopupAsync();
            this.TaskCompletionSource.SetResult("광고성 콘텐츠");
        }

        private async void Menu02_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            await this.Navigation.PopPopupAsync();
            this.TaskCompletionSource.SetResult("동일 게시물 반복 게시");
        }

        private async void Menu03_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            await this.Navigation.PopPopupAsync();
            this.TaskCompletionSource.SetResult("부적절한 내용 (욕설, 비방, 외설적인 내용 등)");
        }
    }
}