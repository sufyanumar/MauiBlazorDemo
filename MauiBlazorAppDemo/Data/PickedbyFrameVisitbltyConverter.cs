using System;
using System.Globalization;

namespace MauiBlazorAppDemo.Data
{
    public class PickedbyFrameVisitbltyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string pickedby)
            {
                if (pickedby == "" || pickedby.Contains("Unknown") || pickedby == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
