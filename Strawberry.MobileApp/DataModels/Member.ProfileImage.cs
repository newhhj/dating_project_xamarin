using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.DataModels
{
    public class Member_ProfileImage : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(Member_ProfileImage));

        public ImageSource ProfileImageSource { get => (ImageSource)GetValue(ProfileImageSourceProperty); set => SetValue(ProfileImageSourceProperty, value); }
        public static readonly BindableProperty ProfileImageSourceProperty = BindableProperty.Create(nameof(ProfileImageSource), typeof(ImageSource), typeof(Member_ProfileImage));
    }
}
