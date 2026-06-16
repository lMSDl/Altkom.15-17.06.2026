using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace Dices.Converters
{
    public class DiceValueToImageSourceConverter : MarkupExtension, IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int diceValue && diceValue >= 1 && diceValue <= 6)
            {
                return new ImageSourceConverter().ConvertFromString($"Images/kostka{diceValue}.png");
            }


            return new ImageSourceConverter().ConvertFromString("Images/kostkapusta.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
