using Strawberry.MobileApp.DataModels;
using Strawberry.MobileApp.Pages.Appeal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Profile
{
    public class ProfilePage_Partner_Data : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(ProfilePage_Partner_Data));

        public ObservableCollection<Member_ProfileImage> ProfileImages { get => (ObservableCollection<Member_ProfileImage>)GetValue(ProfileImagesProperty); set => SetValue(ProfileImagesProperty, value); }
        public static readonly BindableProperty ProfileImagesProperty = BindableProperty.Create(nameof(ProfileImages), typeof(ObservableCollection<Member_ProfileImage>), typeof(ProfilePage_Partner_Data));

        public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
        public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(ProfilePage_Partner_Data));

        public bool IsReciveStarPoint { get => (bool)GetValue(IsReciveStarPointProperty); set => SetValue(IsReciveStarPointProperty, value); }
        public static readonly BindableProperty IsReciveStarPointProperty = BindableProperty.Create(nameof(IsReciveStarPoint), typeof(bool), typeof(ProfilePage_Partner_Data));

        public bool IsSendStarPoint { get => (bool)GetValue(IsSendStarPointProperty); set => SetValue(IsSendStarPointProperty, value); }
        public static readonly BindableProperty IsSendStarPointProperty = BindableProperty.Create(nameof(IsSendStarPoint), typeof(bool), typeof(ProfilePage_Partner_Data));

        public bool IsReciveChoice { get => (bool)GetValue(IsReciveChoiceProperty); set => SetValue(IsReciveChoiceProperty, value); }
        public static readonly BindableProperty IsReciveChoiceProperty = BindableProperty.Create(nameof(IsReciveChoice), typeof(bool), typeof(ProfilePage_Partner_Data));

        public bool IsSendChoice { get => (bool)GetValue(IsSendChoiceProperty); set => SetValue(IsSendChoiceProperty, value); }
        public static readonly BindableProperty IsSendChoiceProperty = BindableProperty.Create(nameof(IsSendChoice), typeof(bool), typeof(ProfilePage_Partner_Data));

        public bool IsShowMyProfile { get => (bool)GetValue(IsShowMyProfileProperty); set => SetValue(IsShowMyProfileProperty, value); }
        public static readonly BindableProperty IsShowMyProfileProperty = BindableProperty.Create(nameof(IsShowMyProfile), typeof(bool), typeof(ProfilePage_Partner_Data));

        public bool IsRoyal { get => (bool)GetValue(IsRoyalProperty); set => SetValue(IsRoyalProperty, value); }
        public static readonly BindableProperty IsRoyalProperty = BindableProperty.Create(nameof(IsRoyal), typeof(bool), typeof(ProfilePage_Partner_Data));

        public int Age { get => (int)GetValue(AgeProperty); set => SetValue(AgeProperty, value); }
        public static readonly BindableProperty AgeProperty = BindableProperty.Create(nameof(Age), typeof(int), typeof(ProfilePage_Partner_Data));

        public bool IsVip { get => (bool)GetValue(IsVipProperty); set => SetValue(IsVipProperty, value); }
        public static readonly BindableProperty IsVipProperty = BindableProperty.Create(nameof(IsVip), typeof(bool), typeof(ProfilePage_Partner_Data));

        public bool HasStarBadge { get => (bool)GetValue(HasStarBadgeProperty); set => SetValue(HasStarBadgeProperty, value); }
        public static readonly BindableProperty HasStarBadgeProperty = BindableProperty.Create(nameof(HasStarBadge), typeof(bool), typeof(ProfilePage_Partner_Data));

        public string Job { get => (string)GetValue(JobProperty); set => SetValue(JobProperty, value); }
        public static readonly BindableProperty JobProperty = BindableProperty.Create(nameof(Job), typeof(string), typeof(ProfilePage_Partner_Data));

        public int Range { get => (int)GetValue(RangeProperty); set => SetValue(RangeProperty, value); }
        public static readonly BindableProperty RangeProperty = BindableProperty.Create(nameof(Range), typeof(int), typeof(ProfilePage_Partner_Data));

        public bool HasVoice { get => (bool)GetValue(HasVoiceProperty); set => SetValue(HasVoiceProperty, value); }
        public static readonly BindableProperty HasVoiceProperty = BindableProperty.Create(nameof(HasVoice), typeof(bool), typeof(ProfilePage_Partner_Data));

        public int Tall { get => (int)GetValue(TallProperty); set => SetValue(TallProperty, value); }
        public static readonly BindableProperty TallProperty = BindableProperty.Create(nameof(Tall), typeof(int), typeof(ProfilePage_Partner_Data));

        public string School { get => (string)GetValue(SchoolProperty); set => SetValue(SchoolProperty, value); }
        public static readonly BindableProperty SchoolProperty = BindableProperty.Create(nameof(School), typeof(string), typeof(ProfilePage_Partner_Data));

        public int TotalViewCount { get => (int)GetValue(TotalViewCountProperty); set => SetValue(TotalViewCountProperty, value); }
        public static readonly BindableProperty TotalViewCountProperty = BindableProperty.Create(nameof(TotalViewCount), typeof(int), typeof(ProfilePage_Partner_Data));

        public int TodayViewCount { get => (int)GetValue(TodayViewCountProperty); set => SetValue(TodayViewCountProperty, value); }
        public static readonly BindableProperty TodayViewCountProperty = BindableProperty.Create(nameof(TodayViewCount), typeof(int), typeof(ProfilePage_Partner_Data));

        public int RateCharming { get => (int)GetValue(RateCharmingProperty); set => SetValue(RateCharmingProperty, value); }
        public static readonly BindableProperty RateCharmingProperty = BindableProperty.Create(nameof(RateCharming), typeof(int), typeof(ProfilePage_Partner_Data));

        public int RateResponse { get => (int)GetValue(RateResponseProperty); set => SetValue(RateResponseProperty, value); }
        public static readonly BindableProperty RateResponseProperty = BindableProperty.Create(nameof(RateResponse), typeof(int), typeof(ProfilePage_Partner_Data));

        public string FirstMessage { get => (string)GetValue(FirstMessageProperty); set => SetValue(FirstMessageProperty, value); }
        public static readonly BindableProperty FirstMessageProperty = BindableProperty.Create(nameof(FirstMessage), typeof(string), typeof(ProfilePage_Partner_Data));

        public string BodyStyle { get => (string)GetValue(BodyStyleProperty); set => SetValue(BodyStyleProperty, value); }
        public static readonly BindableProperty BodyStyleProperty = BindableProperty.Create(nameof(BodyStyle), typeof(string), typeof(ProfilePage_Partner_Data));

        public string Religion { get => (string)GetValue(ReligionProperty); set => SetValue(ReligionProperty, value); }
        public static readonly BindableProperty ReligionProperty = BindableProperty.Create(nameof(Religion), typeof(string), typeof(ProfilePage_Partner_Data));

        public string Alcohol { get => (string)GetValue(AlcoholProperty); set => SetValue(AlcoholProperty, value); }
        public static readonly BindableProperty AlcoholProperty = BindableProperty.Create(nameof(Alcohol), typeof(string), typeof(ProfilePage_Partner_Data));

        public string Smoking { get => (string)GetValue(SmokingProperty); set => SetValue(SmokingProperty, value); }
        public static readonly BindableProperty SmokingProperty = BindableProperty.Create(nameof(Smoking), typeof(string), typeof(ProfilePage_Partner_Data));

        public int StarPoint { get => (int)GetValue(StarPointProperty); set => SetValue(StarPointProperty, value); }
        public static readonly BindableProperty StarPointProperty = BindableProperty.Create(nameof(StarPoint), typeof(int), typeof(ProfilePage_Partner_Data));

        public ObservableCollection<string> CharmingPoints { get => (ObservableCollection<string>)GetValue(CharmingPointsProperty); set => SetValue(CharmingPointsProperty, value); }
        public static readonly BindableProperty CharmingPointsProperty = BindableProperty.Create(nameof(CharmingPoints), typeof(ObservableCollection<string>), typeof(ProfilePage_Partner_Data));

        public ObservableCollection<string> Interests { get => (ObservableCollection<string>)GetValue(InterestsProperty); set => SetValue(InterestsProperty, value); }
        public static readonly BindableProperty InterestsProperty = BindableProperty.Create(nameof(Interests), typeof(ObservableCollection<string>), typeof(ProfilePage_Partner_Data));

        public ObservableCollection<ProfilePage_Partner_Data_BirthDay> BirthdayMembers { get => (ObservableCollection<ProfilePage_Partner_Data_BirthDay>)GetValue(BirthdayMembersProperty); set => SetValue(BirthdayMembersProperty, value); }
        public static readonly BindableProperty BirthdayMembersProperty = BindableProperty.Create(nameof(BirthdayMembers), typeof(ObservableCollection<ProfilePage_Partner_Data_BirthDay>), typeof(ProfilePage_Partner_Data));


        public ObservableCollection<ProfilePage_Partner_Data_Appeal> Appeals { get => (ObservableCollection<ProfilePage_Partner_Data_Appeal>)GetValue(AppealsProperty); set => SetValue(AppealsProperty, value); }
        public static readonly BindableProperty AppealsProperty = BindableProperty.Create(nameof(Appeals), typeof(ObservableCollection<ProfilePage_Partner_Data_Appeal>), typeof(ProfilePage_Partner_Data));


        public int MenuIndex { get => (int)GetValue(MenuIndexProperty); set => SetValue(MenuIndexProperty, value); }
        public static readonly BindableProperty MenuIndexProperty = BindableProperty.Create(nameof(MenuIndex), typeof(int), typeof(ProfilePage_Partner_Data), defaultValue: 0);

        public string SpecialComment
        {
            get
            {
                if (IsReciveChoice && IsSendChoice)
                    return $"축하해요! {Nickname}님과 연결되었어요.";
                else if (IsSendChoice)
                    return $"{Nickname}님에게 좋아요를 받았어요.";
                else if (IsReciveChoice)
                    return $"{Nickname}님에게 좋아요를 보냈어요.";
                else if (IsSendStarPoint && IsReciveStarPoint)
                    return "서로를 높게 평가했어요. 좋아요를 보내보세요.";
                else if (IsSendStarPoint)
                    return $"{Nickname}님이 회원님을 매력적이라 평가했어요!";
                else if (IsShowMyProfile)
                    return $"{Nickname}님이 회원님의 프로필을 확인했어요.";
                else
                    return null;
            }
        }
        public bool IsVisible_SpecialComment { get => !string.IsNullOrWhiteSpace(this.SpecialComment); }
        public bool IsVisible_FirstMessage { get => !string.IsNullOrWhiteSpace(this.FirstMessage); }
        public Color Color_ChoiceButton { get => this.IsReciveChoice ? Color.LightGray : Color.FromHex("4A9CFF"); }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(IsSendStarPoint):
                case nameof(IsReciveStarPoint):
                case nameof(IsSendChoice):
                case nameof(IsShowMyProfile):
                    base.OnPropertyChanged(nameof(SpecialComment));
                    break;
                case nameof(SpecialComment):
                    base.OnPropertyChanged(nameof(IsVisible_SpecialComment));
                    break;
                case nameof(FirstMessage):
                    base.OnPropertyChanged(nameof(IsVisible_FirstMessage));
                    break;
                case nameof(IsReciveChoice):
                    base.OnPropertyChanged(nameof(Color_ChoiceButton));
                    base.OnPropertyChanged(nameof(SpecialComment));
                    break;
                default:
                    break;
            }
        }

        public ProfilePage_Partner_Data()
        {
            this.Appeals = new ObservableCollection<ProfilePage_Partner_Data_Appeal>();
        }
    }

    public class ProfilePage_Partner_Data_BirthDay : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(ProfilePage_Partner_Data_BirthDay));

        public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
        public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(ProfilePage_Partner_Data_BirthDay));

        public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
        public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(ProfilePage_Partner_Data_BirthDay));

        public int Age { get => (int)GetValue(AgeProperty); set => SetValue(AgeProperty, value); }
        public static readonly BindableProperty AgeProperty = BindableProperty.Create(nameof(Age), typeof(int), typeof(ProfilePage_Partner_Data_BirthDay));
    }

    public class ProfilePage_Partner_Data_Appeal : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(ProfilePage_Partner_Data_Appeal));

        public int MemberId { get => (int)GetValue(MemberIdProperty); set => SetValue(MemberIdProperty, value); }
        public static readonly BindableProperty MemberIdProperty = BindableProperty.Create(nameof(MemberId), typeof(int), typeof(ProfilePage_Partner_Data_Appeal));

        public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
        public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(ProfilePage_Partner_Data_Appeal));

        public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
        public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(ProfilePage_Partner_Data_Appeal));

        public int Age { get => (int)GetValue(AgeProperty); set => SetValue(AgeProperty, value); }
        public static readonly BindableProperty AgeProperty = BindableProperty.Create(nameof(Age), typeof(int), typeof(ProfilePage_Partner_Data_Appeal));

        public string Job { get => (string)GetValue(JobProperty); set => SetValue(JobProperty, value); }
        public static readonly BindableProperty JobProperty = BindableProperty.Create(nameof(Job), typeof(string), typeof(ProfilePage_Partner_Data_Appeal));

        public int Range { get => (int)GetValue(RangeProperty); set => SetValue(RangeProperty, value); }
        public static readonly BindableProperty RangeProperty = BindableProperty.Create(nameof(Range), typeof(int), typeof(ProfilePage_Partner_Data_Appeal));

        public string Content { get => (string)GetValue(ContentProperty); set => SetValue(ContentProperty, value); }
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(string), typeof(ProfilePage_Partner_Data_Appeal));

        public string[] ContentImages { get => (string[])GetValue(ContentImagesProperty); set => SetValue(ContentImagesProperty, value); }
        public static readonly BindableProperty ContentImagesProperty = BindableProperty.Create(nameof(ContentImages), typeof(string[]), typeof(ProfilePage_Partner_Data_Appeal));

        public bool IsLike { get => (bool)GetValue(IsLikeProperty); set => SetValue(IsLikeProperty, value); }
        public static readonly BindableProperty IsLikeProperty = BindableProperty.Create(nameof(IsLike), typeof(bool), typeof(ProfilePage_Partner_Data_Appeal));

        public int LikeCount { get => (int)GetValue(LikeCountProperty); set => SetValue(LikeCountProperty, value); }
        public static readonly BindableProperty LikeCountProperty = BindableProperty.Create(nameof(LikeCount), typeof(int), typeof(ProfilePage_Partner_Data_Appeal));

        public int CommentCount { get => (int)GetValue(CommentCountProperty); set => SetValue(CommentCountProperty, value); }
        public static readonly BindableProperty CommentCountProperty = BindableProperty.Create(nameof(CommentCount), typeof(int), typeof(ProfilePage_Partner_Data_Appeal));

        public DateTime CreateTime { get => (DateTime)GetValue(CreateTimeProperty); set => SetValue(CreateTimeProperty, value); }
        public static readonly BindableProperty CreateTimeProperty = BindableProperty.Create(nameof(CreateTime), typeof(DateTime), typeof(ProfilePage_Partner_Data_Appeal));

        public CommentData Comment { get => (CommentData)GetValue(CommentProperty); set => SetValue(CommentProperty, value); }
        public static readonly BindableProperty CommentProperty = BindableProperty.Create(nameof(Comment), typeof(CommentData), typeof(ProfilePage_Partner_Data_Appeal));

        public bool CommentVisible
        {
            get
            {
                return this.Comment != null;
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.Comment):
                    base.OnPropertyChanged(nameof(this.CommentVisible));
                    break;
                default:
                    break;
            }
        }

        public class CommentData : BindableObject
        {
            public string ProfileImage { get => (string)GetValue(RrofileImageProperty); set => SetValue(RrofileImageProperty, value); }
            public static readonly BindableProperty RrofileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(CommentData));

            public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
            public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(CommentData));

            public string Comment { get => (string)GetValue(CommentProperty); set => SetValue(CommentProperty, value); }
            public static readonly BindableProperty CommentProperty = BindableProperty.Create(nameof(Comment), typeof(string), typeof(CommentData));
        }
    }
}
