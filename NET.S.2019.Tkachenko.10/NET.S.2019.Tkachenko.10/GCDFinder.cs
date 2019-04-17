namespace NET.S._2019.Tkachenko._10
{
    using System;

    public class GCDFinder
    {
        private delegate void AlgorithmLogic(ref int[] numbers, ref int i);

        /// <summary>
        /// Finds the gcd of up to 100 given numbers
        /// </summary>
        /// <param name="isEuclideanVanilla">Set true if classic Euclidean algorithm needed</param>
        /// <param name="numbers">Numbers to work with</param>
        /// <returns>Greatest common divisor of given numbers</returns>
        public int Find(bool isEuclideanVanilla, params int[] numbers)
        {
            this.AlgorithmArgumentsValidation(numbers);

            int i = 0;

            numbers[i] = Math.Abs(numbers[i]);

            AlgorithmLogic algorithmLogic;

            if (isEuclideanVanilla)
            {
                algorithmLogic = this.EuclideanAlgorithm;
            }
            else
            {
                algorithmLogic = this.BinaryGCDAlgorithm;
            }

            // Searching for gcd of 2 numbers with the subtraction method
            while (i + 1 < numbers.Length)
            {
                numbers[i + 1] = Math.Abs(numbers[i + 1]);

                if (numbers[i] == 0)
                {
                    numbers[i] = numbers[i + 1];
                }

                if (numbers[i + 1] == 0)
                {
                    numbers[i + 1] = numbers[i];
                }

                algorithmLogic(ref numbers, ref i);

                numbers[i + 1] = numbers[i];
                i++;
            }

            return numbers[i];
        }

        /// <summary>
        /// Implementation of finding Euclidean algorithm's working time
        /// </summary>
        /// <param name="numbers">Numbers to work with</param>
        /// <returns>Time to execute algorithm</returns>
        public TimeSpan GetEuclideanAlgorithmExecutionTime(params int[] numbers)
        {
            // This call of method is used for it's initialization for the first time (to find working time the most accurate)
            this.Find(true, 1, 1);

            DateTime timeStart = DateTime.Now;
            this.Find(true, numbers);
            DateTime timeFinish = DateTime.Now;

            return timeFinish - timeStart;
        }

        /// <summary>
        /// Implementarion of finding Stein's (binary gcd) algorithm's working time
        /// </summary>
        /// <param name="numbers">Numbers to work with</param>
        /// <returns>Time to execute algorithm</returns>
        public TimeSpan GetBinaryGCDAlgorithmExecutionTime(params int[] numbers)
        {
            // This call of method is used for it's initialization for the first time (to find working time the most accurate)
            this.Find(false, 1, 1);

            DateTime timeStart = DateTime.Now;
            this.Find(false, numbers);
            DateTime timeFinish = DateTime.Now;

            return timeFinish - timeStart;
        }

        // Implementaion of classic Euclidean algorithm for finding gcd of up to 100 numbers
        private void EuclideanAlgorithm(ref int[] numbers, ref int i)
        {
            while (numbers[i] != numbers[i + 1])
            {
                if (numbers[i] > numbers[i + 1])
                {
                    numbers[i] = numbers[i] - numbers[i + 1];
                }
                else
                {
                    numbers[i + 1] = numbers[i + 1] - numbers[i];
                }
            }
        }

        // Implementaion of Stein's algorithm for finding gcd of up to 100 numbers
        private void BinaryGCDAlgorithm(ref int[] numbers, ref int i)
        {
            if (numbers[i] != numbers[i + 1])
            {
                // Let shift := lg K, where K is the greatest power of 2 dividing both numbers[i] and numbers[i + 1]
                int shift = 0;
                while (((numbers[i] | numbers[i + 1]) & 1) == 0)
                {
                    shift++;
                    numbers[i] >>= 1;
                    numbers[i + 1] >>= 1;
                }

                while ((numbers[i] & 1) == 0)
                {
                    numbers[i] >>= 1;
                }

                // From here on, numbers[i] is always odd
                do
                {
                    // Remove all factors of 2 in numbers[i + 1] -- they are not common
                    // Note: numbers[i + 1] is not zero, so while will terminate
                    while ((numbers[i + 1] & 1) == 0)
                    {
                        numbers[i + 1] >>= 1;
                    }

                    // Now numbers[i] and numbers[i + 1] are both odd. Swap if necessary so numbers[i] <= numbers[i + 1],
                    // then set numbers[i + 1] = numbers[i + 1] - numbers[i] (which is even). For bignums, the
                    // swapping is just pointer movement, and the subtraction can be done in-place
                    if (numbers[i] > numbers[i + 1])
                    {
                        this.Swap(ref numbers[i], ref numbers[i + 1]);
                    }

                    // Here numbers[i + 1] >= numbers[i]
                    numbers[i + 1] -= numbers[i];
                }
                while (numbers[i + 1] != 0);

                // Restore common factors of 2
                numbers[i] <<= shift;
            }
        }

        // Implementation of common swap
        private void Swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        // Implemetation of arguments validation for gcd finding algorithms
        private void AlgorithmArgumentsValidation(params int[] numbers)
        {
            const int maxArguments = 100;

            if (numbers.Length > maxArguments)
            {
                throw new ArgumentException("There can't be more than 100 arguments.");
            }

            if (numbers.Length == 0 || numbers.Length == 1)
            {
                throw new ArgumentException("There should be at least 2 numbers.");
            }

            bool allArgumentsEqualToZeroError = true;
            bool tooSmallValueError = false;

            int i = 0;
            while (i < numbers.Length && !tooSmallValueError)
            {
                if (numbers[i] != 0)
                {
                    allArgumentsEqualToZeroError = false;
                }

                if (numbers[i] == int.MinValue)
                {
                    tooSmallValueError = true;
                }

                i++;
            }

            if (allArgumentsEqualToZeroError)
            {
                throw new ArgumentException("All arguments can't be equal to 0 at the same time.");
            }

            if (tooSmallValueError)
            {
                throw new ArgumentException("Value can't be equal to minimal integer.");
            }
        }
    }
}