using SkiaSharp;
using Strawberry.MobileApp.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Chatting
{
    public class ChattingPageData : BindableObject
    {
        public string Message { get => (string)GetValue(MessageProperty); set => SetValue(MessageProperty, value); }
        public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(ChattingPageData));

        public ChattingPageData_Room Room { get => (ChattingPageData_Room)GetValue(RoomProperty); set => SetValue(RoomProperty, value); }
        public static readonly BindableProperty RoomProperty = BindableProperty.Create(nameof(Room), typeof(ChattingPageData_Room), typeof(ChattingPageData));

        public ObservableCollection<ChattingPageData_Message> Messages { get => (ObservableCollection<ChattingPageData_Message>)GetValue(MessagesProperty); set => SetValue(MessagesProperty, value); }
        public static readonly BindableProperty MessagesProperty = BindableProperty.Create(nameof(Messages), typeof(ObservableCollection<ChattingPageData_Message>), typeof(ChattingPageData));

        public ChattingPageData()
        {
            this.Messages = new ObservableCollection<ChattingPageData_Message>();
        }
    }

    public class ChattingPageData_Room : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(ChattingPageData_Room));

        public bool IsPayPoint { get => (bool)GetValue(IsPayPointProperty); set => SetValue(IsPayPointProperty, value); }
        public static readonly BindableProperty IsPayPointProperty = BindableProperty.Create(nameof(IsPayPoint), typeof(bool), typeof(ChattingPageData_Room));

        public bool UsePoint { get => (bool)GetValue(UsePointProperty); set => SetValue(UsePointProperty, value); }
        public static readonly BindableProperty UsePointProperty = BindableProperty.Create(nameof(UsePoint), typeof(bool), typeof(ChattingPageData_Room));

        public bool IsCloseMember1 { get => (bool)GetValue(IsCloseMember1Property); set => SetValue(IsCloseMember1Property, value); }
        public static readonly BindableProperty IsCloseMember1Property = BindableProperty.Create(nameof(IsCloseMember1), typeof(bool), typeof(ChattingPageData_Room));

        public bool IsCloseMember2 { get => (bool)GetValue(IsCloseMember2Property); set => SetValue(IsCloseMember2Property, value); }
        public static readonly BindableProperty IsCloseMember2Property = BindableProperty.Create(nameof(IsCloseMember2), typeof(bool), typeof(ChattingPageData_Room));

        public int? OpenMemberId { get => (int?)GetValue(OpenMemberIdProperty); set => SetValue(OpenMemberIdProperty, value); }
        public static readonly BindableProperty OpenMemberIdProperty = BindableProperty.Create(nameof(OpenMemberId), typeof(int?), typeof(ChattingPageData_Room));

        public int StarPoint { get => (int)GetValue(StarPointProperty); set => SetValue(StarPointProperty, value); }
        public static readonly BindableProperty StarPointProperty = BindableProperty.Create(nameof(StarPoint), typeof(int), typeof(ChattingPageData_Room));

        public ChattingPageData_Member Member1 { get => (ChattingPageData_Member)GetValue(Member1Property); set => SetValue(Member1Property, value); }
        public static readonly BindableProperty Member1Property = BindableProperty.Create(nameof(Member1), typeof(ChattingPageData_Member), typeof(ChattingPageData_Room));

        public ChattingPageData_Member Member2 { get => (ChattingPageData_Member)GetValue(Member2Property); set => SetValue(Member2Property, value); }
        public static readonly BindableProperty Member2Property = BindableProperty.Create(nameof(Member2), typeof(ChattingPageData_Member), typeof(ChattingPageData_Room));

        public DateTime CreateTime { get => (DateTime)GetValue(CreateTimeProperty); set => SetValue(CreateTimeProperty, value); }
        public static readonly BindableProperty CreateTimeProperty = BindableProperty.Create(nameof(CreateTime), typeof(DateTime), typeof(ChattingPageData_Room));

        public ChattingPageData_Member Partner
        {
            get
            {
                return App.Instance.Member.Id == Member1.Id ? Member2 : Member1;
            }
        }

        public bool IsVisibleChattingOpen
        {
            get
            {
                return !this.IsPayPoint;
            }
        }

        public bool IsCloseRoom
        {
            get
            {
                return this.Member1.Id == App.Instance.Member.Id ? this.IsCloseMember2 : this.IsCloseMember1;
            }
        }

        public bool IsVisibleStar01
        {
            get
            {
                return this.StarPoint >= 1;
            }
        }

        public bool IsVisibleStar02
        {
            get
            {
                return this.StarPoint >= 2;
            }
        }

        public bool IsVisibleStar03
        {
            get
            {
                return this.StarPoint >= 3;
            }
        }

        public bool IsVisibleStar04
        {
            get
            {
                return this.StarPoint >= 4;
            }
        }

        public bool IsVisibleStar05
        {
            get
            {
                return this.StarPoint >= 5;
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(Member1):
                case nameof(Member2):
                    base.OnPropertyChanged(nameof(Partner));
                    break;
                case nameof(IsPayPoint):
                    base.OnPropertyChanged(nameof(IsVisibleChattingOpen));
                    break;
                case nameof(IsCloseMember1):
                case nameof(IsCloseMember2):
                    base.OnPropertyChanged(nameof(IsCloseRoom));
                    break;
                case nameof(StarPoint):
                    base.OnPropertyChanged(nameof(IsVisibleStar01));
                    base.OnPropertyChanged(nameof(IsVisibleStar02));
                    base.OnPropertyChanged(nameof(IsVisibleStar03));
                    base.OnPropertyChanged(nameof(IsVisibleStar04));
                    base.OnPropertyChanged(nameof(IsVisibleStar05));
                    break;
                default:
                    break;
            }
        }
    }

    public class ChattingPageData_Member : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(ChattingPageData_Member));

        public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
        public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(ChattingPageData_Member));

        public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
        public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(ChattingPageData_Member));
    }

    public class ChattingPageData_Message : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(ChattingPageData_Message));

        public string Content { get => (string)GetValue(ContentProperty); set => SetValue(ContentProperty, value); }
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(string), typeof(ChattingPageData_Message));

        public bool IsShow { get => (bool)GetValue(IsShowProperty); set => SetValue(IsShowProperty, value); }
        public static readonly BindableProperty IsShowProperty = BindableProperty.Create(nameof(IsShow), typeof(bool), typeof(ChattingPageData_Message));

        public MessageTypes Type { get => (MessageTypes)GetValue(TypeProperty); set => SetValue(TypeProperty, value); }
        public static readonly BindableProperty TypeProperty = BindableProperty.Create(nameof(Type), typeof(MessageTypes), typeof(ChattingPageData_Message));

        public bool IsMyMsg { get => (bool)GetValue(IsMyMsgProperty); set => SetValue(IsMyMsgProperty, value); }
        public static readonly BindableProperty IsMyMsgProperty = BindableProperty.Create(nameof(IsMyMsg), typeof(bool), typeof(ChattingPageData_Message));

        public DateTime CreateTime { get => (DateTime)GetValue(CreateTimeProperty); set => SetValue(CreateTimeProperty, value); }
        public static readonly BindableProperty CreateTimeProperty = BindableProperty.Create(nameof(CreateTime), typeof(DateTime), typeof(ChattingPageData_Message));

        public ImageSource DownloadImageSource { get => (ImageSource)GetValue(DownloadImageSourceProperty); set => SetValue(DownloadImageSourceProperty, value); }
        public static readonly BindableProperty DownloadImageSourceProperty = BindableProperty.Create(nameof(DownloadImageSource), typeof(ImageSource), typeof(ChattingPageData_Message));

        public double Ratio { get => (double)GetValue(RatioProperty); set => SetValue(RatioProperty, value); }
        public static readonly BindableProperty RatioProperty = BindableProperty.Create(nameof(Ratio), typeof(double), typeof(ChattingPageData_Message));

        protected override async void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(Content):
                case nameof(Type):
                {
                    if (!string.IsNullOrWhiteSpace(Content) && Type == MessageTypes.Image)
                    {
                        var buffer = await Task.Run(async () =>
                        {
                            using (var http = new HttpClient())
                            {
                                return await http.GetByteArrayAsync(Content);
                            }
                        });

                        using (var stream = new SKMemoryStream(buffer))
                        using (var bitmap = SKBitmap.Decode(stream))
                        {
                            var info = bitmap.Info;
                            Ratio = (double)info.Height / (double)info.Width;

                            var rw = (int)(200 * Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density);

                            if (bitmap.Width > rw)
                            {
                                var rectI = new SKRectI(0, 0, rw, 1000).AspectFit(bitmap.Info.Size);
                                using (var resizeBitmap = bitmap.Resize(rectI.Size, SKFilterQuality.High))
                                using (var bufferStream = new MemoryStream())
                                {
                                    resizeBitmap.Encode(bufferStream, SKEncodedImageFormat.Jpeg, 100);
                                    bufferStream.Seek(0, SeekOrigin.Begin);
                                    buffer = bufferStream.ToArray();
                                }
                            }
                        }

                        DownloadImageSource = ImageSource.FromStream(() => { return new MemoryStream(buffer); });
                    }
                    break;
                }
                default:
                    break;
            }
        }
    }
}
