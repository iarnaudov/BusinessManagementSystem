﻿namespace BmsWpf.Utilities
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;

    public class MultiValueConverter : IMultiValueConverter
    {
        public static MultiValueConverter converter = null;

        public object Convert(object[] values, Type targetType,
            object parameter, CultureInfo culture)
        {
            return values.ToList();
        }

        public object[] ConvertBack(object value, Type[] targetTypes,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
