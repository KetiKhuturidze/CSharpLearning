﻿namespace Strings
{
    public static class UsingIndexer
    {
        /// <summary>
        /// Gets the first character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetFirstChar(string str)
        {
            return str[0];
        }

        /// <summary>
        /// Gets the second character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetSecondChar(string str)
        {
            return str[1];
        }

        /// <summary>
        /// Gets the third character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetThirdChar(string str)
        {
            return str[2];
        }

        /// <summary>
        /// Gets the last character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetLastChar(string str)
        {
            return str[^1];
        }

        /// <summary>
        /// Gets the next to last character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetNextToLastChar(string str)
        {
            return str[^2];
        }

        /// <summary>
        /// Gets the third character from the end of the <paramref name="str"/> string.
        /// </summary>
        public static char GetThirdCharFromEnd(string str)
        {
            return str[^3];
        }

        /// <summary>
        /// Gets the n-th character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetNthChar(string str, int n)
        {
            return str[n - 1];
        }

        /// <summary>
        /// Gets the n-th character from the end of the <paramref name="str"/> string.
        /// </summary>
        public static char GetNthCharFromEnd(string str, int n)
        {
            return str[^n];
        }

        /// <summary>
        /// Gets the last character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetLastCharUsingLength(string str)
        {
            return str[str.Length - 1];
        }

        /// <summary>
        /// Gets the next to last character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetNextToLastCharUsingLength(string str)
        {
            return str[str.Length - 2];
        }

        /// <summary>
        /// Gets the fifth character from the end of the <paramref name="str"/> string.
        /// </summary>
        public static char GetFifthCharFromEndUsingLength(string str)
        {
            return str[str.Length - 5];
        }

        /// <summary>
        /// Gets the n-th character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetNthCharFromEndUsingLength(string str, int n)
        {
            return str[str.Length - n];
        }

        /// <summary>
        /// Gets special code characters from <paramref name="serialNumber"/>.
        /// </summary>
        public static void GetSpecialCodes(string serialNumber, out char expectedCode1, out char expectedCode2, out char expectedCode3)
        {
            expectedCode1 = serialNumber[1];
            int indexer = 3;
            while (serialNumber[indexer] == '0')
            {
                indexer++;
            }

            expectedCode2 = serialNumber[indexer];
            expectedCode3 = serialNumber[indexer + 4];
        }
    }
}
