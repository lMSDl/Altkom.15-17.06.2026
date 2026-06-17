using System.Globalization;
using System.Windows.Controls;

namespace Warehouse.ValidationRules
{
    public class PriceValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (float.TryParse(value.ToString(), out float price))
            {
                if (price < 0)
                {
                    return new ValidationResult(false, "Price cannot be negative.");
                }
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Invalid price format.");
        }
    }
}
