#pragma warning disable S2933   // Fields that are only assigned in the constructor should be "readonly"
#pragma warning disable S107    // Methods should not have too many parameters
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable

// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Local
namespace UmlDesignBasics
{
    public class SimpleClass7
    {
        private int intField;
        private long longField;
        private float floatField;
        private double doubleField;
        private char charField;
        private bool booleanField;
        private string stringField;
        private object objectField;

        public SimpleClass7(
            int intValue,
            long longValue,
            float floatValue,
            double doubleValue,
            char charValue,
            bool boolValue,
            string stringValue,
            object objectValue)
        {
            intField = intValue;
            longField = longValue;
            floatField = floatValue;
            doubleField = doubleValue;
            charField = charValue;
            booleanField = boolValue;
            stringField = stringValue;
            objectField = objectValue;
        }

        public int GetInteger() => intField;

        public long GetLong() => longField;

        public float GetFloat() => floatField;

        public double GetDouble() => doubleField;

        public char GetChar() => charField;

        public bool GetBoolean() => booleanField;

        public string GetString() => stringField;

        public object GetObject() => objectField;
    }
}
