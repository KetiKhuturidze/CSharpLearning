#pragma warning disable S1125 // Boolean literals should not be redundant
#pragma warning disable CA2211
#pragma warning disable SA1401

// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable InconsistentNaming
namespace UmlDesignBasics
{
    public static class SimpleStaticClass5
    {
        public const int BitsInByte = 8;
        public const double Pi = 3.14159653589793238;
        public const int SpeedOfLight = 300000;
        public const float Tau = 3.1415925f * 2f;
        public const char NewLine = '\n';
        public const bool BoolValue = true && false && false;
        public const string HelloWorld = "Hello" + ", " + "world" + "!";
    }
}
