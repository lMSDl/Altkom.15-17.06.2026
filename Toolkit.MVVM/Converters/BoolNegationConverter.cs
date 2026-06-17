using System.Globalization;

namespace Toolkit.MVVM.Converters
{
    public class BoolNegationConverter : BaseConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
            {
                return !b;
            }
            return false;
        }
    }
}
