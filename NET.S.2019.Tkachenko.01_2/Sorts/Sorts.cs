using System;

namespace Sorts
{
    public class MergeSorter
    {
        public MergeSorter() { }

        ///<summary>Sorts integers in ascending order
        ///</summary>
        ///<returns>Sorted array</returns>
        public int[] Sort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            return MergeSort(array, 0, array.Length - 1);
        }

        private int[] MergeSort(int[] array, int startIndex, int endIndex)
        {
            if (endIndex > startIndex)
            {
                int mid = (endIndex + startIndex) / 2;
                MergeSort(array, startIndex, mid);
                MergeSort(array, (mid + 1), endIndex);
                Merge(array, startIndex, (mid + 1), endIndex);
            }

            return array;
        }

        private void Merge(int[] array, int left, int mid, int right)
        {
            //helping array
            int[] temp = new int[array.Length];
            int i, leftEnd, lengthOfInput, tmpPos;

            leftEnd = mid - 1;
            tmpPos = left;
            lengthOfInput = right - left + 1;

            //selecting smaller elements from left (right) sorted array and placing them in temp array.
            while ((left <= leftEnd) && (mid <= right))
            {
                if (array[left] <= array[mid])
                {
                    temp[tmpPos++] = array[left++];
                }
                else
                {
                    temp[tmpPos++] = array[mid++];
                }
            }

            //placing remaining elements in temp from left sorted array
            while (left <= leftEnd)
            {
                temp[tmpPos++] = array[left++];
            }

            //placing remaining elements in temp from right sorted array
            while (mid <= right)
            {
                temp[tmpPos++] = array[mid++];
            }

            //placing temp array to input
            for (i = 0; i < lengthOfInput; i++)
            {
                array[right] = temp[right];
                right--;
            }
        }
    }

    public class QuickSorter
    {
        public QuickSorter() { }

        ///<summary>Sorts integers in ascending order
        ///</summary>
        ///<returns>Sorted array</returns>
        public int[] Sort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            return QuickSort(array, 0, array.Length - 1);
        }

        private int Partition(int[] array, int startIndex, int endIndex)
        {
            int temp;

            //divides left and right subarrays
            int marker = startIndex;

            for (int i = startIndex; i <= endIndex; i++)
            {
                //swap elements if array[endIndex] is pivot
                if (array[i] < array[endIndex])
                {
                    temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }

            //put array[endIndex] between left and right subarrays
            temp = array[marker];
            array[marker] = array[endIndex];
            array[endIndex] = temp;

            return marker;
        }

        private int[] QuickSort(int[] array, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return array;
            }

            int pivot = Partition(array, startIndex, endIndex);
            QuickSort(array, startIndex, pivot - 1);
            QuickSort(array, pivot + 1, endIndex);

            return array;
        }
    }
}
