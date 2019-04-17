namespace NET.S._2019.Tkachenko._10
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class JaggedArrayOperations
    {
        public JaggedArrayOperations(int[][] jaggedArray)
        {
            this.JaggedArray = jaggedArray;
        }

        public int[][] JaggedArray
        {
            get;
            private set;
        }

        /// <summary>
        /// Sorts jagged array rows with the help of the given comparator
        /// </summary>
        /// <param name="comparingLogic">Comparison logic comparator</param>
        /// <returns>Jagged array with sorted rows</returns>
        public int[][] SortWithTheHelpOfComparator(IComparer<int[]> comparingLogic)
        {
            this.ArrayArgumentsValidation(this.JaggedArray);

            Array.Sort(this.JaggedArray, comparingLogic);
            return this.JaggedArray;
        }

        // Implementation of multidimensional array arguments validation
        private void ArrayArgumentsValidation(int[][] jaggedArray)
        {
            if (jaggedArray == null)
            {
                throw new ArgumentNullException("Array can't be equal to null");
            }

            int counter = 0;
            foreach (int[] row in jaggedArray)
            {
                if (row == null)
                {
                    throw new ArgumentNullException("Rows can't be equal to null");
                }

                if (row.Length == 0)
                {
                    throw new ArgumentException("Rows can't be empty");
                }

                counter++;
            }

            if (counter == 0)
            {
                throw new ArgumentException("Array can't be empty");
            }
        }

        // Ascending order comparators
        public static class AscendingOrder
        {
            public class ElementsSumInRowsComparator : IComparer<int[]>
            {
                public int Compare(int[] jaggedArrayPart1, int[] jaggedArrayPart2)
                {
                    if (jaggedArrayPart1.Sum() > jaggedArrayPart2.Sum())
                    {
                        return 1;
                    }
                    else
                        if (jaggedArrayPart1.Sum() < jaggedArrayPart2.Sum())
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            public class MinElementsInRowsComparator : IComparer<int[]>
            {
                public int Compare(int[] jaggedArrayPart1, int[] jaggedArrayPart2)
                {
                    if (jaggedArrayPart1.Min() > jaggedArrayPart2.Min())
                    {
                        return 1;
                    }
                    else
                        if (jaggedArrayPart1.Min() < jaggedArrayPart2.Min())
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            public class MaxElementsInRowsComparator : IComparer<int[]>
            {
                public int Compare(int[] jaggedArrayPart1, int[] jaggedArrayPart2)
                {
                    if (jaggedArrayPart1.Max() > jaggedArrayPart2.Max())
                    {
                        return 1;
                    }
                    else
                        if (jaggedArrayPart1.Max() < jaggedArrayPart2.Max())
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        // Descending order comparators
        public static class DescendingOrder
        {
            public class ElementsSumInRowsComparator : IComparer<int[]>
            {
                public int Compare(int[] jaggedArrayPart1, int[] jaggedArrayPart2)
                {
                    if (jaggedArrayPart1.Sum() < jaggedArrayPart2.Sum())
                    {
                        return 1;
                    }
                    else
                        if (jaggedArrayPart1.Sum() > jaggedArrayPart2.Sum())
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            public class MinElementsInRowsComparator : IComparer<int[]>
            {
                public int Compare(int[] jaggedArrayPart1, int[] jaggedArrayPart2)
                {
                    if (jaggedArrayPart1.Min() < jaggedArrayPart2.Min())
                    {
                        return 1;
                    }
                    else
                        if (jaggedArrayPart1.Min() > jaggedArrayPart2.Min())
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            public class MaxElementsInRowsComparator : IComparer<int[]>
            {
                public int Compare(int[] jaggedArrayPart1, int[] jaggedArrayPart2)
                {
                    if (jaggedArrayPart1.Max() < jaggedArrayPart2.Max())
                    {
                        return 1;
                    }
                    else
                        if (jaggedArrayPart1.Max() > jaggedArrayPart2.Max())
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }
}