namespace Qrdentity.Web.Utilities;

public static class OrderNumberGenerator
{
    public static string Generate()
    {
        string orderNumber = DecimalToArbitrarySystem(DateTime.Now.Ticks, 32);
        return orderNumber;
    }

    /// <summary>
    /// Converts the given decimal number to the numeral system with the
    /// specified radix (in the range [2, 36]).
    /// https://www.pvladov.com/2012/05/decimal-to-arbitrary-numeral-system.html
    /// </summary>
    /// <param name="decimalNumber">The number to convert.</param>
    /// <param name="radix">The radix of the destination numeral system (in the range [2, 36]).</param>
    /// <returns></returns>
    private static string DecimalToArbitrarySystem(long decimalNumber, int radix)
    {
        const int bitsInLong = 64;
        const string allowedDigits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        if (radix < 2 || radix > allowedDigits.Length)
        {
            //TODO
            throw new ArgumentException("The radix must be >= 2 and <= " + allowedDigits.Length);
        }

        if (decimalNumber == 0)
        {
            return "0";
        }

        int index = bitsInLong - 1;
        long currentNumber = Math.Abs(decimalNumber);
        char[] charArray = new char[bitsInLong];

        while (currentNumber != 0)
        {
            int remainder = (int)(currentNumber % radix);
            charArray[index--] = allowedDigits[remainder];
            currentNumber /= radix;
        }

        string result = new String(charArray, index + 1, bitsInLong - index - 1);
        if (decimalNumber < 0)
        {
            result = "-" + result;
        }

        return result;
    }

    /// <summary>
    /// Converts the given number from the numeral system with the specified
    /// radix (in the range [2, 36]) to decimal numeral system.
    /// https://www.pvladov.com/2012/07/arbitrary-to-decimal-numeral-system.html
    /// </summary>
    /// <param name="number">The arbitrary numeral system number to convert.</param>
    /// <param name="radix">The radix of the numeral system the given number
    /// is in (in the range [2, 36]).</param>
    /// <returns></returns>
    private static long ArbitraryToDecimalSystem(string number, int radix)
    {
        const string allowedDigits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        if (radix < 2 || radix > allowedDigits.Length)
        {
            //TODO
            throw new ArgumentException("The radix must be >= 2 and <= " + allowedDigits.Length);
        }

        if (string.IsNullOrEmpty(number))
        {
            return 0;
        }

        // Make sure the arbitrary numeral system number is in upper case
        number = number.ToUpperInvariant();

        long result = 0;
        long multiplier = 1;
        for (int i = number.Length - 1; i >= 0; i--)
        {
            char c = number[i];
            if (i == 0 && c == '-')
            {
                // This is the negative sign symbol
                result = -result;
                break;
            }

            int digit = allowedDigits.IndexOf(c);
            if (digit == -1)
            {
                //TODO
                throw new ArgumentException(
                    "Invalid character in the arbitrary numeral system number",
                    nameof(number));
            }

            result += digit * multiplier;
            multiplier *= radix;
        }

        return result;
    }
}