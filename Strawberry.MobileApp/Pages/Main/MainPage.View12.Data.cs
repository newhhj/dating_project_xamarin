using SkiaSharp;
using Strawberry.MobileApp.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Main
{
	public class MainPage_View12_Data : BindableObject
	{
		public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
		public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(MainPage_View12_Data));

		public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
		public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(MainPage_View12_Data));

		public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
		public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(MainPage_View12_Data));

		public string Content { get => (string)GetValue(ContentProperty); set => SetValue(ContentProperty, value); }
		public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(string), typeof(MainPage_View12_Data));

		public int NotReadCount { get => (int)GetValue(NotReadCountProperty); set => SetValue(NotReadCountProperty, value); }
		public static readonly BindableProperty NotReadCountProperty = BindableProperty.Create(nameof(NotReadCount), typeof(int), typeof(MainPage_View12_Data));

		public DateTime CreateTime { get => (DateTime)GetValue(CreateTimeProperty); set => SetValue(CreateTimeProperty, value); }
		public static readonly BindableProperty CreateTimeProperty = BindableProperty.Create(nameof(CreateTime), typeof(DateTime), typeof(MainPage_View12_Data));

		public ImageSource ProfileImageSource { get => (ImageSource)GetValue(ProfileImageSourceProperty); set => SetValue(ProfileImageSourceProperty, value); }
		public static readonly BindableProperty ProfileImageSourceProperty = BindableProperty.Create(nameof(ProfileImageSource), typeof(ImageSource), typeof(MainPage_View12_Data));

		public double NotReadCountOpacity
		{
			get
			{
				return this.NotReadCount > 0 ? 1 : 0;
			}
		}

		public string CreateTimeText
		{
			get
			{
				var time = DateTime.Now - this.CreateTime;
				if (time.TotalDays >= 1)
					return $"{time.TotalDays:#,##0}일전";
				else if (time.TotalHours >= 1)
					return $"{time.TotalHours:#,##0}시간전";
				else if (time.TotalMinutes >= 1)
					return $"{time.TotalMinutes:#,##0}분전";
				else if (time.TotalSeconds >= 30)
					return $"{time.TotalSeconds:#,##0}초전";
				else
					return "방금전";
			}
		}

		public string NotReadCountText
		{
			get
			{
				return this.NotReadCount > 99 ? "+99" : this.NotReadCount.ToString();
			}
		}

		// 속성 값이 변경되었을 때 호출되는 메서드
		protected override async void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);

			switch (propertyName)
			{
				case nameof(NotReadCount):
					{
						base.OnPropertyChanged(nameof(NotReadCountOpacity));
						base.OnPropertyChanged(nameof(NotReadCountText));
						break;
					}
				case nameof(CreateTime):
					{
						base.OnPropertyChanged(nameof(CreateTimeText));
						break;
					}
				case nameof(ProfileImage):
					{
						if (string.IsNullOrWhiteSpace(ProfileImage))
						{
							this.ProfileImageSource = null;
							break;
						}

						// 프로필 이미지 다운로드
						var buffer = await Task.Run(async () =>
						{
							using (var http = new HttpClient())
							{
								return await http.GetByteArrayAsync(this.ProfileImage);
							}
						});

						// SKBitmap으로 이미지 처리
						using (var stream = new SKMemoryStream(buffer))
						using (var bitmap = SKBitmap.Decode(stream))
						{
							var info = bitmap.Info;
							var rw = (int)(70 * Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density);

							if (bitmap.Width > rw)
							{
								var rectI = new SKRectI(0, 0, rw, rw).AspectFill(bitmap.Info.Size);
								using (var resizeBitmap = bitmap.Resize(rectI.Size, SKFilterQuality.High))
								using (var bufferStream = new MemoryStream())
								{
									resizeBitmap.Encode(bufferStream, SKEncodedImageFormat.Jpeg, 100);
									bufferStream.Seek(0, SeekOrigin.Begin);
									buffer = bufferStream.ToArray();
								}
							}
						}

						ProfileImageSource = ImageSource.FromStream(() => { return new MemoryStream(buffer); });
						break;
					}
				default:
					break;
			}
		}
	}
}
