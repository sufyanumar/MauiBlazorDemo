using System;
using System.Globalization;

namespace MauiBlazorAppDemo.Data
{
    public class InitiatedbyInttoImgSrc : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (string)value;
            //var label = parameter as Label;

            //var initiatedby = int.Parse(label.Text);

            if (status == "Web Chat")
            {
                //if (initiatedby == (int)ChatInitiatedBy.SmsStatic)
                //{
                //    return "sms_profile";
                //}
                //else if (initiatedby == (int)ChatInitiatedBy.Standard)
                //{
                //    return "desktop";
                //}
                return "web_active";
            }
            else
            {
                //if (initiatedby == (int)ChatInitiatedBy.SmsStatic)
                //{
                //    return "sms_profile";
                //}
                //else if (initiatedby == (int)ChatInitiatedBy.Standard)
                //{
                //    return "web_active";
                //}
                return "sms_profile";
            }
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
