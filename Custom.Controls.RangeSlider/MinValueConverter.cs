using System;
using System.Globalization;
using System.Windows.Data;

namespace SpectrumDynamics.Controls.RangeSlider
{
    public class MinValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return 1.222;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
