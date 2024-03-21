using FFImageLoading.Svg.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Appeal
{
    public class AppealPage_Menu04_Data : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(AppealPage_Menu04_Data));

        public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
        public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(AppealPage_Menu04_Data));

        public string Content { get => (string)GetValue(ContentProperty); set => SetValue(ContentProperty, value); }
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(string), typeof(AppealPage_Menu04_Data));

        public ImageSource ProfileImageSource { get => (ImageSource)GetValue(ProfileImageSourceProperty); set => SetValue(ProfileImageSourceProperty, value); }
        public static readonly BindableProperty ProfileImageSourceProperty = BindableProperty.Create(nameof(ProfileImageSource), typeof(ImageSource), typeof(AppealPage_Menu04_Data));

        protected override async void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.ProfileImage):
                {
                    using (var http = new HttpClient())
                    {
                        var buffer = await http.GetByteArrayAsync(this.ProfileImage);
                        this.ProfileImageSource = ImageSource.FromStream(() => { return new MemoryStream(buffer); });
                    }
                    break;
                }    
                default:
                    break;
            }
        }
    }
}
