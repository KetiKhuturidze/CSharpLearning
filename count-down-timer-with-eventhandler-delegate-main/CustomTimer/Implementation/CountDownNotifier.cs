using System;
using CustomTimer.EventArgsClasses;
using CustomTimer.Interfaces;

namespace CustomTimer.Implementation
{
    /// <inheritdoc/>
    public class CountDownNotifier : ICountDownNotifier
    {
        private readonly Timer timer;

        public CountDownNotifier(Timer timer)
        {
            if (timer is null)
            {
                throw new ArgumentException(null, nameof(timer));
            }

            this.timer = timer;
        }

        /// <inheritdoc/>
        public void Run()
        {
            this.timer.Run();
        }

        /// <inheritdoc/>
        public void Init(EventHandler<StartedEventArgs>? startHandler, EventHandler<StoppedEventArgs>? stopHandler, EventHandler<TickEventArgs>? tickHandler)
        {
            this.timer.Started += (sender, e) => startHandler?.Invoke(this, e);
            this.timer.Stopped += (sender, e) => stopHandler?.Invoke(this, e);
            this.timer.Tick += (sender, e) => tickHandler?.Invoke(this, e);
        }
    }
}
