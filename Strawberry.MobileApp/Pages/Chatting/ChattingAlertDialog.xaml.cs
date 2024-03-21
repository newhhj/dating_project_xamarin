using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Chatting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChattingAlertDialog : PopupPage
    {
        public LockDataModel LockData { get; set; } = new LockDataModel();

        public ChattingPageData PageData
        {
            get => (ChattingPageData)this.BindingContext;
            private set => this.BindingContext = value;
        }

        public Task ShowDialogAsync(ChattingPageData data)
        {
            this.PageData = data;
            return App.Instance.MainPage.Navigation.PushPopupAsync(this);
        }

        public ChattingAlertDialog()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            this.Navigation.PopPopupAsync();
            return base.OnBackButtonPressed();
        }

        protected override bool OnBackgroundClicked()
        {
            this.Navigation.PopPopupAsync();
            return base.OnBackgroundClicked();
        }

        private async void Close_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                using (var api = new ApiHelper())
                {
                    await api.ExcuteRemoveChattingRoom(this.PageData.Room.Id);
                }

                var mainPage = (MainPage)App.Instance.MainPage.Navigation.NavigationStack
                    .FirstOrDefault(x => x is MainPage);

                var mainPageData = mainPage.BindingContext as MainPage_Data;
                var item = mainPageData.Items
                    .Where(x => x is MainPage_View12_Data)
                    .Where(x => ((MainPage_View12_Data)x).Id == this.PageData.Room.Id)
                    .FirstOrDefault();

                if (item != null)
                {
                    mainPageData.Items.Remove(item);
                }

                var chattingPage = (ChattingPage)App.Instance.MainPage.Navigation.NavigationStack
                    .FirstOrDefault(x => x is ChattingPage);

                if (chattingPage != null)
                {
                    App.Instance.MainPage.Navigation.RemovePage(chattingPage);
                }

                await this.Navigation.PopPopupAsync();
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

        private async void Block_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                using (var api = new ApiHelper())
                {
                    await api.ExcuteBlockAndRemoveChattingRoom(this.PageData.Room.Id);
                }

                var mainPage = (MainPage)App.Instance.MainPage.Navigation.NavigationStack
                    .FirstOrDefault(x => x is MainPage);

                var mainPageData = mainPage.BindingContext as MainPage_Data;
                var item = mainPageData.Items
                    .Where(x => x is MainPage_View12_Data)
                    .Where(x => ((MainPage_View12_Data)x).Id == this.PageData.Room.Id)
                    .FirstOrDefault();

                if (item != null)
                {
                    mainPageData.Items.Remove(item);
                }

                var chattingPage = (ChattingPage)App.Instance.MainPage.Navigation.NavigationStack
                    .FirstOrDefault(x => x is ChattingPage);

                if (chattingPage != null)
                {
                    App.Instance.MainPage.Navigation.RemovePage(chattingPage);
                }

                await this.Navigation.PopPopupAsync();
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

        private void Alert_Clicked(object sender, EventArgs e)
        {
            this.stackLayout01.IsVisible = false;
            this.stackLayout02.IsVisible = true;
        }

        private async void Manner_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var page = new ChattingMannerPage();
                await page.ShowPageAsync(this.PageData.Room.Id);
                await this.Navigation.PopPopupAsync();
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

        private async void BadManner_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var page = new ChattingBadMannerPage();
                await page.ShowPageAsync(this.PageData.Room.Id);
                await this.Navigation.PopPopupAsync();
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