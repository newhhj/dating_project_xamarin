using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Option
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PointLogPage : BasePage
	{
		public PointLogPage ()
		{
			InitializeComponent ();
		}

        private async Task GetPageDataAsync()
        {
            using (var api = new ApiHelper())
            {
                var result = await api.GetPointLogs(
                    this.PageData.Items.Count,
                    new
                    {
                        Items = default(PointLogItemData[])
                    });

                if (result.Items != null && result.Items.Length > 0)
                {
                    foreach (var item in result.Items)
                    {
                        this.PageData.Items.Add(item);
                    }
                }
            }
        }

        public async Task ShowPageAsync()
        {
            await this.GetPageDataAsync();
            await App.Instance.MainPage.Navigation.PushAsync(this);
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            var view = sender as ScrollView;
            if (e.ScrollY < view.ContentSize.Height - view.Height - 50)
                return;

            lock (this.LockData)
            {
                if (this.LockData.IsLocked)
                    return;
                this.LockData.IsLocked = true;
            }

            try
            {
                await this.GetPageDataAsync();
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

    public class PointLogPageData : BindableObject
    {
        public ObservableCollection<PointLogItemData> Items { get => (ObservableCollection<PointLogItemData>)GetValue(ItemsProperty); set => SetValue(ItemsProperty, value); }
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<PointLogItemData>), typeof(PointLogPageData));

        public PointLogPageData()
        {
            this.Items = new ObservableCollection<PointLogItemData>();
        }
    }

    public class PointLogItemData : BindableObject
    {
        public string Comment { get => (string)GetValue(CommentProperty); set => SetValue(CommentProperty, value); }
        public static readonly BindableProperty CommentProperty = BindableProperty.Create(nameof(Comment), typeof(string), typeof(PointLogItemData));

        public DateTime CreateTime { get => (DateTime)GetValue(CreateTimeProperty); set => SetValue(CreateTimeProperty, value); }
        public static readonly BindableProperty CreateTimeProperty = BindableProperty.Create(nameof(CreateTime), typeof(DateTime), typeof(PointLogItemData));

        public int AcceptPoint { get => (int)GetValue(AcceptPointProperty); set => SetValue(AcceptPointProperty, value); }
        public static readonly BindableProperty AcceptPointProperty = BindableProperty.Create(nameof(AcceptPoint), typeof(int), typeof(PointLogItemData));

        public int CurrentPoint { get => (int)GetValue(CurrentPointProperty); set => SetValue(CurrentPointProperty, value); }
        public static readonly BindableProperty CurrentPointProperty = BindableProperty.Create(nameof(CurrentPoint), typeof(int), typeof(PointLogItemData));

        public Color AcceptPointColor { get => (Color)GetValue(AcceptPointColorProperty); set => SetValue(AcceptPointColorProperty, value); }
        public static readonly BindableProperty AcceptPointColorProperty = BindableProperty.Create(nameof(AcceptPointColor), typeof(Color), typeof(PointLogItemData), Color.FromHex("14C46C"));

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.AcceptPoint):
                    this.SetAcceptPointColor();
                    break;
                default:
                    break;
            }
        }

        private void SetAcceptPointColor()
        {
            this.AcceptPointColor = this.AcceptPoint >= 0 ? Color.FromHex("14C46C") : Color.FromHex("FF2458");
        }
    }
}