using System;

namespace NET.S._2019.Tkachenko._11
{
    public class FibonacciSequence
    {
        /// <summary>
        /// Implementation of receiving first n numbers of Fibonacci sequence
        /// </summary>
        /// <param name="numbersCount">Amount of numbers in Fibonacci sequence</param>
        /// <returns>Fibonacci sequence</returns>
        public int[] GetNumbersOfSequence(int numbersCount)
        {
            if (numbersCount <= 0)
            {
                throw new ArgumentException("The sequence can't be shorter than 0 or equal to it.");
            }

            int[] sequence = new int[numbersCount];

            int previousNumber = 0;
            int currentNumber = 1;
            sequence[0] = currentNumber;

            try
            {
                for (int i = 1; i < numbersCount; i++)
                {
                    int temp = currentNumber;
                    currentNumber = checked(currentNumber + previousNumber);
                    sequence[i] = currentNumber;
                    previousNumber = temp;
                }
            }
            catch
            {
                throw new OverflowException("Your sequence number seems to be too big.");
            }

            return sequence;
        }
    }
}