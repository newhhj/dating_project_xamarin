using Strawberry.MobileApp.DataModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.Pages.Join
{
    public class Data_Join_Preference : BindableObject, IValueConverter, IMultiValueConverter
    {
        public Data_Join_Preference()
        {
            
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                switch (parameter)
                {
                    case "MinAge":
                    {
                        return (GenderTypes)value == GenderTypes.Male ? 19 : 25;
                    }
                    case "NullValueTextColor":
                    {
                        return value == null ? Color.FromHex("#7A7A7A") : Color.FromHex("#4A9CFF");
                    }
                    case "BeautyOrWealthHeader":
                    {
                        return App.Instance.Member.Gender == GenderTypes.Male ? "미모" : "재력";
                    }
                    case "BeautyOrWealthValue":
                    {
                        return (bool)value ? "예" : "아니오";
                    }
                    case "PriorityValue":
                    {
                        switch ((PriorityTypes)value)
                        {
                            case PriorityTypes.BeautyOrWealth:
                                return App.Instance.Member.Gender == GenderTypes.Male ? "미모" : "재력";
                            case PriorityTypes.Age:
                                return "나이";
                            case PriorityTypes.Range:
                                return "거리";
                            case PriorityTypes.Tall:
                                return "키";
                            case PriorityTypes.Body:
                                return "체형";
                            case PriorityTypes.Religion:
                                return "종교";
                            case PriorityTypes.Alcohol:
                                return "음주";
                            case PriorityTypes.Smoking:
                                return "흡연";
                            case PriorityTypes.None:
                            default:
                                return "없음";
                        }
                    }
                    default:
                        throw new Exception();
                }
            }
            catch
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                switch (parameter)
                {
                    case "TallText":
                    {
                        var minTall = (int)values[0];
                        var maxTall = (int)values[1];

                        var minTallText = default(string);
                        var maxTallText = default(string);

                        if (minTall > 190)
                            minTallText = "190cm 이상";
                        else
                            minTallText = $"{minTall}cm";

                        if (maxTall > 190)
                            maxTallText = "190cm 이상";
                        else
                            maxTallText = $"{maxTall}cm";

                        return $"{minTallText} ~ {maxTallText}";
                    }
                    case "BeautyOrWealthHeader":
                    {
                        return App.Instance.Member.Gender == GenderTypes.Male ? "미모" : "재력";
                    }
                    case "BeautyOrWealthValue":
                    {
                        return App.Instance.Member.Gender == GenderTypes.Male ? "미모" : "재력";
                    }
                    default:
                        return values;
                }
            }
            catch
            {
                return values;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
