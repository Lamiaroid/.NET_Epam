using System;

namespace NET.S._2019.Tkachenko._11_Timer
{
    public class TimerEventArgs : EventArgs
    {
        public int Time { get; }

        public string Message { get; }

        public TimerEventArgs(int time, string message)
        {
            Time = time;
            Message = message;
        }
    }
}