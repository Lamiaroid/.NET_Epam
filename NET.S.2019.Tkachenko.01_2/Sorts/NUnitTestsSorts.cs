using Sorts;
using NUnit.Framework;
using System;

namespace NUnitTestsSorts
{
    [TestFixture]
    class MergeSortTests
    {
        MergeSorter mergeSort = new MergeSorter();

        [TestCase]
        public void Test1()
        {
            int[] testArr = { 8, 9, 7 };
            int[] expectedArr = { 7, 8, 9 };
            Assert.AreEqual(expectedArr, mergeSort.Sort(testArr));
        }

        [TestCase]
        public void Test2()
        {
            int[] testArr = { 0, 0, 0 };
            int[] expectedArr = { 0, 0, 0 };
            Assert.AreEqual(expectedArr, mergeSort.Sort(testArr));
        }

        [TestCase]
        public void Test3()
        {
            int[] testArr = { -1, 11, 0, 2, -1, 0, 0, 19, -55, 55 };
            int[] expectedArr = { -55, -1, -1, 0, 0, 0, 2, 11, 19, 55 };
            Assert.AreEqual(expectedArr, mergeSort.Sort(testArr));
        }

        [TestCase]
        public void Test4()
        {
            int[] testArr = { int.MaxValue, int.MinValue, 0 };
            int[] expectedArr = { int.MinValue, 0, int.MaxValue };
            Assert.AreEqual(expectedArr, mergeSort.Sort(testArr));
        }

        [TestCase]
        public void NullArrayTest()
        {
            Assert.Throws<ArgumentNullException>(() => mergeSort.Sort(null), "Array can't be null");
        }

        [TestCase]
        public void EmptyArrayTest()
        {
            int[] testArr = { };
            Assert.Throws<ArgumentException>(() => mergeSort.Sort(testArr), "Array length can't be equal to 0");
        }
    }




    [TestFixture]
    class QuickSortTests
    {
        QuickSorter quickSort = new QuickSorter();

        [TestCase]
        public void Test1()
        {
            int[] testArr = { 8, 9, 7 };
            int[] expectedArr = { 7, 8, 9 };
            Assert.AreEqual(expectedArr, quickSort.Sort(testArr));
        }

        [TestCase]
        public void Test2()
        {
            int[] testArr = { 0, 0, 0 };
            int[] expectedArr = { 0, 0, 0 };
            Assert.AreEqual(expectedArr, quickSort.Sort(testArr));
        }

        [TestCase]
        public void Test3()
        {
            int[] testArr = { -1, 11, 0, 2, -1, 0, 0, 19, -55, 55 };
            int[] expectedArr = { -55, -1, -1, 0, 0, 0, 2, 11, 19, 55 };
            Assert.AreEqual(expectedArr, quickSort.Sort(testArr));
        }

        [TestCase]
        public void Test4()
        {
            int[] testArr = { int.MaxValue, int.MinValue, 0 };
            int[] expectedArr = { int.MinValue, 0, int.MaxValue };
            Assert.AreEqual(expectedArr, quickSort.Sort(testArr));
        }

        [TestCase]
        public void NullArrayTest()
        {
            Assert.Throws<ArgumentNullException>(() => quickSort.Sort(null), "Array can't be null");
        }

        [TestCase]
        public void EmptyArrayTest()
        {
            int[] testArr = {};
            Assert.Throws<ArgumentException>(() => quickSort.Sort(testArr), "Array length can't be equal to 0");
        }
    }
}
