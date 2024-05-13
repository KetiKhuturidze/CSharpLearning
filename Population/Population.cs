using System;

namespace PopulationTask
{
    public static class Population
    {
        /// <summary>
        /// Calculates the count of years which the town need
        /// to see its population greater or equal to currentPopulation inhabitants.
        /// </summary>
        /// <param name="initialPopulation">The population at the beginning of a year.</param>
        /// <param name="percent">The percentage of growth per year.</param>
        /// <param name="visitors">The visitors (new inhabitants per year) who come to live in the town.</param>
        /// <param name="currentPopulation">The population at present.</param>
        /// <returns>The count of years which the town need to see its population
        /// greater or equal to currentPopulation inhabitants.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when initial population is less or equals 0
        /// - or -
        /// the count of visitors cannot be less 0
        /// - or -
        /// the current population is less or equals 0
        /// - or -
        /// the current population is less than initial population.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">Throw if the value of percents is less then 0% or more then 100%.</exception>
        public static int GetYears(int initialPopulation, double percent, int visitors, int currentPopulation)
        {
            if (percent < 0 || percent > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percent));
            }

            if (initialPopulation <= 0)
            {
                throw new ArgumentException("Population can not be <= 0, incorrect argument");
            }

            if (visitors < 0)
            {
                throw new ArgumentException("Visitor numbers cannot be less than 0, incorrect argument");
            }

            if (currentPopulation <= 0)
            {
                throw new ArgumentException("Currnt population cannot be less than, or equal to 0, incorrect argument");
            }

            if (currentPopulation < initialPopulation)
            {
                throw new ArgumentException("Current population cannot be less than initial population, incorrect argument");
            }

            int counter = 0;
            double multiplyByPercent;
            double plusVisitors;
            while (initialPopulation < currentPopulation)
            {
                multiplyByPercent = (double)initialPopulation * (percent / 100);
                plusVisitors = multiplyByPercent + visitors;
                initialPopulation += (int)plusVisitors;
                counter++;
            }

            return counter;
        }
    }
}