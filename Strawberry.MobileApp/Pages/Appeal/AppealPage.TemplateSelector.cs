using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Appeal
{
    public class AppealPage_TemplateSelector : DataTemplateSelector
    {
        public DataTemplate Type01 { get; set; }
        public DataTemplate Type02 { get; set; }
        public DataTemplate Type03 { get; set; }
        public DataTemplate Type04 { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is AppealPage_Menu01_Data)
                return Type01;
            if (item is AppealPage_Menu02_Data)
                return Type02;
            if (item is AppealPage_Menu03_Data)
                return Type03;
            if (item is AppealPage_Menu04_Data)
                return Type04;

            throw new NotImplementedException();
        }
    }
}
