namespace ShiftArrayElements
{
    public static class Shifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations (see README.md for detailed instructions).
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations.</param>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">iterations array is null.</exception>
        public static void Shift(int[] source, int[] iterations)
        {
            int length = source.Length;
            int[] shiftedArray = new int[length];

            for (int i = 0; i < iterations.Length; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < iterations[i]; j++)
                    {
                        int temp = source[0];
                        Array.Copy(source, 1, shiftedArray, 0, length - 1);
                        shiftedArray[length - 1] = temp;
                        Array.Copy(shiftedArray, source, length);
                    }
                }
                else
                {
                    for (int j = 0; j < iterations[i]; j++)
                    {
                        int temp = source[length - 1];
                        Array.Copy(source, 0, shiftedArray, 1, length - 1);
                        shiftedArray[0] = temp;
                        Array.Copy(shiftedArray, source, length);
                    }
                }
            }
        }
    }
}
