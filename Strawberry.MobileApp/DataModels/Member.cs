using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.DataModels
{
    public class Member : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(Member));

        public MemberStateTypes MemberState { get => (MemberStateTypes)GetValue(MemberStateProperty); set => SetValue(MemberStateProperty, value); }
        public static readonly BindableProperty MemberStateProperty = BindableProperty.Create(nameof(MemberState), typeof(MemberStateTypes), typeof(Member), MemberStateTypes.JoinWait);

        public long? KakaoKey { get => (long?)GetValue(KakaoKeyProperty); set => SetValue(KakaoKeyProperty, value); }
        public static readonly BindableProperty KakaoKeyProperty = BindableProperty.Create(nameof(KakaoKey), typeof(long?), typeof(Member));

        public string PhoneNumber { get => (string)GetValue(PhoneNumberProperty); set => SetValue(PhoneNumberProperty, value); }
        public static readonly BindableProperty PhoneNumberProperty = BindableProperty.Create(nameof(PhoneNumber), typeof(string), typeof(Member));

        public string Email { get => (string)GetValue(EmailProperty); set => SetValue(EmailProperty, value); }
        public static readonly BindableProperty EmailProperty = BindableProperty.Create(nameof(Email), typeof(string), typeof(Member));

        public string Password { get => (string)GetValue(PasswordProperty); set => SetValue(PasswordProperty, value); }
        public static readonly BindableProperty PasswordProperty = BindableProperty.Create(nameof(Password), typeof(string), typeof(Member));

        public bool ConsentMarketing { get => (bool)GetValue(ConsentMarketingProperty); set => SetValue(ConsentMarketingProperty, value); }
        public static readonly BindableProperty ConsentMarketingProperty = BindableProperty.Create(nameof(ConsentMarketing), typeof(bool), typeof(Member));

        public ObservableCollection<Member_ProfileImage> ProfileImages { get => (ObservableCollection<Member_ProfileImage>)GetValue(ProfileImagesProperty); set => SetValue(ProfileImagesProperty, value); }
        public static readonly BindableProperty ProfileImagesProperty = BindableProperty.Create(nameof(ProfileImages), typeof(ObservableCollection<Member_ProfileImage>), typeof(Member));

        public GenderTypes? Gender { get => (GenderTypes?)GetValue(GenderProperty); set => SetValue(GenderProperty, value); }
        public static readonly BindableProperty GenderProperty = BindableProperty.Create(nameof(Gender), typeof(GenderTypes?), typeof(Member));

        public DateTime? BirthDay { get => (DateTime?)GetValue(BirthDayProperty); set => SetValue(BirthDayProperty, value); }
        public static readonly BindableProperty BirthDayProperty = BindableProperty.Create(nameof(BirthDay), typeof(DateTime?), typeof(Member));

        public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
        public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(Member));

        public int? Tall { get => (int?)GetValue(TallProperty); set => SetValue(TallProperty, value); }
        public static readonly BindableProperty TallProperty = BindableProperty.Create(nameof(Tall), typeof(int?), typeof(Member));

        public string BodyStyle { get => (string)GetValue(BodyStyleProperty); set => SetValue(BodyStyleProperty, value); }
        public static readonly BindableProperty BodyStyleProperty = BindableProperty.Create(nameof(BodyStyle), typeof(string), typeof(Member));

        public string School { get => (string)GetValue(SchoolProperty); set => SetValue(SchoolProperty, value); }
        public static readonly BindableProperty SchoolProperty = BindableProperty.Create(nameof(School), typeof(string), typeof(Member));

        public string Job { get => (string)GetValue(JobProperty); set => SetValue(JobProperty, value); }
        public static readonly BindableProperty JobProperty = BindableProperty.Create(nameof(Job), typeof(string), typeof(Member));

        public string Religion { get => (string)GetValue(ReligionProperty); set => SetValue(ReligionProperty, value); }
        public static readonly BindableProperty ReligionProperty = BindableProperty.Create(nameof(Religion), typeof(string), typeof(Member));

        public string Alcohol { get => (string)GetValue(AlcoholProperty); set => SetValue(AlcoholProperty, value); }
        public static readonly BindableProperty AlcoholProperty = BindableProperty.Create(nameof(Alcohol), typeof(string), typeof(Member));

        public string Smoking { get => (string)GetValue(SmokingProperty); set => SetValue(SmokingProperty, value); }
        public static readonly BindableProperty SmokingProperty = BindableProperty.Create(nameof(Smoking), typeof(string), typeof(Member));

        public double? Lat { get => (double?)GetValue(LatProperty); set => SetValue(LatProperty, value); }
        public static readonly BindableProperty LatProperty = BindableProperty.Create(nameof(Lat), typeof(double?), typeof(Member));

        public double? Lng { get => (double?)GetValue(LngProperty); set => SetValue(LngProperty, value); }
        public static readonly BindableProperty LngProperty = BindableProperty.Create(nameof(Lng), typeof(double?), typeof(Member));

        public int Point { get => (int)GetValue(PointProperty); set => SetValue(PointProperty, value); }
        public static readonly BindableProperty PointProperty = BindableProperty.Create(nameof(Point), typeof(int), typeof(Member));

        public bool IsRoyal { get => (bool)GetValue(IsRoyalProperty); set => SetValue(IsRoyalProperty, value); }
        public static readonly BindableProperty IsRoyalProperty = BindableProperty.Create(nameof(IsRoyal), typeof(bool), typeof(Member));

        public bool IsVIP { get => (bool)GetValue(IsVIPProperty); set => SetValue(IsVIPProperty, value); }
        public static readonly BindableProperty IsVIPProperty = BindableProperty.Create(nameof(IsVIP), typeof(bool), typeof(Member));

        public DateTime? FreeChattingTime { get => (DateTime?)GetValue(FreeChattingTimeProperty); set => SetValue(FreeChattingTimeProperty, value); }
        public static readonly BindableProperty FreeChattingTimeProperty = BindableProperty.Create(nameof(FreeChattingTime), typeof(DateTime?), typeof(Member));

        public DateTime? FreeChoiceTime { get => (DateTime?)GetValue(FreeChoiceTimeProperty); set => SetValue(FreeChoiceTimeProperty, value); }
        public static readonly BindableProperty FreeChoiceTimeProperty = BindableProperty.Create(nameof(FreeChoiceTime), typeof(DateTime?), typeof(Member));

        public DateTime? FreeSmartChoiceTime { get => (DateTime?)GetValue(FreeSmartChoiceTimeProperty); set => SetValue(FreeSmartChoiceTimeProperty, value); }
        public static readonly BindableProperty FreeSmartChoiceTimeProperty = BindableProperty.Create(nameof(FreeSmartChoiceTime), typeof(DateTime?), typeof(Member));

        public int FreeChattingCount { get => (int)GetValue(FreeChattingCountProperty); set => SetValue(FreeChattingCountProperty, value); }
        public static readonly BindableProperty FreeChattingCountProperty = BindableProperty.Create(nameof(FreeChattingCount), typeof(int), typeof(Member));

        public int FreeChoiceCount { get => (int)GetValue(FreeChoiceCountProperty); set => SetValue(FreeChoiceCountProperty, value); }
        public static readonly BindableProperty FreeChoiceCountProperty = BindableProperty.Create(nameof(FreeChoiceCount), typeof(int), typeof(Member));

        public int Preference_MinAge { get => (int)GetValue(Preference_MinAgeProperty); set => SetValue(Preference_MinAgeProperty, value); }
        public static readonly BindableProperty Preference_MinAgeProperty = BindableProperty.Create(nameof(Preference_MinAge), typeof(int), typeof(Member), 19);

        public int Preference_MaxAge { get => (int)GetValue(Preference_MaxAgeProperty); set => SetValue(Preference_MaxAgeProperty, value); }
        public static readonly BindableProperty Preference_MaxAgeProperty = BindableProperty.Create(nameof(Preference_MaxAge), typeof(int), typeof(Member));

        public int Preference_Range { get => (int)GetValue(Preference_RangeProperty); set => SetValue(Preference_RangeProperty, value); }
        public static readonly BindableProperty Preference_RangeProperty = BindableProperty.Create(nameof(Preference_Range), typeof(int), typeof(Member));

        public int Preference_MinTall { get => (int)GetValue(Preference_MinTallProperty); set => SetValue(Preference_MinTallProperty, value); }
        public static readonly BindableProperty Preference_MinTallProperty = BindableProperty.Create(nameof(Preference_MinTall), typeof(int), typeof(Member));

        public int Preference_MaxTall { get => (int)GetValue(Preference_MaxTallProperty); set => SetValue(Preference_MaxTallProperty, value); }
        public static readonly BindableProperty Preference_MaxTallProperty = BindableProperty.Create(nameof(Preference_MaxTall), typeof(int), typeof(Member));

        public bool Preference_BeautyOrWealth { get => (bool)GetValue(Preference_BeautyOrWealthProperty); set => SetValue(Preference_BeautyOrWealthProperty, value); }
        public static readonly BindableProperty Preference_BeautyOrWealthProperty = BindableProperty.Create(nameof(Preference_BeautyOrWealth), typeof(bool), typeof(Member));

        public string Preference_BodyStyle { get => (string)GetValue(Preference_BodyStyleProperty); set => SetValue(Preference_BodyStyleProperty, value); }
        public static readonly BindableProperty Preference_BodyStyleProperty = BindableProperty.Create(nameof(Preference_BodyStyle), typeof(string), typeof(Member));

        public string Preference_Religion { get => (string)GetValue(Preference_ReligionProperty); set => SetValue(Preference_ReligionProperty, value); }
        public static readonly BindableProperty Preference_ReligionProperty = BindableProperty.Create(nameof(Preference_Religion), typeof(string), typeof(Member));

        public string Preference_Alcohol { get => (string)GetValue(Preference_AlcoholProperty); set => SetValue(Preference_AlcoholProperty, value); }
        public static readonly BindableProperty Preference_AlcoholProperty = BindableProperty.Create(nameof(Preference_Alcohol), typeof(string), typeof(Member));

        public string Preference_Smoking { get => (string)GetValue(Preference_SmokingProperty); set => SetValue(Preference_SmokingProperty, value); }
        public static readonly BindableProperty Preference_SmokingProperty = BindableProperty.Create(nameof(Preference_Smoking), typeof(string), typeof(Member));

        public PriorityTypes Preference_Priority { get => (PriorityTypes)GetValue(Preference_PriorityProperty); set => SetValue(Preference_PriorityProperty, value); }
        public static readonly BindableProperty Preference_PriorityProperty = BindableProperty.Create(nameof(Preference_Priority), typeof(PriorityTypes), typeof(Member));

        public Member()
        {
            this.ProfileImages = new ObservableCollection<Member_ProfileImage>();
        }
    }
}