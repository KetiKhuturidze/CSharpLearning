#pragma warning disable S3400 // Methods should not return constants
#pragma warning disable S1144 // Unused private types or members should be removed
#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable

namespace UmlDesignBasics
{
    public static class SimpleStaticClass3
    {
        public static long GetLongInteger()
        {
            return 101;
        }

        public static double GetDouble()
        {
            return 0.101;
        }

        public static char GetChar()
        {
            return 'a';
        }

        public static string GetString()
        {
            return "abc";
        }

        private static int GetInteger()
        {
            return -101;
        }

        private static float GetFloat()
        {
            return 1.01f;
        }

        private static bool GetBoolean()
        {
            return true;
        }

        private static object GetObject()
        {
            return null;
        }
    }

}
