using System;
using System.Globalization;

namespace MyUnitConverter.Converters
{
	public class CurrencySignConverter : IValueConverter
	{
		public CurrencySignConverter()
		{
		}

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if((string)value == "USD - US Dollar")
            {
                return "USD $";
            }
            else if ((string)value == "GBP - Pound Sterling")
            {
                // Opt + 3
                return "£";
            }
            else if ((string)value == "EUR - Euro")
            {
                // Opt + Shift + 2
                return "€";
            }
            else if ((string)value == "BTC - Bitcoin")
            {
                return "₿";
            }
            else if ((string)value == "MXN - Mexican Peso")
            {
                return "₱";
            }
            else if ((string)value == "CAD - Canadian Dollar")
            {
                return "CAD $";
            }
            else if ((string)value == "JPY - Japanese Yen")
            {
                // Opt + y
                return "¥";
            }
            else if ((string)value == "RUB - Russian Ruble")
            {
                return "₽";
            }
            else
            {
                return "";
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

