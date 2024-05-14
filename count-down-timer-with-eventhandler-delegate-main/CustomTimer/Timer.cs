using System;
using CustomTimer.EventArgsClasses;

namespace CustomTimer
{
    /// <summary>
    /// A custom class for simulating a countdown clock, which implements the ability to send a messages and additional
    /// information about the Started, Tick and Stopped events to any types that are subscribing the specified events.
    /// - When creating a CustomTimer object, it must be assigned:
    ///     - name (not null or empty string, otherwise ArgumentException will be thrown);
    ///     - the number of ticks (the number must be greater than 0 otherwise an exception will throw an ArgumentException).
    /// - After the timer has been created, it should fire the Started event, the event should contain information about
    /// the name of the timer and the number of ticks to start.
    /// - After starting the timer, it fires Tick events, which contain information about the name of the timer and
    /// the number of ticks left for triggering, there should be delays between Tick events, delays are modeled by Thread.Sleep.
    /// - After all Tick events are triggered, the timer should start the Stopped event, the event should contain information about
    /// the name of the timer.
    /// </summary>
    public class Timer
    {
        private readonly string timerName;
        private readonly int ticks;

        /// <summary>
        /// Initializes a new instance of the <see cref="Timer"/> class.
        /// </summary>
        /// <param name="timerName">Name.</param>
        /// <param name="ticks">Ticks.</param>
        public Timer(string timerName, int ticks)
        {
            if (string.IsNullOrEmpty(timerName))
            {
                throw new ArgumentException(null, nameof(timerName));
            }

            if (ticks <= 0)
            {
                throw new ArgumentException(null, nameof(ticks));
            }

            this.timerName = timerName;
            this.ticks = ticks;
            this.Run();
        }

        public event EventHandler<StartedEventArgs>? Started;

        public event EventHandler<TickEventArgs>? Tick;

        public event EventHandler<StoppedEventArgs>? Stopped;

        public void Run()
        {
            this.Started?.Invoke(this, new StartedEventArgs(this.timerName, this.ticks));

            for (int i = 0; i < this.ticks; i++)
            {
                Thread.Sleep(1);
                int ticksLeft = this.ticks - i - 1;
                this.Tick?.Invoke(this, new TickEventArgs(this.timerName, ticksLeft));
            }

            this.Stopped?.Invoke(this, new StoppedEventArgs(this.timerName));
        }
    }
}
