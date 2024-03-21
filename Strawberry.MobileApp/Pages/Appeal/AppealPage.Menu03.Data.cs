using FFImageLoading.Svg.Forms;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Appeal
{
    public class AppealPage_Menu03_Data : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(AppealPage_Menu03_Data));

        public int MemberId { get => (int)GetValue(MemberIdProperty); set => SetValue(MemberIdProperty, value); }
        public static readonly BindableProperty MemberIdProperty = BindableProperty.Create(nameof(MemberId), typeof(int), typeof(AppealPage_Menu03_Data));

        public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
        public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(AppealPage_Menu03_Data));

        public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
        public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(AppealPage_Menu03_Data));

        public int Age { get => (int)GetValue(AgeProperty); set => SetValue(AgeProperty, value); }
        public static readonly BindableProperty AgeProperty = BindableProperty.Create(nameof(Age), typeof(int), typeof(AppealPage_Menu03_Data));

        public string Job { get => (string)GetValue(JobProperty); set => SetValue(JobProperty, value); }
        public static readonly BindableProperty JobProperty = BindableProperty.Create(nameof(Job), typeof(string), typeof(AppealPage_Menu03_Data));

        public int Range { get => (int)GetValue(RangeProperty); set => SetValue(RangeProperty, value); }
        public static readonly BindableProperty RangeProperty = BindableProperty.Create(nameof(Range), typeof(int), typeof(AppealPage_Menu03_Data));

        public string Content { get => (string)GetValue(ContentProperty); set => SetValue(ContentProperty, value); }
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(string), typeof(AppealPage_Menu03_Data));

        public string Area { get => (string)GetValue(AreaProperty); set => SetValue(AreaProperty, value); }
        public static readonly BindableProperty AreaProperty = BindableProperty.Create(nameof(Area), typeof(string), typeof(AppealPage_Menu03_Data));

        public string Time { get => (string)GetValue(TimeProperty); set => SetValue(TimeProperty, value); }
        public static readonly BindableProperty TimeProperty = BindableProperty.Create(nameof(Time), typeof(string), typeof(AppealPage_Menu03_Data));

        public string[] ContentImages { get => (string[])GetValue(ContentImagesProperty); set => SetValue(ContentImagesProperty, value); }
        public static readonly BindableProperty ContentImagesProperty = BindableProperty.Create(nameof(ContentImages), typeof(string[]), typeof(AppealPage_Menu03_Data));

        public bool IsLike { get => (bool)GetValue(IsLikeProperty); set => SetValue(IsLikeProperty, value); }
        public static readonly BindableProperty IsLikeProperty = BindableProperty.Create(nameof(IsLike), typeof(bool), typeof(AppealPage_Menu03_Data));

        public int LikeCount { get => (int)GetValue(LikeCountProperty); set => SetValue(LikeCountProperty, value); }
        public static readonly BindableProperty LikeCountProperty = BindableProperty.Create(nameof(LikeCount), typeof(int), typeof(AppealPage_Menu03_Data));

        public int CommentCount { get => (int)GetValue(CommentCountProperty); set => SetValue(CommentCountProperty, value); }
        public static readonly BindableProperty CommentCountProperty = BindableProperty.Create(nameof(CommentCount), typeof(int), typeof(AppealPage_Menu03_Data));

        public DateTime CreateTime { get => (DateTime)GetValue(CreateTimeProperty); set => SetValue(CreateTimeProperty, value); }
        public static readonly BindableProperty CreateTimeProperty = BindableProperty.Create(nameof(CreateTime), typeof(DateTime), typeof(AppealPage_Menu03_Data));

        public CommentData Comment { get => (CommentData)GetValue(CommentProperty); set => SetValue(CommentProperty, value); }
        public static readonly BindableProperty CommentProperty = BindableProperty.Create(nameof(Comment), typeof(CommentData), typeof(AppealPage_Menu03_Data));

        public bool CommentVisible
        {
            get
            {
                return this.Comment != null;
            }
        }

        public ImageSource LikeIconSource
        {
            get
            {
                return this.IsLike ? 
                    SvgImageSource.FromResource("Strawberry.MobileApp.Images.icon_like01_on.svg") : 
                    SvgImageSource.FromResource("Strawberry.MobileApp.Images.icon_like01_off.svg");
            }
        }

        public string CreateTimeText
        {
            get
            {
                var time = DateTime.Now - this.CreateTime;

                if (time.TotalDays > 1)
                    return (int)Math.Floor(time.TotalDays) + "일전";
                if (time.TotalHours > 1)
                    return (int)Math.Floor(time.TotalHours) + "시간전";
                if (time.TotalMinutes > 1)
                    return (int)Math.Floor(time.TotalMinutes) + "분전";
                if (time.TotalSeconds > 1)
                    return (int)Math.Floor(time.TotalSeconds) + "초전";
                return "방금전";
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
                case nameof(this.IsLike):
                    base.OnPropertyChanged(nameof(this.LikeIconSource));
                    break;
                case nameof(this.CreateTime):
                    base.OnPropertyChanged(nameof(this.CreateTimeText));
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
