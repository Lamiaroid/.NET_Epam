using System;
using System.Threading;

namespace NET.S._2019.Tkachenko._11_Timer
{
    public class Timer
    {
        private const int oneSecond = 1000;

        public delegate void TimerEventHandler(object sender, TimerEventArgs e);

        public event TimerEventHandler Countdown;

        /// <summary>
        /// Implementation of timer countdown
        /// </summary>
        public void StartCoundown(int time, string message)
        {
            if (time <= 0)
            {
                throw new ArgumentException("Time can't be less or equal to 0.");
            }

            if (message == null)
            {
                throw new ArgumentNullException("Message can't be null.");
            }

            Thread.Sleep(oneSecond * time);

            OnCountdown(this, new TimerEventArgs(time, message));
        }

        private void OnCountdown(object sender, TimerEventArgs e)
        {
            Countdown.Invoke(sender, e);
        }
    }
}