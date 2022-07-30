using System;
using System.Text;

namespace VerificationService
{
    /// <summary>
    /// Verifies if the string representation of number is a valid ISBN-10 or ISBN-13 identification number of book.
    /// </summary>
    public static class IsbnVerifier
    {
        private const int PositionOfTheNumberZeroInTheAscii = 48;

        /// <summary>
        /// Verifies if the string representation of number is a valid ISBN-10 or ISBN-13 identification number of book.
        /// </summary>
        /// <param name="isbn">The string representation of book's isbn.</param>
        /// <returns>true if number is a valid ISBN-10 or ISBN-13 identification number of book, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown if isbn is null.</exception>
        public static bool IsValid(string isbn)
        {
            Validate(isbn);

            if (isbn.Length != 10 && isbn.Length != 12 && isbn.Length != 13 && isbn.Length != 17)
            {
                return false;
            }

            for (var i = 0; i < isbn.Length - 1; i++)
            {
                if (isbn[i] == '-' && isbn[i + 1] == '-')
                {
                    return false;
                }
            }

            string[] subs = isbn.Split('-');

            StringBuilder sb = new StringBuilder();

            foreach (var sub in subs)
            {
                sb.Append(sub);
            }

            var sum = 0;
            var result = false;

            if (sb.Length == 10)
            {
                sum = IsbnCodeTen(sb);
                result = Check(sb, sum);
            }

            if (sb.Length == 13)
            {
                sum = IsbnCodeThirteen(sb);
                result = Check(sb, sum);
            }

            return result;
        }

        private static void Validate(string isbn)
        {
            if (isbn is null)
            {
                throw new ArgumentNullException(nameof(isbn));
            }
        }

        private static int IsbnCodeTen(StringBuilder sb)
        {
            var sum = 0;

            for (var i = 0; i < sb.Length - 1; i++)
            {
                sum += (i + 1) * (sb[i] - PositionOfTheNumberZeroInTheAscii);
            }

            sum %= 11;
            return sum;
        }

        private static int IsbnCodeThirteen(StringBuilder sb)
        {
            var sum = 0;
            for (var i = 0; i < sb.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    sum += sb[i] - PositionOfTheNumberZeroInTheAscii;
                }
                else
                {
                    sum += 3 * (sb[i] - PositionOfTheNumberZeroInTheAscii);
                }
            }

            sum %= 10;
            sum = 10 - sum;

            return sum;
        }

        private static bool Check(StringBuilder sb, int sum)
        {
            if (sum == 10 && sb[sb.Length - 1] == 'X')
            {
                return true;
            }

            if (sum == sb[sb.Length - 1] - PositionOfTheNumberZeroInTheAscii)
            {
                return true;
            }

            return false;
        }
    }
}
