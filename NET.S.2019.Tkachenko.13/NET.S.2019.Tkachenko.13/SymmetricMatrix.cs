using System;

namespace NET.S._2019.Tkachenko._13
{
    public class SymmetricMatrix<T> : Matrix<T>
    {
        public SymmetricMatrix(params T[] elements)
        {
            bool matrixFound = false;
            int suggestedNumberOfDiagonalElements = 1;
            while (elements.Length - suggestedNumberOfDiagonalElements > 0 && !matrixFound)
            {
                int elementsInMatrix = 2 * elements.Length - suggestedNumberOfDiagonalElements;
                double squareMatrixSide = Math.Sqrt(elementsInMatrix);

                if (squareMatrixSide - Math.Floor(squareMatrixSide) == 0 && squareMatrixSide == suggestedNumberOfDiagonalElements)
                {
                    SideLength = (int)squareMatrixSide;
                    Length = SideLength * SideLength;

                    matrix = new T[SideLength, SideLength];

                    int counter = 0;
                    for (int i = 0; i < SideLength; i++)
                    {
                        for (int j = i; j < SideLength; j++)
                        {
                            matrix[i, j] = elements[counter++];
                        }
                    }

                    counter = 0;
                    for (int i = 0; i < SideLength; i++)
                    {
                        for (int j = i; j < SideLength; j++)
                        {
                            matrix[j, i] = elements[counter++];
                        }
                    }

                    matrixFound = true;
                }

                suggestedNumberOfDiagonalElements++;
            }
            
            if (!matrixFound)
            {
                throw new ArgumentException("Unable to create symmetric matrix with given amount of elements.");
            }
        }

        /// <summary>
        /// Addition of 2 matrices
        /// </summary>
        /// <param name="matrixA">Symmetric matrix</param>
        /// <param name="matrixB">Any other Matrix</param>
        /// <returns>Square matrix</returns>
        public static SquareMatrix<T> operator +(SymmetricMatrix<T> matrixA, Matrix<T> matrixB)
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