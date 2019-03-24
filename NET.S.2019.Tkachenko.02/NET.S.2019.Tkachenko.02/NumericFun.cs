using System;
using System.Collections.Generic;
using System.Collections;

namespace NET.S._2019.Tkachenko._02
{
    public class NumericFun
    {
        /// <summary>
        /// Inserts bits from numberIn to numberSource in positions from i to j bit
        /// </summary>
        public int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            if (i < 0 || i > 31)
            {
                throw new ArgumentException();
            }

            if (j < 0 || j > 31)
            {
                throw new ArgumentException();
            }

            if (i > j)
            {
                throw new ArgumentException();
            }

            int result = 0;
            BitArray sourceArray = new BitArray(new int[] { numberSource });
            BitArray inArray = new BitArray(new int[] { numberIn });

            int counter = 0;
            for ( ; i <= j; i++)
            {
                sourceArray[i] = inArray[counter];
                counter++;
            }
          
            int power = 0;
            //Converting bit array to new number
            foreach (bool source in sourceArray)
            {
                int bitState = source ? 1 : 0;
                result += bitState * (int)Math.Pow(2, power);
                power++;
            }
           
            return result;
        }

        /// <summary>
        /// Finds the nearest the biggest number made from digits of source number and finds searching time 
        /// </summary>
        public Tuple<int?, TimeSpan> FindNextBiggerNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException();
            }

            DateTime timeStart = DateTime.Now;
            DateTime timeFinish;

            string strNumber = number.ToString();
            int lastDigitPosition = strNumber.Length - 1;
            int biggestDigitBeforeBorder = (int)Char.GetNumericValue(strNumber[lastDigitPosition]);

            int counter = 1;
            while (strNumber.Length - counter > 0)
            {
                //Searching from left to right
                //Trying to find the first number smaller than right neighbour (border number)
                if (biggestDigitBeforeBorder > (int)Char.GetNumericValue(strNumber[lastDigitPosition - counter]))
                {
                    int positionBorder = lastDigitPosition - counter;
                    int positionNearestToBorderDigit = positionBorder + 1;
                    int borderDigit = (int)Char.GetNumericValue(strNumber[positionBorder]);
                    int nearestToBorderDigit = (int)Char.GetNumericValue(strNumber[positionNearestToBorderDigit]);

                    //Searching number bigger than border number by the lowest value (the nearest number)
                    //(searching only right from border)
                    while (counter > 0)
                    {
                        if ((nearestToBorderDigit > (int)Char.GetNumericValue(strNumber[lastDigitPosition - counter])) &&
                            (borderDigit < (int)Char.GetNumericValue(strNumber[lastDigitPosition - counter])))
                        {
                            nearestToBorderDigit = (int)Char.GetNumericValue(strNumber[lastDigitPosition - counter]);
                            positionNearestToBorderDigit = lastDigitPosition - counter;
                        }

                        counter--;
                    }

                    //Swap border and the nearest numbers
                    strNumber = strNumber.Remove(positionBorder, 1).Insert(positionBorder, nearestToBorderDigit.ToString());
                    strNumber = strNumber.Remove(positionNearestToBorderDigit, 1).Insert(positionNearestToBorderDigit, borderDigit.ToString());

                    //Sorting array of values after border number (that has been already changed)
                    int[] partAfterBorderSorted = new int[lastDigitPosition - positionBorder];
                    for (int i = 0; i < partAfterBorderSorted.Length; i++)
                    {
                        partAfterBorderSorted[i] = (int)Char.GetNumericValue(strNumber[positionBorder + 1 + i]);
                    }

                    for (int i = 0; i < partAfterBorderSorted.Length; i++)
                    {
                        for (int j = i; j < partAfterBorderSorted.Length; j++)
                        {
                            if (partAfterBorderSorted[i] > partAfterBorderSorted[j])
                            {
                                int temporary = partAfterBorderSorted[j];
                                partAfterBorderSorted[j] = partAfterBorderSorted[i];
                                partAfterBorderSorted[i] = temporary;
                            }
                        }
                    }

                    //Linking part containing border number with sorted part
                    string nextNumber = "";
                    for (int i = 0; i < positionBorder; i++)
                    {
                        nextNumber += strNumber[i];
                    }
                    nextNumber += nearestToBorderDigit.ToString();

                    for (int i = 0; i < partAfterBorderSorted.Length; i++)
                    {
                        nextNumber += partAfterBorderSorted[i].ToString();
                    }

                    checked
                    {
                        try
                        {
                            timeFinish = DateTime.Now;
                            return new Tuple<int?, TimeSpan>(int.Parse(nextNumber), timeFinish - timeStart);
                        }
                        catch (OverflowException)
                        {
                            return null;
                        }
                    }
                }
                else
                {
                    biggestDigitBeforeBorder = (int)Char.GetNumericValue(strNumber[lastDigitPosition - counter]);
                }

                counter++;
            }

            timeFinish = DateTime.Now;

            return new Tuple<int?, TimeSpan>(null, timeFinish - timeStart);
        }

        /// <summary>
        /// Searches for numbers containing certain digit in given list
        /// </summary>
        public List<int> FilterDigit(List<int> numbersForWork, int digitToContain)
        {
            if (numbersForWork == null)
            {
                throw new ArgumentNullException();
            }

            if (numbersForWork.Count == 0)
            {
                throw new ArgumentException();
            }      

            if (digitToContain > 9 || digitToContain < 0)
            {
                throw new ArgumentException();
            }

            List<int> suitableNumbers = new List<int>();

            foreach (int number in numbersForWork)
            {
                int numberTemp = number;

                do
                {
                    if (Math.Abs(numberTemp % 10) == digitToContain)
                    {
                        suitableNumbers.Add(number);
                        numberTemp = 0;
                    }

                    numberTemp /= 10;
                }
                while (numberTemp != 0);
            }

            return suitableNumbers;
        }

        /// <summary>
        /// Finds n'th root of number with certain precision
        /// </summary>
        public double FindNthRoot(double x, double power, double eps, double suggestedValue = 1)
        {
            if (power <= 0)
            {
                throw new ArgumentException();
            }

            if (x <= 0 && power % 2 == 0)
            {
                throw new ArgumentException();
            }

            if (eps <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            double suggestedValuePrevious = suggestedValue;
            suggestedValue = suggestedValue - RootFunction(suggestedValue, power, x) / RootDerivateFunction(suggestedValue, power);

            if (Math.Abs(suggestedValuePrevious - suggestedValue) > eps)
            {
                return FindNthRoot(x, power, eps, suggestedValue);
            }
            else
            {
                int numberOfDigitsToRound = 0;

                while (eps * 10 <= 1)
                {
                    eps *= 10;
                    numberOfDigitsToRound++;
                }

                return Math.Round(suggestedValue, numberOfDigitsToRound);
            }
        }

        private double RootFunction(double suggestedValue, double power, double x) => Math.Pow(suggestedValue, power) - x;

        private double RootDerivateFunction(double suggestedValue, double power) => power * Math.Pow(suggestedValue, power - 1);
    }
}
