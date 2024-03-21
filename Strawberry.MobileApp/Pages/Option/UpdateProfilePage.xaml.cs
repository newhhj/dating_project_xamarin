using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Helpers;
using Strawberry.MobileApp.Pages.Shares;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Strawberry.MobileApp.Pages.Option
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateProfilePage : BasePage
    {
        public UpdateProfilePageData PageData
        {
            get => (UpdateProfilePageData)this.BindingContext; 
            private set => this.BindingContext = value;
        }

        public UpdateProfilePage()
        {
            InitializeComponent();
        }

        private async Task GetPageDataAsync()
        {
            using (var api = new ApiHelper())
            {
                var result = await api.GetUpdateProfilePageData(default(UpdateProfilePageData));

                var emptyCount = 6 - result.ProfileImages.Count;
                for (int i = 0; i < emptyCount; i++)
                    result.ProfileImages.Add(new UpdateProfileImageData());

                this.PageData = result;
            }
        }

        public async Task ShowPageAsync()
        {
            await this.GetPageDataAsync();
            await App.Instance.MainPage.Navigation.PushAsync(this);
        }

        private async void ClosePage_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IDeviceHelper>().Vibrate();
            await this.Navigation.PopAsync();
        }

        private async void ProfileImage_Clicked(object sender, EventArgs e)
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
                var (filename, buffer) = await this.TakeImageAsync();
                if (buffer == null)
                    return;

                var view = sender as View;
                var data = view.BindingContext as UpdateProfileImageData;

                data.ProfileImage = ImageSource.FromStream(() => { return new MemoryStream(buffer); });
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

        private async void BodyStyle_Clicked(object sender, EventArgs e)
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
                    textData = "마른/슬림근육/보통/근육질/통통/우람";
                else
                    textData = "마른/슬림/보통/다소볼륨/글래머/통통";

                foreach (var item in textData.Split('/'))
                {
                    list.Add(item.Trim());
                }

                var result = await DisplayActionSheet("체형 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                this.PageData.BodyStyle = result;
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

        private async void School_Clicked(object sender, EventArgs e)
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
                var textData = "고등학교/전문대/대학교/석사/박사/기타";

                foreach (var item in textData.Split('/'))
                {
                    list.Add(item.Trim());
                }

                var result = await DisplayActionSheet("학력 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                this.PageData.School = result;
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

        private async void Personality_Clicked(object sender, EventArgs e)
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
                var dialog = new SelectPersonalityDialog();
                var result = await dialog.ShowDialogAsync(this.PageData.Personality);

                if (result == null || result.Length == 0)
                {
                    this.PageData.Personality = null;
                }
                else
                {
                    var personality = new StringBuilder();
                    foreach (var item in result)
                    {
                        if (personality.Length > 0)
                            personality.Append(",");

                        personality.Append(item);
                    };

                    this.PageData.Personality = personality.ToString();
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

                var result = await DisplayActionSheet("종교 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                this.PageData.Religion = result;
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

                var result = await DisplayActionSheet("음주 여부 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                this.PageData.Alcohol = result;
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

                var result = await DisplayActionSheet("흡연 여부 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                this.PageData.Smoking = result;
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

        private async void Blood_Clicked(object sender, EventArgs e)
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
                var textData = "A형/B형/AB형/0형";

                foreach (var item in textData.Split('/'))
                {
                    list.Add(item.Trim());
                }

                var result = await DisplayActionSheet("혈액형 선택", "취소", null, list.ToArray());
                if (string.IsNullOrWhiteSpace(result) || result == "취소")
                    return;

                this.PageData.Blood = result;
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

        private async void ConfirmPhone_Clicked(object sender, EventArgs e)
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
                var page = new SettingAccountPage();
                await page.ShowPageAcync();
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

        private async void CharmingPoints_Clicked(object sender, EventArgs e)
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
                var charmingPoints = this.PageData.CharmingPoints
                    .Select(x => x.Name)
                    .ToArray();
                var dialog = new SelectCharmingPointsDialog();
                var result = await dialog.ShowDialogAsync(charmingPoints);

                if (result == null)
                    return;

                this.PageData.CharmingPoints.Clear();
                foreach (var item in result)
                {
                    this.PageData.CharmingPoints.Add(new UpdateProfileItemData
                    {
                        Name = item
                    });
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

        private async void Interests_Clicked(object sender, EventArgs e)
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
                var interests = this.PageData.Interests
                    .Select(x => x.Name)
                    .ToArray();
                var dialog = new SelectInterestsDialog();
                var result = await dialog.ShowDialogAsync(interests);

                if (result == null)
                    return;

                this.PageData.Interests.Clear();
                foreach (var item in result)
                {
                    this.PageData.Interests.Add(new UpdateProfileItemData
                    {
                        Name = item
                    });
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
                    var newImages = this.PageData.ProfileImages
                        .Where(x => x.ProfileImage is StreamImageSource)
                        .Select(x =>
                        {
                            var buffer = default(byte[]);
                            var source = (StreamImageSource)x.ProfileImage;
                            var stream = source.Stream(CancellationToken.None).Result;
                            using (var memoryStream = new MemoryStream())
                            {
                                stream.CopyTo(memoryStream);
                                buffer = memoryStream.ToArray();
                            }

                            return new
                            {
                                Id = x.ProfileImageId,
                                Buffer = buffer
                            };
                        })
                        .ToArray();

                    var charmingPoints = this.PageData.CharmingPoints
                        .Select(x => x.Name)
                        .ToArray();

                    var interests = this.PageData.Interests
                        .Select(x => x.Name)
                        .ToArray();

                    var result = await api.ExcuteUpdateMember(
                        newImages.Select(x => x.Id).ToArray(),
                        newImages.Select(x => x.Buffer).ToArray(),
                        this.PageData.BodyStyle,
                        this.PageData.JobName,
                        this.PageData.School,
                        this.PageData.SchoolName,
                        this.PageData.Personality,
                        this.PageData.Religion,
                        this.PageData.Alcohol,
                        this.PageData.Smoking,
                        this.PageData.Blood,
                        charmingPoints,
                        interests,
                        new
                        {
                            ProfileImages = default(Member_ProfileImage[]),
                            Point = default(int)
                        });

                    if (result.ProfileImages != null && result.ProfileImages.Length > 0)
                    {
                        App.Instance.Member.ProfileImages.Clear();
                        foreach (var profileImage in result.ProfileImages)
                            App.Instance.Member.ProfileImages.Add(profileImage);
                    }

                    App.Instance.Member.Point = result.Point;
                }

                await App.Instance.MainPage.Navigation.PopAsync();
                await App.Instance.MainPage.DisplayToastAsync("프로필이 수정되었습니다. 이미지는 관리자 승인 후 적용됩니다.");
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

        private async void Royal_Clicked(object sender, EventArgs e)
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
                var page = new RoyalCenterPage();
                await page.ShowPageAsync();
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

    public class UpdateProfilePageData : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(UpdateProfilePageData));

        public ObservableCollection<UpdateProfileImageData> ProfileImages { get => (ObservableCollection<UpdateProfileImageData>)GetValue(ProfileImagesProperty); set => SetValue(ProfileImagesProperty, value); }
        public static readonly BindableProperty ProfileImagesProperty = BindableProperty.Create(nameof(ProfileImages), typeof(ObservableCollection<UpdateProfileImageData>), typeof(UpdateProfilePageData));

        public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
        public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(UpdateProfilePageData));

        public GenderTypes Gender { get => (GenderTypes)GetValue(GenderProperty); set => SetValue(GenderProperty, value); }
        public static readonly BindableProperty GenderProperty = BindableProperty.Create(nameof(Gender), typeof(GenderTypes), typeof(UpdateProfilePageData), GenderTypes.Male);

        public DateTime BirthDay { get => (DateTime)GetValue(BirthDayProperty); set => SetValue(BirthDayProperty, value); }
        public static readonly BindableProperty BirthDayProperty = BindableProperty.Create(nameof(BirthDay), typeof(DateTime), typeof(UpdateProfilePageData));

        public int Tall { get => (int)GetValue(TallProperty); set => SetValue(TallProperty, value); }
        public static readonly BindableProperty TallProperty = BindableProperty.Create(nameof(Tall), typeof(int), typeof(UpdateProfilePageData));

        public string BodyStyle { get => (string)GetValue(BodyStyleProperty); set => SetValue(BodyStyleProperty, value); }
        public static readonly BindableProperty BodyStyleProperty = BindableProperty.Create(nameof(BodyStyle), typeof(string), typeof(UpdateProfilePageData));

        public string JobName { get => (string)GetValue(JobNameProperty); set => SetValue(JobNameProperty, value); }
        public static readonly BindableProperty JobNameProperty = BindableProperty.Create(nameof(JobName), typeof(string), typeof(UpdateProfilePageData));

        public string Job { get => (string)GetValue(JobProperty); set => SetValue(JobProperty, value); }
        public static readonly BindableProperty JobProperty = BindableProperty.Create(nameof(Job), typeof(string), typeof(UpdateProfilePageData));

        public string School { get => (string)GetValue(SchoolProperty); set => SetValue(SchoolProperty, value); }
        public static readonly BindableProperty SchoolProperty = BindableProperty.Create(nameof(School), typeof(string), typeof(UpdateProfilePageData));

        public string SchoolName { get => (string)GetValue(SchoolNameProperty); set => SetValue(SchoolNameProperty, value); }
        public static readonly BindableProperty SchoolNameProperty = BindableProperty.Create(nameof(SchoolName), typeof(string), typeof(UpdateProfilePageData));

        public string Personality { get => (string)GetValue(PersonalityProperty); set => SetValue(PersonalityProperty, value); }
        public static readonly BindableProperty PersonalityProperty = BindableProperty.Create(nameof(Personality), typeof(string), typeof(UpdateProfilePageData));

        public string Religion { get => (string)GetValue(ReligionProperty); set => SetValue(ReligionProperty, value); }
        public static readonly BindableProperty ReligionProperty = BindableProperty.Create(nameof(Religion), typeof(string), typeof(UpdateProfilePageData));

        public string Alcohol { get => (string)GetValue(AlcoholProperty); set => SetValue(AlcoholProperty, value); }
        public static readonly BindableProperty AlcoholProperty = BindableProperty.Create(nameof(Alcohol), typeof(string), typeof(UpdateProfilePageData));

        public string Smoking { get => (string)GetValue(SmokingProperty); set => SetValue(SmokingProperty, value); }
        public static readonly BindableProperty SmokingProperty = BindableProperty.Create(nameof(Smoking), typeof(string), typeof(UpdateProfilePageData));

        public string Blood { get => (string)GetValue(BloodProperty); set => SetValue(BloodProperty, value); }
        public static readonly BindableProperty BloodProperty = BindableProperty.Create(nameof(Blood), typeof(string), typeof(UpdateProfilePageData));

        public bool IsConfirmPhoneNumber { get => (bool)GetValue(IsConfirmPhoneNumberProperty); set => SetValue(IsConfirmPhoneNumberProperty, value); }
        public static readonly BindableProperty IsConfirmPhoneNumberProperty = BindableProperty.Create(nameof(IsConfirmPhoneNumber), typeof(bool), typeof(UpdateProfilePageData), false);

        public ObservableCollection<UpdateProfileItemData> CharmingPoints { get => (ObservableCollection<UpdateProfileItemData>)GetValue(CharmingPointsProperty); set => SetValue(CharmingPointsProperty, value); }
        public static readonly BindableProperty CharmingPointsProperty = BindableProperty.Create(nameof(CharmingPoints), typeof(ObservableCollection<UpdateProfileItemData>), typeof(UpdateProfilePageData));

        public ObservableCollection<UpdateProfileItemData> Interests { get => (ObservableCollection<UpdateProfileItemData>)GetValue(InterestsProperty); set => SetValue(InterestsProperty, value); }
        public static readonly BindableProperty InterestsProperty = BindableProperty.Create(nameof(Interests), typeof(ObservableCollection<UpdateProfileItemData>), typeof(UpdateProfilePageData));

        public bool IsRoyal { get => (bool)GetValue(IsRoyalProperty); set => SetValue(IsRoyalProperty, value); }
        public static readonly BindableProperty IsRoyalProperty = BindableProperty.Create(nameof(IsRoyal), typeof(bool), typeof(UpdateProfilePageData), false);

        public bool IsVisiblePersonality { get => (bool)GetValue(IsVisiblePersonalityProperty); set => SetValue(IsVisiblePersonalityProperty, value); }
        public static readonly BindableProperty IsVisiblePersonalityProperty = BindableProperty.Create(nameof(IsVisiblePersonality), typeof(bool), typeof(UpdateProfilePageData), false);

        public bool IsVisibleNullPersonality { get => (bool)GetValue(IsVisibleNullPersonalityProperty); set => SetValue(IsVisibleNullPersonalityProperty, value); }
        public static readonly BindableProperty IsVisibleNullPersonalityProperty = BindableProperty.Create(nameof(IsVisibleNullPersonality), typeof(bool), typeof(UpdateProfilePageData), true);

        public bool IsVisibleBlood { get => (bool)GetValue(IsVisibleBloodProperty); set => SetValue(IsVisibleBloodProperty, value); }
        public static readonly BindableProperty IsVisibleBloodProperty = BindableProperty.Create(nameof(IsVisibleBlood), typeof(bool), typeof(UpdateProfilePageData), false);

        public bool IsVisibleNullBlood { get => (bool)GetValue(IsVisibleNullBloodProperty); set => SetValue(IsVisibleNullBloodProperty, value); }
        public static readonly BindableProperty IsVisibleNullBloodProperty = BindableProperty.Create(nameof(IsVisibleNullBlood), typeof(bool), typeof(UpdateProfilePageData), true);

        public string GenderText { get => (string)GetValue(GenderTextProperty); set => SetValue(GenderTextProperty, value); }
        public static readonly BindableProperty GenderTextProperty = BindableProperty.Create(nameof(GenderText), typeof(string), typeof(UpdateProfilePageData), "남성");

        public bool IsVisibleRoyalButton { get => (bool)GetValue(IsVisibleRoyalButtonProperty); set => SetValue(IsVisibleRoyalButtonProperty, value); }
        public static readonly BindableProperty IsVisibleRoyalButtonProperty = BindableProperty.Create(nameof(IsVisibleRoyalButton), typeof(bool), typeof(UpdateProfilePageData), true);

        public bool IsVisiblePhoneConfirm { get => (bool)GetValue(IsVisiblePhoneConfirmProperty); set => SetValue(IsVisiblePhoneConfirmProperty, value); }
        public static readonly BindableProperty IsVisiblePhoneConfirmProperty = BindableProperty.Create(nameof(IsVisiblePhoneConfirm), typeof(bool), typeof(UpdateProfilePageData), false);

        public bool IsVisiblePhoneDeny { get => (bool)GetValue(IsVisiblePhoneDenyProperty); set => SetValue(IsVisiblePhoneDenyProperty, value); }
        public static readonly BindableProperty IsVisiblePhoneDenyProperty = BindableProperty.Create(nameof(IsVisiblePhoneDeny), typeof(bool), typeof(UpdateProfilePageData), true);



        public UpdateProfilePageData()
        {
            this.ProfileImages = new ObservableCollection<UpdateProfileImageData>();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.Gender):
                    this.GenderText = this.Gender == GenderTypes.Male ? "남성" : "여성";
                    break;
                case nameof(this.IsRoyal):
                    this.IsVisibleRoyalButton = !this.IsRoyal;
                    break;
                case nameof(this.IsConfirmPhoneNumber):
                    this.IsVisiblePhoneConfirm = this.IsConfirmPhoneNumber;
                    this.IsVisiblePhoneDeny = !this.IsConfirmPhoneNumber;
                    break;
                case nameof(this.Personality):
                    this.IsVisiblePersonality = !string.IsNullOrEmpty(this.Personality);
                    this.IsVisibleNullPersonality = string.IsNullOrEmpty(this.Personality);
                    break;
                case nameof(this.Blood):
                    this.IsVisibleBlood = !string.IsNullOrEmpty(this.Blood);
                    this.IsVisibleNullBlood = string.IsNullOrEmpty(this.Blood);
                    break;
                default:
                    break;
            }
        }
    }

    public class UpdateProfileImageData : BindableObject
    {
        public int ProfileImageId { get => (int)GetValue(ProfileImageIdProperty); set => SetValue(ProfileImageIdProperty, value); }
        public static readonly BindableProperty ProfileImageIdProperty = BindableProperty.Create(nameof(ProfileImageId), typeof(int), typeof(UpdateProfileImageData), 0);

        public ImageSource ProfileImage { get => (ImageSource)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
        public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(ImageSource), typeof(UpdateProfileImageData));
    }

    public class UpdateProfileItemData : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(UpdateProfileItemData));

        public string Name { get => (string)GetValue(NameProperty); set => SetValue(NameProperty, value); }
        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(UpdateProfileItemData));
    }
}