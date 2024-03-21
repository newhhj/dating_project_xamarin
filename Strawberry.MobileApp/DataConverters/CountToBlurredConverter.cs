using FFImageLoading.Forms;
using FFImageLoading.Transformations;
using FFImageLoading.Work;
using PanCardView.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Strawberry.MobileApp.DataConverters
{
    public class CountToBlurredConverter : IValueConverter, IMultiValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var carouselView = (PanCardView.CarouselView)parameter;
                var items = carouselView.ItemsSource;
                var idx = -1;
                if (items != null)
                    idx = items.FindIndex((string)value);

                if (targetType == typeof(List<ITransformation>))
                {
                    if (idx == -1)
                        return null;

                    if (idx < App.Instance.Member.ProfileImages.Count)
                        return null;
                    else
                        return new List<FFImageLoading.Work.ITransformation>
                        {
                            new BlurredTransformation(30)
                        };
                }
                else if (targetType == typeof(bool))
                {
                    if (idx == -1)
                        return false;

                    if (idx < App.Instance.Member.ProfileImages.Count)
                        return false;
                    else
                        return true;
                }

                throw new NotImplementedException();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "ToBlur":
                {
                    var SelectedIndex = (int)values[0];
                    var ProfileImagesCount = (int)values[1];

                    if (SelectedIndex + 1 > ProfileImagesCount)
                    {
                        return new List<ITransformation>
                        {
                            new BlurredTransformation(30)
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
                case "ToVisible":
                {
                    var SelectedIndex = (int)values[0];
                    var ProfileImagesCount = (int)values[1];

                    if (SelectedIndex + 1 > ProfileImagesCount)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
