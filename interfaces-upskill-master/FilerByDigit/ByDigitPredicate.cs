﻿using System;
using FilterByPredicate;

namespace FilterByDigit
{
    /// <summary>
    /// Predicate that determines the presence of some digit in integer.
    /// </summary>
    public class ByDigitPredicate : IPredicate
    {
        /// <summary>
        /// Gets or sets a digit.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Digit more than 9 or less than 0.</exception>
        public int Digit
        {
            get;
            set;
        }

        /// <inheritdoc/>
        public bool IsMatch(int number)
        {
            string element = number.ToString();
            foreach (char c in element)
            {
                if (c == (char)('0' + this.Digit))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
