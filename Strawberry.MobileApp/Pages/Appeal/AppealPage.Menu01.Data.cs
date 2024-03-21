using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Appeal
{
    public class AppealPage_Menu01_Data : BindableObject
    {
        public int Id { get => (int)GetValue(IdProperty); set => SetValue(IdProperty, value); }
        public static readonly BindableProperty IdProperty = BindableProperty.Create(nameof(Id), typeof(int), typeof(AppealPage_Menu01_Data));

        public string[] ContentImages { get => (string[])GetValue(ContentImagesProperty); set => SetValue(ContentImagesProperty, value); }
        public static readonly BindableProperty ContentImagesProperty = BindableProperty.Create(nameof(ContentImages), typeof(string[]), typeof(AppealPage_Menu01_Data));

        public string ContentImage
        {
            get
            {
                return this.ContentImages?.FirstOrDefault();
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.ContentImages):
                    base.OnPropertyChanged(nameof(this.ContentImage));
                    break;
                default:
                    break;
            }
        }
    }
}
