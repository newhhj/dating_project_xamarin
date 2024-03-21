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
    public partial class SelectInterestsDialog : PopupPage
    {
        public SelectInterestsDialogData PageData
        {
            get => (SelectInterestsDialogData)this.BindingContext;
            set => this.BindingContext = value;
        }

        private TaskCompletionSource<string[]> TaskCompletionSource { get; set; }

        public SelectInterestsDialog()
        {
            InitializeComponent();
        }

        public async Task<string[]> ShowDialogAsync(string[] items)
        {
            this.PageData = new SelectInterestsDialogData();
            this.TaskCompletionSource = new TaskCompletionSource<string[]>();

            var text = "즐거운 음주/영화관람/맛집탐방/진지한 만남/훈남훈녀/놀이동산/넷플릭스/음주가무/혼술/IT/봉사활동/가벼운 술자리/결혼/패션/명품/애플신상/파티/자기개발/운동 스포츠/드라이브/얼리어답터/비혼/퇴근 한잔/재혼/웹툰/지구환경/웰빙/요리/건강 헬스/친구만 원해/국내 여행/해외 여행/클럽/음악 노래/쇼핑/전시 박람/캠핑 레져/재테크/휴양지/외국어";
            var texts = text.Split('/');

            foreach (var item in texts)
            {
                this.PageData.Items.Add(new SelectInterestsItemData
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
            var data = (SelectInterestsItemData)((View)sender).BindingContext;

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

    public class SelectInterestsDialogData : BindableObject
    {
        public ObservableCollection<SelectInterestsItemData> Items { get => (ObservableCollection<SelectInterestsItemData>)GetValue(ItemsProperty); set => SetValue(ItemsProperty, value); }
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<SelectInterestsItemData>), typeof(SelectInterestsDialogData));

        

        public SelectInterestsDialogData()
        {
            this.Items = new ObservableCollection<SelectInterestsItemData>();
        }
    }

    public class SelectInterestsItemData : BindableObject
    {
        public string Name { get => (string)GetValue(NameProperty); set => SetValue(NameProperty, value); }
        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(SelectInterestsItemData));

        public bool IsSelected { get => (bool)GetValue(IsSelectedProperty); set => SetValue(IsSelectedProperty, value); }
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(SelectInterestsItemData), false);

        public Color ItemBackgroundColor { get => (Color)GetValue(ItemBackgroundColorProperty); set => SetValue(ItemBackgroundColorProperty, value); }
        public static readonly BindableProperty ItemBackgroundColorProperty = BindableProperty.Create(nameof(ItemBackgroundColor), typeof(Color), typeof(SelectInterestsItemData), Color.FromHex("#E9E9E9"));

        public Color ItemTextColor { get => (Color)GetValue(ItemTextColorProperty); set => SetValue(ItemTextColorProperty, value); }
        public static readonly BindableProperty ItemTextColorProperty = BindableProperty.Create(nameof(ItemTextColor), typeof(Color), typeof(SelectInterestsItemData), Color.FromHex("#707070"));

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