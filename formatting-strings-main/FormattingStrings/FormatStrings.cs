using System.Globalization;

namespace FormattingStrings
{
    public static class FormatStrings
    {
        public static string Format1(int number1, int number2, float number3, double number4)
        {
            return string.Format(NumberFormatInfo.InvariantInfo, "{0} {2} {1} {3}", number1, number2, number3, number4);
        }

        public static string Format2(string str1, double number1, string str2, float number2, int number3)
        {
            return string.Format(NumberFormatInfo.InvariantInfo, "{0} {2} {1} {3:X} {4}", str2, number1, number2, number3, str1);
        }

        public static string Format3(string str1, float number1, double number2, int number3)
        {
            return string.Format(NumberFormatInfo.InvariantInfo, "{0}, {2}, {1:P0}, {3:C}", number3, number1, str1, number2);
        }

        public static string Format4(int number1, int number2, long number3, string str1, string str2)
        {
            return string.Format(NumberFormatInfo.InvariantInfo, "{0},{1},{2:X},{3},{4}", number2, str1, number1, number3, str2);
        }

        public static string Format5(string str1, double number1, int number2, int number3)
        {
            return string.Format(NumberFormatInfo.InvariantInfo, "{{ \"id\": {0}, \"name\": \"{1}\", \"deposit\": {2:F2}, \"days\": {3:D3} }}", number3, str1, number1, number2);
        }

        public static string Format6(int number1, double number2, string str1, string str2, string str3)
        {
            return string.Format(NumberFormatInfo.InvariantInfo, "{{ \"parameter\": \"{0}\", \"code\": {{ \"type\": \"{1}\", \"label\": \"{2:X4}\" }}, \"value\": {{ \"data\": \"{3:F2}\", \"units\": \"{4}\" }}}}", str3, str2, number1, number2, str1);
        }

        public static string Format7(string str1, string str2, float number1, float number2, int number3)
        {
            return string.Format(CultureInfo.InvariantCulture, "|{0,6}|{1,9}|{2,8}|{3,9}|{4,6}|", number3, str1, number1, str2, number2);
        }

        public static string Format8(string str1, string str2, string str3, double number1, double number2, double number3)
        {
            return string.Format(CultureInfo.InvariantCulture, "|{0,9} |{1,8} |{2,11} |{3,12} |{4,11} |{5,9} |", str3, number1, number2, number3, str2, str1);
        }

        public static string Format9(string str1, string str2, float number1, float number2, float number3)
        {
            return string.Format(CultureInfo.InvariantCulture, "|{0,11:P2} | {1,-13}| {2,-15}| {3,12:C2} | {4,-21:N04}|", number3, str1, str2, number2, number1);
        }

        public static string Format10(decimal number1, decimal number2, double number3, string str1, string str2, string str3)
        {
            return string.Format(CultureInfo.InvariantCulture, "| {0,-9}| {1,-13:F0}|{2,13:N02} |{3,16} |{4,12} | {5,-21:C4}|", str1, number1, number3, str3, str2, number2);
        }
    }
}
