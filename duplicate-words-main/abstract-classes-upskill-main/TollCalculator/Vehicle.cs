using System;

namespace TollCalculator
{
    /// <summary>
    /// Represents a vehicle base class in pricing and toll calculation system.
    /// </summary>
    public abstract class Vehicle
    {
        private decimal baseToll;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        protected Vehicle()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class with the specified base toll.
        /// </summary>
        /// <param name="baseToll">A base toll for the <see cref="Vehicle"/> class.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="baseToll"/> is less than zero.</exception>
        protected Vehicle(decimal baseToll)
        {
            if (baseToll < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(baseToll));
            }

            this.BaseToll = baseToll;
        }

        /// <summary>
        /// Gets or sets a base toll for the vehicle.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than zero.</exception>
        public decimal BaseToll
        {
            get => this.baseToll;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.baseToll = value;
            }
        }

        /// <summary>
        /// Calculates the final toll for the vehicle that adjusts for time peaks and traffic direction.
        /// </summary>
        /// <param name="timeOfToll">A time of toll.</param>
        /// <param name="direction">A traffic direction.</param>
        /// <returns>The final toll for the vehicle that adjusts for time peaks and traffic direction.</returns>
        public decimal CalculateToll(DateTime timeOfToll, TrafficDirection direction)
        {
            return this.Calculate() * PeakTimePremium(timeOfToll, direction);
        }

        /// <summary>
        /// Calculates the base toll that relies only on the vehicle type.
        /// </summary>
        /// <returns>The base toll of vehicle.</returns>
        protected abstract decimal Calculate();

        /// <summary>
        /// Calculates a weighting factor for the base toll, taking into account time peaks and direction of travel.
        /// ----------------------------------------------------------
        /// Day         Time            Direction       Weight factor
        /// ----------------------------------------------------------
        /// Weekday     morning rush    inbound             x 2.00
        /// Weekday     morning rush    outbound            x 1.00
        /// Weekday     daytime         inbound             x 1.50
        /// Weekday     daytime         outbound            x 1.50
        /// Weekday     evening rush    inbound             x 1.00
        /// Weekday     evening rush    outbound            x 2.00
        /// Weekday     overnight       inbound             x 0.75
        /// Weekday     overnight       outbound            x 0.75
        /// Weekend     morning rush    inbound             x 1.00
        /// Weekend     morning rush    outbound            x 1.00
        /// Weekend     daytime         inbound             x 1.00
        /// Weekend     daytime         outbound            x 1.00
        /// Weekend     evening rush    inbound             x 1.00
        /// Weekend     evening rush    outbound            x 1.00
        /// Weekend     overnight       inbound             x 1.00
        /// Weekend     overnight       outbound            x 1.00.
        /// </summary>
        /// <param name="timeOfToll">A time of toll.</param>
        /// <param name="direction">A traffic direction.</param>
        /// <returns>A weight factor that adjusts for time peaks and traffic direction.</returns>
        private static decimal PeakTimePremium(DateTime timeOfToll, TrafficDirection direction)
        {
            switch ((IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), direction))
            {
                case (true, TimeBand.MorningRush, TrafficDirection.Inbound):
                    {
                        return 2;
                    }

                case (true, TimeBand.Daytime, TrafficDirection.Inbound):
                    {
                        return 1.5m;
                    }

                case (true, TimeBand.Daytime, TrafficDirection.Outbound):
                    {
                        return 1.5m;
                    }

                case (true, TimeBand.EveningRush, TrafficDirection.Outbound):
                    {
                        return 2;
                    }

                case (true, TimeBand.Overnight, TrafficDirection.Inbound):
                    {
                        return 0.75m;
                    }

                case (true, TimeBand.Overnight, TrafficDirection.Outbound):
                    {
                        return 0.75m;
                    }
            }

            return 1;
        }

        /// <summary>
        /// Defines whether a DateTime represents a weekend or a weekday.
        /// </summary>
        /// <param name="timeOfToll">The time when the toll was collected.</param>
        /// <returns>true if <paramref name="timeOfToll"/> is weekday; false otherwise.</returns>
        private static bool IsWeekDay(DateTime timeOfToll)
        {
            return timeOfToll.DayOfWeek != DayOfWeek.Saturday && timeOfToll.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        /// Categorizes the time into the time bands.
        /// </summary>
        /// <param name="timeOfToll">The time when the toll was collected.</param>
        /// <returns><see cref="TimeBand"/> instance.</returns>
        private static TimeBand GetTimeBand(DateTime timeOfToll)
        {
            if (timeOfToll.Hour > 6 && timeOfToll.Hour <= 10)
            {
                return TimeBand.MorningRush;
            }
            else if (timeOfToll.Hour > 10 && timeOfToll.Hour <= 16)
            {
                return TimeBand.Daytime;
            }
            else if (timeOfToll.Hour > 16 && timeOfToll.Hour <= 19)
            {
                return TimeBand.EveningRush;
            }

            return TimeBand.Overnight;
        }
    }
}
