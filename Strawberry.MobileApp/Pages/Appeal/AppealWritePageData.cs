using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using static Strawberry.MobileApp.Pages.Appeal.AppealPage_Data;

namespace Strawberry.MobileApp.Pages.Appeal
{
    public class AppealWritePageData : BindableObject
    {
        

        public ContentTypes ContentType { get => (ContentTypes)GetValue(ContentTypeProperty); set => SetValue(ContentTypeProperty, value); }
        public static readonly BindableProperty ContentTypeProperty = BindableProperty.Create(nameof(ContentType), typeof(ContentTypes), typeof(AppealWritePageData));

        public List<ImageSource> Images { get => (List<ImageSource>)GetValue(ImagesProperty); set => SetValue(ImagesProperty, value); }
        public static readonly BindableProperty ImagesProperty = BindableProperty.Create(nameof(Images), typeof(List<ImageSource>), typeof(AppealWritePageData));

        public string Content { get => (string)GetValue(ContentProperty); set => SetValue(ContentProperty, value); }
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(string), typeof(AppealWritePageData));

        public string Area { get => (string)GetValue(AreaProperty); set => SetValue(AreaProperty, value); }
        public static readonly BindableProperty AreaProperty = BindableProperty.Create(nameof(Area), typeof(string), typeof(AppealWritePageData));

        public string Time { get => (string)GetValue(TimeProperty); set => SetValue(TimeProperty, value); }
        public static readonly BindableProperty TimeProperty = BindableProperty.Create(nameof(Time), typeof(string), typeof(AppealWritePageData));

        public bool UseComment { get => (bool)GetValue(UseCommentProperty); set => SetValue(UseCommentProperty, value); }
        public static readonly BindableProperty UseCommentProperty = BindableProperty.Create(nameof(UseComment), typeof(bool), typeof(AppealWritePageData), true);

        public bool ImageContainerVisible
        {
            get
            {
                switch (this.ContentType)
                {
                    case ContentTypes.Boast:
                    case ContentTypes.Metting:
                    case ContentTypes.Sell:
                        return true;
                    case ContentTypes.Talk:
                    default:
                        return false;
                }
            }
        }

        public bool PlaceHolderType01Visible
        {
            get
            {
                switch (this.ContentType)
                {
                    case ContentTypes.Boast:
                    case ContentTypes.Sell:
                    case ContentTypes.Talk:
                        return string.IsNullOrWhiteSpace(this.Content);
                    case ContentTypes.Metting:
                    default:
                        return false;
                }
            }
        }

        public bool PlaceHolderType02Visible
        {
            get
            {
                switch (this.ContentType)
                {
                    case ContentTypes.Metting:
                        return string.IsNullOrWhiteSpace(this.Content);
                    case ContentTypes.Boast:
                    case ContentTypes.Sell:
                    case ContentTypes.Talk:
                    default:
                        return false;
                }
            }
        }

        public bool SubViewType01Visible
        {
            get
            {
                return this.ContentType == ContentTypes.Metting;
            }
        }

        public bool SubViewType02Visible
        {
            get
            {
                return this.ContentType == ContentTypes.Sell;
            }
        }

        public AppealWritePageData()
        {
            this.Images = new List<ImageSource>();
            for (int i = 0; i < 6; i++)
                this.Images.Add(null);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.ContentType):
                    base.OnPropertyChanged(nameof(this.ImageContainerVisible));
                    base.OnPropertyChanged(nameof(this.PlaceHolderType01Visible));
                    base.OnPropertyChanged(nameof(this.PlaceHolderType02Visible));
                    base.OnPropertyChanged(nameof(this.SubViewType01Visible));
                    base.OnPropertyChanged(nameof(this.SubViewType02Visible));
                    break;
                case nameof(this.Content):
                    base.OnPropertyChanged(nameof(this.PlaceHolderType01Visible));
                    base.OnPropertyChanged(nameof(this.PlaceHolderType02Visible));
                    break;
                default:
                    break;
            }
        }
    }
}
