using NUnit.Framework;
using System;

namespace NET.S._2019.Tkachenko._03
{
    [TestFixture]
    class Tests
    {
        #region DoubleToBinaryStringConverionTests
        [TestCase]
        public void DoubleToBinaryStringConversionTest1()
        {
            double number = -255.255;

            string actual = number.GetBinaryStringRepresentation();
            string expected = "1100000001101111111010000010100011110101110000101000111101011100";

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void DoubleToBinaryStringConversionTest2()
        {
            double number = 255.255;

            string actual = number.GetBinaryStringRepresentation();
            string expected = "0100000001101111111010000010100011110101110000101000111101011100";

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void DoubleToBinaryStringConversionTest3()
        {
            double number = 4294967295.0;

            string actual = number.GetBinaryStringRepresentation();
            string expected = "0100000111101111111111111111111111111111111000000000000000000000";

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void DoubleToBinaryStringConversionTest4()
        {
            double number = double.MinValue;

            string actual = number.GetBinaryStringRepresentation();
            string expected = "1111111111101111111111111111111111111111111111111111111111111111";

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void DoubleToBinaryStringConversionTest5()
        {
            double number = double.MaxValue;

            string actual = number.GetBinaryStringRepresentation();
            string expected = "0111111111101111111111111111111111111111111111111111111111111111";

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void DoubleToBinaryStringConversionTest6()
        {
            double number = double.Epsilon;

            string actual = number.GetBinaryStringRepresentation();
            string expected = "0000000000000000000000000000000000000000000000000000000000000001";

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void DoubleToBinaryStringConversionTest7()
        {
            double number = double.NaN;

            string actual = number.GetBinaryStringRepresentation();
            string expected = "1111111111111000000000000000000000000000000000000000000000000000";

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void DoubleToBinaryStringConversionTest8()
        {
            double number = double.NegativeInfinity;

            string actual = number.GetBinaryStringRepresentation();
            string expected = "1111111111110000000000000000000000000000000000000000000000000000";

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void DoubleToBinaryStringConversionTest9()
        {
            double number = double.PositiveInfinity;

            string actual = number.GetBinaryStringRepresentation();
            string expected = "0111111111110000000000000000000000000000000000000000000000000000";

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void DoubleToBinaryStringConversionTest10()
        {
            double number = -0.0;

            string actual = number.GetBinaryStringRepresentation();
            string expected = "1000000000000000000000000000000000000000000000000000000000000000";

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void DoubleToBinaryStringConversionTest11()
        {
            double number = 0.0;

            string actual = number.GetBinaryStringRepresentation();
            string expected = "0000000000000000000000000000000000000000000000000000000000000000";

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region GCD_EuclideadAlgoritmTests
        [TestCase]
        public void EuclideanAlgorithmTest1()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 3;
            int actual = gcdFinder.EuclideanAlgorithm(3, 6);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclideanAlgorithmTest2()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 3;
            int actual = gcdFinder.EuclideanAlgorithm(18, 6, 3);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclideanAlgorithmTest3()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 106;
            int actual = gcdFinder.EuclideanAlgorithm(106, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclideanAlgorithmTest4()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 1;
            int actual = gcdFinder.EuclideanAlgorithm(105, 95, 107, 22, 14);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclideanAlgorithmTest5()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 1;
            int actual = gcdFinder.EuclideanAlgorithm(int.MaxValue, 17);

            Assert.AreEqual(expected, actual);
        }   

        [TestCase]
        public void EuclideanAlgorithmTest6()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 17;
            int actual = gcdFinder.EuclideanAlgorithm(-34, 68, -136, 17, -272);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclideanAlgorithmTest7()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 1221;
            int actual = gcdFinder.EuclideanAlgorithm(-0, 0, -0, 1221, 0, -0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclideanAlgorithmTest8()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 1;
            int actual = gcdFinder.EuclideanAlgorithm(123451, 1231246, -34698693, 12364568, -124752344, -1231245, 9999999);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclideanAlgorithmMinimalIntTest1()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.EuclideanAlgorithm(256, int.MinValue), "Value can't be equal to minimal integer.");
        }

        [TestCase]
        public void EuclideanAlgorithmWithMinimalIntTest2()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.EuclideanAlgorithm(int.MaxValue, int.MinValue), "Value can't be equal to minimal integer.");
        }

        [TestCase]
        public void EuclideanAlgorithmOneArgumentTest()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.EuclideanAlgorithm(11), "There should be at least 2 numbers.");
        }

        [TestCase]
        public void EuclideanAlgorithmZeroArgumentsTest()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.EuclideanAlgorithm(), "There should be at least 2 numbers.");
        }

        [TestCase]
        public void EuclideanAlgorithmZeroArgumentAllZerosTest1()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.EuclideanAlgorithm(0, 0), "All arguments can't be equal to 0 at the same time.");
        }

        [TestCase]
        public void EuclideanAlgorithmZeroArgumentAllZerosTest2()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.EuclideanAlgorithm(0, 0, 0, 0, 0, 0, 0, 0), "All arguments can't be equal to 0 at the same time.");
        }
        #endregion

        #region GCD_BinaryGCDAlgorithmTests
        [TestCase]
        public void BinaryGCDAlgorithmTest1()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 3;
            int actual = gcdFinder.EuclideanAlgorithm(3, 6);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmTest2()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 3;
            int actual = gcdFinder.EuclideanAlgorithm(18, 6, 3);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmTest3()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 106;
            int actual = gcdFinder.EuclideanAlgorithm(106, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmTest4()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 1;
            int actual = gcdFinder.EuclideanAlgorithm(105, 95, 107, 22, 14);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmTest5()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 1;
            int actual = gcdFinder.EuclideanAlgorithm(int.MaxValue, 17);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmTest6()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 17;
            int actual = gcdFinder.EuclideanAlgorithm(-34, 68, -136, 17, -272);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmTest7()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 1221;
            int actual = gcdFinder.EuclideanAlgorithm(-0, 0, -0, 1221, 0, -0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmTest8()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 1;
            int actual = gcdFinder.EuclideanAlgorithm(123451, 1231246, -34698693, 12364568, -124752344, -1231245, 9999999);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmMinimalIntTest1()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.EuclideanAlgorithm(256, int.MinValue), "Value can't be equal to minimal integer.");
        }

        [TestCase]
        public void BinaryGCDAlgorithmWithMinimalIntTest2()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.EuclideanAlgorithm(int.MaxValue, int.MinValue), "Value can't be equal to minimal integer.");
        }

        [TestCase]
        public void BinaryGCDnAlgorithmOneArgumentTest()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.EuclideanAlgorithm(11), "There should be at least 2 numbers.");
        }

        [TestCase]
        public void BinaryGCDAlgorithmZeroArgumentsTest()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.EuclideanAlgorithm(), "There should be at least 2 numbers.");
        }

        [TestCase]
        public void BinaryGCDAlgorithmZeroArgumentAllZerosTest1()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.EuclideanAlgorithm(0, 0), "All arguments can't be equal to 0 at the same time.");
        }

        [TestCase]
        public void BinaryGCDAlgorithmZeroArgumentAllZerosTest2()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.EuclideanAlgorithm(0, 0, 0, 0, 0, 0, 0, 0), "All arguments can't be equal to 0 at the same time.");
        }
        #endregion
    }
}
