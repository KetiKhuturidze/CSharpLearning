using System.Text;
using NUnit.Framework;
using static NumberWords.Converter;

namespace NumberWords.Tests
{
    [TestFixture]
    public class ConverterTests
    {
        private static readonly object[][] ConvertDecimalData = new object[][]
        {
            new object[] { 0.1m, "zero point one" },
            new object[] { 1.0m, "one point zero" },
            new object[] { 1.1m, "one point one" },
            new object[] { 100.001m, "one zero zero point zero zero one" },
            new object[] { 12345.6789m, "one two three four five point six seven eight nine" },
            new object[] { 123450.054321m, "one two three four five zero point zero five four three two one" },
            new object[] { 123456789.123456789m, "one two three four five six seven eight nine point one two three four five six seven eight nine" },
            new object[] { decimal.MaxValue, "seven nine two two eight one six two five one four two six four three three seven five nine three five four three nine five zero three three five point zero" },
            new object[] { decimal.MinValue, "minus seven nine two two eight one six two five one four two six four three three seven five nine three five four three nine five zero three three five point zero" },
        };

        private static readonly object[][] ConvertDoubleData = new object[][]
        {
            new object[] { -0.0d, "Minus zero" },
            new object[] { 0.0d, "Zero" },
            new object[] { 0.1d, "Zero point one" },
            new object[] { -23.809d, "Minus two three point eight zero nine" },
            new object[] { 12345.6789d, "One two three four five point six seven eight nine" },
            new object[] { -0.123456789d, "Minus zero point one two three four five six seven eight nine" },
            new object[] { 1.23333e308d, "One point two three three three three E plus three zero eight" },
            new object[] { double.MaxValue, "One point seven nine seven six nine three one three four eight six two three one five seven E plus three zero eight" },
            new object[] { double.MinValue, "Minus one point seven nine seven six nine three one three four eight six two three one five seven E plus three zero eight" },
            new object[] { double.Epsilon, "Double epsilon" },
            new object[] { double.NaN, "NaN" },
            new object[] { double.NegativeInfinity, "-∞" },
            new object[] { double.PositiveInfinity, "+∞" },
        };

        [TestCase(-1, ExpectedResult = "minus one")]
        [TestCase(-2, ExpectedResult = "minus two")]
        [TestCase(-3, ExpectedResult = "minus three")]
        [TestCase(-4, ExpectedResult = "minus four")]
        [TestCase(-5, ExpectedResult = "minus five")]
        [TestCase(-6, ExpectedResult = "minus six")]
        [TestCase(-7, ExpectedResult = "minus seven")]
        [TestCase(-8, ExpectedResult = "minus eight")]
        [TestCase(-9, ExpectedResult = "minus nine")]
        [TestCase(-11, ExpectedResult = "minus one one")]
        [TestCase(-12, ExpectedResult = "minus one two")]
        [TestCase(-13, ExpectedResult = "minus one three")]
        [TestCase(-14, ExpectedResult = "minus one four")]
        [TestCase(-15, ExpectedResult = "minus one five")]
        [TestCase(-16, ExpectedResult = "minus one six")]
        [TestCase(-17, ExpectedResult = "minus one seven")]
        [TestCase(-18, ExpectedResult = "minus one eight")]
        [TestCase(-19, ExpectedResult = "minus one nine")]
        [TestCase(0, ExpectedResult = "zero")]
        [TestCase(1, ExpectedResult = "one")]
        [TestCase(2, ExpectedResult = "two")]
        [TestCase(3, ExpectedResult = "three")]
        [TestCase(4, ExpectedResult = "four")]
        [TestCase(5, ExpectedResult = "five")]
        [TestCase(6, ExpectedResult = "six")]
        [TestCase(7, ExpectedResult = "seven")]
        [TestCase(8, ExpectedResult = "eight")]
        [TestCase(9, ExpectedResult = "nine")]
        [TestCase(10, ExpectedResult = "one zero")]
        [TestCase(11, ExpectedResult = "one one")]
        [TestCase(12, ExpectedResult = "one two")]
        [TestCase(13, ExpectedResult = "one three")]
        [TestCase(14, ExpectedResult = "one four")]
        [TestCase(15, ExpectedResult = "one five")]
        [TestCase(16, ExpectedResult = "one six")]
        [TestCase(17, ExpectedResult = "one seven")]
        [TestCase(18, ExpectedResult = "one eight")]
        [TestCase(19, ExpectedResult = "one nine")]
        [TestCase(-1234567890, ExpectedResult = "minus one two three four five six seven eight nine zero")]
        [TestCase(1234567890, ExpectedResult = "one two three four five six seven eight nine zero")]
        public string ConvertInteger_ReturnsString(int number)
        {
            // Act
            return ConvertInteger(number);
        }

        [TestCaseSource(nameof(ConvertDecimalData))]
        public void ConvertDecimal_ReturnsString(decimal number, string expectedResult)
        {
            // Arrange
            StringBuilder stringBuilder = new StringBuilder();

            // Act
            ConvertDecimal(number, stringBuilder);

            // Assert
            Assert.That(stringBuilder.ToString(), Is.EqualTo(expectedResult));
        }

        [TestCaseSource(nameof(ConvertDoubleData))]
        public void ConverDouble_ReturnsString(double number, string expectedResult)
        {
            // Act
            string actualResult = ConverDouble(number);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
