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

namespace Strawberry.MobileApp.Pages.Shares
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmDialog : PopupPage
    {
        private TaskCompletionSource<bool> TaskCompletionSource { get; set; }

        public ConfirmDialogData PageData { get => (ConfirmDialogData)this.BindingContext; private set => this.BindingContext = value; }

        public ConfirmDialog(string title = null, string subject = null, string denny = "아니요", string accept = "예")
        {
            this.PageData = new ConfirmDialogData
            {
                Title = title,
                Subject = subject,
                Denny = denny,
                Accept = accept,
            };

            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            var result = base.OnBackButtonPressed();
            this.TaskCompletionSource?.SetResult(false);
            return result;
        }

        protected override bool OnBackgroundClicked()
        {
            var result = base.OnBackgroundClicked();
            this.TaskCompletionSource?.SetResult(false);
            return result;
        }

        private void Denny_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopPopupAsync();
            this.TaskCompletionSource?.SetResult(false);
        }

        private void Accept_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopPopupAsync();
            this.TaskCompletionSource?.SetResult(true);
        }

        public Task<bool> ShowDialog()
        {
            this.Navigation.PushPopupAsync(this);
            this.TaskCompletionSource = new TaskCompletionSource<bool>();
            return this.TaskCompletionSource.Task;
        }
    }

    public class ConfirmDialogData : BindableObject
    {
        public string Title { get => (string)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(ConfirmDialogData));

        public string Subject { get => (string)GetValue(SubjectProperty); set => SetValue(SubjectProperty, value); }
        public static readonly BindableProperty SubjectProperty = BindableProperty.Create(nameof(Subject), typeof(string), typeof(ConfirmDialogData));

        public string Denny { get => (string)GetValue(DennyProperty); set => SetValue(DennyProperty, value); }
        public static readonly BindableProperty DennyProperty = BindableProperty.Create(nameof(Denny), typeof(string), typeof(ConfirmDialogData), defaultValue: "아니요");

        public string Accept { get => (string)GetValue(AcceptProperty); set => SetValue(AcceptProperty, value); }
        public static readonly BindableProperty AcceptProperty = BindableProperty.Create(nameof(Accept), typeof(string), typeof(ConfirmDialogData), defaultValue: "예");
    }
}