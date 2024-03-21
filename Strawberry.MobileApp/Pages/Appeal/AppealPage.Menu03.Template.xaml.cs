using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using System;
using System.Collections.Generic;
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
    public partial class AppealPage_Menu03_Template : DataTemplate
    {
        private LockDataModel LockData { get; set; } = new LockDataModel();

        public AppealPage_Menu03_Template()
        {
            InitializeComponent();
        }

        private async void Item_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var element = sender as Element;
                var data = element.BindingContext as AppealPage_Menu03_Data;

                var page = new AppealDetailPage();
                await page.ShowAsync(data.Id);
            }
            catch (Exception ex)
            {
                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void ItemThumbnail_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var element = sender as Element;
                var data = element.BindingContext as AppealPage_Menu03_Data;
                while (data == null)
                {
                    if (element.Parent == null)
                        throw new Exception();

                    element = element.Parent;
                    data = element.BindingContext as AppealPage_Menu03_Data;
                }

                var page = new AppealDetailPage();
                await page.ShowAsync(data.Id);
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrWhiteSpace(ex.Message))
                    await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Alert_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                var element = sender as Element;
                var data = element.BindingContext as AppealPage_Menu03_Data;

                var dialog = new AppealDetailAlertDialog();
                var result = await dialog.ShowDialogAsync();
                if (string.IsNullOrWhiteSpace(result.title))
                    return;

                using (var api = new ApiHelper())
                {
                    await api.ExcuteAlertPoomPoom(
                        result.title,
                        result.message,
                        data.Id,
                        data.MemberId);

                    await App.Instance.MainPage.DisplayToastAsync("신고되었습니다.");
                }
            }
            catch (Exception ex)
            {
                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private void Grid_SizeChanged(object sender, EventArgs e)
        {
            var view = sender as View;
            if (view.Width <= 0)
                return;

            view.HeightRequest = view.Width * 0.59d;
        }
    }
}