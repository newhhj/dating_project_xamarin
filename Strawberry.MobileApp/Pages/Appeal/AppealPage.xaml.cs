using Newtonsoft.Json.Linq;
using Rg.Plugins.Popup.Extensions;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Appeal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppealPage : BasePage
    {
        public AppealPage()
        {
            InitializeComponent();
        }

        public async Task GetItems()
        {
            using (var api = new ApiHelper())
            {
                var result = await api.GetPoomPooms(
                    this.pageData.ContentType,
                    this.pageData.Items.Count,
                    new
                    {
                        Top5Items = default(AppealPage_Top5_Data[]),
                        Items = default(JObject[])
                    });

                if (this.pageData.Items.Count == 0 && result.Top5Items != null && result.Top5Items.Length > 0)
                {
                    var index = 0;
                    foreach (var item in this.pageData.Top5Items)
                    {
                        item.Index = index;
                        index++;

                        this.pageData.Top5Items.Add(item);
                    }
                }

                if (result.Items != null && result.Items.Length > 0)
                {
                    foreach (var item in result.Items)
                    {
                        switch (this.pageData.ContentType)
                        {
                            case AppealPage_Data.ContentTypes.Boast:
                                this.pageData.Items.Add(item.ToObject<AppealPage_Menu01_Data>());
                                break;
                            case AppealPage_Data.ContentTypes.Metting:
                                this.pageData.Items.Add(item.ToObject<AppealPage_Menu02_Data>());
                                break;
                            case AppealPage_Data.ContentTypes.Sell:
                                this.pageData.Items.Add(item.ToObject<AppealPage_Menu03_Data>());
                                break;
                            case AppealPage_Data.ContentTypes.Talk:
                                this.pageData.Items.Add(item.ToObject<AppealPage_Menu04_Data>());
                                break;
                            default:
                                break;
                        }
                        
                    }
                }
                else
                {
                    this.pageData.HasMoreData = false;
                }
            }
        }

        private async void Menu01_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                this.pageData.HasMoreData = true;
                this.pageData.ContentType = AppealPage_Data.ContentTypes.Boast;
                this.pageData.Top5Items.Clear();
                this.pageData.Items.Clear();
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

        private async void Menu02_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                this.pageData.HasMoreData = true;
                this.pageData.ContentType = AppealPage_Data.ContentTypes.Metting;
                this.pageData.Top5Items.Clear();
                this.pageData.Items.Clear();
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

        private async void Menu03_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                this.pageData.HasMoreData = true;
                this.pageData.ContentType = AppealPage_Data.ContentTypes.Sell;
                this.pageData.Top5Items.Clear();
                this.pageData.Items.Clear();
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

        private async void Menu04_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                this.pageData.HasMoreData = true;
                this.pageData.ContentType = AppealPage_Data.ContentTypes.Talk;
                this.pageData.Top5Items.Clear();
                this.pageData.Items.Clear();
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

        private async void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            var scrollView = sender as ScrollView;
            if (e.ScrollY + scrollView.Height + 10 < scrollView.ContentSize.Height)
                return;

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                if (!this.pageData.HasMoreData)
                    return;

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

        private async void Write_Clicked(object sender, EventArgs e)
        {
            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var dialog = new AppealWriteDialog();
                var contentType = await dialog.ShowAsync();
                if (!contentType.HasValue)
                    return;

                var writePage = new AppealWritePage(contentType.Value);
                var isWrite = await writePage.ShowAsync();
                if (isWrite)
                {
                    if (contentType == AppealPage_Data.ContentTypes.Boast)
                    {
                        await this.DisplayToastAsync("등록되었습니다.");
                    }
                    else
                    {
                        this.pageData.Items.Clear();
                        await this.GetItems();
                    }
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

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.Navigation.PopAsync();
        }
    }
}