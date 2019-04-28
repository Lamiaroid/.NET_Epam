using System;
using System.Collections;
using System.Collections.Generic;

namespace NET.S._2019.Tkachenko._13
{
    public class Queue<T>
    {
        private T[] queue;
             
        public T FirstElement
        {
            get;
            private set;
        }

        public T LastElement
        {
            get;
            private set;
        }

        public int Size
        {
            get;
            private set;
        }

        public bool IsEmpty
        {
            get;
            private set;
        }       

        public Queue(params T[] elements)
        {
            queue = elements;
            ChangeQueueData();
        }

        /// <summary>
        /// Adds element to the tail of queue
        /// </summary>
        /// <param name="element">Element to add</param>
        public void Insert(T element)
        {
            if (Size < int.MaxValue)
            {
                Array.Resize(ref queue, queue.Length + 1);
                queue[queue.Length - 1] = element;
                ChangeQueueData();
            }
        }

        /// <summary>
        /// Returns element from the head of queue
        /// </summary>
        /// <returns>The last element</returns>
        public T Remove()
        {
            if (Size > 0)
            {
                T element = queue[queue.Length - 1];
                Array.Resize(ref queue, queue.Length - 1);
                ChangeQueueData();
                return element;
            }

            return default(T);
        }

        /// <summary>
        /// Makes queue empty 
        /// </summary>
        public void Clear()
        {
            queue = new T[0];
            ChangeQueueData();
        }

        public IEnumerator<T> GetEnumerator() => new QueueEnumerator<T>(queue);

        // Changes current queue data
        private void ChangeQueueData()
        {
            Size = queue.Length;

            if (Size != 0)
            {
                IsEmpty = false;
                FirstElement = queue[0];
                LastElement = queue[queue.Length - 1];
            }
            else
            {
                IsEmpty = true;
                FirstElement = default(T);
                LastElement = default(T);
            }    
        }
    }

    public class QueueEnumerator<T> : IEnumerator<T>
    {
        private T[] elements;
        private int position = -1;

        public QueueEnumerator(T[] elements)
        {
            this.elements = elements;
        }

        public T Current
        {
            get
            {
                if (position == -1 || position >= elements.Length)
                {
                    throw new InvalidOperationException();
                }

                return elements[position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (position < elements.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose() { }
    }
}