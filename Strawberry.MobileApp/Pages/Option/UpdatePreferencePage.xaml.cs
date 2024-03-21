using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
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
    public partial class UpdatePreferencePage : BasePage
    {
        public UpdatePreferencePageData PageData
        {
            get => (UpdatePreferencePageData)this.BindingContext;
            private set => this.BindingContext = value;
        }

        public UpdatePreferencePage()
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
                this.PageData = await api.GetUpdatePreferencePageData(default(UpdatePreferencePageData));
            }
        }

        private void ClosePage_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            this.Navigation.PopAsync();
        }

        private async void BeautyOrWealth_Clicked(object sender, EventArgs e)
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
                var result = await this.DisplayActionSheet($"{(this.PageData.Gender == GenderTypes.Male ? "미모" : "재력")} 선호 선택", "취소", null, "예", "아니오");
                this.PageData.BeautyOrWealth = result == "예";
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Body_Clicked(object sender, EventArgs e)
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
                var list = new List<string>();
                var textData = default(string);

                if (this.PageData.Gender == GenderTypes.Male)
                    textData = "마른/슬림/보통/다소볼륨/글래머/통통";
                else
                    textData = "마른/슬림근육/보통/근육질/통통/우람";

                foreach (var item in textData.Split('/'))
                {
                    list.Add(item.Trim());
                }

                var result = await DisplayActionSheet("체형 선호 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                this.PageData.Body = result;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Religion_Clicked(object sender, EventArgs e)
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
                var list = new List<string>();
                var textData = "무교/기독교/불교/천주교/원불교/기타";

                foreach (var item in textData.Split('/'))
                {
                    list.Add(item.Trim());
                }

                var result = await DisplayActionSheet("종교 선호", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                this.PageData.Religion = result;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Alcohol_Clicked(object sender, EventArgs e)
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
                var list = new List<string>();
                var textData = "안함/가끔/자주";

                foreach (var item in textData.Split('/'))
                {
                    list.Add(item.Trim());
                }

                var result = await DisplayActionSheet("음주 선호 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                this.PageData.Alcohol = result;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Smoking_Clicked(object sender, EventArgs e)
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
                var list = new List<string>();
                var textData = "안함/가끔/자주";

                foreach (var item in textData.Split('/'))
                {
                    list.Add(item.Trim());
                }

                var result = await DisplayActionSheet("흡연 선호 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                this.PageData.Smoking = result;
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Priority_Clicked(object sender, EventArgs e)
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
                var list = new List<string>();
                var textData = $"없음/{(this.PageData.Gender == GenderTypes.Male ? "미모" : "재력")}/나이/거리/키/체형/종교/음주/흡연";

                foreach (var item in textData.Split('/'))
                {
                    list.Add(item.Trim());
                }

                var result = await DisplayActionSheet("우선 조건 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                switch (result)
                {
                    case "미모":
                    case "재력":
                        this.PageData.Priority = PriorityTypes.BeautyOrWealth;
                        break;
                    case "나이":
                        this.PageData.Priority = PriorityTypes.Age;
                        break;
                    case "거리":
                        this.PageData.Priority = PriorityTypes.Range;
                        break;
                    case "키":
                        this.PageData.Priority = PriorityTypes.Tall;
                        break;
                    case "체형":
                        this.PageData.Priority = PriorityTypes.Body;
                        break;
                    case "종교":
                        this.PageData.Priority = PriorityTypes.Religion;
                        break;
                    case "음주":
                        this.PageData.Priority = PriorityTypes.Alcohol;
                        break;
                    case "흡연":
                        this.PageData.Priority = PriorityTypes.Smoking;
                        break;
                    case "없음":
                    default:
                        this.PageData.Priority = PriorityTypes.None;
                        break;
                }
            }
            finally
            {
                this.LockData.IsLocked = false;
            }
        }

        private async void Accept_Clicked(object sender, EventArgs e)
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
                using (var api = new ApiHelper())
                {
                    await api.ExcuteUpdatePreference(
                        this.PageData.MinAge,
                        this.PageData.MaxAge,
                        this.PageData.Range,
                        this.PageData.MinTall,
                        this.PageData.MaxTall,
                        this.PageData.BeautyOrWealth,
                        this.PageData.Body,
                        this.PageData.Religion,
                        this.PageData.Alcohol,
                        this.PageData.Smoking,
                        this.PageData.Priority);

                    await this.Navigation.PopAsync();
                    await App.Instance.MainPage.DisplayToastAsync("선호설정이 적용되었습니다.");
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
    }

    public class UpdatePreferencePageData : BindableObject
    {
        public GenderTypes Gender { get => (GenderTypes)GetValue(GenderProperty); set => SetValue(GenderProperty, value); }
        public static readonly BindableProperty GenderProperty = BindableProperty.Create(nameof(Gender), typeof(GenderTypes), typeof(UpdatePreferencePageData), GenderTypes.Male);

        public int MinAge { get => (int)GetValue(MinAgeProperty); set => SetValue(MinAgeProperty, value); }
        public static readonly BindableProperty MinAgeProperty = BindableProperty.Create(nameof(MinAge), typeof(int), typeof(UpdatePreferencePageData), 19);

        public int MaxAge { get => (int)GetValue(MaxAgeProperty); set => SetValue(MaxAgeProperty, value); }
        public static readonly BindableProperty MaxAgeProperty = BindableProperty.Create(nameof(MaxAge), typeof(int), typeof(UpdatePreferencePageData), 49);

        public int Range { get => (int)GetValue(RangeProperty); set => SetValue(RangeProperty, value); }
        public static readonly BindableProperty RangeProperty = BindableProperty.Create(nameof(Range), typeof(int), typeof(UpdatePreferencePageData), 30);

        public int MinTall { get => (int)GetValue(MinTallProperty); set => SetValue(MinTallProperty, value); }
        public static readonly BindableProperty MinTallProperty = BindableProperty.Create(nameof(MinTall), typeof(int), typeof(UpdatePreferencePageData), 150);

        public int MaxTall { get => (int)GetValue(MaxTallProperty); set => SetValue(MaxTallProperty, value); }
        public static readonly BindableProperty MaxTallProperty = BindableProperty.Create(nameof(MaxTall), typeof(int), typeof(UpdatePreferencePageData), 191);

        public bool BeautyOrWealth { get => (bool)GetValue(BeautyOrWealthProperty); set => SetValue(BeautyOrWealthProperty, value); }
        public static readonly BindableProperty BeautyOrWealthProperty = BindableProperty.Create(nameof(BeautyOrWealth), typeof(bool), typeof(UpdatePreferencePageData), false);

        public string Body { get => (string)GetValue(BodyProperty); set => SetValue(BodyProperty, value); }
        public static readonly BindableProperty BodyProperty = BindableProperty.Create(nameof(Body), typeof(string), typeof(UpdatePreferencePageData));

        public string Religion { get => (string)GetValue(ReligionProperty); set => SetValue(ReligionProperty, value); }
        public static readonly BindableProperty ReligionProperty = BindableProperty.Create(nameof(Religion), typeof(string), typeof(UpdatePreferencePageData));

        public string Alcohol { get => (string)GetValue(AlcoholProperty); set => SetValue(AlcoholProperty, value); }
        public static readonly BindableProperty AlcoholProperty = BindableProperty.Create(nameof(Alcohol), typeof(string), typeof(UpdatePreferencePageData));

        public string Smoking { get => (string)GetValue(SmokingProperty); set => SetValue(SmokingProperty, value); }
        public static readonly BindableProperty SmokingProperty = BindableProperty.Create(nameof(Smoking), typeof(string), typeof(UpdatePreferencePageData));

        public PriorityTypes Priority { get => (PriorityTypes)GetValue(PriorityProperty); set => SetValue(PriorityProperty, value); }
        public static readonly BindableProperty PriorityProperty = BindableProperty.Create(nameof(Priority), typeof(PriorityTypes), typeof(UpdatePreferencePageData), PriorityTypes.None);



        public int DefaultMinAge { get => (int)GetValue(DefaultMinAgeProperty); set => SetValue(DefaultMinAgeProperty, value); }
        public static readonly BindableProperty DefaultMinAgeProperty = BindableProperty.Create(nameof(DefaultMinAge), typeof(int), typeof(UpdatePreferencePageData), 19);

        public string AgeRangeText { get => (string)GetValue(AgeRangeTextProperty); set => SetValue(AgeRangeTextProperty, value); }
        public static readonly BindableProperty AgeRangeTextProperty = BindableProperty.Create(nameof(AgeRangeText), typeof(string), typeof(UpdatePreferencePageData), "19세 ~ 49세");

        public string TallRangeText { get => (string)GetValue(TallRangeTextProperty); set => SetValue(TallRangeTextProperty, value); }
        public static readonly BindableProperty TallRangeTextProperty = BindableProperty.Create(nameof(TallRangeText), typeof(string), typeof(UpdatePreferencePageData), "150cm ~ 190cm이상");

        public string BeautyOrWealthLabelText { get => (string)GetValue(BeautyOrWealthLabelTextProperty); set => SetValue(BeautyOrWealthLabelTextProperty, value); }
        public static readonly BindableProperty BeautyOrWealthLabelTextProperty = BindableProperty.Create(nameof(BeautyOrWealthLabelText), typeof(string), typeof(UpdatePreferencePageData), "미모");

        public string BeautyOrWealthValueText { get => (string)GetValue(BeautyOrWealthValueTextProperty); set => SetValue(BeautyOrWealthValueTextProperty, value); }
        public static readonly BindableProperty BeautyOrWealthValueTextProperty = BindableProperty.Create(nameof(BeautyOrWealthValueText), typeof(string), typeof(UpdatePreferencePageData), "아니오");

        public string PriorityText { get => (string)GetValue(PriorityTextProperty); set => SetValue(PriorityTextProperty, value); }
        public static readonly BindableProperty PriorityTextProperty = BindableProperty.Create(nameof(PriorityText), typeof(string), typeof(UpdatePreferencePageData), "없음");



        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.Priority):
                    switch (this.Priority)
                    {
                        default:
                        case PriorityTypes.None:
                            this.PriorityText = "없음";
                            break;
                        case PriorityTypes.BeautyOrWealth:
                            this.PriorityText = this.Gender == GenderTypes.Male ? "미모" : "재력";
                            break;
                        case PriorityTypes.Age:
                            this.PriorityText = "나이";
                            break;
                        case PriorityTypes.Range:
                            this.PriorityText = "거리";
                            break;
                        case PriorityTypes.Tall:
                            this.PriorityText = "키";
                            break;
                        case PriorityTypes.Body:
                            this.PriorityText = "체형";
                            break;
                        case PriorityTypes.Religion:
                            this.PriorityText = "종교";
                            break;
                        case PriorityTypes.Alcohol:
                            this.PriorityText = "음주";
                            break;
                        case PriorityTypes.Smoking:
                            this.PriorityText = "흡연";
                            break;
                    }
                    break;
                case nameof(this.BeautyOrWealth):
                    this.BeautyOrWealthValueText = this.BeautyOrWealth ? "예" : "아니오";
                    break;
                case nameof(this.MinAge):
                case nameof(this.MaxAge):
                    this.AgeRangeText = $"{this.MinAge}세 ~ {this.MaxAge}세";
                    break;
                case nameof(this.MinTall):
                case nameof(this.MaxTall):
                    this.TallRangeText = $"{this.MinTall}cm ~ {Math.Min(190, this.MaxTall)}cm{(this.MaxTall > 190 ? " 이상" : null)}";
                    break;
                case nameof(this.Gender):
                    this.BeautyOrWealthLabelText = this.Gender == GenderTypes.Male ? "미모" : "재력";
                    this.DefaultMinAge = this.Gender == GenderTypes.Male ? 19 : 25;
                    this.MinAge = Math.Max(this.DefaultMinAge, this.MinAge);
                    break;
                default:
                    break;
            }
        }
    }

    public class UpdatePreferencePageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "ValueColor":
                    return string.IsNullOrWhiteSpace((string)value) ? "#7A7A7A" : "#4A9CFF";
                default:
                    return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}