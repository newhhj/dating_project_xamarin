using FFImageLoading.Svg.Forms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Appeal
{
    public class AppealDetailPageData : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(AppealDetailPageData));

        public int MemberId { get => (int)GetValue(MemberIdProperty); set => SetValue(MemberIdProperty, value); }
        public static readonly BindableProperty MemberIdProperty = BindableProperty.Create(nameof(MemberId), typeof(int), typeof(AppealDetailPageData));

        public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
        public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(AppealDetailPageData));

        public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
        public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(AppealDetailPageData));

        public int Age { get => (int)GetValue(AgeProperty); set => SetValue(AgeProperty, value); }
        public static readonly BindableProperty AgeProperty = BindableProperty.Create(nameof(Age), typeof(int), typeof(AppealDetailPageData));

        public string Job { get => (string)GetValue(JobProperty); set => SetValue(JobProperty, value); }
        public static readonly BindableProperty JobProperty = BindableProperty.Create(nameof(Job), typeof(string), typeof(AppealDetailPageData));

        public double Range { get => (double)GetValue(RangeProperty); set => SetValue(RangeProperty, value); }
        public static readonly BindableProperty RangeProperty = BindableProperty.Create(nameof(Range), typeof(double), typeof(AppealDetailPageData));

        public string Content { get => (string)GetValue(ContentProperty); set => SetValue(ContentProperty, value); }
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(string), typeof(AppealDetailPageData));

        public string Area { get => (string)GetValue(AreaProperty); set => SetValue(AreaProperty, value); }
        public static readonly BindableProperty AreaProperty = BindableProperty.Create(nameof(Area), typeof(string), typeof(AppealDetailPageData));

        public string Time { get => (string)GetValue(TimeProperty); set => SetValue(TimeProperty, value); }
        public static readonly BindableProperty TimeProperty = BindableProperty.Create(nameof(Time), typeof(string), typeof(AppealDetailPageData));

        public ImageData[] Images { get => (ImageData[])GetValue(ImagesProperty); set => SetValue(ImagesProperty, value); }
        public static readonly BindableProperty ImagesProperty = BindableProperty.Create(nameof(Images), typeof(ImageData[]), typeof(AppealDetailPageData));

        public int Likes { get => (int)GetValue(LikesProperty); set => SetValue(LikesProperty, value); }
        public static readonly BindableProperty LikesProperty = BindableProperty.Create(nameof(Likes), typeof(int), typeof(AppealDetailPageData));

        public bool UseLike { get => (bool)GetValue(UseLikeProperty); set => SetValue(UseLikeProperty, value); }
        public static readonly BindableProperty UseLikeProperty = BindableProperty.Create(nameof(UseLike), typeof(bool), typeof(AppealDetailPageData));

        public bool UseComment { get => (bool)GetValue(UseCommentProperty); set => SetValue(UseCommentProperty, value); }
        public static readonly BindableProperty UseCommentProperty = BindableProperty.Create(nameof(UseComment), typeof(bool), typeof(AppealDetailPageData));

        public ObservableCollection<CommentData> Comments { get => (ObservableCollection<CommentData>)GetValue(CommentsProperty); set => SetValue(CommentsProperty, value); }
        public static readonly BindableProperty CommentsProperty = BindableProperty.Create(nameof(Comments), typeof(ObservableCollection<CommentData>), typeof(AppealDetailPageData));

        public int? ReplyMemberId { get => (int?)GetValue(ReplyMemberIdProperty); set => SetValue(ReplyMemberIdProperty, value); }
        public static readonly BindableProperty ReplyMemberIdProperty = BindableProperty.Create(nameof(ReplyMemberId), typeof(int?), typeof(AppealDetailPageData));

        public string ReplyNickname { get => (string)GetValue(ReplyNicknameProperty); set => SetValue(ReplyNicknameProperty, value); }
        public static readonly BindableProperty ReplyNicknameProperty = BindableProperty.Create(nameof(ReplyNickname), typeof(string), typeof(AppealDetailPageData));

        public string NewComment { get => (string)GetValue(NewCommentProperty); set => SetValue(NewCommentProperty, value); }
        public static readonly BindableProperty NewCommentProperty = BindableProperty.Create(nameof(NewComment), typeof(string), typeof(AppealDetailPageData));

        public bool AreaTimeVisible
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.Area) || !string.IsNullOrWhiteSpace(this.Time);
            }
        }

        public bool AreaVisible
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.Area);
            }
        }

        public bool TimeVisible
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.Time);
            }
        }

        public bool CommentsVisible
        {
            get
            {
                return this.Comments?.Count > 0;
            }
        }

        public SvgImageSource LikeIconSource
        {
            get
            {
                return this.UseLike ? 
                    SvgImageSource.FromResource("Strawberry.MobileApp.Images.icon_like01_on.svg", this.GetType().Assembly) : 
                    SvgImageSource.FromResource("Strawberry.MobileApp.Images.icon_like01_off.svg", this.GetType().Assembly);
            }
        }

        public SvgImageSource CommentIconSource
        {
            get
            {
                return SvgImageSource.FromResource("Strawberry.MobileApp.Images.icon_comment01.svg", this.GetType().Assembly);
            }
        }

        public ImageSource BackButtonImageSource
        {
            get
            {
                return SvgImageSource.FromResource("Strawberry.MobileApp.Images.icon_back01.svg", this.GetType().Assembly);
            }
        }

        public bool ReplyNicknameVisible
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ReplyNickname);
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.Area):
                    base.OnPropertyChanged(nameof(this.AreaVisible));
                    base.OnPropertyChanged(nameof(this.AreaTimeVisible));
                    break;
                case nameof(this.Time):
                    base.OnPropertyChanged(nameof(this.TimeVisible));
                    base.OnPropertyChanged(nameof(this.AreaTimeVisible));
                    break;
                case nameof(this.UseLike):
                    base.OnPropertyChanged(nameof(this.LikeIconSource));
                    break;
                case nameof(this.Comments):
                    base.OnPropertyChanged(nameof(this.CommentsVisible));
                    break;
                case nameof(this.ReplyNickname):
                    base.OnPropertyChanged(nameof(this.ReplyNicknameVisible));
                    break;
                default:
                    break;
            }
        }

        public void InvokePropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
        }

        public class ImageData : BindableObject
        {
            public string Url { get => (string)GetValue(UrlProperty); set => SetValue(UrlProperty, value); }
            public static readonly BindableProperty UrlProperty = BindableProperty.Create(nameof(Url), typeof(string), typeof(ImageData));

            public ImageSource Source { get => (ImageSource)GetValue(SourceProperty); set => SetValue(SourceProperty, value); }
            public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(ImageSource), typeof(ImageData));

            public double ViewWidth { get => (double)GetValue(ViewWidthProperty); set => SetValue(ViewWidthProperty, value); }
            public static readonly BindableProperty ViewWidthProperty = BindableProperty.Create(nameof(ViewWidth), typeof(double), typeof(ImageData));

            public double ViewHeight { get => (double)GetValue(ViewHeightProperty); set => SetValue(ViewHeightProperty, value); }
            public static readonly BindableProperty ViewHeightProperty = BindableProperty.Create(nameof(ViewHeight), typeof(double), typeof(ImageData));

            public double Ratio { get => (double)GetValue(RatioProperty); set => SetValue(RatioProperty, value); }
            public static readonly BindableProperty RatioProperty = BindableProperty.Create(nameof(Ratio), typeof(double), typeof(ImageData));

            protected override async void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                base.OnPropertyChanged(propertyName);

                switch (propertyName)
                {
                    case nameof(this.Url):
                        using (var http = new HttpClient())
                        {
                            var buffer = await http.GetByteArrayAsync(this.Url);
                            using (var bitmap = SKCodec.Create(new SKMemoryStream(buffer)))
                            {
                                var w = bitmap.Info.Width;
                                var h = bitmap.Info.Height;
                                this.Ratio = (double)h / (double)w;
                            }
                            this.Source = ImageSource.FromStream(() => { return new MemoryStream(buffer); });
                        }
                        break;
                    case nameof(this.ViewWidth):
                    case nameof(this.Ratio):
                        this.ViewHeight = this.ViewWidth * this.Ratio;
                        break;
                    default:
                        break;
                }
            }
        }

        public class CommentData : BindableObject
        {
            public int CommentId { get => (int)GetValue(CommentIdProperty); set => SetValue(CommentIdProperty, value); }
            public static readonly BindableProperty CommentIdProperty = BindableProperty.Create(nameof(CommentId), typeof(int), typeof(CommentData));

            public string Comment { get => (string)GetValue(CommentProperty); set => SetValue(CommentProperty, value); }
            public static readonly BindableProperty CommentProperty = BindableProperty.Create(nameof(Comment), typeof(string), typeof(CommentData));

            public int MemberId { get => (int)GetValue(MemberIdProperty); set => SetValue(MemberIdProperty, value); }
            public static readonly BindableProperty MemberIdProperty = BindableProperty.Create(nameof(MemberId), typeof(int), typeof(CommentData));

            public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
            public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(CommentData));

            public DateTime CreateTime { get => (DateTime)GetValue(CreateTimeProperty); set => SetValue(CreateTimeProperty, value); }
            public static readonly BindableProperty CreateTimeProperty = BindableProperty.Create(nameof(CreateTime), typeof(DateTime), typeof(CommentData));

            public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
            public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(CommentData));

            public string ReplyNickname { get => (string)GetValue(ReplyNicknameProperty); set => SetValue(ReplyNicknameProperty, value); }
            public static readonly BindableProperty ReplyNicknameProperty = BindableProperty.Create(nameof(ReplyNickname), typeof(string), typeof(CommentData));

            public bool ReplyNicknameVisible
            {
                get
                {
                    return !string.IsNullOrWhiteSpace(this.ReplyNickname);
                }
            }

            public bool ReplyCommentUIVisible
            {
                get
                {
                    return App.Instance.Member.Id != this.MemberId;
                }
            }

            public bool ReplyRemoveUIVisible
            {
                get
                {
                    return App.Instance.Member.Id == this.MemberId;
                }
            }

            public string CreateTimeText
            {
                get
                {
                    var time = DateTime.Now - this.CreateTime;
                    if (time.TotalDays >= 1)
                        return $"{(int)Math.Truncate(time.TotalDays)}일전";
                    if (time.TotalHours >= 1)
                        return $"{(int)Math.Truncate(time.TotalHours)}시간전";
                    if (time.TotalMinutes >= 1)
                        return $"{(int)Math.Truncate(time.TotalMinutes)}분전";
                    if (time.TotalSeconds >= 1)
                        return $"{(int)Math.Truncate(time.TotalSeconds)}초전";

                    return $"방금전";
                }
            }

            protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                base.OnPropertyChanged(propertyName);

                switch (propertyName)
                {
                    case nameof(this.ReplyNickname):
                        base.OnPropertyChanged(nameof(this.ReplyNicknameVisible));
                        break;
                    case nameof(this.CreateTime):
                        base.OnPropertyChanged(nameof(this.CreateTimeText));
                        break;
                    case nameof(this.MemberId):
                        base.OnPropertyChanged(nameof(this.ReplyCommentUIVisible));
                        base.OnPropertyChanged(nameof(this.ReplyRemoveUIVisible));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
