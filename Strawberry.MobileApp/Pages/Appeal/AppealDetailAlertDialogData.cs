using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Appeal
{
    public class AppealDetailAlertDialogData : BindableObject
    {
        public string Title { get => (string)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(AppealDetailAlertDialogData));

        public string Message { get => (string)GetValue(MessageProperty); set => SetValue(MessageProperty, value); }
        public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(AppealDetailAlertDialogData));

        public string EtcMessage { get => (string)GetValue(EtcMessageProperty); set => SetValue(EtcMessageProperty, value); }
        public static readonly BindableProperty EtcMessageProperty = BindableProperty.Create(nameof(EtcMessage), typeof(string), typeof(AppealDetailAlertDialogData));

        public Color Item01TextColor
        {
            get
            {
                return this.Title == "욕설 및 비방" ? Color.FromHex("#4A9CFF") : Color.Black;
            }
        }

        public Color Item02TextColor
        {
            get
            {
                return this.Title == "개인 신상정보 노출" ? Color.FromHex("#4A9CFF") : Color.Black;
            }
        }

        public Color Item03TextColor
        {
            get
            {
                return this.Title == "광고 및 도배" ? Color.FromHex("#4A9CFF") : Color.Black;
            }
        }

        public Color Item04TextColor
        {
            get
            {
                return this.Title == "부적절한 사진" ? Color.FromHex("#4A9CFF") : Color.Black;
            }
        }

        public Color Item05TextColor
        {
            get
            {
                return this.Title == "기타" ? Color.FromHex("#4A9CFF") : Color.Black;
            }
        }

        public Color ExcuteButtonColor
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Title) ? Color.FromHex("#C5C5C5") : Color.FromHex("#4A9CFF");
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.Title):
                    base.OnPropertyChanged(nameof(this.Item01TextColor));
                    base.OnPropertyChanged(nameof(this.Item02TextColor));
                    base.OnPropertyChanged(nameof(this.Item03TextColor));
                    base.OnPropertyChanged(nameof(this.Item04TextColor));
                    base.OnPropertyChanged(nameof(this.Item05TextColor));
                    base.OnPropertyChanged(nameof(this.ExcuteButtonColor));
                    break;
                case nameof(this.EtcMessage):
                    if (!string.IsNullOrWhiteSpace(this.EtcMessage))
                    {
                        this.Title = "기타";
                        this.Message = this.EtcMessage;
                    }
                    else
                    {
                        this.Title = null;
                        this.Message = null;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
