#pragma warning disable CA1822 // Member does not access instance data and can be marked as static
#pragma warning disable S3400  // Remove this method and declare a constant for this value

namespace UmlDesignBasics
{
    public class SimpleClass3
    {
        public int GetInteger()
        {
            return int.MaxValue;
        }

        public long GetLong()
        {
            return long.MinValue;
        }

        public float GetFloat()
        {
            return float.Epsilon;
        }

        public double GetDouble()
        {
            return double.NaN;
        }

        public char GetChar()
        {
            return 'c';
        }

        public bool GetBoolean()
        {
            return true;
        }

        public string GetString()
        {
            return "abcdef";
        }

        public object GetObject()
        {
            return new object();
        }
    }
}