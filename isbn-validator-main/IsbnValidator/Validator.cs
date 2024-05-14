namespace IsbnValidator
{
    public static class Validator
    {
        /// <summary>
        /// Returns true if the specified <paramref name="isbn"/> is valid; returns false otherwise.
        /// </summary>
        /// <param name="isbn">The string representation of 10-digit ISBN.</param>
        /// <returns>true if the specified <paramref name="isbn"/> is valid; false otherwise.</returns>
        /// <exception cref="ArgumentException"><paramref name="isbn"/> is empty or has only white-space characters.</exception>
        public static bool IsIsbnValid(string isbn)
        {
            if (isbn is null || string.IsNullOrEmpty(isbn) || string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException("invalid isbn");
            }

            string newStr = isbn.Replace("-", string.Empty);

            if (newStr.Length != 10 || !CheckHyphens(isbn, newStr))
            {
                return false;
            }

            int sum = 0;
            int j = 0;

            for (int i = 1; i <= 10; i++)
            {
                if (newStr[j] == 'X' && i == 10)
                {
                    sum += 10 * (11 - i);
                    j++;
                }
                else if (int.TryParse(newStr[j].ToString(), out int result))
                {
                    sum += result * (11 - i);
                    j++;
                }
                else
                {
                    return false;
                }
            }

            return sum % 11 == 0;
        }

        private static bool CheckHyphens(string isbn, string newStr)
        {
            if (isbn.Length - newStr.Length > 3)
            {
                return false;
            }

            for (int i = 0; i < isbn.Length; i++)
            {
                if (isbn[i] == '-' && isbn[++i] == '-')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
