using BLL.Interface.Interfaces;
using System;

namespace BLL.ServiceImplementation
{
    public class AccountGenerateID : IAccountGenerateID
    {
        private static Random random = new Random(new Random(DateTime.Now.Second + DateTime.Now.Millisecond).Next((int)DateTime.Now.TimeOfDay.TotalMilliseconds));

        /// <summary>
        /// Generates random ID
        /// </summary>
        public string GenerateID()
        {
            string[] charSequence = new string[] { "x", "X", "y", "Y", "a", "A", "b", "B", "g", "G", "S", "Q", "W", "t", "p", "m" };
            const int number = 1000;

            return random.Next(number).ToString() + charSequence[random.Next(charSequence.Length)] +
                   charSequence[random.Next(charSequence.Length)] + random.Next(number).ToString() +
                   charSequence[random.Next(charSequence.Length)] + random.Next(number).ToString();
        }
    }
}