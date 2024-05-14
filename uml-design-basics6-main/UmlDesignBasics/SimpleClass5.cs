#pragma warning disable S2933   // Fields that are only assigned in the constructor should be "readonly"
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable

// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Local
namespace UmlDesignBasics
{
    public class SimpleClass5
    {
        private int intField = -216;
        private long longField = -621;
        private float floatField = -54.62f;
        private double doubleField = -62.054;
        private char charField = 'd';
        private bool booleanField = true;
        private string stringField = "defabc";
        private object objectField = typeof(int);

        public bool GetBoolean() => booleanField;

        public int GetInteger() => intField;

        public long GetLong() => longField;

        public float GetFloat() => floatField;

        public double GetDouble() => doubleField;

        public char GetChar() => charField;

        public string GetString() => stringField;

        public object GetObject() => objectField;
    }
}
