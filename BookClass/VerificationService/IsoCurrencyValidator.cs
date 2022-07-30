using System;

namespace VerificationService
{
    /// <summary>
    /// Class for validating currency strings.
    /// </summary>
    public static class IsoCurrencyValidator
    {
        /// <summary>
        /// Determines whether a specified string is a valid ISO currency symbol.
        /// </summary>
        /// <param name="currency">Currency string to check.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="currency"/> is a valid ISO currency symbol; <see langword="false"/> otherwise.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if currency is null.</exception>
        public static bool IsValid(string currency)
        {
            if (currency is null)
            {
                throw new ArgumentNullException(nameof(currency));
            }

            char[] charCurrency = currency.ToCharArray();

            for (var i = 0; i < currency.Length; i++)
            {
                if (char.IsPunctuation(charCurrency[i]))
                {
                    throw new ArgumentException("Invalid currency", nameof(currency));
                }
            }

            string[] isoCurrency =
                {
                "AED", "ALL", "AMD", "ARS", "AUD", "AZN", "BGN", "BHD", "BND", "BOB", "BRL",
                "BYR", "BZD", "CAD", "CHF", "CLP", "CNY", "COP", "CRC", "CZK", "DKK", "DOP", "DZD", "EEK",
                "EGP", "ETB", "EUR", "GBP", "GTQ", "HKD", "HNL", "HRK", "HUF", "IDR", "ILS", "INR", "IQD", "IRR",
                "ISK", "JMD", "JOD", "JPY", "KES", "KG", "KRW", "KWD", "KZT", "LBP", "LTL", "LVL", "LYD", "MAD",
                "MKD", "MNT", "MOP", "MVR", "MXN", "MYR", "NIO", "NOK", "NZD", "OMR", "PAB", "PHP", "PKR",
                "PLN", "PYG", "QAR", "RON", "RSD", "RUB", "SAR", "SEK", "SYP", "THB", "TND", "TRY", "TTD", "TWD",
                "UAH", "USD", "UYU", "UZS", "VEF", "VND", "YER", "ZAR", "ŻEL", "ZWL",
                };

            for (var i = 0; i < isoCurrency.Length; i++)
            {
                if (currency == isoCurrency[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
