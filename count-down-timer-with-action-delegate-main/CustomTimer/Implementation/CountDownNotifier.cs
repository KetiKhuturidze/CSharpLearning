using System;
using CustomTimer.Interfaces;

namespace CustomTimer.Implementation
{
    /// <inheritdoc/>
    public class CountDownNotifier : ICountDownNotifier
    {
        private readonly Timer timer;

        public CountDownNotifier(Timer timer)
        {
            if (timer == null)
            {
                throw new ArgumentNullException(nameof(timer));
            }

            this.timer = timer;
            this.timer.Started += this.TimerStarted;
            this.timer.Tick += this.TimerTick;
            this.timer.Stopped += this.TimerStopped;
        }

        public void Init(Action<string, int> startHandler, Action<string> stopHandler, Action<string, int> tickHandler)
        {
            this.timer.Started += (name, ticks) => startHandler?.Invoke(name, ticks);
            this.timer.Stopped += name => stopHandler?.Invoke(name);
            this.timer.Tick += (name, ticks) => tickHandler?.Invoke(name, ticks);
        }

        public void Run()
        {
            this.timer.Run();
        }

        private void TimerStarted(string name, int ticks)
        {
            // text
            // text
        }

        private void TimerTick(string name, int ticks)
        {
            // text
            // text
        }

        private void TimerStopped(string name)
        {
            // text
            // text
        }
    }
}