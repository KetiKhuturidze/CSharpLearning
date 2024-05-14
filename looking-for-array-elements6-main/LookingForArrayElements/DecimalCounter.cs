using System;

namespace LookingForArrayElements
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[]?[]? ranges)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            if (arrayToSearch.Length == 0)
            {
                throw new ArgumentException("The arrayToSearch is empty.");
            }

            int counter = 0;

            foreach (var range in ranges)
            {
                if (range is null)
                {
                    throw new ArgumentNullException(nameof(ranges), "One of the ranges is null.");
                }

                if (range.Length != 2)
                {
                    throw new ArgumentException("Invalid range");
                }

                decimal rangeStart = range[0];
                decimal rangeEnd = range[1];

                if (rangeStart > rangeEnd)
                {
                    throw new ArgumentException("Invalid range");
                }

                foreach (decimal valueToSearch in arrayToSearch)
                {
                    if (valueToSearch >= rangeStart && valueToSearch <= rangeEnd)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[]? arrayToSearch, decimal[]?[]? ranges, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            if (startIndex < 0 || startIndex >= arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (count < 0 || startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (arrayToSearch.Length == 0)
            {
                throw new ArgumentException("The arrayToSearch is empty.");
            }

            int counter = 0;

            for (int i = startIndex; i < startIndex + count; i++)
            {
                decimal valueToSearch = arrayToSearch[i];

                foreach (var range in ranges)
                {
                    if (range is null)
                    {
                        throw new ArgumentNullException(nameof(ranges), "One of the ranges is null.");
                    }

                    if (range.Length != 2)
                    {
                        throw new ArgumentException("Invalid range");
                    }

                    decimal rangeStart = range[0];
                    decimal rangeEnd = range[1];

                    if (rangeStart > rangeEnd)
                    {
                        throw new ArgumentException("Invalid range");
                    }

                    if (valueToSearch >= rangeStart && valueToSearch <= rangeEnd)
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
