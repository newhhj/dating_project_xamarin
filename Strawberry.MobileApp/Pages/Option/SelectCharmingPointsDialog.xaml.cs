using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Strawberry.MobileApp.Pages.Join;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    public partial class SelectCharmingPointsDialog : PopupPage
    {
        public SelectCharmingPointsDialogData PageData
        {
            get => (SelectCharmingPointsDialogData)this.BindingContext;
            set => this.BindingContext = value;
        }

        private TaskCompletionSource<string[]> TaskCompletionSource { get; set; }

        public SelectCharmingPointsDialog()
        {
            InitializeComponent();
        }

        public async Task<string[]> ShowDialogAsync(string[] items)
        {
            this.PageData = new SelectCharmingPointsDialogData();
            this.TaskCompletionSource = new TaskCompletionSource<string[]>();

            var text = "1인가구/즐거운 술자리/연락이 잘되요/미소가 이뻐요/비율이 좋아요/맛집도사/다리가 예뻐요/뇌색/허세 없어요/뛰어난 커리어/운동 잘해요/춤을 잘 춰요/긍정적 마인드/소통을 잘해요/유머감각/이야기를 잘 들어줘요/목소리가 좋아요/동안이예요/예의와 매너 굿/다정해요/패션 감각/솔직해요/애교 많아요/피부가 좋아요/웃음이 많아요/털털해요/장난기가 많아요/엉덩이가 예뻐요/경제력/한 사람만 봐요/ISTJ/ISFJ/INFJ/INTJ/ISTP/ISFP/INFP/INTP/ESTP/ESFP/ENFP/ENTP/ESTJ/ESFJ/ENFJ/ENTJ";
            var texts = text.Split('/');

            foreach (var item in texts)
            {
                this.PageData.Items.Add(new SelectCharmingPointsItemData
                {
                    Name = item,
                    IsSelected = items?.Any(x => x == item) ?? false
                });
            }

            await App.Instance.MainPage.Navigation.PushPopupAsync(this);
            return await this.TaskCompletionSource.Task;
        }

        protected override bool OnBackButtonPressed()
        {
            this.TaskCompletionSource.SetResult(null);
            return base.OnBackButtonPressed();
        }

        protected override bool OnBackgroundClicked()
        {
            this.TaskCompletionSource.SetResult(null);
            return base.OnBackgroundClicked();
        }

        private void Item_Clicked(object sender, EventArgs e)
        {
            var data = (SelectCharmingPointsItemData)((View)sender).BindingContext;

            if (!data.IsSelected && this.PageData.Items.Count(x => x.IsSelected) >= 3)
            {
                return;
            }
            else
            {
                data.IsSelected = !data.IsSelected;
            }
        }

        private void Accept_Clicked(object sender, EventArgs e)
        {
            var result = this.PageData.Items
                .Where(x => x.IsSelected)
                .Select(x => x.Name)
                .ToArray();

            this.TaskCompletionSource.SetResult(result);
            this.Navigation.PopPopupAsync();
        }
    }

    public class SelectCharmingPointsDialogData : BindableObject
    {
        public ObservableCollection<SelectCharmingPointsItemData> Items { get => (ObservableCollection<SelectCharmingPointsItemData>)GetValue(ItemsProperty); set => SetValue(ItemsProperty, value); }
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<SelectCharmingPointsItemData>), typeof(SelectCharmingPointsDialogData));

        

        public SelectCharmingPointsDialogData()
        {
            this.Items = new ObservableCollection<SelectCharmingPointsItemData>();
        }
    }

    public class SelectCharmingPointsItemData : BindableObject
    {
        public string Name { get => (string)GetValue(NameProperty); set => SetValue(NameProperty, value); }
        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(SelectCharmingPointsItemData));

        public bool IsSelected { get => (bool)GetValue(IsSelectedProperty); set => SetValue(IsSelectedProperty, value); }
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(SelectCharmingPointsItemData), false);

        public Color ItemBackgroundColor { get => (Color)GetValue(ItemBackgroundColorProperty); set => SetValue(ItemBackgroundColorProperty, value); }
        public static readonly BindableProperty ItemBackgroundColorProperty = BindableProperty.Create(nameof(ItemBackgroundColor), typeof(Color), typeof(SelectCharmingPointsItemData), Color.FromHex("#E9E9E9"));

        public Color ItemTextColor { get => (Color)GetValue(ItemTextColorProperty); set => SetValue(ItemTextColorProperty, value); }
        public static readonly BindableProperty ItemTextColorProperty = BindableProperty.Create(nameof(ItemTextColor), typeof(Color), typeof(SelectCharmingPointsItemData), Color.FromHex("#707070"));

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.IsSelected):
                    this.ItemBackgroundColor = this.IsSelected ? Color.FromHex("#194A9CFF") : Color.FromHex("#E9E9E9");
                    this.ItemTextColor = this.IsSelected ? Color.FromHex("#4A9CFF") : Color.FromHex("#707070");
                    break;
                default:
                    break;
            }
        }
    }
}