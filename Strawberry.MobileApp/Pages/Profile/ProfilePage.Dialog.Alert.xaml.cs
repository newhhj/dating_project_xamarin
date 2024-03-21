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
    public partial class ProfilePage_Dialog_Alert : PopupPage
    {
        private TaskCompletionSource<ProfilePage_Dialog_Alert_Data> TaskCompletionSource { get; set; }

        public ProfilePage_Dialog_Alert()
        {
            this.TaskCompletionSource = new TaskCompletionSource<ProfilePage_Dialog_Alert_Data>();
            InitializeComponent();
        }

        private void Type01_Clicked(object sender, EventArgs e)
        {
            this.pageData.AlertType = 1;
        }

        private void Type02_Clicked(object sender, EventArgs e)
        {
            this.pageData.AlertType = 2;
        }

        private void Type03_Clicked(object sender, EventArgs e)
        {
            this.pageData.AlertType = 3;
        }

        private void Type04_Clicked(object sender, EventArgs e)
        {
            this.pageData.AlertType = 4;
        }

        private void Type05_Clicked(object sender, EventArgs e)
        {
            this.alertMessage.Focus();
        }

        private async void alertMessage_Focused(object sender, FocusEventArgs e)
        {
            this.pageData.AlertType = 5;

            await Task.Delay(300);
            await this.TranslateTo(0, 1);
            await Task.Delay(1);
            await this.TranslateTo(0, 0);
        }

        private async void alertMessage_Unfocused(object sender, FocusEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.pageData.AlertMessage))
                this.pageData.AlertType = 5;
            else
                this.pageData.AlertType = 0;

            await Task.Delay(300);
            await this.TranslateTo(0, 1);
            await Task.Delay(1);
            await this.TranslateTo(0, 0);
        }

        private void Block_Clicked(object sender, EventArgs e)
        {
            this.pageData.BlockChecked = !this.pageData.BlockChecked;
        }

        private void Confirm_Clicked(object sender, EventArgs e)
        {
            if (this.pageData.AlertType == 0)
                return;

            this.Navigation.PopPopupAsync();
            this.TaskCompletionSource.SetResult(this.pageData);
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

        public Task<ProfilePage_Dialog_Alert_Data> ShowDialog()
        {
            this.TaskCompletionSource = new TaskCompletionSource<ProfilePage_Dialog_Alert_Data>();
            this.Navigation.PushPopupAsync(this);
            return this.TaskCompletionSource.Task;
        }

        public void Init(string nickname)
        {
            this.pageData.Nickname = nickname;
        }
    }

    public class ProfilePage_Dialog_Alert_Data : BindableObject, IValueConverter
    {
        public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
        public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(ProfilePage_Dialog_Alert_Data));

        public int AlertType { get => (int)GetValue(AlertTypeProperty); set => SetValue(AlertTypeProperty, value); }
        public static readonly BindableProperty AlertTypeProperty = BindableProperty.Create(nameof(AlertType), typeof(int), typeof(ProfilePage_Dialog_Alert_Data));

        public string AlertMessage { get => (string)GetValue(AlertMessageProperty); set => SetValue(AlertMessageProperty, value); }
        public static readonly BindableProperty AlertMessageProperty = BindableProperty.Create(nameof(AlertMessage), typeof(string), typeof(ProfilePage_Dialog_Alert_Data));

        public bool BlockChecked { get => (bool)GetValue(BlockCheckedProperty); set => SetValue(BlockCheckedProperty, value); }
        public static readonly BindableProperty BlockCheckedProperty = BindableProperty.Create(nameof(BlockChecked), typeof(bool), typeof(ProfilePage_Dialog_Alert_Data), true);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "AlertType1":
                    return (int)value == 1 ? Color.FromHex("#4A9CFF") : Color.Black;
                case "AlertType2":
                    return (int)value == 2 ? Color.FromHex("#4A9CFF") : Color.Black;
                case "AlertType3":
                    return (int)value == 3 ? Color.FromHex("#4A9CFF") : Color.Black;
                case "AlertType4":
                    return (int)value == 4 ? Color.FromHex("#4A9CFF") : Color.Black;
                case "AlertType5":
                    return (int)value == 5 ? Color.FromHex("#4A9CFF") : Color.Black;
                case "ToggleBlocked":
                    return (bool)value;
                case "ConfirmButtonColor":
                    return ((int)value > 0 && (int)value < 5) || ((int)value == 5 && !string.IsNullOrWhiteSpace(AlertMessage)) ? Color.FromHex("#4A9CFF") : Color.FromHex("#C5C5C5");
                default:
                    break;
            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}