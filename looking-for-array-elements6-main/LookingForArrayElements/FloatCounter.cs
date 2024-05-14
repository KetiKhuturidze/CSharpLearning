using System;

namespace LookingForArrayElements
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[]? arrayToSearch, float[]? rangeStart, float[]? rangeEnd)
        {
            if (arrayToSearch == null || rangeStart == null || rangeEnd == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("ranges don't have the same number of elements", nameof(rangeEnd));
            }

            int count = 0;

            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                float valueToSearch = arrayToSearch[i];

                for (int j = 0; j < rangeStart.Length; j++)
                {
                    float start = rangeStart[j];
                    float end = rangeEnd[j];

                    if (valueToSearch >= start && valueToSearch <= end)
                    {
                        count++;
                        break; // Found a match, move to the next value in arrayToSearch
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[]? arrayToSearch, float[]? rangeStart, float[]? rangeEnd, int startIndex, int count)
        {
            if (arrayToSearch == null || rangeStart == null || rangeEnd == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("rangeStart and rangeEnd arrays must have the same length.");
            }

            if (startIndex < 0 || startIndex >= arrayToSearch.Length || count <= 0 || startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            int counter = 0;

            for (int i = startIndex; i < startIndex + count; i++)
            {
                float valueToSearch = arrayToSearch[i];

                for (int j = 0; j < rangeStart.Length; j++)
                {
                    float start = rangeStart[j];
                    float end = rangeEnd[j];

                    if (start > end)
                    {
                        throw new ArgumentException("Range start value cannot be greater than the range end value.", nameof(rangeStart));
                    }

                    if (valueToSearch >= start && valueToSearch <= end)
                    {
                        counter++;
                        break; // Found a match, move to the next value in arrayToSearch
                    }
                }
            }

            return counter;
        }
    }
}
