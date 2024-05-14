// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
#pragma warning disable SA1202 // Methods should not have too many parameters

namespace UmlDesignBasics
{
    public class SimpleClass12
    {
        // Private parameterless constructor for property initialization
        private SimpleClass12()
        {
            this.IntValue = -983;
            this.LongValue = -985;
            this.FloatValue = -984.983f;
            this.DoubleValue = -9238.9634;
            this.CharValue = 'g';
            this.BooleanValue = true;
            this.StringValue = "mnojkl";
            this.ObjectValue = null;
        }

        public SimpleClass12(int intValue)
            : this() // invoke the parameterless constructor
        {
            this.IntValue = intValue;
        }

        public SimpleClass12(long longValue)
            : this()
        {
            this.LongValue = longValue;
        }

        public SimpleClass12(float floatValue)
            : this()
        {
            this.FloatValue = floatValue;
        }

        public SimpleClass12(double doubleValue)
            : this()
        {
            this.DoubleValue = doubleValue;
        }

        public SimpleClass12(char charValue)
            : this()
        {
            this.CharValue = charValue;
        }

        public SimpleClass12(bool boolValue)
            : this()
        {
            this.BooleanValue = boolValue;
        }

        public SimpleClass12(string stringValue)
            : this()
        {
            this.StringValue = stringValue;
        }

        public SimpleClass12(object objectValue)
            : this()
        {
            this.ObjectValue = objectValue;
        }

        public int IntValue { get; private set; }

        public long LongValue { get; private set; }

        public float FloatValue { get; private set; }

        public double DoubleValue { get; private set; }

        public char CharValue { get; private set; }

        public bool BooleanValue { get; private set; }

        public string StringValue { get; private set; }

        public object ObjectValue { get; private set; }
    }
}
