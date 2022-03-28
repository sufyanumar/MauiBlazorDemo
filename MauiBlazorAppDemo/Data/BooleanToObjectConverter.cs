﻿using System.Globalization;

namespace MauiBlazorAppDemo.Data
{
        /// <summary>
        /// Boolean to object converter.
        /// </summary>
        public class BooleanToObjectConverter<T> : IValueConverter
        {
            /// <summary>
            /// Init this instance.
            /// </summary>
            public static void Init()
            {
                var time = DateTime.UtcNow;
            }

            /// <summary>
            /// Gets or sets the false object.
            /// </summary>
            /// <value>The false object.</value>
            public T FalseObject { set; get; }

            /// <summary>
            /// Gets or sets the true object.
            /// </summary>
            /// <value>The true object.</value>
            public T TrueObject { set; get; }

            /// <param name="value">To be added.</param>
            /// <param name="targetType">To be added.</param>
            /// <param name="parameter">To be added.</param>
            /// <param name="culture">To be added.</param>
            /// <summary>
            /// Convert the specified value, targetType, parameter and culture.
            /// </summary>
            public object Convert(object value, Type targetType,
                object parameter, CultureInfo culture)
            {
                return (bool)value ? this.TrueObject : this.FalseObject;
            }

            /// <param name="value">To be added.</param>
            /// <param name="targetType">To be added.</param>
            /// <param name="parameter">To be added.</param>
            /// <param name="culture">To be added.</param>
            /// <summary>
            /// Converts the back.
            /// </summary>
            /// <returns>The back.</returns>
            public object ConvertBack(object value, Type targetType,
                object parameter, CultureInfo culture)
            {
                return ((T)value).Equals(this.TrueObject);
            }
        }
}
