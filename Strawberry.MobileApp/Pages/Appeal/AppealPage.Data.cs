using FFImageLoading.Svg.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Appeal
{
    public class AppealPage_Data : BindableObject
    {
        public enum ContentTypes
        {
            /// <summary>
            /// 자랑
            /// </summary>
            Boast = 0,
            /// <summary>
            /// 번개(쏜다)
            /// </summary>
            Metting,
            /// <summary>
            /// 판매
            /// </summary>
            Sell,
            /// <summary>
            /// 수다
            /// </summary>
            Talk
        }

        public ContentTypes ContentType { get => (ContentTypes)GetValue(ContentTypeProperty); set => SetValue(ContentTypeProperty, value); }
        public static readonly BindableProperty ContentTypeProperty = BindableProperty.Create(nameof(ContentType), typeof(ContentTypes), typeof(AppealPage_Data));

        public ObservableCollection<AppealPage_Top5_Data> Top5Items { get => (ObservableCollection<AppealPage_Top5_Data>)GetValue(Top5ItemsProperty); set => SetValue(Top5ItemsProperty, value); }
        public static readonly BindableProperty Top5ItemsProperty = BindableProperty.Create(nameof(Top5Items), typeof(ObservableCollection<AppealPage_Top5_Data>), typeof(AppealPage_Data));

        public ObservableCollection<object> Items { get => (ObservableCollection<object>)GetValue(ItemsProperty); set => SetValue(ItemsProperty, value); }
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<object>), typeof(AppealPage_Data));

        public Color Menu01TextColor
        {
            get
            {
                return this.ContentType == ContentTypes.Boast ? Color.FromHex("#000000") : Color.FromHex("#A6333333");
            }
        }

        public Color Menu02TextColor
        {
            get
            {
                return this.ContentType == ContentTypes.Metting ? Color.FromHex("#000000") : Color.FromHex("#A6333333");
            }
        }

        public Color Menu03TextColor
        {
            get
            {
                return this.ContentType == ContentTypes.Sell ? Color.FromHex("#000000") : Color.FromHex("#A6333333");
            }
        }

        public Color Menu04TextColor
        {
            get
            {
                return this.ContentType == ContentTypes.Sell ? Color.FromHex("#000000") : Color.FromHex("#A6333333");
            }
        }

        public Color Menu01IndicatorColor
        {
            get
            {
                return this.ContentType == ContentTypes.Boast ? Color.FromHex("#3641E6E6") : Color.Transparent;
            }
        }

        public Color Menu02IndicatorColor
        {
            get
            {
                return this.ContentType == ContentTypes.Metting ? Color.FromHex("#3641E6E6") : Color.Transparent;
            }
        }

        public Color Menu03IndicatorColor
        {
            get
            {
                return this.ContentType == ContentTypes.Sell ? Color.FromHex("#3641E6E6") : Color.Transparent;
            }
        }

        public Color Menu04IndicatorColor
        {
            get
            {
                return this.ContentType == ContentTypes.Talk ? Color.FromHex("#3641E6E6") : Color.Transparent;
            }
        }

        public bool Top5Visible
        {
            get
            {
                return this.Top5Items != null && this.Top5Items.Count > 0;
            }
        }

        public ImageSource BackButtonImageSource
        {
            get
            {
                return SvgImageSource.FromResource("Strawberry.MobileApp.Images.icon_back01.svg", this.GetType().Assembly);
            }
        }

        public bool HasMoreData { get; set; }

        public AppealPage_Data()
        {
            this.Top5Items = new ObservableCollection<AppealPage_Top5_Data>();
            this.Top5Items.CollectionChanged += this.Top5Items_CollectionChanged;

            this.Items = new ObservableCollection<object>();

            this.HasMoreData = true;
        }

        private void Top5Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnPropertyChanged(nameof(this.Top5Visible));
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.ContentType):
                    base.OnPropertyChanged(nameof(this.Menu01TextColor));
                    base.OnPropertyChanged(nameof(this.Menu02TextColor));
                    base.OnPropertyChanged(nameof(this.Menu03TextColor));
                    base.OnPropertyChanged(nameof(this.Menu04TextColor));
                    base.OnPropertyChanged(nameof(this.Menu01IndicatorColor));
                    base.OnPropertyChanged(nameof(this.Menu02IndicatorColor));
                    base.OnPropertyChanged(nameof(this.Menu03IndicatorColor));
                    base.OnPropertyChanged(nameof(this.Menu04IndicatorColor));
                    break;
                case nameof(this.Top5Items):
                    base.OnPropertyChanged(nameof(this.Top5Visible));
                    break;
                default:
                    break;
            }
        }
    }
}
