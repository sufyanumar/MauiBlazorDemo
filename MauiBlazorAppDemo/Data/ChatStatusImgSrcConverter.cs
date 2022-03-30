using System;
using System.Globalization;
namespace MauiBlazorAppDemo.Data
{
    
    public class ChatStatusImgSrcConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (int)value;

            if (status == (int)NotificationStatusEnum.Picked)
            {
                return "check_small.png";
            }
            else if (status == (int)NotificationStatusEnum.Rejected)
            {
                return "cross_small.png";
            }
            else if (status == (int)NotificationStatusEnum.Missed)
            {
                return "missed_small.png";
            }
            else if (status == (int)NotificationStatusEnum.NotPicked)
            {
                return "missed_small.png";
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
