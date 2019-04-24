using System;
using System.Collections.Generic;

namespace NET.S._2019.Tkachenko._11
{
    public class BinarySearch
    {
        /// <summary>
        /// Implementation of binary search algorithm
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="array">Array of data</param>
        /// <param name="searchFor">Value to search for</param>
        /// <param name="comparer">Comparer</param>
        /// <returns>Returns position of element if it's found and -1 if not</returns>
        public int Find<T>(T[] array, T searchFor, IComparer<T> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array can't be null.");
            }

            if (searchFor == null)
            {
                throw new ArgumentNullException("Element to search for can't be null.");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException("Comparer can't be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array length can't be equal to 0.");
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    throw new ArgumentNullException("Elements can't be null.");
                }
            }

            int high = array.Length - 1;
            int mid;
            int low = 0;

            if (array[0].Equals(searchFor))
            {
                return 0;
            }
            else if (array[high].Equals(searchFor))
            {
                return high;
            }
            else
            {
                while (low <= high)
                {
                    mid = (high + low) / 2;
                    if (comparer.Compare(array[mid], searchFor) == 0)
                    {
                        return mid;
                    }
                    else if (comparer.Compare(array[mid], searchFor) > 0)
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }

                return -1;
            }
        }
    }
}