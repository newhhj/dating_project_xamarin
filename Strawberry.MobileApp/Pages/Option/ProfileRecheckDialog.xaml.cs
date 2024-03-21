using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Option
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileRecheckDialog : PopupPage
    {
        private LockDataModel LockData { get; set; } = new LockDataModel();
        private ProfileRecheckDialogData PageData { get => (ProfileRecheckDialogData)this.BindingContext; set => this.BindingContext = value; }

        public ProfileRecheckDialog()
        {
            InitializeComponent();
        }

        public Task ShowDialogAsync(string profileImage)
        {
            this.PageData.ProfileImage = profileImage;
            return App.Instance.MainPage.Navigation.PushPopupAsync(this);
        }

        private async void Recheck_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (App.Instance.Member.Point < 10)
                {
                    var profileRecheckPaymentDialog = new ProfileRecheckPaymentDialog();
                    await profileRecheckPaymentDialog.ShowDialogAsync();

                    await this.Navigation.PopPopupAsync();
                }
                else
                {
                    using (var api = new ApiHelper())
                    {
                        await api.ExcuteMemberLevelReCheck();
                        await this.Navigation.PopPopupAsync();
                        await App.Instance.MainPage.DisplayToastAsync("재측정이 요청되었습니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await this.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopPopupAsync();
        }
    }

    public class ProfileRecheckDialogData : BindableObject
    {
        public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
        public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(ProfileRecheckDialogData));
    }
}