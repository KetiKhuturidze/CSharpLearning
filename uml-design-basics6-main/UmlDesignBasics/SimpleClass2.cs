#pragma warning disable SA1401  // Fields should be private
#pragma warning disable CA1823  // Unused field
#pragma warning disable CS0169  // Field is never used
#pragma warning disable S1104   // Fields should not have public accessibility
#pragma warning disable S1144   // Unused private types or members should be removed
#pragma warning disable CA1051 // Remove unused private members

// ReSharper disable InconsistentNaming
namespace UmlDesignBasics
{
    public class SimpleClass2
    {
        public int IntField;
        public float FloatField;
        public double DoubleField;
        public bool BooleanField;

        private long longField;
        private char charField;
        private string stringField;
        private object objectField;
    }
}
