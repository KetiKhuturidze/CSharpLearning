#pragma warning disable IDE0032 // Use auto property
#pragma warning disable S2292   // Make this an auto-implemented property and remove its backing field.
#pragma warning disable

// ReSharper disable ConvertToAutoProperty
namespace UmlDesignBasics
{
    public class SimpleClass8
    {
        private int intField;
        private long longField;
        private float floatField;
        private double doubleField;
        private char charField;
        private bool booleanField;
        private string stringField;
        private object objectField;

        public int IntValue
        {
            get => intField;
            set => intField = value;
        }

        public long LongValue
        {
            get => longField;
            set => longField = value;
        }

        public float FloatValue
        {
            get => floatField;
            set => floatField = value;
        }

        public double DoubleValue
        {
            get => doubleField;
            set => doubleField = value;
        }

        public char CharValue
        {
            get => charField;
            set => charField = value;
        }

        public bool BooleanValue
        {
            get => booleanField;
            set => booleanField = value;
        }

        public string StringValue
        {
            get => stringField;
            set => stringField = value;
        }

        public object ObjectValue
        {
            get => objectField;
            set => objectField = value;
        }
    }
}
