﻿using System.Globalization;

[assembly: CLSCompliant(true)]

namespace FormattingStrings
{
    public static class IntegerToString
    {
        public static string LiteralToString1()
        {
            return 1000.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        public static string LiteralToString2()
        {
            return 1234.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        public static string LiteralToString3()
        {
            return 100_000_000.ToString("G", CultureInfo.InvariantCulture);
        }

        public static string LiteralToString4()
        {
            var st = -123_456_789;
            return st.ToString("G", CultureInfo.InvariantCulture);
        }

        public static string LiteralToString5()
        {
            return 0xABCDEFAB.ToString("X", CultureInfo.InvariantCulture);
        }

        public static string LiteralToString6()
        {
            return 0xafbaceda.ToString("X", CultureInfo.InvariantCulture).ToLowerInvariant();
        }

        public static string LiteralToString7()
        {
            return 0xA.ToString("x4", CultureInfo.InvariantCulture);
        }

        public static string LiteralToString8()
        {
            return 0xfed.ToString("x8", CultureInfo.InvariantCulture).ToUpperInvariant();
        }

        public static string LiteralToString9()
        {
            return 0xA.ToString("D4", CultureInfo.InvariantCulture);
        }

        public static string LiteralToString10()
        {
            return 0xfed.ToString("D8", CultureInfo.InvariantCulture);
        }

        public static string LiteralToString11()
        {
            return 1394.ToString("C", CultureInfo.InvariantCulture);
        }

        public static string LiteralToString12()
        {
            return 28549.ToString("C6", CultureInfo.InvariantCulture);
        }
    }
}
