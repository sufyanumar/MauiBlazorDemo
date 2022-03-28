using System;
using System.Globalization;


namespace MauiBlazorAppDemo.Data
{
    public class DateTimeToFriendlyTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                var timeEnded = string.Empty;
                try
                {
                    var currentDate = (DateTime)value;
                    var now = DateTime.UtcNow;
                    TimeSpan dif = now - currentDate;
                    var endDate = now.AddMinutes(-dif.TotalMinutes);
                    if ((endDate.Date == DateTime.UtcNow.Date))
                    {
                        timeEnded = endDate.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        timeEnded = currentDate.ToString("MM/dd/yyyy");
                    }
                }
                catch(Exception err)
                {

                }
                return timeEnded;
            }

            return value ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
