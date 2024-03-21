using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Option
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPersonalityDialog : PopupPage
    {
        public SelectPersonalityDialogData PageData
        {
            get => (SelectPersonalityDialogData)this.BindingContext;
            set => this.BindingContext = value;
        }

        private TaskCompletionSource<string[]> TaskCompletionSource { get; set; }

        public SelectPersonalityDialog()
        {
            InitializeComponent();
        }

        public async Task<string[]> ShowDialogAsync(string personality)
        {
            this.PageData = new SelectPersonalityDialogData();
            this.TaskCompletionSource = new TaskCompletionSource<string[]>();
            await App.Instance.MainPage.Navigation.PushPopupAsync(this);

            if (!string.IsNullOrWhiteSpace(personality))
            {
                var items = personality.Split(',');
                foreach (var item in items)
                {
                    var itemData = item.Trim();
                    this.PageData.SelectedItems.Add(itemData);
                    switch (itemData)
                    {
                        case "활발한":
                            this.PageData.IsSelectedItem01 = true;
                            break;
                        case "친절한":
                            this.PageData.IsSelectedItem02 = true;
                            break;
                        case "도발적인":
                            this.PageData.IsSelectedItem03 = true;
                            break;
                        case "감성적인":
                            this.PageData.IsSelectedItem04 = true;
                            break;
                        case "애교있는":
                            this.PageData.IsSelectedItem05 = true;
                            break;
                        case "주도적인":
                            this.PageData.IsSelectedItem06 = true;
                            break;
                        default:
                            break;
                    }
                }
            }

            return await this.TaskCompletionSource.Task;
        }

        protected override bool OnBackButtonPressed()
        {
            this.TaskCompletionSource.SetResult(null);
            return base.OnBackButtonPressed();
        }

        protected override bool OnBackgroundClicked()
        {
            this.TaskCompletionSource.SetResult(null);
            return base.OnBackgroundClicked();
        }

        private void Item01_Clicked(object sender, EventArgs e)
        {
            var keyword = "활발한";
            if (this.PageData.SelectedItems.Any(x => x == keyword))
            {
                this.PageData.SelectedItems.Remove(keyword);
                this.PageData.IsSelectedItem01 = false;
            }
            else
            {
                if (this.PageData.SelectedItems.Count >= 3)
                    return;
                this.PageData.SelectedItems.Add(keyword);
                this.PageData.IsSelectedItem01 = true;
            }
        }

        private void Item02_Clicked(object sender, EventArgs e)
        {
            var keyword = "친절한";
            if (this.PageData.SelectedItems.Any(x => x == keyword))
            {
                this.PageData.SelectedItems.Remove(keyword);
                this.PageData.IsSelectedItem02 = false;
            }
            else
            {
                if (this.PageData.SelectedItems.Count >= 3)
                    return;
                this.PageData.SelectedItems.Add(keyword);
                this.PageData.IsSelectedItem02 = true;
            }
        }

        private void Item03_Clicked(object sender, EventArgs e)
        {
            var keyword = "도발적인";
            if (this.PageData.SelectedItems.Any(x => x == keyword))
            {
                this.PageData.SelectedItems.Remove(keyword);
                this.PageData.IsSelectedItem03 = false;
            }
            else
            {
                if (this.PageData.SelectedItems.Count >= 3)
                    return;
                this.PageData.SelectedItems.Add(keyword);
                this.PageData.IsSelectedItem03 = true;
            }
        }

        private void Item04_Clicked(object sender, EventArgs e)
        {
            var keyword = "감성적인";
            if (this.PageData.SelectedItems.Any(x => x == keyword))
            {
                this.PageData.SelectedItems.Remove(keyword);
                this.PageData.IsSelectedItem04 = false;
            }
            else
            {
                if (this.PageData.SelectedItems.Count >= 3)
                    return;
                this.PageData.SelectedItems.Add(keyword);
                this.PageData.IsSelectedItem04 = true;
            }
        }

        private void Item05_Clicked(object sender, EventArgs e)
        {
            var keyword = "애교있는";
            if (this.PageData.SelectedItems.Any(x => x == keyword))
            {
                this.PageData.SelectedItems.Remove(keyword);
                this.PageData.IsSelectedItem05 = false;
            }
            else
            {
                if (this.PageData.SelectedItems.Count >= 3)
                    return;
                this.PageData.SelectedItems.Add(keyword);
                this.PageData.IsSelectedItem05 = true;
            }
        }

        private void Item06_Clicked(object sender, EventArgs e)
        {
            var keyword = "주도적인";
            if (this.PageData.SelectedItems.Any(x => x == keyword))
            {
                this.PageData.SelectedItems.Remove(keyword);
                this.PageData.IsSelectedItem06 = false;
            }
            else
            {
                if (this.PageData.SelectedItems.Count >= 3)
                    return;
                this.PageData.SelectedItems.Add(keyword);
                this.PageData.IsSelectedItem06 = true;
            }
        }

        private void Accept_Clicked(object sender, EventArgs e)
        {
            this.TaskCompletionSource.SetResult(this.PageData.SelectedItems.ToArray());
            this.Navigation.PopPopupAsync();
        }
    }

    public class SelectPersonalityDialogData : BindableObject
    {
        public ObservableCollection<string> SelectedItems { get => (ObservableCollection<string>)GetValue(SelectedItemsProperty); set => SetValue(SelectedItemsProperty, value); }
        public static readonly BindableProperty SelectedItemsProperty = BindableProperty.Create(nameof(SelectedItems), typeof(ObservableCollection<string>), typeof(SelectPersonalityDialogData));

        public bool IsSelectedItem01 { get => (bool)GetValue(IsSelectedItem01Property); set => SetValue(IsSelectedItem01Property, value); }
        public static readonly BindableProperty IsSelectedItem01Property = BindableProperty.Create(nameof(IsSelectedItem01), typeof(bool), typeof(SelectPersonalityDialogData), false);

        public bool IsSelectedItem02 { get => (bool)GetValue(IsSelectedItem02Property); set => SetValue(IsSelectedItem02Property, value); }
        public static readonly BindableProperty IsSelectedItem02Property = BindableProperty.Create(nameof(IsSelectedItem02), typeof(bool), typeof(SelectPersonalityDialogData), false);

        public bool IsSelectedItem03 { get => (bool)GetValue(IsSelectedItem03Property); set => SetValue(IsSelectedItem03Property, value); }
        public static readonly BindableProperty IsSelectedItem03Property = BindableProperty.Create(nameof(IsSelectedItem03), typeof(bool), typeof(SelectPersonalityDialogData), false);

        public bool IsSelectedItem04 { get => (bool)GetValue(IsSelectedItem04Property); set => SetValue(IsSelectedItem04Property, value); }
        public static readonly BindableProperty IsSelectedItem04Property = BindableProperty.Create(nameof(IsSelectedItem04), typeof(bool), typeof(SelectPersonalityDialogData), false);

        public bool IsSelectedItem05 { get => (bool)GetValue(IsSelectedItem05Property); set => SetValue(IsSelectedItem05Property, value); }
        public static readonly BindableProperty IsSelectedItem05Property = BindableProperty.Create(nameof(IsSelectedItem05), typeof(bool), typeof(SelectPersonalityDialogData), false);

        public bool IsSelectedItem06 { get => (bool)GetValue(IsSelectedItem06Property); set => SetValue(IsSelectedItem06Property, value); }
        public static readonly BindableProperty IsSelectedItem06Property = BindableProperty.Create(nameof(IsSelectedItem06), typeof(bool), typeof(SelectPersonalityDialogData), false);

        public SelectPersonalityDialogData()
        {
            this.SelectedItems = new ObservableCollection<string>();
        }
    }
}