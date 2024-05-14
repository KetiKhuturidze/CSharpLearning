﻿using System;
using GenericMethods.Interfaces;

namespace IntegerPredicate
{
    /// <summary>
    /// Predicate class for the integer type.
    /// </summary>
    public class ContainsDigitPredicate : IPredicate<int>
    {
        /// <summary>
        /// Gets or sets digit in the integer number.
        /// </summary>
        public int Digit
        {
            get;
            set;
        }

        /// <summary>
        /// Determines if a number contains a given digit.
        /// </summary>
        /// <param name="obj">The integer value.</param>
        /// <returns>true if integer value contains given digit; otherwise, false.</returns>
        public bool IsMatch(int obj)
        {
            foreach (char i in obj.ToString())
            {
                if (this.Digit.ToString() == i.ToString())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
