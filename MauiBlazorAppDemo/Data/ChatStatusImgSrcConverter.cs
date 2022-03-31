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
                return "check_small";
            }
            else if (status == (int)NotificationStatusEnum.Rejected)
            {
                return "cross_small";
            }
            else if (status == (int)NotificationStatusEnum.Missed)
            {
                return "missed_small";
            }
            else if (status == (int)NotificationStatusEnum.NotPicked)
            {
                return "missed_small";
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
