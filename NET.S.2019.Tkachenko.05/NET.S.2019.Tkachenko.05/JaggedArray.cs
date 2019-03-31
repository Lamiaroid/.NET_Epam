using System;

namespace NET.S._2019.Tkachenko._05
{
    public class JaggedArray
    {
        private int[][] _jaggedArray;

        public JaggedArray(int[][] jaggedArray)
        {
            _jaggedArray = jaggedArray;
        }

        /// <summary>
        /// Implementation of sorting of rows (multidimensional array) by sum of elements in row
        /// </summary>
        /// <param name="ascendingOrder">Turns on/off sort in increasing order</param>
        public int[][] SortRowsByElementsSumInRows(bool ascendingOrder)
        {
            ArrayArgumentsValidation(_jaggedArray);

            int rowsCount = GetJaggedArrayRowsCount(_jaggedArray);       
            int[] rowsSums = new int[rowsCount];

            int counter = 0;
            foreach (int[] row in _jaggedArray)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    try
                    {
                        rowsSums[counter] = checked(rowsSums[counter] + row[i]);
                    }
                    catch (OverflowException exception)
                    {
                        throw new OverflowException();
                    }
                }
                counter++;
            }

            return Sort(_jaggedArray, rowsSums, ascendingOrder);       
        }

        /// <summary>
        /// Implementation of sorting of rows (multidimensional array) by minimum elements in row
        /// </summary>
        /// <param name="ascendingOrder">Turns on/off sort in increasing order</param>
        public int[][] SortRowsByMinElementsInRows(bool ascendingOrder)
        {
            ArrayArgumentsValidation(_jaggedArray);

            int rowsCount = GetJaggedArrayRowsCount(_jaggedArray);
            int[] rowsMinElements = new int[rowsCount];

            int counter = 0;
            foreach (int[] row in _jaggedArray)
            {
                rowsMinElements[counter] = row[0];
                for (int i = 1; i < row.Length; i++)
                {
                    if (row[i] < rowsMinElements[counter])
                    {
                        rowsMinElements[counter] = row[i];
                    }
                }
                counter++;
            }

            return Sort(_jaggedArray, rowsMinElements, ascendingOrder);
        }

        /// <summary>
        /// Implementation of sorting of rows (multidimensional array) by maximum elements in row
        /// </summary>
        /// <param name="ascendingOrder">Turns on/off sort in increasing order</param>
        public int[][] SortRowsByMaxElementsInRows(bool ascendingOrder)
        {
            ArrayArgumentsValidation(_jaggedArray);

            int rowsCount = GetJaggedArrayRowsCount(_jaggedArray);
            int[] rowsMinElements = new int[rowsCount];

            int counter = 0;
            foreach (int[] row in _jaggedArray)
            {
                rowsMinElements[counter] = row[0];
                for (int i = 1; i < row.Length; i++)
                {
                    if (row[i] > rowsMinElements[counter])
                    {
                        rowsMinElements[counter] = row[i];
                    }
                }
                counter++;
            }

            return Sort(_jaggedArray, rowsMinElements, ascendingOrder);
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

        // Implementation of sorting multidimensional array rows in ascending/descending order with the help of provided array of rows' properties (bubble sort)
        private int[][] Sort(int[][] arrayForSort, int[] helpingParams, bool ascendingOrder)
        {
            if (ascendingOrder)
            {
                for (int i = 0; i < helpingParams.Length - 1; i++)
                {
                    for (int j = 0; j < helpingParams.Length - i - 1; j++)
                    {
                        if (helpingParams[j] > helpingParams[j + 1])
                        {
                            Swap(ref arrayForSort[j], ref arrayForSort[j + 1]);
                            Swap(ref helpingParams[j], ref helpingParams[j + 1]);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < helpingParams.Length - 1; i++)
                {
                    for (int j = 0; j < helpingParams.Length - i - 1; j++)
                    {
                        if (helpingParams[j] < helpingParams[j + 1])
                        {
                            Swap(ref arrayForSort[j], ref arrayForSort[j + 1]);
                            Swap(ref helpingParams[j], ref helpingParams[j + 1]);
                        }
                    }
                }
            }

            return arrayForSort;
        }

        // Implementation of receiving multidimensional array rows count
        private int GetJaggedArrayRowsCount(int[][] jaggedArray)
        {
            int count = 0;
            foreach (int[] row in jaggedArray)
            {
                count++;
            }

            return count;
        }

        // Implementation of common swap for arrays
        private void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }

        // Implementation of common swap for integers
        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
