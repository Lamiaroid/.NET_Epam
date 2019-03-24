using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NET.S._2019.Tkachenko._02
{
    [TestFixture]
    class NumericFunTests
    {
        [TestCase]
        public void InsertNumberSimpleTest1()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 15;
            Assert.AreEqual(expected, numericFun.InsertNumber(15, 15, 0, 0));
        }

        [TestCase]
        public void InsertNumberSimpleTest2()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 9;
            Assert.AreEqual(expected, numericFun.InsertNumber(8, 15, 0, 0));
        }

        [TestCase]
        public void InsertNumberSimpleTest3()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 120;
            Assert.AreEqual(expected, numericFun.InsertNumber(8, 15, 3, 8));
        }

        [TestCase]
        public void InsertNumberMaxValueTest()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 8191;
            Assert.AreEqual(expected, numericFun.InsertNumber(15, int.MaxValue, 0, 12));
        }

        [TestCase]
        public void InsertNumberMinValueTest()
        {
            NumericFun numericFun = new NumericFun();
            int expected = -2147482848;
            Assert.AreEqual(expected, numericFun.InsertNumber(int.MinValue, 800, 0, 12));
        }

        [TestCase]
        public void InsertNumberInvalidBitsPositionTest1()
        {
            NumericFun numericFun = new NumericFun();
            Assert.Throws<ArgumentException>(() => numericFun.InsertNumber(19999, 1999, -11, 55), "i cannot be smaller than 0; j cannot be bigger than 31");
        }

        [TestCase]
        public void InsertNumberInvalidBitsPositionTest2()
        {
            NumericFun numericFun = new NumericFun();
            Assert.Throws<ArgumentException>(() => numericFun.InsertNumber(128, 22, 66, 5), "i cannot be bigger than 31");
        }

        [TestCase]
        public void InsertNumberInvalidBitsPositionTest3()
        {
            NumericFun numericFun = new NumericFun();
            Assert.Throws<ArgumentException>(() => numericFun.InsertNumber(77, 11, -1, -12), "i cannot be smaller than 0; j cannot be smaller than 0");
        }

        [TestCase]
        public void InsertNumberInvalidBitsPositionTest4()
        {
            NumericFun numericFun = new NumericFun();
            Assert.Throws<ArgumentException>(() => numericFun.InsertNumber(77, 11, 9, 5), "i cannot be bigger than j");
        }








        [TestCase]
        public void FindNextBiggerNumberSimpleTest1()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 21;
            Assert.AreEqual(expected, numericFun.FindNextBiggerNumber(12).Item1);
        }

        [TestCase]
        public void FindNextBiggerNumberSimpleTest2()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 531;
            Assert.AreEqual(expected, numericFun.FindNextBiggerNumber(513).Item1);
        }

        [TestCase]
        public void FindNextBiggerNumberSimpleTest3()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 2071;
            Assert.AreEqual(expected, numericFun.FindNextBiggerNumber(2017).Item1);
        }

        [TestCase]
        public void FindNextBiggerNumberSimpleTest4()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 441;
            Assert.AreEqual(expected, numericFun.FindNextBiggerNumber(414).Item1);
        }

        [TestCase]
        public void FindNextBiggerNumberSimpleTest5()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 414;
            Assert.AreEqual(expected, numericFun.FindNextBiggerNumber(144).Item1);
        }

        [TestCase]
        public void FindNextBiggerNumberSimpleTest6()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 1241233;
            Assert.AreEqual(expected, numericFun.FindNextBiggerNumber(1234321).Item1);
        }

        [TestCase]
        public void FindNextBiggerNumberSimpleTest7()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 1234162;
            Assert.AreEqual(expected, numericFun.FindNextBiggerNumber(1234126).Item1);
        }

        [TestCase]
        public void FindNextBiggerNumberSimpleTest8()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 3462345;
            Assert.AreEqual(expected, numericFun.FindNextBiggerNumber(3456432).Item1);
        }

        [TestCase]
        public void FindNextBiggerNumberSimpleTest9()
        {
            NumericFun numericFun = new NumericFun();
            int? expected = null;
            Assert.AreEqual(expected, numericFun.FindNextBiggerNumber(10).Item1);
        }

        [TestCase]
        public void FindNextBiggerNumberSimpleTest10()
        {
            NumericFun numericFun = new NumericFun();
            int? expected = null;
            Assert.AreEqual(expected, numericFun.FindNextBiggerNumber(20).Item1);
        }

        [TestCase]
        public void FindNextBiggerNumberWhenNumberLessThanZeroTest()
        {
            NumericFun numericFun = new NumericFun();
            Assert.Throws<ArgumentException>(() => numericFun.FindNextBiggerNumber(-127), "Number can't be equal to zero or less");
        }











        [TestCase]
        public void FindNextBiggerNumberGetTimeTest()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 0;
            Assert.AreEqual(expected, numericFun.FindNextBiggerNumber(12431).Item2.Milliseconds);
        }













        [TestCase]
        public void FilterDigitSimpleTest1()
        {
            NumericFun numericFun = new NumericFun();
            List<int> expected = new List<int>() { 1, -11, 151, 13 };
            Assert.AreEqual(expected, numericFun.FilterDigit(new List<int>() { 1, 2, 3, 4, -11, 151, 13 }, 1));
        }

        [TestCase]
        public void FilterDigitSimpleTest2()
        {
            NumericFun numericFun = new NumericFun();
            List<int> expected = new List<int>() { 0, 0, 0, 10, 0, 100 };
            Assert.AreEqual(expected, numericFun.FilterDigit(new List<int>() { 0, 0, 0, 10, 0, 100, -1 }, 0));
        }

        [TestCase]
        public void FilterDigitSimpleTest3()
        {
            NumericFun numericFun = new NumericFun();
            List<int> expected = new List<int>() { int.MinValue, int.MaxValue, -777777, 7777777 };
            Assert.AreEqual(expected, numericFun.FilterDigit(new List<int>() { 0, int.MinValue, int.MaxValue, 346645623, 1235523940, -777777, 7777777 }, 7));
        }

        [TestCase]
        public void FilterDigitSimpleTest4()
        {
            NumericFun numericFun = new NumericFun();
            List<int> expected = new List<int>() { };
            Assert.AreEqual(expected, numericFun.FilterDigit(new List<int>() { 0, 256, 128, -99, 888, -777777, 7777777 }, 4));
        }

        [TestCase]
        public void FilterDigitEmptyListTest()
        {
            NumericFun numericFun = new NumericFun();
            Assert.Throws<ArgumentException>(() => numericFun.FilterDigit(new List<int>() { }, 0), "List can't be empty");
        }

        [TestCase]
        public void FilterDigitNullListTest()
        {
            NumericFun numericFun = new NumericFun();
            Assert.Throws<ArgumentNullException>(() => numericFun.FilterDigit(null, 0), "List can't be null");
        }

        [TestCase]
        public void FilterDigitEmptyNotDigitInFilterTest1()
        {
            NumericFun numericFun = new NumericFun();
            Assert.Throws<ArgumentException>(() => numericFun.FilterDigit(new List<int>() { 11, 22}, 11), "Filter can be only natural digit");
        }

        [TestCase]
        public void FilterDigitEmptyNotDigitInFilterTest2()
        {
            NumericFun numericFun = new NumericFun();
            Assert.Throws<ArgumentException>(() => numericFun.FilterDigit(new List<int>() { -17, -1, 22}, -1), "Filter can be only natural digit");
        }












        [TestCase]
        public void FindNthRootSimpleTest1()
        {
            NumericFun numericFun = new NumericFun();
            double expected = 1;
            Assert.AreEqual(expected, numericFun.FindNthRoot(1, 5, 0.0001));
        }

        [TestCase]
        public void FindNthRootSimpleTest2()
        {
            NumericFun numericFun = new NumericFun();
            double expected = 2;
            Assert.AreEqual(expected, numericFun.FindNthRoot(8, 3, 0.0001));
        }

        [TestCase]
        public void FindNthRootSimpleTest3()
        {
            NumericFun numericFun = new NumericFun();
            double expected = 0.1;
            Assert.AreEqual(expected, numericFun.FindNthRoot(0.001, 3, 0.0001));
        }

        [TestCase]
        public void FindNthRootSimpleTest4()
        {
            NumericFun numericFun = new NumericFun();
            double expected = 0.45;
            Assert.AreEqual(expected, numericFun.FindNthRoot(0.04100625, 4, 0.0001));
        }

        [TestCase]
        public void FindNthRootSimpleTest5()
        {
            NumericFun numericFun = new NumericFun();
            double expected = 0.6;
            Assert.AreEqual(expected, numericFun.FindNthRoot(0.0279936, 7, 0.0001));
        }

        [TestCase]
        public void FindNthRootSimpleTest6()
        {
            NumericFun numericFun = new NumericFun();
            double expected = 0.3;
            Assert.AreEqual(expected, numericFun.FindNthRoot(0.0081, 4, 0.01));
        }

        [TestCase]
        public void FindNthRootSimpleTest7()
        {
            NumericFun numericFun = new NumericFun();
            double expected = -0.2;
            Assert.AreEqual(expected, numericFun.FindNthRoot(-0.008, 3, 0.1));
        }

        [TestCase]
        public void FindNthRootSimpleTest8()
        {
            NumericFun numericFun = new NumericFun();
            double expected = 0.545;
            Assert.AreEqual(expected, numericFun.FindNthRoot(0.004241979, 9, 0.00000001));
        }

        [TestCase]
        public void FindNthRootArgumentOutOfRangeTest1()
        {
            NumericFun numericFun = new NumericFun();
            Assert.Throws<ArgumentOutOfRangeException>(() => numericFun.FindNthRoot(8, 15, -7), "Precision can't be equal or less than zero");
        }

        [TestCase]
        public void FindNthRootArgumentOutOfRangeTest2()
        {
            NumericFun numericFun = new NumericFun();
            Assert.Throws<ArgumentOutOfRangeException>(() => numericFun.FindNthRoot(8, 15, -0.6), "Precision can't be equal or less than zero");
        }

        [TestCase]
        public void FindNthRootNegativeNumberWithOddRootTest()
        {
            NumericFun numericFun = new NumericFun();
            Assert.Throws<ArgumentException>(() => numericFun.FindNthRoot(-2, 2, 0.001), "Number can't be negative with odd root power");
        }

        [TestCase]
        public void FindNthRootNegativeRootPowerTest()
        {
            NumericFun numericFun = new NumericFun();
            Assert.Throws<ArgumentException>(() => numericFun.FindNthRoot(8, -2, 0.001), "Root power can't be equal or less than zero");
        }
    }
}
