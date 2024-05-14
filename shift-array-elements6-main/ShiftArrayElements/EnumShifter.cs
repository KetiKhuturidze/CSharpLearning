namespace ShiftArrayElements
{
    public static class EnumShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using directions from <see cref="directions"/> array, one element shift per each direction array element.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="directions">An array with directions.</param>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">directions array is null.</exception>
        /// <exception cref="InvalidOperationException">direction array contains an element that is not <see cref="Direction.Left"/> or <see cref="Direction.Right"/>.</exception>
        public static void Shift(int[] source, Direction[] directions)
        {
            foreach (var currentDirection in directions)
            {
                switch (currentDirection)
                {
                    case Direction.Left:
                        {
                            int tempp = source[0];
                            for (int i = 0; i < source.Length - 1; i++)
                            {
                                source[i] = source[i + 1];
                            }

                            source[source.Length - 1] = tempp;
                            break;
                        }

                    case Direction.Right:
                        {
                            int tempp = source[source.Length - 1];
                            for (int i = source.Length - 1; i > 0; i--)
                            {
                                source[i] = source[i - 1];
                            }

                            source[0] = tempp;
                            break;
                        }

                    default:
                        throw new InvalidOperationException($"Incorrect {currentDirection} enum value.");
                }
            }
        }
    }
}
