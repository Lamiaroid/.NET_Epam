using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NET.S._2019.Tkachenko._13
{
    [TestFixture]
    class Tests
    {
        #region QueueTests
        [TestCase]
        public void QueueTest1()
        {
            Queue<int> queue = new Queue<int>(1, 3, 4, 7, 9);
            queue.Insert(5);
            queue.Insert(11);

            int[] expected = new int[] { 1, 11, 7 };
            int[] actual = new int[] { queue.FirstElement, queue.LastElement, queue.Size };

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void QueueTest2()
        {
            Queue<int> queue = new Queue<int>();
            queue.Insert(138);

            int[] expected = new int[] { 138, 138, 1 };
            int[] actual = new int[] { queue.FirstElement, queue.LastElement, queue.Size };

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void QueueTest3()
        {
            Queue<int> queue = new Queue<int>(1, 2);
            queue.Remove();
            queue.Remove();

            int[] expected = new int[] { 0, 0, 0 };
            int[] actual = new int[] { queue.FirstElement, queue.LastElement, queue.Size };

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void QueueTest4()
        {
            Queue<int> queue = new Queue<int>(1, 2, 3);
            queue.Remove();

            int expected = 2;
            int actual = queue.Remove();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void QueueTest5()
        {
            Queue<int> queue = new Queue<int>(1, 2, 3, 4, 5);
            queue.Clear();

            int[] expected = new int[] { 0, 0, 0 };
            int[] actual = new int[] { queue.FirstElement, queue.LastElement, queue.Size }; ;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void QueueTest6()
        {
            Queue<int> queue = new Queue<int>();
            queue.Remove();
            queue.Remove();

            int[] expected = new int[] { 0, 0, 0 };
            int[] actual = new int[] { queue.FirstElement, queue.LastElement, queue.Size };

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void QueueTest7()
        {
            Queue<int> queue = new Queue<int>();
            queue.Clear();

            int[] expected = new int[] { 0, 0, 0 };
            int[] actual = new int[] { queue.FirstElement, queue.LastElement, queue.Size };

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void QueueTest8()
        {
            Queue<int> queue = new Queue<int>(51, 42, 66, 77, 19);
            queue.Remove();
            queue.Insert(111);

            int[] expected = new int[] { 51, 111, 5 };
            int[] actual = new int[] { queue.FirstElement, queue.LastElement, queue.Size };

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void QueueTest9()
        {
            Queue<string> queue = new Queue<string>("mom", "dad", "66", "lol", "here");
            queue.Remove();
            queue.Insert("tree");
            queue.Insert("ok");

            string[] expected = new string[] { "mom", "ok" };
            string[] actual = new string[] { queue.FirstElement, queue.LastElement };

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void QueueTest10()
        {
            Queue<string> queue = new Queue<string>("mom", "dad", "66", "lol", "here");
            queue.Remove();
            queue.Insert("tree");
            queue.Insert("ok");

            int expected = 6;
            int actual = queue.Size;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void QueueTest11()
        {
            Queue<string> queue = new Queue<string>("mom", "dad");
            queue.Remove();
            queue.Remove();

            string[] expected = new string[] { null, null };
            string[] actual = new string[] { queue.FirstElement, queue.LastElement };

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void QueueTest12()
        {
            Queue<string> queue = new Queue<string>("mom", "dad");
            queue.Remove();
            queue.Remove();

            int expected = 0;
            int actual = queue.Size;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void QueueTest13()
        {
            Queue<string> queue = new Queue<string>("mom", "dad");

            string expected = "dad";
            string actual = queue.Remove();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void QueueTest14()
        {
            Queue<string> queue = new Queue<string>("mom", "dad", "fun");

            string[] queueElements = new string[queue.Size];
            int counter = 0;
            foreach (var element in queue)
            {
                queueElements[counter] = element;
                counter++;                  
            }

            string[] expected = new string[] { "mom", "dad", "fun" };
            string[] actual = queueElements;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void QueueTest15()
        {
            Queue<string> queue = new Queue<string>("mom", "dad", "fun");
            queue.Remove();
            queue.Remove();
            queue.Insert("stone");

            string[] queueElements = new string[queue.Size];
            int counter = 0;
            foreach (var element in queue)
            {
                queueElements[counter] = element;
                counter++;
            }

            string[] expected = new string[] { "mom", "stone" };
            string[] actual = queueElements;

            Assert.AreEqual(expected, actual);
        }
        #endregion
        #region MatrixTests
        [TestCase]
        public void CreatingSquareMatrixSuccess()
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(1, 2, 3, 4, 5, 6, 7, 8, 9);

            int[,] expected = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            int[,] actual = squareMatrix.ReceiveMatrix();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void CreatingSquareMatrixFail()
        {
            Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(1, 2, 3, 4, 5, 6, 7), "Unable to create square matrix with given amount of elements.");
        }

        [TestCase]
        public void CreatingSymmetricMatrixSuccess()
        {
            SymmetricMatrix<int> symmetricMatrix = new SymmetricMatrix<int>(1, 2, 3, 4, 5, 6);

            int[,] expected = new int[,]
            {
                { 1, 2, 3 },
                { 2, 4, 5 },
                { 3, 5, 6 }
            };
            int[,] actual = symmetricMatrix.ReceiveMatrix();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void CreatingSymmetricMatrixFail()
        {
            Assert.Throws<ArgumentException>(() => new SymmetricMatrix<int>(1, 2, 3, 4, 5, 6, 7), "Unable to create symmetric matrix with given amount of elements.");
        }

        [TestCase]
        public void CreatingDiagonalMatrixSuccess()
        {
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(1, 2, 3);

            int[,] expected = new int[,]
            {
                { 1, 0, 0 },
                { 0, 2, 0 },
                { 0, 0, 3 }
            };
            int[,] actual = diagonalMatrix.ReceiveMatrix();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MatrixAdditionTest1()
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(1, 2, 3, 4);
            SymmetricMatrix<int> symmetricMatrix = new SymmetricMatrix<int>(1, 2, 3);

            int[,] expected = new int[,]
            {
                { 2, 4 },
                { 5, 7 }
            };
            int[,] actual = (squareMatrix + symmetricMatrix).ReceiveMatrix();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MatrixAdditionTest2()
        {
            SquareMatrix<int> squareMatrix1 = new SquareMatrix<int>(1, 2, 3, 4);
            SquareMatrix<int> squareMatrix2 = new SquareMatrix<int>(1, 2, 3, 4);

            int[,] expected = new int[,]
            {
                { 2, 4 },
                { 6, 8 }
            };
            int[,] actual = (squareMatrix1 + squareMatrix2).ReceiveMatrix();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MatrixAdditionTest3()
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(1, 2, 3, 4);
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(1, 2);

            int[,] expected = new int[,]
            {
                { 2, 2 },
                { 3, 6 }
            };
            int[,] actual = (squareMatrix + diagonalMatrix).ReceiveMatrix();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MatrixAdditionTest4()
        {
            SymmetricMatrix<int> symmetricMatrix = new SymmetricMatrix<int>(1, 2, 3);
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(1, 2, 3, 4);

            int[,] expected = new int[,]
            {
                { 2, 4 },
                { 5, 7 }
            };
            int[,] actual = (symmetricMatrix + squareMatrix).ReceiveMatrix();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MatrixAdditionTest5()
        {
            SymmetricMatrix<int> symmetricMatrix1 = new SymmetricMatrix<int>(1, 2, 3);
            SymmetricMatrix<int> symmetricMatrix2 = new SymmetricMatrix<int>(1, 2, 3);

            int[,] expected = new int[,]
            {
                { 2, 4 },
                { 4, 6 }
            };
            int[,] actual = (symmetricMatrix1 + symmetricMatrix2).ReceiveMatrix();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MatrixAdditionTest6()
        {
            SymmetricMatrix<int> symmetricMatrix = new SymmetricMatrix<int>(1, 2, 3);
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(1, 2);

            int[,] expected = new int[,]
            {
                { 2, 2 },
                { 2, 5 }
            };
            int[,] actual = (symmetricMatrix + diagonalMatrix).ReceiveMatrix();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MatrixAdditionTest7()
        {
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(1, 2);
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(1, 2, 3, 4);

            int[,] expected = new int[,]
            {
                { 2, 2 },
                { 3, 6 }
            };
            int[,] actual = (diagonalMatrix + squareMatrix).ReceiveMatrix();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MatrixAdditionTest8()
        {
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(1, 2);
            SymmetricMatrix<int> symmetricMatrix = new SymmetricMatrix<int>(1, 2, 3);

            int[,] expected = new int[,]
            {
                { 2, 2 },
                { 2, 5 }
            };
            int[,] actual = (diagonalMatrix + symmetricMatrix).ReceiveMatrix();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MatrixAdditionTest9()
        {
            DiagonalMatrix<int> diagonalMatrix1 = new DiagonalMatrix<int>(1, 2);
            DiagonalMatrix<int> diagonalMatrix2 = new DiagonalMatrix<int>(1, 2);

            int[,] expected = new int[,]
            {
                { 2, 0 },
                { 0, 4 }
            };
            int[,] actual = (diagonalMatrix1 + diagonalMatrix2).ReceiveMatrix();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MatrixAdditionTest10()
        {
            SymmetricMatrix<int> symmetricMatrix = new SymmetricMatrix<int>(1, 2, 3, 4, 5, 6);
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(1, 2, 3, 4, 5, 6, 7, 8, 9);
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(1, 2, 3);

            int[,] expected = new int[,]
            {
                { 3, 4, 6 },
                { 6, 11, 11 },
                { 10, 13, 18 }
            };
            int[,] actual = (symmetricMatrix + squareMatrix + diagonalMatrix).ReceiveMatrix();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void MatrixAdditionTest11()
        {
            SymmetricMatrix<string> symmetricMatrix = new SymmetricMatrix<string>("1", "2", "3", "4", "5", "6");
            SquareMatrix<string> squareMatrix = new SquareMatrix<string>("1", "2", "3", "4", "5", "6", "7", "8", "9");
            DiagonalMatrix<string> diagonalMatrix = new DiagonalMatrix<string>("1", "2", "3");

            string[,] expected = new string[,]
            {
                { "111", "22", "33" },
                { "24", "452", "56" },
                { "37", "58", "693" }
            };
            string[,] actual = (symmetricMatrix + squareMatrix + diagonalMatrix).ReceiveMatrix();

            Assert.AreEqual(expected, actual);
        }
        #endregion
        #region BinarySearchTreeTests
        #region Int32Tests
        [TestCase]
        public void BinarySearchTreeInt32EquivalencePreOrderBypassTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>(8);
            bst.Insert(3);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(4);
            bst.Insert(7);
            bst.Insert(10);
            bst.Insert(14);
            bst.Insert(13);

            IEnumerable<int> expected = new int[] { 8, 3, 1, 6, 4, 7, 10, 14, 13 };
            IEnumerable<int> actual = bst.PreOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeInt32ComparerPreOrderBypassTest()
        {
            Int32Comparer comparer = new Int32Comparer();
            BinarySearchTree<int> bst = new BinarySearchTree<int>(8);
            bst.Insert(3, comparer);
            bst.Insert(1, comparer);
            bst.Insert(6, comparer);
            bst.Insert(4, comparer);
            bst.Insert(7, comparer);
            bst.Insert(10, comparer);
            bst.Insert(14, comparer);
            bst.Insert(13, comparer);

            IEnumerable<int> expected = new int[] { 8, 3, 1, 6, 4, 7, 10, 14, 13 };
            IEnumerable<int> actual = bst.PreOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeInt32EquivalenceInOrderBypassTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>(8);
            bst.Insert(3);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(4);
            bst.Insert(7);
            bst.Insert(10);
            bst.Insert(14);
            bst.Insert(13);

            IEnumerable<int> expected = new int[] { 1, 3, 4, 6, 7, 8, 10, 13, 14 };
            IEnumerable<int> actual = bst.InOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeInt32ComparerInOrderBypassTest()
        {
            Int32Comparer comparer = new Int32Comparer();
            BinarySearchTree<int> bst = new BinarySearchTree<int>(8);
            bst.Insert(3, comparer);
            bst.Insert(1, comparer);
            bst.Insert(6, comparer);
            bst.Insert(4, comparer);
            bst.Insert(7, comparer);
            bst.Insert(10, comparer);
            bst.Insert(14, comparer);
            bst.Insert(13, comparer);

            IEnumerable<int> expected = new int[] { 1, 3, 4, 6, 7, 8, 10, 13, 14 };
            IEnumerable<int> actual = bst.InOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeInt32EquivalencePostOrderBypassTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>(8);
            bst.Insert(3);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(4);
            bst.Insert(7);
            bst.Insert(10);
            bst.Insert(14);
            bst.Insert(13);

            IEnumerable<int> expected = new int[] { 1, 4, 7, 6, 3, 13, 14, 10, 8 };
            IEnumerable<int> actual = bst.PostOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeInt32ComparerPostOrderBypassTest()
        {
            Int32Comparer comparer = new Int32Comparer();
            BinarySearchTree<int> bst = new BinarySearchTree<int>(8);
            bst.Insert(3, comparer);
            bst.Insert(1, comparer);
            bst.Insert(6, comparer);
            bst.Insert(4, comparer);
            bst.Insert(7, comparer);
            bst.Insert(10, comparer);
            bst.Insert(14, comparer);
            bst.Insert(13, comparer);

            IEnumerable<int> expected = new int[] { 1, 4, 7, 6, 3, 13, 14, 10, 8 };
            IEnumerable<int> actual = bst.PostOrderBypass();

            Assert.AreEqual(expected, actual);
        }
        #endregion
        #region StringTests
        [TestCase]
        public void BinarySearchTreeStringEquivalencePreOrderBypassTest()
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>("abcdefgh");
            bst.Insert("abc");
            bst.Insert("a");
            bst.Insert("abcdef");
            bst.Insert("abcd");
            bst.Insert("abcdefg");
            bst.Insert("abcdefghij");
            bst.Insert("abcdefghijklmn");
            bst.Insert("abcdefghijklm");

            IEnumerable<string> expected = new string[] { "abcdefgh", "abc", "a", "abcdef", "abcd", "abcdefg", "abcdefghij", "abcdefghijklmn", "abcdefghijklm" };
            IEnumerable<string> actual = bst.PreOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeStringComparerPreOrderBypassTest()
        {
            StringComparer comparer = new StringComparer();
            BinarySearchTree<string> bst = new BinarySearchTree<string>("abcdefgh");
            bst.Insert("abc", comparer);
            bst.Insert("a", comparer);
            bst.Insert("abcdef", comparer);
            bst.Insert("abcd", comparer);
            bst.Insert("abcdefg", comparer);
            bst.Insert("abcdefghij", comparer);
            bst.Insert("abcdefghijklmn", comparer);
            bst.Insert("abcdefghijklm", comparer);

            IEnumerable<string> expected = new string[] { "abcdefgh", "abc", "a", "abcdef", "abcd", "abcdefg", "abcdefghij", "abcdefghijklmn", "abcdefghijklm" };
            IEnumerable<string> actual = bst.PreOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeStringEquivalenceInOrderBypassTest()
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>("abcdefgh");
            bst.Insert("abc");
            bst.Insert("a");
            bst.Insert("abcdef");
            bst.Insert("abcd");
            bst.Insert("abcdefg");
            bst.Insert("abcdefghij");
            bst.Insert("abcdefghijklmn");
            bst.Insert("abcdefghijklm");

            IEnumerable<string> expected = new string[] { "a", "abc", "abcd", "abcdef", "abcdefg", "abcdefgh", "abcdefghij", "abcdefghijklm", "abcdefghijklmn" };
            IEnumerable<string> actual = bst.InOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeStringComparerInOrderBypassTest()
        {
            StringComparer comparer = new StringComparer();
            BinarySearchTree<string> bst = new BinarySearchTree<string>("abcdefgh");
            bst.Insert("abc", comparer);
            bst.Insert("a", comparer);
            bst.Insert("abcdef", comparer);
            bst.Insert("abcd", comparer);
            bst.Insert("abcdefg", comparer);
            bst.Insert("abcdefghij", comparer);
            bst.Insert("abcdefghijklmn", comparer);
            bst.Insert("abcdefghijklm", comparer);

            IEnumerable<string> expected = new string[] { "a", "abc", "abcd", "abcdef", "abcdefg", "abcdefgh", "abcdefghij", "abcdefghijklm", "abcdefghijklmn" };
            IEnumerable<string> actual = bst.InOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeStringEquivalencePostOrderBypassTest()
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>("abcdefgh");
            bst.Insert("abc");
            bst.Insert("a");
            bst.Insert("abcdef");
            bst.Insert("abcd");
            bst.Insert("abcdefg");
            bst.Insert("abcdefghij");
            bst.Insert("abcdefghijklmn");
            bst.Insert("abcdefghijklm");

            IEnumerable<string> expected = new string[] { "a", "abcd", "abcdefg", "abcdef", "abc", "abcdefghijklm", "abcdefghijklmn", "abcdefghij", "abcdefgh" };
            IEnumerable<string> actual = bst.PostOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeStringComparerPostOrderBypassTest()
        {
            StringComparer comparer = new StringComparer();
            BinarySearchTree<string> bst = new BinarySearchTree<string>("abcdefgh");
            bst.Insert("abc", comparer);
            bst.Insert("a", comparer);
            bst.Insert("abcdef", comparer);
            bst.Insert("abcd", comparer);
            bst.Insert("abcdefg", comparer);
            bst.Insert("abcdefghij", comparer);
            bst.Insert("abcdefghijklmn", comparer);
            bst.Insert("abcdefghijklm", comparer);

            IEnumerable<string> expected = new string[] { "a", "abcd", "abcdefg", "abcdef", "abc", "abcdefghijklm", "abcdefghijklmn", "abcdefghij", "abcdefgh" };
            IEnumerable<string> actual = bst.PostOrderBypass();

            Assert.AreEqual(expected, actual);
        }
        #endregion
        #region BookTests
        [TestCase]
        public void BinarySearchTreeBookEquivalencePreOrderBypassTest()
        {
            BinarySearchTree<Book> bst = new BinarySearchTree<Book>(new Book(100, "Markelov", "Wonderland", 15, 2015, 8, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 3, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 1, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 6, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 4, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 7, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 10, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 14, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 13, 50.99));

            IEnumerable<Book> expected = new Book[] 
            {
                new Book(100, "Markelov", "Wonderland", 15, 2015, 8, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 3, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 1, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 6, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 4, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 7, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 10, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 14, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 13, 50.99)
            };
            IEnumerable<Book> actual = bst.PreOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeBookComparerPreOrderBypassTest()
        {
            BookComparer comparer = new BookComparer();
            BinarySearchTree<Book> bst = new BinarySearchTree<Book>(new Book(100, "Markelov", "Wonderland", 15, 2015, 8, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 3, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 1, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 6, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 4, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 7, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 10, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 14, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 13, 50.99), comparer);

            IEnumerable<Book> expected = new Book[]
            {
                new Book(100, "Markelov", "Wonderland", 15, 2015, 8, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 3, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 1, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 6, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 4, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 7, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 10, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 14, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 13, 50.99)
            };
            IEnumerable<Book> actual = bst.PreOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeBookEquivalenceInOrderBypassTest()
        {
            BinarySearchTree<Book> bst = new BinarySearchTree<Book>(new Book(100, "Markelov", "Wonderland", 15, 2015, 8, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 3, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 1, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 6, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 4, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 7, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 10, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 14, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 13, 50.99));

            IEnumerable<Book> expected = new Book[]
            {
                new Book(100, "Markelov", "Wonderland", 15, 2015, 1, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 3, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 4, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 6, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 7, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 8, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 10, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 13, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 14, 50.99)
            };
            IEnumerable<Book> actual = bst.InOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeBookComparerInOrderBypassTest()
        {
            BookComparer comparer = new BookComparer();
            BinarySearchTree<Book> bst = new BinarySearchTree<Book>(new Book(100, "Markelov", "Wonderland", 15, 2015, 8, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 3, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 1, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 6, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 4, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 7, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 10, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 14, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 13, 50.99), comparer);

            IEnumerable<Book> expected = new Book[]
            {
                new Book(100, "Markelov", "Wonderland", 15, 2015, 1, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 3, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 4, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 6, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 7, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 8, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 10, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 13, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 14, 50.99)
            };
            IEnumerable<Book> actual = bst.InOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeBookEquivalencePostOrderBypassTest()
        {
            BinarySearchTree<Book> bst = new BinarySearchTree<Book>(new Book(100, "Markelov", "Wonderland", 15, 2015, 8, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 3, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 1, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 6, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 4, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 7, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 10, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 14, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 13, 50.99));

            IEnumerable<Book> expected = new Book[]
            {
                new Book(100, "Markelov", "Wonderland", 15, 2015, 1, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 4, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 7, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 6, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 3, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 13, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 14, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 10, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 8, 50.99)
            };
            IEnumerable<Book> actual = bst.PostOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeBookComparerPostOrderBypassTest()
        {
            BookComparer comparer = new BookComparer();
            BinarySearchTree<Book> bst = new BinarySearchTree<Book>(new Book(100, "Markelov", "Wonderland", 15, 2015, 8, 50.99));
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 3, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 1, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 6, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 4, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 7, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 10, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 14, 50.99), comparer);
            bst.Insert(new Book(100, "Markelov", "Wonderland", 15, 2015, 13, 50.99), comparer);

            IEnumerable<Book> expected = new Book[]
            {
                new Book(100, "Markelov", "Wonderland", 15, 2015, 1, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 4, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 7, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 6, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 3, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 13, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 14, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 10, 50.99),
                new Book(100, "Markelov", "Wonderland", 15, 2015, 8, 50.99)
            };
            IEnumerable<Book> actual = bst.PostOrderBypass();

            Assert.AreEqual(expected, actual);
        }
        #endregion
        #region PointTests
        [TestCase]
        public void BinarySearchTreePointComparerPreOrderBypassTest()
        {
            PointComparer comparer = new PointComparer();
            BinarySearchTree<Point> bst = new BinarySearchTree<Point>(new Point(Math.Sqrt(32), Math.Sqrt(32)));
            bst.Insert(new Point(Math.Sqrt(6), Math.Sqrt(3)), comparer);
            bst.Insert(new Point(0, 1), comparer);
            bst.Insert(new Point(Math.Sqrt(24), Math.Sqrt(12)), comparer);
            bst.Insert(new Point(Math.Sqrt(8), Math.Sqrt(8)), comparer);
            bst.Insert(new Point(Math.Sqrt(38), Math.Sqrt(11)), comparer);
            bst.Insert(new Point(Math.Sqrt(67), Math.Sqrt(33)), comparer);
            bst.Insert(new Point(Math.Sqrt(157), Math.Sqrt(39)), comparer);
            bst.Insert(new Point(Math.Sqrt(150), Math.Sqrt(19)), comparer);

            IEnumerable<Point> expected = new Point[]
            {
                new Point(Math.Sqrt(32), Math.Sqrt(32)),
                new Point(Math.Sqrt(6), Math.Sqrt(3)),
                new Point(0, 1),
                new Point(Math.Sqrt(24), Math.Sqrt(12)),
                new Point(Math.Sqrt(8), Math.Sqrt(8)),              
                new Point(Math.Sqrt(38), Math.Sqrt(11)),                
                new Point(Math.Sqrt(67), Math.Sqrt(33)),
                new Point(Math.Sqrt(157), Math.Sqrt(39)),
                new Point(Math.Sqrt(150), Math.Sqrt(19))                
            };
            IEnumerable<Point> actual = bst.PreOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreePointComparerInOrderBypassTest()
        {
            PointComparer comparer = new PointComparer();
            BinarySearchTree<Point> bst = new BinarySearchTree<Point>(new Point(Math.Sqrt(32), Math.Sqrt(32)));
            bst.Insert(new Point(Math.Sqrt(6), Math.Sqrt(3)), comparer);
            bst.Insert(new Point(0, 1), comparer);
            bst.Insert(new Point(Math.Sqrt(24), Math.Sqrt(12)), comparer);
            bst.Insert(new Point(Math.Sqrt(8), Math.Sqrt(8)), comparer);
            bst.Insert(new Point(Math.Sqrt(38), Math.Sqrt(11)), comparer);
            bst.Insert(new Point(Math.Sqrt(67), Math.Sqrt(33)), comparer);
            bst.Insert(new Point(Math.Sqrt(157), Math.Sqrt(39)), comparer);
            bst.Insert(new Point(Math.Sqrt(150), Math.Sqrt(19)), comparer);

            IEnumerable<Point> expected = new Point[]
            {
                new Point(0, 1),
                new Point(Math.Sqrt(6), Math.Sqrt(3)),
                new Point(Math.Sqrt(8), Math.Sqrt(8)),
                new Point(Math.Sqrt(24), Math.Sqrt(12)),
                new Point(Math.Sqrt(38), Math.Sqrt(11)),
                new Point(Math.Sqrt(32), Math.Sqrt(32)),
                new Point(Math.Sqrt(67), Math.Sqrt(33)),
                new Point(Math.Sqrt(150), Math.Sqrt(19)),
                new Point(Math.Sqrt(157), Math.Sqrt(39))
            };
            IEnumerable<Point> actual = bst.InOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreePointComparerPostOrderBypassTest()
        {
            PointComparer comparer = new PointComparer();
            BinarySearchTree<Point> bst = new BinarySearchTree<Point>(new Point(Math.Sqrt(32), Math.Sqrt(32)));
            bst.Insert(new Point(Math.Sqrt(6), Math.Sqrt(3)), comparer);
            bst.Insert(new Point(0, 1), comparer);
            bst.Insert(new Point(Math.Sqrt(24), Math.Sqrt(12)), comparer);
            bst.Insert(new Point(Math.Sqrt(8), Math.Sqrt(8)), comparer);
            bst.Insert(new Point(Math.Sqrt(38), Math.Sqrt(11)), comparer);
            bst.Insert(new Point(Math.Sqrt(67), Math.Sqrt(33)), comparer);
            bst.Insert(new Point(Math.Sqrt(157), Math.Sqrt(39)), comparer);
            bst.Insert(new Point(Math.Sqrt(150), Math.Sqrt(19)), comparer);

            IEnumerable<Point> expected = new Point[]
            {
                new Point(0, 1),
                new Point(Math.Sqrt(8), Math.Sqrt(8)),               
                new Point(Math.Sqrt(38), Math.Sqrt(11)),
                new Point(Math.Sqrt(24), Math.Sqrt(12)),
                new Point(Math.Sqrt(6), Math.Sqrt(3)),
                new Point(Math.Sqrt(150), Math.Sqrt(19)),
                new Point(Math.Sqrt(157), Math.Sqrt(39)),
                new Point(Math.Sqrt(67), Math.Sqrt(33)),
                new Point(Math.Sqrt(32), Math.Sqrt(32))             
            };
            IEnumerable<Point> actual = bst.PostOrderBypass();

            Assert.AreEqual(expected, actual);
        }
        #endregion
        #endregion
    }
}