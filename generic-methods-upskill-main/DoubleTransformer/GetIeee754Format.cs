using System;
using System.Text;
using GenericMethods.Interfaces;

namespace DoubleTransformer
{
    /// <summary>
    /// Transformer class for double.
    /// </summary>
    public class GetIeee754Format : ITransformer<double, string>
    {
        /// <summary>
        /// Transform double value to IEEE754 format <see cref="https://www.wikiwand.com/en/IEEE_754"/> in the string form.
        /// </summary>
        /// <param name="obj">The double value.</param>
        /// <returns>The IEEE754 format in the string form.</returns>
        public string Transform(double obj)
        {
            long bits = DoubleToBits(obj);

            string signBit = GetBit(bits, 63).ToString();
            string exponentBits = GetBits(bits, 52, 62);
            string mantissaBits = GetBits(bits, 0, 51);

            StringBuilder result = new StringBuilder();
            result.Append(signBit).Append(exponentBits).Append(mantissaBits);

            return result.ToString();
        }

        private static long DoubleToBits(double value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            return BitConverter.ToInt64(bytes, 0);
        }

        private string GetBits(long value, int startBit, int endBit)
        {
            StringBuilder bits = new StringBuilder();
            for (int i = startBit; i <= endBit; i++)
            {
                bits.Insert(0, GetBit(value, i));
            }
            return bits.ToString();
        }

        private static int GetBit(long value, int position)
        {
            return ((value & (1L << position)) != 0) ? 1 : 0;
        }
    }
}
