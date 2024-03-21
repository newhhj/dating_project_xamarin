using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Join
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Join_Confirm : BasePage, IValueConverter, IMultiValueConverter
    {
        public Page_Join_Confirm()
        {
            InitializeComponent();
        }

        private async void UpdateProfile_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new Pages.Join.Page_Join_Profile());
        }

        protected override void OnAppearing()
        {
            #region Remove Empty Image
            {
                var items = App.Instance.Member.ProfileImages
                    .Where(x => x.ProfileImageSource == null)
                    .ToArray();

                foreach (var item in items)
                    App.Instance.Member.ProfileImages.Remove(item);
            }
            #endregion

            base.OnAppearing();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                switch (parameter)
                {
                    case "JoinWaitVisible":
                        return (MemberStateTypes)value == MemberStateTypes.JoinWait;
                    case "JoinConfirmVisible":
                        return (MemberStateTypes)value == MemberStateTypes.JoinConfirm;
                    case "JoinDenyVisible":
                        return (MemberStateTypes)value == MemberStateTypes.JoinDeny;
                    case "NextButtonColor":
                        return (MemberStateTypes)value == MemberStateTypes.JoinConfirm ? Color.FromHex("#4A9CFF") : Color.FromHex("#C5C5C5");
                    case "Age":
                    {
                        var birthDay = (DateTime)value;
                        return DateTime.Today.Year - birthDay.Year + 1;
                    }
                    default:
                        throw new Exception();
                }
            }
            catch
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return values[0] == values[1] ? 20 : 10;
            }
            catch
            {
                return values;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (App.Instance.Member.MemberState != MemberStateTypes.JoinConfirm)
                    return;

                var nextPage = new Join.Page_Join_CharmingPoint();
                await nextPage.Init();
                await this.Navigation.PushAsync(nextPage);
            }
            catch (Exception ex)
            {
                await this.DisplayAlert("알림", ex.Message, "확인");
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }
    }
}