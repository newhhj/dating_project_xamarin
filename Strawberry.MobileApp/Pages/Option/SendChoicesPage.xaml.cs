using Rg.Plugins.Popup.Extensions;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Main;
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
    public partial class SendChoicesPage : BasePage
    {
        public SendChoicesPageData PageData
        {
            get => this.pageData;
            private set => this.pageData = value;
        }

        public SendChoicesPage()
        {
            InitializeComponent();
        }

        public async Task GetPageData()
        {
            using (var api = new ApiHelper())
            {
                var result = await api.GetSendChoicesPageData(
                    this.PageData.Items.Count,
                    new
                    {
                        Items = default(SendChoicesPageItemData[])
                    });

                if (result.Items != null && result.Items.Length > 0)
                {
                    foreach (var item in result.Items)
                        this.PageData.Items.Add(item);

                    this.PageData.HasMoreItem = true;
                }
                else
                {
                    this.PageData.HasMoreItem = false;
                }
            }
        }

        public async Task ShowPageAsync()
        {
            await this.GetPageData();
            await App.Instance.MainPage.Navigation.PushAsync(this);
        }

        private void ClosePage_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.Navigation.PopAsync();
        }

        private async void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (!this.PageData.HasMoreItem)
                return;

            var scrollView = sender as ScrollView;
            var maxScroll = Math.Max(0, scrollView.ContentSize.Height - scrollView.Height);

            if (maxScroll - e.ScrollY < 100)
            {
                lock (this.LockData)
                {
                    if (this.LockData.IsLocked)
                        return;
                    this.LockData.IsLocked = true;
                }

                try
                {
                    await this.GetPageData();
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

        private async void SmartChoice_Clicked(object sender, EventArgs e)
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
                var data = view.BindingContext as SendChoicesPageItemData;

                if (App.Instance.Member.Point < 10)
                {
                    var paymentDialog = new MainPage_Dialog_Payment(data.ProfileImage, data.Nickname);
                    await this.Navigation.PushPopupAsync(paymentDialog);
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
                while (ex.InnerException != null)
                    ex = ex.InnerException;

                await App.Instance.MainPage.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Remove_Clicked(object sender, EventArgs e)
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
                var data = view.BindingContext as SendChoicesPageItemData;

                using (var api = new ApiHelper())
                {
                    await api.ExcuteRemoveChoice(
                        data.Id,
                        data.MemberId);
                }

                this.PageData.Items.Remove(data);
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

    public class SendChoicesPageData : BindableObject
    {
        public bool HasMoreItem { get => (bool)GetValue(HasMoreItemProperty); set => SetValue(HasMoreItemProperty, value); }
        public static readonly BindableProperty HasMoreItemProperty = BindableProperty.Create(nameof(HasMoreItem), typeof(bool), typeof(SendChoicesPageData), true);

        public ObservableCollection<SendChoicesPageItemData> Items { get => (ObservableCollection<SendChoicesPageItemData>)GetValue(ItemsProperty); set => SetValue(ItemsProperty, value); }
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<SendChoicesPageItemData>), typeof(SendChoicesPageData));

        public SendChoicesPageData()
        {
            this.Items = new ObservableCollection<SendChoicesPageItemData>();
        }
    }

    public class SendChoicesPageItemData : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(SendChoicesPageItemData));

        public int MemberId { get => (int)GetValue(MemberIdProperty); set => SetValue(MemberIdProperty, value); }
        public static readonly BindableProperty MemberIdProperty = BindableProperty.Create(nameof(MemberId), typeof(int), typeof(SendChoicesPageItemData));

        public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
        public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(SendChoicesPageItemData));

        public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
        public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(SendChoicesPageItemData));

        public int Age { get => (int)GetValue(AgeProperty); set => SetValue(AgeProperty, value); }
        public static readonly BindableProperty AgeProperty = BindableProperty.Create(nameof(Age), typeof(int), typeof(SendChoicesPageItemData));

        public string Job { get => (string)GetValue(JobProperty); set => SetValue(JobProperty, value); }
        public static readonly BindableProperty JobProperty = BindableProperty.Create(nameof(Job), typeof(string), typeof(SendChoicesPageItemData));
    }
}