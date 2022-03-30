using System.Globalization;

namespace MauiBlazorAppDemo.Data
{
    /// <summary>
    /// Multi converter.
    /// </summary>
    public class AnyTrueMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0)
                return false;

            var boolValues = values.OfType<bool>().ToArray();

            if (boolValues.Length != values.Length)
                return false;

            var count = boolValues.Count(v => v);

            if (count>=1)
            {
                return true;
            }

            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
