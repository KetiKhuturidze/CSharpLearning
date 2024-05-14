using System;

namespace LookingForChars
{
    public static class CharsCounter
    {
        /// <summary>
        /// Searches a string for all characters that are in <see cref="Array" />, and returns the number of occurrences of all characters.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <returns>The number of occurrences of all characters.</returns>
        public static int GetCharsCount(string? str, char[]? chars)
        {
            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            int counter = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (chars[i] == str[j])
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        /// <summary>
        /// Searches a string for all characters that are in <see cref="Array" />,
        /// and returns the number of occurrences of all characters within the range of
        /// elements in the <see cref="string"/> that starts at the specified index and ends at the specified index.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <param name="startIndex">A zero-based starting index of the search.</param>
        /// <param name="endIndex">A zero-based ending index of the search.</param>
        /// <returns>The number of occurrences of all characters within the specified range of elements in the <see cref="string"/>.</returns>
        public static int GetCharsCount(string? str, char[]? chars, int startIndex, int endIndex)
        {
            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (str.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(str));
            }

            if (chars.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(chars));
            }

            if (startIndex > endIndex || startIndex > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (endIndex > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex));
            }

            int counter = 0;

            while (startIndex <= endIndex)
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    if (str[startIndex] == chars[i])
                    {
                        counter++;
                    }
                }

                startIndex++;
            }

            return counter;
        }

        /// <summary>
        /// Searches a string for a limited number of characters that are in <see cref="Array" />,
        /// and returns the number of occurrences of all characters within the range of elements in
        /// the <see cref="string"/> that starts at the specified index and ends at the specified index.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <param name="startIndex">A zero-based starting index of the search.</param>
        /// <param name="endIndex">A zero-based ending index of the search.</param>
        /// <param name="limit">A maximum number of characters to search.</param>
        /// <returns>The limited number of occurrences of characters to search for within the specified range of elements in the <see cref="string"/>.</returns>
        public static int GetCharsCount(string? str, char[]? chars, int startIndex, int endIndex, int limit)
        {
            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (limit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(limit));
            }

            if (str.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(str));
            }

            if (chars.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(chars));
            }

            if (startIndex > endIndex || startIndex > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (endIndex > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex));
            }

            int counter = 0;

            do
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    if (str[startIndex] == chars[i] && counter < limit)
                    {
                        counter++;
                        break;
                    }
                }

                startIndex++;
            }
            while (startIndex <= endIndex);

            return counter;
        }
    }
}
