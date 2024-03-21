using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Main;
using Strawberry.MobileApp.Pages.Profile;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.RecommandPartner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecommendPartnersPage : BasePage
    {
        public RecommendPartnersPage_Data PageData
        {
            get => (RecommendPartnersPage_Data)this.BindingContext; 
            private set => this.BindingContext = value;
        }

        public RecommendPartnersPage(int dataType)
        {
            InitializeComponent();

            this.PageData = new RecommendPartnersPage_Data
            {
                DataType = dataType,
                Items = new ObservableCollection<RecommendPartnersPage_Data_Item>()
            };
        }

        public async Task GetItems()
        {
            using (var api = new ApiHelper())
            {
                var result = await api.GetRecommandPartners(
                    this.PageData.DataType,
                    this.PageData.Items.Count,
                    new
                    {
                        Partners = default(RecommendPartnersPage_Data_Item[])
                    });

                if (result.Partners != null && result.Partners.Length > 0)
                {
                    foreach (var item in result.Partners)
                    {
                        this.PageData.Items.Add(item);
                    }
                }
            }
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            var view = (ScrollView)sender;
            if (view.ContentSize.Height - view.Height - 10 <= e.ScrollY)
            {
                lock (this.LockData)
                {
                    if (this.LockData.IsLocked)
                        return;
                    this.LockData.IsLocked = true;
                }

                try
                {
                    await this.GetItems();
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

        private async void Profile_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var element = (Element)sender;
                var data = (RecommendPartnersPage_Data_Item)element.BindingContext;

                {
                    var dialog = new Shares.ConfirmDialog("딸기 5개가 필요해요", "딸기를 소모하여 프로필을 확인하시겠습니까?");
                    var result = await dialog.ShowDialog();
                    if (!result)
                        return;
                }

                if (App.Instance.Member.Point < 5)
                {
                    var dialog = new MainPage_Dialog_Payment(data.ProfileImage, data.Nickname);
                    await this.Navigation.PushPopupAsync(dialog);
                    return;
                }

                var profilePage = new ProfilePage_Partner();
                await profilePage.GetDataAsync(data.Id, false);
                await this.Navigation.PushAsync(profilePage);
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

        private async void Choice_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var element = (Element)sender;
                var data = (RecommendPartnersPage_Data_Item)element.BindingContext;

                if (App.Instance.Member.FreeChoiceCount > 0)
                {
                    var dialog = new Shares.ConfirmDialog("무료 좋아요가 가능합니다.", "무료 좋아요를 사용하시겠습니까?");
                    var result = await dialog.ShowDialog();
                    if (!result)
                        return;
                }
                else if (App.Instance.Member.Point < 5)
                {
                    var dialog = new MainPage_Dialog_Payment(data.ProfileImage, data.Nickname);
                    await this.Navigation.PushPopupAsync(dialog);
                    return;
                }
                else if (App.Instance.Member.Point >= 5)
                {
                    var dialog = new Shares.ConfirmDialog("딸기 5개가 필요해요", "딸기를 소모하여 좋아요를 보내시겠습니까?");
                    var result = await dialog.ShowDialog();
                    if (!result)
                        return;
                }

                using (var api = new ApiHelper())
                {
                    var result = await api.ExcuteChoice(data.Id, new
                    {
                        FreeChoiceCount = default(int),
                        Point = default(int)
                    });

                    App.Instance.Member.FreeChoiceCount = result.FreeChoiceCount;
                    App.Instance.Member.Point = result.Point;

                    this.PageData.Items.Remove(data);

                    await this.DisplayToastAsync("좋아요를 보냈습니다.");
                }
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

        private async void SmartChoice_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var element = (Element)sender;
                var data = (RecommendPartnersPage_Data_Item)element.BindingContext;

                if (App.Instance.Member.Point < 10)
                {
                    var dialog = new MainPage_Dialog_Payment(data.ProfileImage, data.Nickname);
                    await this.Navigation.PushPopupAsync(dialog);
                    return;
                }
                else if (App.Instance.Member.Point >= 10)
                {
                    var dialog = new Shares.ConfirmDialog("딸기 10개가 필요해요", "딸기를 소모하여 좋아요를 보내시겠습니까?");
                    var result = await dialog.ShowDialog();
                    if (!result)
                        return;
                }

                var messageDialog = new MainPage_Dialog_SendSmartChoice(data.Nickname, data.ProfileImage);
                await this.Navigation.PushPopupAsync(messageDialog);
                var message = await messageDialog.TaskCompletionSource.Task;

                if (string.IsNullOrWhiteSpace(message))
                    return;

                using (var api = new ApiHelper())
                {
                    var result = await api.ExcuteSmartChoice(data.Id, message, new
                    {
                        Point = default(int)
                    });

                    App.Instance.Member.Point = result.Point;

                    this.PageData.Items.Remove(data);

                    await this.DisplayToastAsync("좋아요를 보냈습니다.");
                }
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