using System.Text;
using static System.Math;

namespace NumberWords
{
    public static class Converter
    {
        /// <summary>
        /// Returns the string representation of the <paramref name="number"/>.
        /// </summary>
        /// <param name="number">A number to convert.</param>
        /// <returns>The string representation of the <paramref name="number"/>.</returns>
        public static string ConvertInteger(int number)
        {
            if (number == 0)
            {
                return "zero";
            }

            if (number < 0)
            {
                return "minus " + ConvertInteger(Math.Abs(number));
            }

            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            string result = string.Empty;

            while (number > 0)
            {
                int digit = number % 10;
                result = digits[digit] + " " + result;
                number /= 10;
            }

            return result.Trim();
        }

        /// <summary>
        /// Writes the string representation of the <paramref name="number"/> to
        /// the <paramref name="stringBuilder"/>.
        /// </summary>
        /// <param name="number">A number to convert.</param>
        public static void ConvertDecimal(decimal number, StringBuilder stringBuilder)
        {
            string numberString = number.ToString();

            for (int i = 0; i < numberString.Length; i++)
            {
                char c = numberString[i];

                if (i != 0)
                {
                    stringBuilder.Append(' ');
                }

                switch (c)
                {
                    case '0':
                        stringBuilder.Append("zero");
                        break;
                    case '1':
                        stringBuilder.Append("one");
                        break;
                    case '2':
                        stringBuilder.Append("two");
                        break;
                    case '3':
                        stringBuilder.Append("three");
                        break;
                    case '4':
                        stringBuilder.Append("four");
                        break;
                    case '5':
                        stringBuilder.Append("five");
                        break;
                    case '6':
                        stringBuilder.Append("six");
                        break;
                    case '7':
                        stringBuilder.Append("seven");
                        break;
                    case '8':
                        stringBuilder.Append("eight");
                        break;
                    case '9':
                        stringBuilder.Append("nine");
                        break;
                    case '.':
                        stringBuilder.Append("point");
                        break;
                }
            }
        }

        /// <summary>
        /// Returns the string representation of the <paramref name="number"/>.
        /// </summary>
        /// <param name="number">A number to convert.</param>
        /// <returns>The string representation of the <paramref name="number"/>.</returns>
        public static string ConverDouble(double number)
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            string result = string.Empty;
            switch (number)
            {
                case double.Epsilon:
                    return "Double epsilon";
                case double.NaN:
                    return "NaN";
                case double.NegativeInfinity:
                    return "-∞";
                case double.PositiveInfinity:
                    return "+∞";
            }

            string numberString = number.ToString();

            foreach (char c in numberString)
            {
                switch (c)
                {
                    case '0':
                        result += $"{digits[0]} ";
                        break;
                    case '1':
                        result += $"{digits[1]} ";
                        break;
                    case '2':
                        result += $"{digits[2]} ";
                        break;
                    case '3':
                        result += $"{digits[3]} ";
                        break;
                    case '4':
                        result += $"{digits[4]} ";
                        break;
                    case '5':
                        result += $"{digits[5]} ";
                        break;
                    case '6':
                        result += $"{digits[6]} ";
                        break;
                    case '7':
                        result += $"{digits[7]} ";
                        break;
                    case '8':
                        result += $"{digits[8]} ";
                        break;
                    case '9':
                        result += $"{digits[9]} ";
                        break;
                    case '.':
                        result += "point ";
                        break;
                    case '-':
                        result += "minus ";
                        break;
                    case 'E':
                        result += "E ";
                        break;
                    case '+':
                        result += "plus ";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(result))
            {
                result = char.ToUpper(result[0]) + result.Substring(1);
            }

            return result.Trim();
        }
    }
}
