using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Appeal
{
    public class AppealPage_Top5_Data : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(AppealPage_Top5_Data));

        public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
        public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(AppealPage_Top5_Data));

        public int Index { get => (int)GetValue(IndexProperty); set => SetValue(IndexProperty, value); }
        public static readonly BindableProperty IndexProperty = BindableProperty.Create(nameof(Index), typeof(int), typeof(AppealPage_Top5_Data));
    }
}
