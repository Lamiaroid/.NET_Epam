using NET.S._2019.Tkachenko._02;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void InsertNumberSimpleTest1()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 15;
            Assert.AreEqual(expected, numericFun.InsertNumber(15, 15, 0, 0));
        }

        [TestMethod]
        public void InsertNumberSimpleTest2()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 9;
            Assert.AreEqual(expected, numericFun.InsertNumber(8, 15, 0, 0));
        }

        [TestMethod]
        public void InsertNumberSimpleTest3()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 120;
            Assert.AreEqual(expected, numericFun.InsertNumber(8, 15, 3, 8));
        }

        [TestMethod]
        public void InsertNumberMaxValueTest()
        {
            NumericFun numericFun = new NumericFun();
            int expected = 8191;
            Assert.AreEqual(expected, numericFun.InsertNumber(15, int.MaxValue, 0, 12));
        }

        [TestMethod]
        public void InsertNumberMinValueTest()
        {
            NumericFun numericFun = new NumericFun();
            int expected = -2147482848;
            Assert.AreEqual(expected, numericFun.InsertNumber(int.MinValue, 800, 0, 12));
        }

        [TestMethod]
        public void InsertNumberInvalidBitsPositionTest1()
        {
            NumericFun numericFun = new NumericFun();
            Assert.ThrowsException<ArgumentException>(() => numericFun.InsertNumber(19999, 1999, -11, 55), "i cannot be smaller than 0; j cannot be bigger than 31");
        }

        [TestMethod]
        public void InsertNumberInvalidBitsPositionTest2()
        {
            NumericFun numericFun = new NumericFun();
            Assert.ThrowsException<ArgumentException>(() => numericFun.InsertNumber(128, 22, 66, 5), "i cannot be bigger than 31");
        }

        [TestMethod]
        public void InsertNumberInvalidBitsPositionTest3()
        {
            NumericFun numericFun = new NumericFun();
            Assert.ThrowsException<ArgumentException>(() => numericFun.InsertNumber(77, 11, -1, -12), "i cannot be smaller than 0; j cannot be smaller than 0");
        }

        [TestMethod]
        public void InsertNumberInvalidBitsPositionTest4()
        {
            NumericFun numericFun = new NumericFun();
            Assert.ThrowsException<ArgumentException>(() => numericFun.InsertNumber(77, 11, 9, 5), "i cannot be bigger than j");
        }
    }
}
