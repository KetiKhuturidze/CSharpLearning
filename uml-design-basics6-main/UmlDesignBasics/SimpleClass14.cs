#pragma warning disable S107 // Methods should not have too many parameters

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable IntroduceOptionalParameters.Global
namespace UmlDesignBasics
{
    public class SimpleClass14
    {
        private SimpleClass14(int intValue, long longValue, float floatValue, double doubleValue, char charValue, bool boolValue, string stringValue, object objectValue)
        {
            this.IntValue = intValue;
            this.LongValue = longValue;
            this.FloatValue = floatValue;
            this.DoubleValue = doubleValue;
            this.CharValue = charValue;
            this.BooleanValue = boolValue;
            this.StringValue = stringValue;
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

        public static SimpleClass14 Create() => new SimpleClass14(-1132, -11537, 11369.321F, 11867.3854, 'i', true, "pqr", null);

        public static SimpleClass14 Create(int intValue) => new SimpleClass14(intValue, -11537, 11369.321F, 11867.3854, 'i', true, "pqr", null);

        public static SimpleClass14 Create(int intValue, long longValue) => new SimpleClass14(intValue, longValue, 11369.321F, 11867.3854, 'i', true, "pqr", null);

        public static SimpleClass14 Create(int intValue, long longValue, float floatValue) => new SimpleClass14(intValue, longValue, floatValue, 11867.3854, 'i', true, "pqr", null);

        public static SimpleClass14 Create(int intValue, long longValue, float floatValue, double doubleValue) => new SimpleClass14(intValue, longValue, floatValue, doubleValue, 'i', true, "pqr", null);

        public static SimpleClass14 Create(int intValue, long longValue, float floatValue, double doubleValue, char charValue) => new SimpleClass14(intValue, longValue, floatValue, doubleValue, charValue, true, "pqr", null);

        public static SimpleClass14 Create(int intValue, long longValue, float floatValue, double doubleValue, char charValue, bool boolValue) => new SimpleClass14(intValue, longValue, floatValue, doubleValue, charValue, boolValue, "pqr", null);

        public static SimpleClass14 Create(int intValue, long longValue, float floatValue, double doubleValue, char charValue, bool boolValue, string stringValue) => new SimpleClass14(intValue, longValue, floatValue, doubleValue, charValue, boolValue, stringValue, null);

        public static SimpleClass14 Create(int intValue, long longValue, float floatValue, double doubleValue, char charValue, bool boolValue, string stringValue, object objectValue) => new SimpleClass14(intValue, longValue, floatValue, doubleValue, charValue, boolValue, stringValue, objectValue);
    }
}