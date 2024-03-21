using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Chatting
{
    public class ChattingPageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MyTextMessage { get; set; }
        public DataTemplate MyImageMessage { get; set; }
        public DataTemplate MyVoiceMessage { get; set; }

        public DataTemplate PartnerTextMessage { get; set; }
        public DataTemplate PartnerImageMessage { get; set; }
        public DataTemplate PartnerVoiceMessage { get; set; }

        public DataTemplate WaitMessage { get; set; }
        public DataTemplate CloseMessage { get; set; }
        public DataTemplate StarPointMessage { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var data = item as ChattingPageData_Message;
            switch (data.Type)
            {
                case DataModels.MessageTypes.Text:
                    return data.IsMyMsg ? this.MyTextMessage : this.PartnerTextMessage;
                case DataModels.MessageTypes.Image:
                    return data.IsMyMsg ? this.MyImageMessage : this.PartnerImageMessage;
                case DataModels.MessageTypes.Voice:
                    return data.IsMyMsg ? this.MyVoiceMessage : this.PartnerVoiceMessage;
                case DataModels.MessageTypes.Wait:
                    return this.WaitMessage;
                case DataModels.MessageTypes.Close:
                    return this.CloseMessage;
                case DataModels.MessageTypes.StarPoint:
                    return this.StarPointMessage;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
