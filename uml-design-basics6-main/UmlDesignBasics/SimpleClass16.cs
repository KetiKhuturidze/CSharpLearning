#pragma warning disable IDE0032 // Use auto-property
#pragma warning disable S107    // Method should not have too many parameters
#pragma warning disable SA1201    // Method should not have too many parameters
#pragma warning disable SA1202    // Method should not have too many parameters

// Methods should not have too many parameters
// ReSharper disable ConvertToAutoProperty
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
namespace UmlDesignBasics
{
    public class SimpleClass16
    {
        private readonly int intField;
        private readonly long longField;
        private readonly float floatField;
        private readonly double doubleField;
        private readonly char charField;
        private readonly bool booleanField;
        private readonly string stringField;
        private readonly object objectField;

        public const int DefaultIntValue = -135914;
        public const long DefaultLongValue = 138672;
        public const float DefaultFloatValue = 130124.58123F;
        public const double DefaultDoubleValue = -130521.71531;
        public const char DefaultCharValue = 'k';
        public const bool DefaultBoolValue = false;
        public const string DefaultStringValue = "stuvwx";
        public const object DefaultObjectValue = null;

        public int IntValue => this.intField;

        public long LongValue => this.longField;

        public float FloatValue { get => this.floatField; }

        public double DoubleValue => this.doubleField;

        public char CharValue => this.charField;

        public bool BooleanValue => this.booleanField;

        public string StringValue => this.stringField;

        public object ObjectValue => this.objectField;

        public SimpleClass16(
            int intValue = DefaultIntValue,
            long longValue = DefaultLongValue,
            float floatValue = DefaultFloatValue,
            double doubleValue = DefaultDoubleValue,
            char charValue = DefaultCharValue,
            bool booleanValue = DefaultBoolValue,
            string stringValue = DefaultStringValue,
            object objectValue = DefaultObjectValue)
        {
            this.intField = intValue;
            this.longField = longValue;
            this.floatField = floatValue;
            this.doubleField = doubleValue;
            this.charField = charValue;
            this.booleanField = booleanValue;
            this.stringField = stringValue;
            this.objectField = objectValue;
        }
    }
}
