using System;

namespace TimeStruct
{
    /// <summary>
    /// documented.
    /// </summary>
    public readonly struct Time
    {
        private const int MinutesPerHour = 60;
        private const int HoursPerDay = 24;
        private const int MinutesPerDay = MinutesPerHour * HoursPerDay;

        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> struct.
        /// </summary>
        /// <param name="minutes"> reps the mins in an hour .</param>
        public Time(int minutes)
            : this(minutes / MinutesPerHour, minutes % MinutesPerHour)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> struct.
        /// </summary>
        /// kjnqj
        /// <param name="hours">faef</param> ksjsj
        /// <param name="minutes">faewew</param>ksss
        /// smsks
        public Time(int hours, int minutes)
        {
            int totalMinutes = (hours * MinutesPerHour) + minutes;
            totalMinutes = totalMinutes % MinutesPerDay;
            totalMinutes = totalMinutes + MinutesPerDay;
            totalMinutes = totalMinutes % MinutesPerDay;
            this.Hours = totalMinutes / MinutesPerHour;
            this.Minutes = totalMinutes % MinutesPerHour;
        }

        /// <summary>
        /// Gets initializes a new instance of the <see cref="Time"/> struct.
        /// </summary>
        /// kjnqj.
        /// <param name="hours">fsfsdf</param> ksjsj
        /// <param name="minutes">sffdsd</param>ksss
        /// smsks
        public readonly int Hours { get; }

        /// <summary>
        /// Gets initializes a new instance of the <see cref="Time"/> struct.
        /// </summary>
        /// kjnqjdd.
        /// <param name="hours">dgdsr.</param> ksjsj
        /// <param name="minutes">ffre.</param>ksss
        /// smsks
        public readonly int Minutes { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return new string($"{this.Hours:D2}:{this.Minutes:D2}");
        }

        /// <summary>
        /// this is.
        /// </summary>
        /// <param name="hours">scdc.</param>
        /// <param name="minutes">dcscd.</param>
        public void Deconstruct(out int hours, out int minutes)
        {
            hours = this.Hours;
            minutes = this.Minutes;
        }
    }
}
