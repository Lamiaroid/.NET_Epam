using System.Collections.Generic;

namespace NET.S._2019.Tkachenko._13
{
    public class BinarySearchTree<T> : IComparer<string>, IComparer<int>, IComparer<Book>
    {
        public BinarySearchTree<T> Left
        {
            get;
            private set;
        }

        public BinarySearchTree<T> Right
        {
            get;
            private set;
        }

        public T Value
        {
            get;
            private set;
        }

        public BinarySearchTree(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        /// <summary>
        /// Inserts new element in the binary search tree
        /// </summary>
        /// <param name="value">Element to insert</param>
        public void Insert(T value)
        {
            if (Compare((dynamic)Value, (dynamic)value) > 0)
            {
                if (Left == null)
                {
                    Left = new BinarySearchTree<T>(value);
                }
                else
                {
                    Left.Insert(value);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new BinarySearchTree<T>(value);
                }
                else
                {
                    Right.Insert(value);
                }
            }
        }

        /// <summary>
        /// Inserts new element in the binary search tree with the help of compararer
        /// </summary>
        /// <param name="value">Element to insert</param>
        /// <param name="comparer">Comparer</param>
        public void Insert(T value, IComparer<T> comparer)
        {
            if (comparer.Compare(Value, value) > 0)
            {
                if (Left == null)
                {
                    Left = new BinarySearchTree<T>(value);
                }
                else
                {
                    Left.Insert(value, comparer);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new BinarySearchTree<T>(value);
                }
                else
                {
                    Right.Insert(value, comparer);
                }
            }
        }

        /// <summary>
        /// Comparison of 2 strings
        /// </summary>
        public int Compare(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return 1;
            }
            else if (a.Length < b.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Comparison of 2 integers
        /// </summary>
        public int Compare(int a, int b)
        {
            if (a > b)
            {
                return 1;
            }
            else if (a < b)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Comparison of 2 Books
        /// </summary>
        public int Compare(Book a, Book b)
        {
            if (a.Pages > b.Pages)
            {
                return 1;
            }
            else if (a.Pages < b.Pages)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Makes preorder bypass
        /// </summary>
        /// <returns>Sequence from bypass</returns>
        public IEnumerable<T> PreOrderBypass()
        {
            foreach (T value in PreOrder(this))
            {
                yield return value;
            }
        }

        /// <summary>
        /// Makes inorder bypass
        /// </summary>
        /// <returns>Sequence from bypass</returns>
        public IEnumerable<T> InOrderBypass()
        {
            foreach (T value in InOrder(this))
            {
                yield return value;
            }
        }

        /// <summary>
        /// Makes postorder bypass
        /// </summary>
        /// <returns>Sequence from bypass</returns>
        public IEnumerable<T> PostOrderBypass()
        {
            foreach (T value in PostOrder(this))
            {
                yield return value;
            }
        }

        // Helping func for preorder bypass
        private IEnumerable<T> PreOrder(BinarySearchTree<T> node)
        {
            if (node != null)
            {
                yield return node.Value;

                foreach (T value in PreOrder(node.Left))
                {
                    yield return value;
                }

                foreach (T value in PreOrder(node.Right))
                {
                    yield return value;
                }
            }
        }

        // Helping func for inorder bypass
        private IEnumerable<T> InOrder(BinarySearchTree<T> node)
        {
            if (node != null)
            {
                foreach (T value in InOrder(node.Left))
                {
                    yield return value;
                }

                yield return node.Value;

                foreach (T value in InOrder(node.Right))
                {
                    yield return value;
                }
            }
        }

        // Helping func for postorder bypass
        private IEnumerable<T> PostOrder(BinarySearchTree<T> node)
        {
            if (node != null)
            {
                foreach (T value in PostOrder(node.Left))
                {
                    yield return value;
                }

                foreach (T value in PostOrder(node.Right))
                {
                    yield return value;
                }

                yield return node.Value;
            }
        }
    }
}