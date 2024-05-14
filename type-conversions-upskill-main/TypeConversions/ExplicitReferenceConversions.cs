using System;
using System.Xml.Linq;
using TypeConversions.TypesForConversions;

namespace TypeConversions
{
    public static class ExplicitReferenceConversions
    {
        /// <summary>
        /// Performs an explicit conversion <see cref="object"/> type to <see cref="Circle"/> type by using 'cast expression' syntax.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="Circle"/> object or null when unable to cast <see cref="object"/> type to <see cref="Circle"/> type.</returns>
        public static Circle? CastExpressionFromObjectToCircle(object @object)
        {
            if (@object is Circle circle)
            {
                return circle;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="object"/> type to <see cref="Square"/> type by using 'cast expression' syntax.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="Square"/> object or null when unable to cast <see cref="object"/> type to <see cref="Square"/> type.</returns>
        public static Square? CastExpressionFromObjectToSquare(object @object)
        {
            if (@object is Square square)
            {
                return square;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="object"/> type to <see cref="Shape"/> type by using 'cast expression' syntax.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="Shape"/> object or null when unable to cast <see cref="object"/> type to <see cref="Shape"/> type.</returns>
        public static Shape? CastExpressionFromObjectToShape(object @object)
        {
            return (Shape?)@object;
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="Shape"/> type to <see cref="Circle"/> type by using 'cast expression' syntax.
        /// </summary>
        /// <param name="shape"><see cref="Shape"/> object.</param>
        /// <returns><see cref="Circle"/> object or null when unable to cast <see cref="Shape"/> type to <see cref="Circle"/> type.</returns>
        public static Circle? CastExpressionShapeToCircle(Shape shape)
        {
            if (shape is Circle circle)
            {
                return circle;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="Shape"/> type to <see cref="Square"/> type by using 'cast expression' syntax.
        /// </summary>
        /// <param name="shape"><see cref="Shape"/> object.</param>
        /// <returns><see cref="Square"/> object or null when unable to cast <see cref="Shape"/> type to <see cref="Square"/> type.</returns>
        public static Square? CastExpressionFromShapeToSquare(Shape shape)
        {
            if (shape is Square square)
            {
                return square;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="IColorable"/> type to <see cref="Square"/> type by using 'cast expression' syntax.
        /// </summary>
        /// <param name="colorable"><see cref="IColorable"/> object.</param>
        /// <returns><see cref="Square"/> object or null when unable to cast <see cref="IColorable"/> type to <see cref="Square"/> type.</returns>
        public static Square? CastExpressionFromIColorableToSquare(IColorable colorable)
        {
            return (Square?)colorable;
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="object"/> type to <see cref="Shape"/> type by using 'as operator' syntax.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="Shape"/> object or null when unable to cast <see cref="object"/> type to <see cref="Shape"/> type.</returns>
        public static Shape? AsOperatorFromObjectToShape(object @object)
        {
            return (Shape?)@object;
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="object"/> type to <see cref="Square"/> type by using 'as operator' syntax.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="Square"/> object or null when unable to cast <see cref="object"/> type to <see cref="Square"/> type.</returns>
        public static Square? AsOperatorFromObjectToSquare(object @object)
        {
            if (@object is Square square)
            {
                return square;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="object"/> type to <see cref="Circle"/> type by using 'as operator' syntax.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="Circle"/> object or null when unable to cast <see cref="object"/> type to <see cref="Circle"/> type.</returns>
        public static Circle? AsOperatorFromObjectToCircle(object @object)
        {
            if (@object is Circle circle)
            {
                return circle;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="Shape"/> type to <see cref="Square"/> type by using 'as operator' syntax.
        /// </summary>
        /// <param name="shape"><see cref="Shape"/> object.</param>
        /// <returns><see cref="Square"/> object or null when unable to cast <see cref="object"/> type to <see cref="Square"/> type.</returns>
        public static Square? AsOperatorFromShapeToSquare(Shape shape)
        {
            if (shape is Square square)
            {
                return square;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="Shape"/> type to <see cref="Circle"/> type by using 'as operator' syntax.
        /// </summary>
        /// <param name="shape"><see cref="Shape"/> object.</param>
        /// <returns><see cref="Circle"/> object or null when unable to cast <see cref="Shape"/> type to <see cref="Circle"/> type.</returns>
        public static Circle? AsOperatorFromShapeToCircle(Shape shape)
        {
            if (shape is Circle circle)
            {
                return circle;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="Shape"/> type to <see cref="Circle"/> type by using 'as operator' syntax.
        /// </summary>
        /// <param name="colorable"><see cref="IColorable"/> object.</param>
        /// <returns><see cref="Square"/> object or null when unable to cast <see cref="IColorable"/> type to <see cref="Square"/> type.</returns>
        public static Square? AsOperatorFromIColorableToSquare(IColorable colorable)
        {
            return (Square?)colorable;
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="object"/> type to <see cref="Shape"/> type by using 'pattern matching'.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="Shape"/> object or null when unable to cast <see cref="object"/> type to <see cref="Shape"/> type.</returns>
        public static Shape? PatternMatchingFromObjectToShape(object @object)
        {
            return (Shape?)@object;
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="object"/> type to <see cref="Square"/> type by using 'pattern matching'.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="Square"/> object or null when unable to cast <see cref="object"/> type to <see cref="Square"/> type.</returns>
        public static Square? PatternMatchingFromObjectToSquare(object @object)
        {
            if (@object is Square square)
            {
                return square;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="object"/> type to <see cref="Circle"/> type by using 'pattern matching'.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="Circle"/> object or null when unable to cast <see cref="object"/> type to <see cref="Circle"/> type.</returns>
        public static Circle? PatternMatchingFromObjectToCircle(object @object)
        {
            if (@object is Circle circle)
            {
                return circle;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="Shape"/> type to <see cref="Square"/> type by using 'pattern matching'.
        /// </summary>
        /// <param name="shape"><see cref="Shape"/> object.</param>
        /// <returns><see cref="Square"/> object or null when unable to cast <see cref="object"/> type to <see cref="Square"/> type.</returns>
        public static Square? PatternMatchingFromShapeToSquare(Shape shape)
        {
            if (shape is Square square)
            {
                return square;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="Shape"/> type to <see cref="Circle"/> type by using 'pattern matching'.
        /// </summary>
        /// <param name="shape"><see cref="Shape"/> object.</param>
        /// <returns><see cref="Circle"/> object or null when unable to cast <see cref="Shape"/> type to <see cref="Circle"/> type.</returns>
        public static Circle? PatternMatchingFromShapeToCircle(Shape shape)
        {
            if (shape is Circle circle)
            {
                return circle;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an explicit conversion <see cref="Shape"/> type to <see cref="Circle"/> type by using 'pattern matching'.
        /// </summary>
        /// <param name="colorable"><see cref="IColorable"/> object.</param>
        /// <returns><see cref="Square"/> object or null when unable to cast <see cref="IColorable"/> type to <see cref="Square"/> type.</returns>
        public static Square? PatternMatchingFromIColorableToSquare(IColorable colorable)
        {
            if (colorable is Square square)
            {
                return square;
            }
            else
            {
                return null;
            }
        }
    }
}
