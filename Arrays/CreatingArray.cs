using System;

namespace WorkingWithArrays
{
    public static class CreatingArray
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1825:Avoid zero-length array allocations", Justification = "Education purposes")]
        public static int[] CreateEmptyArrayOfIntegers()
        {
            return new int[0];
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1825:Avoid zero-length array allocations", Justification = "Education purposes")]
        public static bool[] CreateEmptyArrayOfBooleans()
        {
            bool[] array = { };
            return array;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1825:Avoid zero-length array allocations", Justification = "Education purposes")]
        public static string[] CreateEmptyArrayOfStrings()
        {
            return new string[] { };
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1825:Avoid zero-length array allocations", Justification = "Education purposes")]
        public static char[] CreateEmptyArrayOfCharacters()
        {
            // TODO #1-4. Add the method implementation. The method should return an empty array.
            // Return an empty array using the syntax with an empty initialization list.
            return new char[] { };
        }

        public static double[] CreateEmptyArrayOfDoubles()
        {
            return Array.Empty<double>();
        }

        public static float[] CreateEmptyArrayOfFloats()
        {
            return Array.Empty<float>();
        }

        public static decimal[] CreateEmptyArrayOfDecimals()
        {
            return Array.Empty<decimal>();
        }

        public static int[] CreateArrayOfTenIntegersWithDefaultValues()
        {
            return new int[10];
        }

        public static bool[] CreateArrayOfTwentyBooleansWithDefaultValues()
        {
            return new bool[20];
        }

        public static string[] CreateArrayOfFiveEmptyStrings()
        {
            string[] strings = { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
            return strings;
        }

        public static char[] CreateArrayOfFifteenCharactersWithDefaultValues()
        {
            return new char[15];
        }

        public static double[] CreateArrayOfEighteenDoublesWithDefaultValues()
        {
            return new double[18];
        }

        public static float[] CreateArrayOfOneHundredFloatsWithDefaultValues()
        {
            return new float[100];
        }

        public static decimal[] CreateArrayOfOneThousandDecimalsWithDefaultValues()
        {
            return new decimal[1000];
        }

        public static int[] CreateIntArrayWithOneElement()
        {
            return new int[] { 123456 };
        }

        public static int[] CreateIntArrayWithTwoElements()
        {
            return new int[] { 1_111_111, 9_999_999 };
        }

        public static int[] CreateIntArrayWithTenElements()
        {
            int[] ints = { 0, 4234, 3845, 2942, 1104, 9794, 923943, 7537, 4162, 10134 };
            return ints;
        }

        public static bool[] CreateBoolArrayWithOneElement()
        {
            bool[] bools = { true };
            return bools;
        }

        public static bool[] CreateBoolArrayWithFiveElements()
        {
            bool[] bools = { true, false, true, false, true };
            return bools;
        }

        public static bool[] CreateBoolArrayWithSevenElements()
        {
            bool[] bools = { false, true, true, false, true, true, false };
            return bools;
        }

        public static string[] CreateStringArrayWithOneElement()
        {
            string[] ss = { "one" };
            return ss;
        }

        public static string[] CreateStringArrayWithThreeElements()
        {
            string[] ss = { "one", "two", "three" };
            return ss;
        }

        public static string[] CreateStringArrayWithSixElements()
        {
            string[] ss = { "one", "two", "three", "four", "five", "six" };
            return ss;
        }

        public static char[] CreateCharArrayWithOneElement()
        {
            char[] c = { 'a' };
            return c;
        }

        public static char[] CreateCharArrayWithThreeElements()
        {
            char[] c = { 'a', 'b', 'c' };
            return c;
        }

        public static char[] CreateCharArrayWithNineElements()
        {
            char[] c = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'a' };
            return c;
        }

        public static double[] CreateDoubleArrayWithOneElement()
        {
            double[] db = { 1.12 };
            return db;
        }

        public static double[] CreateDoubleWithFiveElements()
        {
            double[] db = { 1.12, 2.23, 3.34, 4.45, 5.56 };
            return db;
        }

        public static double[] CreateDoubleWithNineElements()
        {
            double[] db = { 1.12, 2.23, 3.34, 4.45, 5.56, 6.67, 7.78, 8.89, 9.91 };
            return db;
        }

        public static float[] CreateFloatArrayWithOneElement()
        {
            float[] ff = { 123456789.123456f };
            return ff;
        }

        public static float[] CreateFloatWithThreeElements()
        {
            float[] ff = { 1000000.12f, 2.2233344E+09f, 10000.0f };
            return ff;
        }

        public static float[] CreateFloatWithFiveElements()
        {
            float[] ff = { 1.0123f, 20.012345f, 300.01234567f, 4_000.01234567f, 500_000.01234567f };
            return ff;
        }

        public static decimal[] CreateDecimalArrayWithOneElement()
        {
            decimal[] dd = { 10_000.123456m };
            return dd;
        }

        public static decimal[] CreateDecimalWithFiveElements()
        {
            decimal[] dd = { 1000.1234m, 100000.2345m, 100000.3456m, 1000000.456789m, 10000000.5678901m };
            return dd;
        }

        public static decimal[] CreateDecimalWithNineElements()
        {
            decimal[] dd = { 10.122112m, 200.233223m, 3000.344334m, 40_000.455445m, 500_000.566556m, 6_000_000.677667m, 70_000_000.788778m, 800_000_000.899889m, 9_000_000_000.911991m };
            return dd;
        }
    }
}
