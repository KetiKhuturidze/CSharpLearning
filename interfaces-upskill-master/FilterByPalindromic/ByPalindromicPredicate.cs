using System;
using FilterByPredicate;

namespace FilterByPalindromic
{
    /// <summary>
    /// Palindrome predicate.
    /// </summary>
    public class ByPalindromicPredicate : IPredicate
    {
        /// <inheritdoc/>
        public bool IsMatch(int number)
        {
            if (number < 0)
            {
                return false;
            }

            if (number.ToString().Length == 1)
            {
                return true;
            }

            int originalNumber = number;
            int reversedNumber = 0;

            while (number > 0)
            {
                int remainder = number % 10;
                reversedNumber = (reversedNumber * 10) + remainder;
                number /= 10;
            }

            return originalNumber == reversedNumber;
        }
    }
}
