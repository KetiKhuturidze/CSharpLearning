using System;
using System.Xml.Linq;
using TypeConversions.TypesForConversions;

namespace TypeConversions
{
    public static class UnboxingConversions
    {
        /// <summary>
        /// Performs an unboxing conversion <see cref="object"/> type to <see cref="Point"/> type by using 'cast expression' syntax.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="Point"/> object or null when unable to cast <see cref="object"/> type to <see cref="Point"/> type.</returns>
        public static Point? CastExpressionFromObjectToPoint(object @object)
        {
            return (Point?)@object;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="object"/> type to <see cref="Point"/> type by using 'as operator' syntax.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="Point"/> object or null when unable to cast <see cref="object"/> type to <see cref="Point"/> type.</returns>
        public static Point? AsOperatorFromObjectToPoint(object @object)
        {
            return @object as Point?;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="object"/> type to <see cref="Point"/> type by using pattern matching.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="Point"/> object or null when unable to cast <see cref="object"/> type to <see cref="Point"/> type.</returns>
        public static Point? PatternMatchingFromObjectToPoint(object @object)
        {
            if (@object is Point point)
            {
                return point;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="ValueType"/> type to <see cref="Point"/> type by using 'cast expression' syntax.
        /// </summary>
        /// <param name="valueType"><see cref="ValueType"/> object.</param>
        /// <returns><see cref="Point"/> object or null when unable to cast <see cref="ValueType"/> type to <see cref="Point"/> type.</returns>
        public static Point? CastExpressionFromValueTypeToPoint(ValueType valueType)
        {
            return valueType as Point?;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="ValueType"/> type to <see cref="Point"/> type by using 'as operator' syntax.
        /// </summary>
        /// <param name="valueType"><see cref="ValueType"/> object.</param>
        /// <returns><see cref="Point"/> object or null when unable to cast <see cref="ValueType"/> type to <see cref="Point"/> type.</returns>
        public static Point? AsOperatorFromValueTypeToPoint(ValueType valueType)
        {
            return valueType as Point?;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="ValueType"/> type to <see cref="Point"/> type by using 'pattern matching' syntax.
        /// </summary>
        /// <param name="valueType"><see cref="ValueType"/> object.</param>
        /// <returns><see cref="Point"/> object or null when unable to cast <see cref="ValueType"/> type to <see cref="Point"/> type.</returns>
        public static Point? PatternMatchingFromValueTypeToPoint(ValueType valueType)
        {
            if (valueType is Point point)
            {
                return point;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="IColorable"/> type to <see cref="Point"/> type by using 'cast expression' syntax.
        /// </summary>
        /// <param name="colorable"><see cref="IColorable"/> object.</param>
        /// <returns><see cref="Point"/> object or null when unable to cast <see cref="IColorable"/> type to <see cref="Point"/> type.</returns>
        public static Point? CastExpressionFromIColorableToPoint(IColorable colorable)
        {
            return colorable as Point?;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="IColorable"/> type to <see cref="Point"/> type by using 'as operator' syntax.
        /// </summary>
        /// <param name="colorable"><see cref="IColorable"/> object.</param>
        /// <returns><see cref="Point"/> object or null when unable to cast <see cref="IColorable"/> type to <see cref="Point"/> type.</returns>
        public static Point? AsOperatorFromIColorableToPoint(IColorable colorable)
        {
            return colorable as Point?;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="IColorable"/> type to <see cref="Point"/> type by using 'pattern matching' syntax.
        /// </summary>
        /// <param name="colorable"><see cref="IColorable"/> object.</param>
        /// <returns><see cref="Point"/> object or null when unable to cast <see cref="IColorable"/> type to <see cref="Point"/> type.</returns>
        public static Point? PatternMatchingFromIColorableToPoint(IColorable colorable)
        {
            if (colorable is Point point)
            {
                return point;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="object"/> type to <see cref="Color"/> type by using 'cast expression' syntax.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="Color"/> object or null when unable to cast <see cref="object"/> type to <see cref="Color"/> type.</returns>
        public static Color? CastExpressionFromObjectToColor(object @object)
        {
            return (Color?)@object;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="object"/> type to <see cref="Color"/> type by using 'as operator' syntax.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="Color"/> object or null when unable to cast <see cref="object"/> type to <see cref="Color"/> type.</returns>
        public static Color? AsOperatorFromObjectToColor(object @object)
        {
            return @object as Color?;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="object"/> type to <see cref="Color"/> type by using 'pattern matching'.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="Color"/> object or null when unable to cast <see cref="object"/> type to <see cref="Color"/> type.</returns>
        public static Color? PatternMatchingFromObjectToColor(object @object)
        {
            if (@object is Color color)
            {
                return color;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="ValueType"/> type to <see cref="Color"/> type by using 'cast expression' syntax.
        /// </summary>
        /// <param name="valueType"><see cref="object"/> object.</param>
        /// <returns><see cref="Color"/> object or null when unable to cast <see cref="ValueType"/> type to <see cref="Color"/> type.</returns>
        public static Color? CastExpressionFromValueTypeToColor(ValueType valueType)
        {
            return (Color?)valueType;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="ValueType"/> type to <see cref="Color"/> type by using 'as operator' syntax.
        /// </summary>
        /// <param name="valueType"><see cref="ValueType"/> object.</param>
        /// <returns><see cref="Color"/> object or null when unable to cast <see cref="object"/> type to <see cref="Color"/> type.</returns>
        public static Color? AsOperatorFromValueTypeToColor(ValueType valueType)
        {
            return valueType as Color?;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="ValueType"/> type to <see cref="Color"/> type by using 'pattern matching'.
        /// </summary>
        /// <param name="valueType"><see cref="ValueType"/> object.</param>
        /// <returns><see cref="Color"/> object or null when unable to cast <see cref="ValueType"/> type to <see cref="Color"/> type.</returns>
        public static Color? PatternMatchingFromValueTypeToColor(ValueType valueType)
        {
            if (valueType is Color c)
            {
                return c;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="Enum"/> type to <see cref="Color"/> type by using 'cast expression' syntax.
        /// </summary>
        /// <param name="enum"><see cref="Enum"/> object.</param>
        /// <returns><see cref="Color"/> object or null when unable to cast <see cref="Enum"/> type to <see cref="Color"/> type.</returns>
        public static Color? CastExpressionFromEnumToColor(Enum @enum)
        {
            return (Color?)@enum;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="Enum"/> type to <see cref="Color"/> type by using 'as operator' syntax.
        /// </summary>
        /// <param name="enum"><see cref="Enum"/> object.</param>
        /// <returns><see cref="Color"/> object or null when unable to cast <see cref="Enum"/> type to <see cref="Color"/> type.</returns>
        public static Color? AsOperatorFromEnumToColor(Enum @enum)
        {
            return @enum as Color?;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="Enum"/> type to <see cref="Color"/> type by using 'pattern matching'.
        /// </summary>
        /// <param name="enum"><see cref="Enum"/> object.</param>
        /// <returns><see cref="Color"/> object or null when unable to cast <see cref="Enum"/> type to <see cref="Color"/> type.</returns>
        public static Color? PatternMatchingFromEnumToColor(Enum @enum)
        {
            if (@enum is Color color)
            {
                return color;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="object"/> type to <see cref="int"/> type by using 'cast expression' syntax.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="int"/> object or null when unable to cast <see cref="object"/> type to <see cref="int"/> type.</returns>
        public static int? CastExpressionFromObjectToInt32(object @object)
        {
            return (int?)@object;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="object"/> type to <see cref="int"/> type by using 'as operator' syntax.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="int"/> object or null when unable to cast <see cref="object"/> type to <see cref="int"/> type.</returns>
        public static int? AsOperatorFromObjectToInt32(object @object)
        {
            return @object as int?;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="object"/> type to <see cref="int"/> type by using pattern matching.
        /// </summary>
        /// <param name="object"><see cref="object"/> object.</param>
        /// <returns><see cref="int"/> object or null when unable to cast <see cref="object"/> type to <see cref="int"/> type.</returns>
        public static int? PatternMatchingFromObjectToInt32(object @object)
        {
            if (@object is int i)
            {
                return i;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="ValueType"/> type to <see cref="int"/> type by using 'cast expression' syntax.
        /// </summary>
        /// <param name="valueType"><see cref="ValueType"/> object.</param>
        /// <returns><see cref="int"/> object or null when unable to cast <see cref="ValueType"/> type to <see cref="int"/> type.</returns>
        public static int? CastExpressionFromValueTypeToInt32(ValueType valueType)
        {
            return (int?)valueType;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="ValueType"/> type to <see cref="int"/> type by using 'as operator' syntax.
        /// </summary>
        /// <param name="valueType"><see cref="ValueType"/> object.</param>
        /// <returns><see cref="int"/> object or null when unable to cast <see cref="ValueType"/> type to <see cref="int"/> type.</returns>
        public static int? AsOperatorFromValueTypeToInt32(ValueType valueType)
        {
            return valueType as int?;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="ValueType"/> type to <see cref="int"/> type by using pattern matching.
        /// </summary>
        /// <param name="valueType"><see cref="ValueType"/> object.</param>
        /// <returns><see cref="int"/> object or null when unable to cast <see cref="ValueType"/> type to <see cref="int"/> type.</returns>
        public static int? PatternMatchingFromValueTypeToInt32(ValueType valueType)
        {
            if (valueType is int i)
            {
                return i;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="IFormattable"/> type to <see cref="int"/> type by using 'cast expression' syntax.
        /// </summary>
        /// <param name="formattable"><see cref="IFormattable"/> object.</param>
        /// <returns><see cref="int"/> object or null when unable to cast <see cref="IFormattable"/> type to <see cref="int"/> type.</returns>
        public static int? CastExpressionFromIFormattableToInt32(IFormattable formattable)
        {
            return (int?)formattable;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="IFormattable"/> type to <see cref="int"/> type by using 'as operator' syntax.
        /// </summary>
        /// <param name="formattable"><see cref="IFormattable"/> object.</param>
        /// <returns><see cref="int"/> object or null when unable to cast <see cref="IFormattable"/> type to <see cref="int"/> type.</returns>
        public static int? AsOperatorFromIFormattableToInt32(IFormattable formattable)
        {
            return formattable as int?;
        }

        /// <summary>
        /// Performs an unboxing conversion <see cref="IFormattable"/> type to <see cref="int"/> type by using pattern matching.
        /// </summary>
        /// <param name="formattable"><see cref="IFormattable"/> object.</param>
        /// <returns><see cref="int"/> object or null when unable to cast <see cref="IFormattable"/> type to <see cref="int"/> type.</returns>
        public static int? PatternMatchingFromIFormattableToInt32(IFormattable formattable)
        {
            if (formattable is int i)
            {
                return i;
            }
            else
            {
                return null;
            }
        }
    }
}
