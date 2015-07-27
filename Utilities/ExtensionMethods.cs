using System.Globalization;

namespace Utilities
{
    public static class CurrencyExtensions
    {
        public static string AsCurrency(this int value)
        {
            return value.AsCurrency(CultureInfo.CurrentCulture);
        }

        public static string AsCurrency(this int value, CultureInfo culture)
        {
            var result = value/100m;
            return result.ToString("c", culture);
        }

        public static decimal AsCurrencyValue(this string value)
        {
            decimal returnValue;
            decimal.TryParse(value, out returnValue);
            return returnValue;
        }
    }
}