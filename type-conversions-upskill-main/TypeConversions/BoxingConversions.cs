using System;
using System.Drawing;
using TypeConversions.TypesForConversions;

namespace TypeConversions
{
    public static class BoxingConversions
    {
        /// <summary>
        /// Performs an boxing conversion custom <see cref="Point"/> struct to <see cref="object"/> class.
        /// </summary>
        /// <param name="point"><see cref="Point"/> object.</param>
        /// <returns><see cref="object"/> object.</returns>
        public static object BoxToObject(TypesForConversions.Point point)
        {
            object o = point;
            return o;
        }

        /// <summary>
        /// Performs an boxing conversion build-in <see cref="int"/> struct to <see cref="object"/> class.
        /// </summary>
        /// <param name="value"><see cref="int"/> object.</param>
        /// <returns><see cref="object"/> object.</returns>
        public static object BoxToObject(int value)
        {
            object o = value;
            return o;
        }

        /// <summary>
        /// Performs an boxing conversion custom <see cref="Color"/> enum to <see cref="object"/> class.
        /// </summary>
        /// <param name="color"><see cref="Color"/> object.</param>
        /// <returns><see cref="object"/> object.</returns>
        public static object BoxToObject(TypesForConversions.Color color)
        {
            object o = color;
            return o;
        }

        /// <summary>
        /// Performs an boxing conversion custom <see cref="Point"/> struct to <see cref="ValueType"/> class.
        /// </summary>
        /// <param name="point"><see cref="Point"/> object.</param>
        /// <returns><see cref="ValueType"/> object.</returns>
        public static ValueType BoxToValueType(TypesForConversions.Point point)
        {
            object o = point;
            return (ValueType)o;
        }

        /// <summary>
        /// Performs an boxing conversion build-in <see cref="int"/> struct to <see cref="ValueType"/> class.
        /// </summary>
        /// <param name="value"><see cref="int"/> object.</param>
        /// <returns><see cref="ValueType"/> object.</returns>
        public static ValueType BoxToValueType(int value)
        {
            return value;
        }

        /// <summary>
        /// Performs an boxing conversion custom <see cref="Color"/> enum to <see cref="ValueType"/> class.
        /// </summary>
        /// <param name="color"><see cref="int"/> object.</param>
        /// <returns><see cref="ValueType"/> object.</returns>
        public static ValueType BoxToValueType(TypesForConversions.Color color)
        {
            return color;
        }

        /// <summary>
        /// Performs an boxing conversion custom <see cref="Point"/> struct to <see cref="IColorable"/> interface.
        /// </summary>
        /// <param name="point"><see cref="Point"/> object.</param>
        /// <returns><see cref="IColorable"/> object.</returns>
        public static IColorable BoxToIColorable(TypesForConversions.Point point)
        {
            return point;
        }

        /// <summary>
        /// Performs an boxing conversion build-in <see cref="int"/> struct to <see cref="IFormattable"/> interface.
        /// </summary>
        /// <param name="value"><see cref="int"/> object.</param>
        /// <returns><see cref="IFormattable"/> object.</returns>
        public static IFormattable BoxToIFormattable(int value)
        {
            return value;
        }

        /// <summary>
        /// Performs an boxing conversion custom <see cref="Color"/> enum to <see cref="Enum"/> class.
        /// </summary>
        /// <param name="color"><see cref="Color"/> object.</param>
        /// <returns><see cref="Enum"/> object.</returns>
        public static Enum BoxToEnum(TypesForConversions.Color color)
        {
            return color;
        }
    }
}
