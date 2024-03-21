using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.RecommandPartner
{
    public class RecommendPartnersPage_Data : BindableObject
    {
        public int DataType { get => (int)GetValue(DataTypeProperty); set => SetValue(DataTypeProperty, value); }
        public static readonly BindableProperty DataTypeProperty = BindableProperty.Create(nameof(DataType), typeof(int), typeof(RecommendPartnersPage_Data));

        public ObservableCollection<RecommendPartnersPage_Data_Item> Items { get => (ObservableCollection<RecommendPartnersPage_Data_Item>)GetValue(ItemsProperty); set => SetValue(ItemsProperty, value); }
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<RecommendPartnersPage_Data_Item>), typeof(RecommendPartnersPage_Data));
    }

    public class RecommendPartnersPage_Data_Item : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(RecommendPartnersPage_Data));

        public string ProfileImage { get => (string)GetValue(ProfileImageProperty); set => SetValue(ProfileImageProperty, value); }
        public static readonly BindableProperty ProfileImageProperty = BindableProperty.Create(nameof(ProfileImage), typeof(string), typeof(RecommendPartnersPage_Data));

        public string Nickname { get => (string)GetValue(NicknameProperty); set => SetValue(NicknameProperty, value); }
        public static readonly BindableProperty NicknameProperty = BindableProperty.Create(nameof(Nickname), typeof(string), typeof(RecommendPartnersPage_Data));

        public int Age { get => (int)GetValue(AgeProperty); set => SetValue(AgeProperty, value); }
        public static readonly BindableProperty AgeProperty = BindableProperty.Create(nameof(Age), typeof(int), typeof(RecommendPartnersPage_Data));

        public string Job { get => (string)GetValue(JobProperty); set => SetValue(JobProperty, value); }
        public static readonly BindableProperty JobProperty = BindableProperty.Create(nameof(Job), typeof(string), typeof(RecommendPartnersPage_Data));

        public int Range { get => (int)GetValue(RangeProperty); set => SetValue(RangeProperty, value); }
        public static readonly BindableProperty RangeProperty = BindableProperty.Create(nameof(Range), typeof(int), typeof(RecommendPartnersPage_Data));
    }
}
