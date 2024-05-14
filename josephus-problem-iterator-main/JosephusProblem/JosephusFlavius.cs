using System;
using System.Collections.Generic;

namespace JosephusProblem
{
    /// <summary>
    /// Providing functionality for the Josephus Flavius problem.
    /// <see>You can find more details on this problem in Wikipedia - https://en.wikipedia.org/wiki/Josephus_problem</see>.
    /// </summary>
    public static class JosephusFlavius
    {
        /// <summary>
        /// Returns the iterator that generates a list of persons that are crossed out.
        /// </summary>
        /// <param name="count">Count of the persons in circle.</param>
        /// <param name="crossedOut">The number of the person to be crossed out.</param>
        /// <returns>Returns the iterator that generates a list of persons that are crossed out.</returns>
        /// <exception cref="ArgumentException"><paramref name="count"/>is less than 1.</exception>
        /// <exception cref="ArgumentException"><paramref name="crossedOut"/> is less than 1.</exception>
        public static IEnumerable<int> GetCrossedOutPersons(int count, int crossedOut)
        {
            if (count < 1 || crossedOut < 1)
            {
                throw new ArgumentException("Both count and crossedOut must be greater than or equal to 1.");
            }

            List<int> persons = new List<int>();
            for (int i = 1; i <= count; i++)
            {
                persons.Add(i);
            }

            List<int> crossedOutPersons = new List<int>();
            int currentIndex = 0;
            for (int i = 0; i < count - 1; i++)
            {
                currentIndex = (currentIndex + crossedOut - 1) % persons.Count;
                crossedOutPersons.Add(persons[currentIndex]);
                persons.RemoveAt(currentIndex);
            }

            return crossedOutPersons;
        }

        /// <summary>
        /// Returns order number of survivor.
        /// </summary>
        /// <param name="count">Count of the persons in circle.</param>
        /// <param name="crossedOut">The number of the person to be crossed out.</param>
        /// <returns>The order number of the last survivor.</returns>
        /// <exception cref="ArgumentException"><paramref name="count"/>is less than 1.</exception>
        /// <exception cref="ArgumentException"><paramref name="crossedOut"/> is less than 1.</exception>
        public static int GetSurvivor(int count, int crossedOut)
        {
            if (count < 1 || crossedOut < 1)
            {
                throw new ArgumentException("Both count and crossedOut must be greater than or equal to 1.");
            }

            int survivor = 0;

            for (int i = 2; i <= count; i++)
            {
                survivor = (survivor + crossedOut) % i;
            }

            return survivor + 1;
        }
    }
}
