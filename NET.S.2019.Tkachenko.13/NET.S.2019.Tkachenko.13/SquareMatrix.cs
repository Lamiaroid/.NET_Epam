using System;

namespace NET.S._2019.Tkachenko._13
{
    public class SquareMatrix<T> : Matrix<T>
    {
        public SquareMatrix(params T[] elements)
        {
            double squareMatrixSide = Math.Sqrt(elements.Length);

            if (squareMatrixSide - Math.Floor(squareMatrixSide) == 0)
            {
                SideLength = (int)squareMatrixSide;
                Length = elements.Length;

                matrix = new T[SideLength, SideLength];

                for (int i = 0; i < SideLength; i++)
                {
                    for (int j = 0; j < SideLength; j++)
                    {
                        matrix[i, j] = elements[i * SideLength + j];
                    }
                }
            }
            else
            {
                throw new ArgumentException("Unable to create square matrix with given amount of elements.");
            }
        }

        /// <summary>
        /// Addition of 2 matrices
        /// </summary>
        /// <param name="matrixA">Square matrix</param>
        /// <param name="matrixB">Any other matrix</param>
        /// <returns>Square matrix</returns>
        public static SquareMatrix<T> operator +(SquareMatrix<T> matrixA, Matrix<T> matrixB)
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