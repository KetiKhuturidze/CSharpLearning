#pragma warning disable S2933   // Fields that are only assigned in the constructor should be "readonly"
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable SA1516 // Add readonly modifier
#pragma warning disable

// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Local
namespace UmlDesignBasics
{
    public class SimpleClass6
    {
        private int intField;
        private long longField;
        private float floatField;
        private double doubleField;
        private char charField;
        private bool booleanField;
        private string stringField;
        private object objectField;

        public SimpleClass6()
        {
            intField = 754;
            longField = 721;
            floatField = -76.67f;
            doubleField = 372.127;
            charField = 'e';
            booleanField = true;
            stringField = "ghi";
            objectField = typeof(float);
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
