using System;
using TypeConversions.TypesForConversions;

namespace TypeConversions
{
    public static class ImplicitReferenceConversions
    {
        /// <summary>
        /// Performs an implicit conversion <see cref="Shape"/> type to <see cref="object"/> type.
        /// </summary>
        /// <param name="shape"><see cref="Shape"/> object.</param>
        /// <returns><see cref="object"/> object.</returns>
        public static object ConvertToObject(Shape shape)
        {
            return shape;
        }

        /// <summary>
        /// Performs an implicit conversion <see cref="Circle"/> type to <see cref="object"/> type.
        /// </summary>
        /// <param name="circle"><see cref="Circle"/> object.</param>
        /// <returns><see cref="object"/> object.</returns>
        public static object ConvertToObject(Circle circle)
        {
            return circle;
        }

        /// <summary>
        /// Performs an implicit conversion <see cref="Square"/> type to <see cref="object"/> type.
        /// </summary>
        /// <param name="square"><see cref="Square"/> object.</param>
        /// <returns><see cref="object"/> object.</returns>
        public static object ConvertToObject(Square square)
        {
            return square;
        }

        /// <summary>
        /// Performs an implicit conversion <see cref="Circle"/> type to <see cref="Shape"/> type.
        /// </summary>
        /// <param name="circle"><see cref="Circle"/> object.</param>
        /// <returns><see cref="Shape"/> object.</returns>
        public static Shape ConvertToShape(Circle circle)
        {
            return circle;
        }

        /// <summary>
        /// Performs an implicit conversion <see cref="Square"/> type to <see cref="Shape"/> type.
        /// </summary>
        /// <param name="square"><see cref="Square"/> object.</param>
        /// <returns><see cref="Shape"/> object.</returns>
        public static Shape ConvertToShape(Square square)
        {
            return square;
        }

        /// <summary>
        /// Performs an implicit conversion <see cref="Square"/> type to <see cref="IColorable"/> type.
        /// </summary>
        /// <param name="square"><see cref="Square"/> object.</param>
        /// <returns><see cref="IColorable"/> object.</returns>
        public static IColorable ConvertToIColorable(Square square)
        {
            return square;
        }
    }
}
