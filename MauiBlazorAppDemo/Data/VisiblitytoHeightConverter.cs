using System;
using System.Globalization;

namespace MauiBlazorAppDemo.Data
{
    public class VisiblitytoHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bol = (bool)value;
            if (bol) { return new GridLength (40, GridUnitType.Absolute); }
            else { return new GridLength(0, GridUnitType.Absolute); }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}
