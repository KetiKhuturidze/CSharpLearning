#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable

// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable InconsistentNaming
namespace UmlDesignBasics
{
    public static class SimpleStaticClass4
    {
        private static char charField = 'b';
        private static bool booleanField = true;
        private static string stringField = "def";
        private static object objectField = typeof(SimpleStaticClass4);
        private static int intField = 212;
        private static long longField = -232;
        private static double doubleField = 2.121;
        private static float floatField = 2.12f;

        public static int GetInteger()
        {
            return SimpleStaticClass4.intField;
        }

        public static long GetLongInteger()
        {
            return SimpleStaticClass4.longField;
        }

        public static double GetDouble()
        {
            return SimpleStaticClass4.doubleField;
        }

        public static char GetChar()
        {
            return SimpleStaticClass4.charField;
        }

        public static string GetString()
        {
            return SimpleStaticClass4.stringField;
        }

        public static float GetFloat()
        {
            return SimpleStaticClass4.floatField;
        }

        public static bool GetBoolean()
        {
            return SimpleStaticClass4.booleanField;
        }

        public static object GetObject()
        {
            return SimpleStaticClass4.objectField;
        }
    }
}
