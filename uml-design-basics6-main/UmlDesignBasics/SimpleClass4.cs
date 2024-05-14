 // Fields should not have public accessibility
 #pragma warning disable
// ReSharper disable InconsistentNaming
namespace UmlDesignBasics
{
    public class SimpleClass4
    {
        private int intField;
        private long longField;
        private float floatField;
        private double doubleField;
        private char charField;
        private bool booleanField;
        private string stringField;
        private object objectField;

        public bool GetBoolean() => this.booleanField;

        public int GetInteger() => this.intField;

        public long GetLong() => this.longField;

        public float GetFloat() => this.floatField;

        public double GetDouble() => this.doubleField;

        public char GetChar() => this.charField;

        public string GetString() => this.stringField;

        public object GetObject() => this.objectField;

        public void SetInteger(int value) => this.intField = value;

        public void SetLong(long value) => this.longField = value;

        public void SetFloat(float value) => this.floatField = value;

        public void SetDouble(double value) => this.doubleField = value;

        public void SetChar(char value) => this.charField = value;

        public void SetBoolean(bool value) => this.booleanField = value;

        public void SetString(string value) => this.stringField = value;

        public void SetObject(object value) => this.objectField = value;
    }
}
