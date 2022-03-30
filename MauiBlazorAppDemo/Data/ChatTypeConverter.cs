using System;
using System.Globalization;
namespace MauiBlazorAppDemo.Data
{
    
    public class ChatTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (string)value;
            if (!string.IsNullOrEmpty(status))
            {
                if (status == "transferrequest")
                {
                    return "Transferred";
                }
                else if (status == "start")
                {
                    return null;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
