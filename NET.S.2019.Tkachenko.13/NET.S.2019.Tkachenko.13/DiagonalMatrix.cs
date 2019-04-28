namespace NET.S._2019.Tkachenko._13
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        public DiagonalMatrix(params T[] elements)
        {
            SideLength = elements.Length;
            Length = elements.Length * elements.Length;
            
            matrix = new T[elements.Length, elements.Length];

            int counter = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = 0; j < elements.Length; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = elements[counter++];
                    }
                    else
                    {
                        matrix[i, j] = default(T);
                    }
                }
            }
        }

        /// <summary>
        /// Addition of 2 matrices
        /// </summary>
        /// <param name="matrixA">Diagonal matrix</param>
        /// <param name="matrixB">Any other matrix</param>
        /// <returns>Square matrix</returns>
        public static SquareMatrix<T> operator +(DiagonalMatrix<T> matrixA, Matrix<T> matrixB)
        {
            T[] newData = new T[matrixA.Length];

            int counter = 0;
            for (int i = 0; i < matrixA.SideLength; i++)
            {
                for (int j = 0; j < matrixA.SideLength; j++)
                {
                    newData[counter] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                    counter++;
                }
            }

            return new SquareMatrix<T>(newData);
        }
    }
}