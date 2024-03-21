using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Strawberry.MobileApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Appeal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppealDetailAlertDialog : PopupPage
    {
        private LockDataModel LockData { get; set; } = new LockDataModel();
        private TaskCompletionSource<(string title, string message)> TaskCompletionSource { get; set; } = new TaskCompletionSource<(string title, string message)>();

        public AppealDetailAlertDialog()
        {
            InitializeComponent();
        }

        public Task<(string title, string message)> ShowDialogAsync()
        {
            App.Instance.MainPage.Navigation.PushPopupAsync(this);
            return this.TaskCompletionSource.Task;
        }

        protected override bool OnBackButtonPressed()
        {
            var result = base.OnBackButtonPressed();
            this.TaskCompletionSource.SetResult((null, null));
            return result;
        }

        protected override bool OnBackgroundClicked()
        {
            var result = base.OnBackgroundClicked();
            this.TaskCompletionSource.SetResult((null, null));
            return result;
        }

        private void Item01_Clicked(object sender, EventArgs e)
        {
            this.pageData.Title = "욕설 및 비방";
            this.pageData.Message = "욕설, 비난, 모욕, 성희롱, 차별";
        }

        private void Item02_Clicked(object sender, EventArgs e)
        {
            this.pageData.Title = "개인 신상정보 노출";
            this.pageData.Message = "개인 또는 타인의 신상정보를 게시";
        }

        private void Item03_Clicked(object sender, EventArgs e)
        {
            this.pageData.Title = "광고 및 도배";
            this.pageData.Message = "상업적인 게시글이나 불필요한 글 도배";
        }

        private void Item04_Clicked(object sender, EventArgs e)
        {
            this.pageData.Title = "부적절한 사진";
            this.pageData.Message = "상반신 또는 하반신의 과한 노출";
        }

        private void Item05_Clicked(object sender, EventArgs e)
        {
            this.alertMessage.Focus();
        }

        private async void AlertMessage_Focused(object sender, FocusEventArgs e)
        {
            await Task.Delay(300);
            await this.TranslateTo(0, 1);
            await Task.Delay(1);
            await this.TranslateTo(0, 0);
        }

        private async void AlertMessage_Unfocused(object sender, FocusEventArgs e)
        {
            await Task.Delay(300);
            await this.TranslateTo(0, 1);
            await Task.Delay(1);
            await this.TranslateTo(0, 0);
        }

        private async void Excute_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(this.pageData.Title))
                    return;

                await this.Navigation.PopPopupAsync();
                this.TaskCompletionSource.SetResult((this.pageData.Title, this.pageData.Message));
            }
            catch (Exception ex)
            {
                await this.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }
    }
}