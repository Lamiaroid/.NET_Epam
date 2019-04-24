using System;

namespace NET.S._2019.Tkachenko._11_Timer
{
    public class Tester
    {
        /// <summary>
        /// Implementation of subscribing for event
        /// </summary>
        /// <param name="timer">Current timer to subscribe</param>
        public void Subscribe(Timer timer)
        {
            timer.Countdown += CountdownIsOver;
        }

        private void CountdownIsOver(object sender, TimerEventArgs eventArgs)
        {
            Console.WriteLine("You have received a message: " + eventArgs.Message);
        }
    }
}