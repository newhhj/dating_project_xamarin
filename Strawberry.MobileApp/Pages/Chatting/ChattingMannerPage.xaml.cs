using Rg.Plugins.Popup.Extensions;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Main;
using Strawberry.MobileApp.Pages.Shares;
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
    public partial class ChattingMannerPage : BasePage
    {
        private int RoomId { get; set; }

        public ChattingMannerPage()
        {
            InitializeComponent();
        }

        public Task ShowPageAsync(int roomId)
        {
            this.RoomId = roomId;
            return App.Instance.MainPage.Navigation.PushAsync(this);
        }

        private void Item01_Clicked(object sender, EventArgs e)
        {
            var item = "친절하고 매너가 좋아요.";
            if (this.pageData.SelectedItems.Any(x => x == item))
            {
                this.pageData.SelectedItems.Remove(item);
                this.pageData.Item01Selected = false;
            }
            else
            {
                this.pageData.SelectedItems.Add(item);
                this.pageData.Item01Selected = true;
            }
        }

        private void Item02_Clicked(object sender, EventArgs e)
        {
            var item = "응답이 빨라요.";
            if (this.pageData.SelectedItems.Any(x => x == item))
            {
                this.pageData.SelectedItems.Remove(item);
                this.pageData.Item02Selected = false;
            }
            else
            {
                this.pageData.SelectedItems.Add(item);
                this.pageData.Item02Selected = true;
            }
        }

        private void Item03_Clicked(object sender, EventArgs e)
        {
            var item = "커플이 되었어요.";
            if (this.pageData.SelectedItems.Any(x => x == item))
            {
                this.pageData.SelectedItems.Remove(item);
                this.pageData.Item03Selected = false;
            }
            else
            {
                this.pageData.SelectedItems.Add(item);
                this.pageData.Item03Selected = true;
            }
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void Accept_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (this.pageData.SelectedItems.Count == 0)
                    throw new Exception("한 가지 이상을 선택하세요.");


                using (var api = new ApiHelper())
                {
                    await api.ExcuteMannerAndRemoveChattingRoom(
                        this.RoomId,
                        DataModels.AppraisalTypes.Manner,
                        this.pageData.SelectedItems.ToArray());
                }

                var mainPage = (MainPage)App.Instance.MainPage.Navigation.NavigationStack
                    .FirstOrDefault(x => x is MainPage);

                var mainPageData = mainPage.BindingContext as MainPage_Data;
                var item = mainPageData.Items
                    .Where(x => x is MainPage_View12_Data)
                    .Where(x => ((MainPage_View12_Data)x).Id == this.RoomId)
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

                await this.Navigation.PopAsync();
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