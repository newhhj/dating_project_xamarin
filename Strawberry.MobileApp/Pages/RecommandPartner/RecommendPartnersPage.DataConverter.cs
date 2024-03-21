using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.RecommandPartner
{
    public class RecommendPartnersPage_DataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "Title":
                {
                    switch ((int)value)
                    {
                        case 1:
                            return "딸기 추천";
                        case 2:
                            return "상위 10%";
                        case 3:
                            return "진지함";
                        case 4:
                            return "연락잘되는";
                        case 5:
                            return "음주가능";
                        case 6:
                            return "번개만남";
                        case 7:
                            return "맛집홀릭";
                        case 8:
                            return "동네친구";
                        case 9:
                            return "선호 성격";
                        case 10:
                            return "선호 체형";
                        case 11:
                            return "선호 키";
                        case 12:
                            return "운동 좋아";
                        default:
                            break;
                    }
                    break;
                }
                default:
                    break;
            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
