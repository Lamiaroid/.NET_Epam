using System;
using NUnit.Framework;

namespace NET.S._2019.Tkachenko._11
{
    [TestFixture]
    class Tests
    {
        #region BinarySearchTests
        [TestCase]
        public void BinarySearchTest1()
        {
            BinarySearch bs = new BinarySearch();
            int[] test = new int[] { 1, 2, 3, 19, -333, -11, 0, int.MinValue, 127, 22, 1100, int.MaxValue };
            TestComparerInt comparer = new TestComparerInt();

            int expected = 8;
            int actual = bs.Find(test, 127, comparer);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTest2()
        {
            BinarySearch bs = new BinarySearch();
            double[] test = new double[] { 1.773, 2.0, 19.23, 19, -333.333, -11, 0.7, 0, 9.7, 100.7, 123.567, 0, int.MinValue, 127, 22, 11.001, int.MaxValue, 118.54 };
            TestComparerDouble comparer = new TestComparerDouble();

            int expected = 10;
            int actual = bs.Find(test, 123.567, comparer);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTest3()
        {
            BinarySearch bs = new BinarySearch();
            double[] test = new double[] { 1.773, 2.0, 19.23, 19, -333.333, -11, 0.7, 0, 9.7, 100.7, 123.567, 0, int.MinValue, 127, 22, 11.001, int.MaxValue, 118.54 };
            TestComparerDouble comparer = new TestComparerDouble();

            int expected = -1;
            int actual = bs.Find(test, 123.5678, comparer);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTest4()
        {
            BinarySearch bs = new BinarySearch();
            string[] test = new string[] { "", "asdasdg", "Oh, Mama!", "sunshine", "Tree is me", "Escanor", "-1", "", "aaa", "AAA" };
            TestComparerString comparer = new TestComparerString();

            int expected = 4;
            int actual = bs.Find(test, "Tree is me", comparer);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTest5()
        {
            BinarySearch bs = new BinarySearch();
            string[] test = new string[] { "aaa" };
            TestComparerString comparer = new TestComparerString();

            int expected = 0;
            int actual = bs.Find(test, "aaa", comparer);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchEmptyArrayTest()
        {
            BinarySearch bs = new BinarySearch();
            string[] test = new string[] { };
            TestComparerString comparer = new TestComparerString();

            Assert.Throws<ArgumentException>(() => bs.Find(test, "mama", comparer), "Array can't be empty.");
        }

        [TestCase]
        public void BinarySearchNullArrayTest()
        {
            BinarySearch bs = new BinarySearch();
            string[] test = null;
            TestComparerString comparer = new TestComparerString();

            Assert.Throws<ArgumentNullException>(() => bs.Find(test, "mama", comparer), "Array can't be null.");
        }

        [TestCase]
        public void BinarySearchNullElementTest()
        {
            BinarySearch bs = new BinarySearch();
            string[] test = new string[] { "aaa", null, "AAA" };
            TestComparerString comparer = new TestComparerString();

            Assert.Throws<ArgumentNullException>(() => bs.Find(test, "AAA", comparer), "Array can't have null elements.");
        }

        [TestCase]
        public void BinarySearchNullComparerTest()
        {
            BinarySearch bs = new BinarySearch();
            string[] test = new string[] { "aaa", "Extra", "AAA" };
            TestComparerString comparer = null;

            Assert.Throws<ArgumentNullException>(() => bs.Find(test, "AAA", comparer), "Comparer can't be null.");
        }

        [TestCase]
        public void BinarySearchElementToSearchForNullTest()
        {
            BinarySearch bs = new BinarySearch();
            string[] test = new string[] { "aaa", "Extra", "AAA" };
            TestComparerString comparer = new TestComparerString();

            Assert.Throws<ArgumentNullException>(() => bs.Find(test, null, comparer), "Element to search for can't be null.");
        }
        #endregion
        #region FibonacciTests
        [TestCase]
        public void FibonacciSequenceTest1()
        {
            FibonacciSequence fs = new FibonacciSequence();

            int[] expected = new int[] { 1, 1, 2, 3 };
            int[] actual = fs.GetNumbersOfSequence(4);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void FibonacciSequenceTest2()
        {
            FibonacciSequence fs = new FibonacciSequence();

            int[] expected = new int[] { 1 };
            int[] actual = fs.GetNumbersOfSequence(1);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void FibonacciSequenceTest3()
        {
            FibonacciSequence fs = new FibonacciSequence();

            int[] expected = new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987 };
            int[] actual = fs.GetNumbersOfSequence(16);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void FibonacciSequenceNegativeNumberTest()
        {
            FibonacciSequence fs = new FibonacciSequence();

            Assert.Throws<ArgumentException>(() => fs.GetNumbersOfSequence(-1), "The sequence number cant't be less or equal to 0");
        }

        [TestCase]
        public void FibonacciSequenceOverflowTest()
        {
            FibonacciSequence fs = new FibonacciSequence();

            Assert.Throws<OverflowException>(() => fs.GetNumbersOfSequence(1000), "Seems like one of numbers of your sequence is too big.");
        }
        #endregion
    }
}