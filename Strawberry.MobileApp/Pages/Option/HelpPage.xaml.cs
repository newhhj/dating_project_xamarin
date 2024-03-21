using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Option
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpPage : BasePage
    {
        public HelpPage()
        {
            InitializeComponent();
        }

        public async Task ShowPageAsync()
        {
            await this.GetPageDataAsync();
            await App.Instance.MainPage.Navigation.PushAsync(this);
        }

        private async Task GetPageDataAsync()
        {
            using (var api = new ApiHelper())
            {
                var result = await api.GetHelpPageData(
                    new
                    {
                        Items = default(HelpPageItemData[])
                    });

                if (result.Items != null && result.Items.Length > 0)
                {
                    foreach (var item in result.Items)
                    {
                        this.pageData.Items.Add(item);
                    }
                }
            }
        }

        private void ClosePage_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.Navigation.PopAsync();
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
                var view = sender as View;
                var data = view.BindingContext as HelpPageItemData;

                var page = new HelpItemPage();
                await page.ShowPageAsync(data.Title, data.Content);
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }
    }

    public class HelpPageData : BindableObject
    {
        public ObservableCollection<HelpPageItemData> Items { get => (ObservableCollection<HelpPageItemData>)GetValue(ItemsProperty); set => SetValue(ItemsProperty, value); }
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<HelpPageItemData>), typeof(HelpPageData));

        public HelpPageData()
        {
            Items = new ObservableCollection<HelpPageItemData>();
        }
    }

    public class HelpPageItemData : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(HelpPageItemData));

        public string Title { get => (string)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(HelpPageItemData));

        public string Content { get => (string)GetValue(ContentProperty); set => SetValue(ContentProperty, value); }
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(string), typeof(HelpPageItemData));
    }
}