using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Join
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Join_PhoneCert : BasePage
    {
        public string PhoneNumber { get; }
        public string Code { get; }

        public Page_Join_PhoneCert(string phoneNumber, string code)
        {
            InitializeComponent();
            this.PhoneNumber = phoneNumber;
            this.Code = code;
        }


        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var view = sender as Entry;
            var txt = e.NewTextValue?.Replace(" ", "");

            if (string.IsNullOrWhiteSpace(txt))
            {
                view.Text = txt;
                return;
            }

            if (Regex.IsMatch(txt, "[^0-9]"))
            {
                view.Text = e.OldTextValue;
                return;
            }

            if (txt.Length > 1)
            {
                if (!string.IsNullOrWhiteSpace(e.OldTextValue))
                    view.Text = txt = txt.Replace(e.OldTextValue, "");

                view.Text = view.Text.Substring(0, 1);
            }

            if (Regex.IsMatch(txt, "^[0-9]{1}$"))
            {
                var tabs = view.GetTabIndexesOnParentPage(out _);
                var currentTabIndex = view.TabIndex;
                var nextView = view.FindNextElement(true, tabs, ref currentTabIndex);
                (nextView as VisualElement)?.Focus();
            }
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
                if (!this.PageData.UseNextButton)
                    return;

                if (this.PageData.Code != this.Code)
                    throw new Exception("인증번호를 다시 확인해주세요.");

                App.Instance.Member.PhoneNumber = this.PhoneNumber;

                await this.Navigation.PushAsync(new Page_Join_Email());

                var pages = this.Navigation.NavigationStack.Where(x => x is Page_Join_Phone || x is Page_Join_PhoneCert).ToArray();
                foreach (var page in pages)
                    this.Navigation.RemovePage(page);
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