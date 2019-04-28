using System;

namespace NET.S._2019.Tkachenko._13
{
    public abstract class Matrix<T>
    {
        protected T[,] matrix;

        public delegate void MatrixEventHandler();

        public event MatrixEventHandler OnElementWasChanged;

        public int SideLength
        {
            get;
            protected set;
        }

        public int Length
        {
            get;
            protected set;
        }

        public T this[int i, int j]
        {
            get
            {
                return matrix[i, j];
            }
            set
            {
                OnElementWasChanged += GetChangingTime;
                matrix[i, j] = value;
            }
        }

        /// <summary>
        /// Returns current matrix
        /// </summary>
        /// <returns>Current matrix</returns>
        public T[,] ReceiveMatrix() => matrix;

        /// <summary>
        /// Invokes all delegates received during changing elements
        /// </summary>
        public void GetTimes()
        {
            OnElementWasChanged?.Invoke();
        }

        // Delegate action
        protected void GetChangingTime()
        {
            Console.WriteLine($"The time one of matrix elements was changed: {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}:{DateTime.Now.Millisecond}");
        }
    }
}