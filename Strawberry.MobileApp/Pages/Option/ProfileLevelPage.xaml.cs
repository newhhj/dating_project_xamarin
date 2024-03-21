using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Intro;
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
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Option
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileLevelPage : BasePage, IMultiValueConverter
    {
        public ProfileLevelPageData PageData { get => (ProfileLevelPageData)this.BindingContext; set => this.BindingContext = value; }

        public ProfileLevelPage()
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
                var result = await api.GetProfileLevelPageData(new
                {
                    Item = default(ProfileLevelPageData)
                });

                this.PageData = result.Item;
            }
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == values[1])
                return 20;
            else
                return 10;

            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void Rechecked_Clicked(object sender, EventArgs e)
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
                    var result = await api.GetHasProfileRecheckLog(new
                    {
                        HasValue = default(bool)
                    });

                    if (!result.HasValue)
                    {
                        var profileImage = this.PageData.ProfileImages.FirstOrDefault();
                        var dialog = new ProfileRecheckDialog();
                        await dialog.ShowDialogAsync(profileImage);
                    }
                    else
                    {
                        await this.DisplayToastAsync("재측정을 이미 요청했습니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;
                await this.DisplayToastAsync(ex.Message);
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }
    }

    public class ProfileLevelPageData : BindableObject
    {
        public ObservableCollection<string> ProfileImages { get => (ObservableCollection<string>)GetValue(ProfileImagesProperty); set => SetValue(ProfileImagesProperty, value); }
        public static readonly BindableProperty ProfileImagesProperty = BindableProperty.Create(nameof(ProfileImages), typeof(ObservableCollection<string>), typeof(ProfileLevelPageData));

        public LevelTypes LevelType { get => (LevelTypes)GetValue(LevelTypeProperty); set => SetValue(LevelTypeProperty, value); }
        public static readonly BindableProperty LevelTypeProperty = BindableProperty.Create(nameof(LevelType), typeof(LevelTypes), typeof(ProfileLevelPageData));

        public double LevelPoint { get => (double)GetValue(LevelPointProperty); set => SetValue(LevelPointProperty, value); }
        public static readonly BindableProperty LevelPointProperty = BindableProperty.Create(nameof(LevelPoint), typeof(double), typeof(ProfileLevelPageData));



        public string LevelText { get => (string)GetValue(LevelTextProperty); set => SetValue(LevelTextProperty, value); }
        public static readonly BindableProperty LevelTextProperty = BindableProperty.Create(nameof(LevelText), typeof(string), typeof(ProfileLevelPageData), "실버 0.00점");

        public bool IsVisibleTierBar01 { get => (bool)GetValue(IsVisibleTierBar01Property); set => SetValue(IsVisibleTierBar01Property, value); }
        public static readonly BindableProperty IsVisibleTierBar01Property = BindableProperty.Create(nameof(IsVisibleTierBar01), typeof(bool), typeof(ProfileLevelPageData), true);

        public bool IsVisibleTierBar02 { get => (bool)GetValue(IsVisibleTierBar02Property); set => SetValue(IsVisibleTierBar02Property, value); }
        public static readonly BindableProperty IsVisibleTierBar02Property = BindableProperty.Create(nameof(IsVisibleTierBar02), typeof(bool), typeof(ProfileLevelPageData), false);

        public bool IsVisibleTierBar03 { get => (bool)GetValue(IsVisibleTierBar03Property); set => SetValue(IsVisibleTierBar03Property, value); }
        public static readonly BindableProperty IsVisibleTierBar03Property = BindableProperty.Create(nameof(IsVisibleTierBar03), typeof(bool), typeof(ProfileLevelPageData), false);

        public bool IsVisibleTierBar04 { get => (bool)GetValue(IsVisibleTierBar04Property); set => SetValue(IsVisibleTierBar04Property, value); }
        public static readonly BindableProperty IsVisibleTierBar04Property = BindableProperty.Create(nameof(IsVisibleTierBar04), typeof(bool), typeof(ProfileLevelPageData), false);

        public Color Tier01TextColor { get => (Color)GetValue(Tier01TextColorProperty); set => SetValue(Tier01TextColorProperty, value); }
        public static readonly BindableProperty Tier01TextColorProperty = BindableProperty.Create(nameof(Tier01TextColor), typeof(Color), typeof(ProfileLevelPageData), Color.FromHex("#4A9CFF"));

        public Color Tier02TextColor { get => (Color)GetValue(Tier02TextColorProperty); set => SetValue(Tier02TextColorProperty, value); }
        public static readonly BindableProperty Tier02TextColorProperty = BindableProperty.Create(nameof(Tier02TextColor), typeof(Color), typeof(ProfileLevelPageData), Color.FromHex("#7A7A7A"));

        public Color Tier03TextColor { get => (Color)GetValue(Tier03TextColorProperty); set => SetValue(Tier03TextColorProperty, value); }
        public static readonly BindableProperty Tier03TextColorProperty = BindableProperty.Create(nameof(Tier03TextColor), typeof(Color), typeof(ProfileLevelPageData), Color.FromHex("#7A7A7A"));

        public Color Tier04TextColor { get => (Color)GetValue(Tier04TextColorProperty); set => SetValue(Tier04TextColorProperty, value); }
        public static readonly BindableProperty Tier04TextColorProperty = BindableProperty.Create(nameof(Tier04TextColor), typeof(Color), typeof(ProfileLevelPageData), Color.FromHex("#7A7A7A"));




        public bool IsVisibleTier01AreaBar { get => (bool)GetValue(IsVisibleTier01AreaBarProperty); set => SetValue(IsVisibleTier01AreaBarProperty, value); }
        public static readonly BindableProperty IsVisibleTier01AreaBarProperty = BindableProperty.Create(nameof(IsVisibleTier01AreaBar), typeof(bool), typeof(ProfileLevelPageData), true);

        public bool IsVisibleTier02AreaBar { get => (bool)GetValue(IsVisibleTier02AreaBarProperty); set => SetValue(IsVisibleTier02AreaBarProperty, value); }
        public static readonly BindableProperty IsVisibleTier02AreaBarProperty = BindableProperty.Create(nameof(IsVisibleTier02AreaBar), typeof(bool), typeof(ProfileLevelPageData), false);

        public bool IsVisibleTier03AreaBar { get => (bool)GetValue(IsVisibleTier03AreaBarProperty); set => SetValue(IsVisibleTier03AreaBarProperty, value); }
        public static readonly BindableProperty IsVisibleTier03AreaBarProperty = BindableProperty.Create(nameof(IsVisibleTier03AreaBar), typeof(bool), typeof(ProfileLevelPageData), false);

        public bool IsVisibleTier01Pointer { get => (bool)GetValue(IsVisibleTier01PointerProperty); set => SetValue(IsVisibleTier01PointerProperty, value); }
        public static readonly BindableProperty IsVisibleTier01PointerProperty = BindableProperty.Create(nameof(IsVisibleTier01Pointer), typeof(bool), typeof(ProfileLevelPageData), true);

        public bool IsVisibleTier02Pointer { get => (bool)GetValue(IsVisibleTier02PointerProperty); set => SetValue(IsVisibleTier02PointerProperty, value); }
        public static readonly BindableProperty IsVisibleTier02PointerProperty = BindableProperty.Create(nameof(IsVisibleTier02Pointer), typeof(bool), typeof(ProfileLevelPageData), true);

        public bool IsVisibleTier03Pointer { get => (bool)GetValue(IsVisibleTier03PointerProperty); set => SetValue(IsVisibleTier03PointerProperty, value); }
        public static readonly BindableProperty IsVisibleTier03PointerProperty = BindableProperty.Create(nameof(IsVisibleTier03Pointer), typeof(bool), typeof(ProfileLevelPageData), false);

        public bool IsVisibleTier04Pointer { get => (bool)GetValue(IsVisibleTier04PointerProperty); set => SetValue(IsVisibleTier04PointerProperty, value); }
        public static readonly BindableProperty IsVisibleTier04PointerProperty = BindableProperty.Create(nameof(IsVisibleTier04Pointer), typeof(bool), typeof(ProfileLevelPageData), false);

        public Color Tier01AreaTextColor { get => (Color)GetValue(Tier01AreaTextColorProperty); set => SetValue(Tier01AreaTextColorProperty, value); }
        public static readonly BindableProperty Tier01AreaTextColorProperty = BindableProperty.Create(nameof(Tier01AreaTextColor), typeof(Color), typeof(ProfileLevelPageData), Color.FromHex("#4A9CFF"));

        public Color Tier02AreaTextColor { get => (Color)GetValue(Tier02AreaTextColorProperty); set => SetValue(Tier02AreaTextColorProperty, value); }
        public static readonly BindableProperty Tier02AreaTextColorProperty = BindableProperty.Create(nameof(Tier02AreaTextColor), typeof(Color), typeof(ProfileLevelPageData), Color.FromHex("#4A9CFF"));

        public Color Tier03AreaTextColor { get => (Color)GetValue(Tier03AreaTextColorProperty); set => SetValue(Tier03AreaTextColorProperty, value); }
        public static readonly BindableProperty Tier03AreaTextColorProperty = BindableProperty.Create(nameof(Tier03AreaTextColor), typeof(Color), typeof(ProfileLevelPageData), Color.FromHex("#7A7A7A"));

        public Color Tier04AreaTextColor { get => (Color)GetValue(Tier04AreaTextColorProperty); set => SetValue(Tier04AreaTextColorProperty, value); }
        public static readonly BindableProperty Tier04AreaTextColorProperty = BindableProperty.Create(nameof(Tier04AreaTextColor), typeof(Color), typeof(ProfileLevelPageData), Color.FromHex("#7A7A7A"));

        public ProfileLevelPageData()
        {
            this.ProfileImages = new ObservableCollection<string>();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.LevelType):
                case nameof(this.LevelPoint):
                    this.SetLevelText();
                    this.SetIsVisibleTierBar();
                    this.SetTierTextColor();
                    this.SetIsVisibleTierAreaBar();
                    this.SetIsVisibleTierPointer();
                    this.SetTierAreaTextColor();
                    break;
                default:
                    break;
            }
        }

        private void SetTierAreaTextColor()
        {
            this.Tier01AreaTextColor = (int)this.LevelType == 0 ? Color.FromHex("#4A9CFF") : Color.FromHex("#7A7A7A");
            this.Tier02AreaTextColor = (int)this.LevelType == 0 || (int)this.LevelType == 1 ? Color.FromHex("#4A9CFF") : Color.FromHex("#7A7A7A");
            this.Tier03AreaTextColor = (int)this.LevelType == 1 || (int)this.LevelType >= 2 ? Color.FromHex("#4A9CFF") : Color.FromHex("#7A7A7A");
            this.Tier04AreaTextColor = (int)this.LevelType >= 2 ? Color.FromHex("#4A9CFF") : Color.FromHex("#7A7A7A");
        }

        private void SetIsVisibleTierPointer()
        {
            this.IsVisibleTier01Pointer = (int)this.LevelType == 0;
            this.IsVisibleTier02Pointer = (int)this.LevelType == 0 || (int)this.LevelType == 1;
            this.IsVisibleTier03Pointer = (int)this.LevelType == 1 || (int)this.LevelType >= 2;
            this.IsVisibleTier04Pointer = (int)this.LevelType >= 2;
        }

        private void SetIsVisibleTierAreaBar()
        {
            this.IsVisibleTier01AreaBar = (int)this.LevelType == 0;
            this.IsVisibleTier02AreaBar = (int)this.LevelType == 1;
            this.IsVisibleTier03AreaBar = (int)this.LevelType >= 2;
        }

        private void SetTierTextColor()
        {
            this.Tier01TextColor = this.LevelType == LevelTypes.Silver ? Color.FromHex("#4A9CFF") : Color.FromHex("#7A7A7A");
            this.Tier02TextColor = this.LevelType == LevelTypes.Gold ? Color.FromHex("#4A9CFF") : Color.FromHex("#7A7A7A");
            this.Tier03TextColor = this.LevelType == LevelTypes.Platinum ? Color.FromHex("#4A9CFF") : Color.FromHex("#7A7A7A");
            this.Tier04TextColor = this.LevelType == LevelTypes.Diamond ? Color.FromHex("#4A9CFF") : Color.FromHex("#7A7A7A");
        }

        private void SetIsVisibleTierBar()
        {
            this.IsVisibleTierBar01 = this.LevelType == LevelTypes.Silver;
            this.IsVisibleTierBar02 = this.LevelType == LevelTypes.Gold;
            this.IsVisibleTierBar03 = this.LevelType == LevelTypes.Platinum;
            this.IsVisibleTierBar04 = this.LevelType == LevelTypes.Diamond;
        }

        private void SetLevelText()
        {
            var level = "실버";
            switch (this.LevelType)
            {
                case LevelTypes.Silver:
                    level = "실버";
                    break;
                case LevelTypes.Gold:
                    level = "골드";
                    break;
                case LevelTypes.Platinum:
                    level = "플래티넘";
                    break;
                case LevelTypes.Diamond:
                    level = "다이아몬드";
                    break;
                default:
                    break;
            }
            this.LevelText = $"{level} {this.LevelPoint:#,##0.00}점";
        }
    }
}