using System;
using NUnit.Framework;

namespace NET.S._2019.Tkachenko._05
{
    [TestFixture]
    class Tests
    {
        #region JaggedArraySortByRowsSumsTests
        [TestCase]
        public void JaggedArraySortByRowsSumsTest1()
        {
            int[][] data = { new int[4] { 4, 5, 6, 11 },
                             new int[2] { 7, 9 },
                             new int[3] { 1, 2, 6 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[3] { 1, 2, 6 },
                                 new int[2] { 7, 9 },
                                 new int[4] { 4, 5, 6, 11 } };
            int[][] actual = jaggedArray.SortRowsByElementsSumInRows(true);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsTest2()
        {
            int[][] data = { new int[4] { 4, 5, 6, 11 },
                             new int[2] { 7, 9 },
                             new int[3] { 1, 2, 6 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[4] { 4, 5, 6, 11 },
                                 new int[2] { 7, 9 },
                                 new int[3] { 1, 2, 6 } };
            int[][] actual = jaggedArray.SortRowsByElementsSumInRows(false);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsTest3()
        {
            int[][] data = { new int[6] { 4, 5, 6, 11, 18, -11 },
                             new int[5] { 7, 9, 0, 5, 1 },
                             new int[6] { 1, 2, 6, 1, -1, 3 },
                             new int[1] { 5 },
                             new int[2] { -19, 22 },
                             new int[4] { 100, 100, -150, 88 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[2] { -19, 22 },
                                 new int[1] { 5 },                               
                                 new int[6] { 1, 2, 6, 1, -1, 3 },
                                 new int[5] { 7, 9, 0, 5, 1 },
                                 new int[6] { 4, 5, 6, 11, 18, -11 },
                                 new int[4] { 100, 100, -150, 88 } };
            int[][] actual = jaggedArray.SortRowsByElementsSumInRows(true);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsTest4()
        {
            int[][] data = { new int[6] { 4, 5, 6, 11, 18, -11 },
                             new int[5] { 7, 9, 0, 5, 1 },
                             new int[6] { 1, 2, 6, 1, -1, 3 },
                             new int[1] { 5 },
                             new int[2] { -19, 22 },
                             new int[4] { 100, 100, -150, 88 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[4] { 100, 100, -150, 88 },
                                 new int[6] { 4, 5, 6, 11, 18, -11 },
                                 new int[5] { 7, 9, 0, 5, 1 },
                                 new int[6] { 1, 2, 6, 1, -1, 3 },
                                 new int[1] { 5 },
                                 new int[2] { -19, 22 } };
            int[][] actual = jaggedArray.SortRowsByElementsSumInRows(false);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsTest5()
        {
            int[][] data = { new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                             new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                             new int[7] { 4, 5, 6, -13, -22, 33, -17 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                                 new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                                 new int[7] { 4, 5, 6, -13, -22, 33, -17 } };
            int[][] actual = jaggedArray.SortRowsByElementsSumInRows(true);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsTest6()
        {
            int[][] data = { new int[5] { 0, 0, 0, 0, 0 },
                             new int[3] { 11, 33, -44 },
                             new int[5] { 0, 0, 0, 0, 0 },
                             new int[2] { -7, 7 },
                             new int[5] { 0, 0, 0, 0, 0 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[5] { 0, 0, 0, 0, 0 },
                                 new int[3] { 11, 33, -44 },
                                 new int[5] { 0, 0, 0, 0, 0 },
                                 new int[2] { -7, 7 },
                                 new int[5] { 0, 0, 0, 0, 0 } };
            int[][] actual = jaggedArray.SortRowsByElementsSumInRows(false);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsOverflowTest()
        {
            int[][] data = { new int[5] { 0, int.MaxValue, int.MaxValue, 0, 1 },
                             new int[5] { 0, int.MinValue, int.MinValue, 0, 0 },
                             new int[5] { 1, int.MaxValue, 2, 3, 0 },
                             new int[5] { int.MinValue, 0, -11, 0, -11 },
                             new int[5] { int.MaxValue, int.MinValue, int.MaxValue, int.MinValue, int.MaxValue } };
            JaggedArray jaggedArray = new JaggedArray(data);

            Assert.Throws<OverflowException>(() => jaggedArray.SortRowsByElementsSumInRows(true));
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsEmptyTest()
        {
            int[][] data = { };
            JaggedArray jaggedArray = new JaggedArray(data);

            Assert.Throws<ArgumentException>(() => jaggedArray.SortRowsByElementsSumInRows(true));
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsNullTest()
        {
            int[][] data = null;
            JaggedArray jaggedArray = new JaggedArray(data);

            Assert.Throws<ArgumentNullException>(() => jaggedArray.SortRowsByElementsSumInRows(true));
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsRowEmptyTest()
        {
            int[][] data = { new int[3] { 19, 22, 33 },
                             new int[0] { },
                             new int[3] { 19, 22, 33 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            Assert.Throws<ArgumentException>(() => jaggedArray.SortRowsByElementsSumInRows(false));
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsRowNullTest()
        {
            int[][] data = { null,
                             new int[1] { 17 },
                             new int[3] { 19, 22, 33 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            Assert.Throws<ArgumentNullException>(() => jaggedArray.SortRowsByElementsSumInRows(false));
        }
        #endregion
        #region JaggedArraySortByMinElementsInRowsTests
        [TestCase]
        public void JaggedArraySortByMinElementsInRowsTest1()
        {
            int[][] data = { new int[4] { 4, 5, 6, 11 },
                             new int[2] { 7, 9 },
                             new int[3] { 1, 2, 6 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[3] { 1, 2, 6 },                                
                                 new int[4] { 4, 5, 6, 11 },
                                 new int[2] { 7, 9 } };
            int[][] actual = jaggedArray.SortRowsByMinElementsInRows(true);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMinElementsInRowsTest2()
        {
            int[][] data = { new int[4] { 4, 5, 6, 11 },
                             new int[2] { 7, 9 },
                             new int[3] { 1, 2, 6 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[2] { 7, 9 },
                                 new int[4] { 4, 5, 6, 11 },
                                 new int[3] { 1, 2, 6 } };
            int[][] actual = jaggedArray.SortRowsByMinElementsInRows(false);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMinElementsInRowsTest3()
        {
            int[][] data = { new int[6] { 4, 5, 6, 11, 18, -11 },
                             new int[5] { 7, 9, 0, 5, 1 },
                             new int[6] { 1, 2, 6, 1, -1, 3 },
                             new int[1] { 5 },
                             new int[2] { -19, 22 },
                             new int[4] { 100, 100, -150, 88 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[4] { 100, 100, -150, 88 },
                                 new int[2] { -19, 22 },
                                 new int[6] { 4, 5, 6, 11, 18, -11 },
                                 new int[6] { 1, 2, 6, 1, -1, 3 },
                                 new int[5] { 7, 9, 0, 5, 1 },
                                 new int[1] { 5 } };
            int[][] actual = jaggedArray.SortRowsByMinElementsInRows(true);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMinElementsInRowsTest4()
        {
            int[][] data = { new int[1] { 5 },
                             new int[5] { 7, 9, 0, 5, 1 },
                             new int[6] { 1, 2, 6, 1, -1, 3 },
                             new int[6] { 4, 5, 6, 11, 18, -11 },                                                                                 
                             new int[2] { -19, 22 },
                             new int[4] { 100, 100, -150, 88 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[1] { 5 },
                                 new int[5] { 7, 9, 0, 5, 1 },
                                 new int[6] { 1, 2, 6, 1, -1, 3 },      
                                 new int[6] { 4, 5, 6, 11, 18, -11 },
                                 new int[2] { -19, 22 },
                                 new int[4] { 100, 100, -150, 88 } };
            int[][] actual = jaggedArray.SortRowsByMinElementsInRows(false);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMinElementsInRowsTest5()
        {
            int[][] data = { new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                             new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                             new int[7] { 4, 5, 6, -13, -22, 33, -17 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                                 new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                                 new int[7] { 4, 5, 6, -13, -22, 33, -17 } };
            int[][] actual = jaggedArray.SortRowsByMinElementsInRows(true);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMinElementsInRowsTest6()
        {
            int[][] data = { new int[5] { 0, 0, 0, 0, 0 },
                             new int[3] { 0, 0, 0 },
                             new int[5] { 0, 0, 0, 0, 0 },
                             new int[2] { 0, 0 },
                             new int[5] { 0, 0, 0, 0, 0 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[5] { 0, 0, 0, 0, 0 },
                                 new int[3] { 0, 0, 0 },
                                 new int[5] { 0, 0, 0, 0, 0 },
                                 new int[2] { 0, 0 },
                                 new int[5] { 0, 0, 0, 0, 0 } };
            int[][] actual = jaggedArray.SortRowsByMinElementsInRows(false);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMinElementsInRowsEmptyTest()
        {
            int[][] data = { };
            JaggedArray jaggedArray = new JaggedArray(data);

            Assert.Throws<ArgumentException>(() => jaggedArray.SortRowsByMinElementsInRows(true));
        }

        [TestCase]
        public void JaggedArraySortByMinElementsInRowsNullTest()
        {
            int[][] data = null;
            JaggedArray jaggedArray = new JaggedArray(data);

            Assert.Throws<ArgumentNullException>(() => jaggedArray.SortRowsByMinElementsInRows(true));
        }

        [TestCase]
        public void JaggedArraySortByMinElementsInRowsRowEmptyTest()
        {
            int[][] data = { new int[3] { 19, 22, 33 },
                             new int[0] { },
                             new int[3] { 19, 22, 33 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            Assert.Throws<ArgumentException>(() => jaggedArray.SortRowsByMinElementsInRows(false));
        }

        [TestCase]
        public void JaggedArraySortByMinElementsInRowsRowNullTest()
        {
            int[][] data = { null,
                             new int[1] { 17 },
                             new int[3] { 19, 22, 33 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            Assert.Throws<ArgumentNullException>(() => jaggedArray.SortRowsByMinElementsInRows(false));
        }
        #endregion
        #region JaggedArraySortByMaxElementsInRowsTests
        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsTest1()
        {
            int[][] data = { new int[3] { 1, 2, 6 },               
                             new int[2] { 7, 9 },
                             new int[4] { 4, 5, 6, 11 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[3] { 1, 2, 6 },
                                 new int[2] { 7, 9 },
                                 new int[4] { 4, 5, 6, 11 } };
            int[][] actual = jaggedArray.SortRowsByMaxElementsInRows(true);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsTest2()
        {
            int[][] data = { new int[4] { 4, 5, 6, 11 },
                             new int[2] { 7, 9 },
                             new int[3] { 1, 2, 6 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[4] { 4, 5, 6, 11 },
                                 new int[2] { 7, 9 },
                                 new int[3] { 1, 2, 6 } };
            int[][] actual = jaggedArray.SortRowsByMaxElementsInRows(false);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsTest3()
        {
            int[][] data = { new int[6] { 4, 5, 6, 11, 18, -11 },
                             new int[5] { 7, 9, 0, 5, 1 },
                             new int[6] { 1, 2, 6, 1, -1, 3 },
                             new int[1] { 5 },
                             new int[2] { -19, 22 },
                             new int[4] { 100, 100, -150, 88 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[1] { 5 },                                            
                                 new int[6] { 1, 2, 6, 1, -1, 3 },
                                 new int[5] { 7, 9, 0, 5, 1 },
                                 new int[6] { 4, 5, 6, 11, 18, -11 },
                                 new int[2] { -19, 22 },
                                 new int[4] { 100, 100, -150, 88 } };
            int[][] actual = jaggedArray.SortRowsByMaxElementsInRows(true);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsTest4()
        {
            int[][] data = { new int[6] { 4, 5, 6, 11, 18, -11 },
                             new int[5] { 7, 9, 0, 5, 1 },
                             new int[6] { 1, 2, 6, 1, -1, 3 },
                             new int[1] { 5 },
                             new int[2] { -19, 22 },
                             new int[4] { 100, 100, -150, 88 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[4] { 100, 100, -150, 88 },
                                 new int[2] { -19, 22 },
                                 new int[6] { 4, 5, 6, 11, 18, -11 },
                                 new int[5] { 7, 9, 0, 5, 1 },                                 
                                 new int[6] { 1, 2, 6, 1, -1, 3 },
                                 new int[1] { 5 } };
            int[][] actual = jaggedArray.SortRowsByMaxElementsInRows(false);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsTest5()
        {
            int[][] data = { new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                             new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                             new int[7] { 4, 5, 6, -13, -22, 33, -17 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                                 new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                                 new int[7] { 4, 5, 6, -13, -22, 33, -17 } };
            int[][] actual = jaggedArray.SortRowsByMaxElementsInRows(true);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsTest6()
        {
            int[][] data = { new int[5] { 0, 0, 0, 0, 0 },
                             new int[3] { 0, 0, 0 },
                             new int[5] { 0, 0, 0, 0, 0 },
                             new int[2] { 0, 0 },
                             new int[5] { 0, 0, 0, 0, 0 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            int[][] expected = { new int[5] { 0, 0, 0, 0, 0 },
                                 new int[3] { 0, 0, 0 },
                                 new int[5] { 0, 0, 0, 0, 0 },
                                 new int[2] { 0, 0 },
                                 new int[5] { 0, 0, 0, 0, 0 } };
            int[][] actual = jaggedArray.SortRowsByMaxElementsInRows(false);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsEmptyTest()
        {
            int[][] data = { };
            JaggedArray jaggedArray = new JaggedArray(data);

            Assert.Throws<ArgumentException>(() => jaggedArray.SortRowsByMaxElementsInRows(true));
        }

        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsNullTest()
        {
            int[][] data = null;
            JaggedArray jaggedArray = new JaggedArray(data);

            Assert.Throws<ArgumentNullException>(() => jaggedArray.SortRowsByMaxElementsInRows(true));
        }

        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsRowEmptyTest()
        {
            int[][] data = { new int[3] { 19, 22, 33 },
                             new int[0] { },
                             new int[3] { 19, 22, 33 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            Assert.Throws<ArgumentException>(() => jaggedArray.SortRowsByMaxElementsInRows(false));
        }

        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsRowNullTest()
        {
            int[][] data = { null,
                             new int[1] { 17 },
                             new int[3] { 19, 22, 33 } };
            JaggedArray jaggedArray = new JaggedArray(data);

            Assert.Throws<ArgumentNullException>(() => jaggedArray.SortRowsByMaxElementsInRows(false));
        }
        #endregion
        #region PolynomialTests
        [TestCase]
        public void PolynomialToStringTest()
        {
            int[] factors = { 1, 0, 3, -4, 5, 11, 8 };
            Polynomial polynomial = new Polynomial(factors);

            string expected = "8x^6 + 11x^5 + 5x^4 - 4x^3 + 3x^2 + 1x^0";
            string actual = polynomial.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PolynomialGetHashCodeTest()
        {
            int[] factors = { 1, 0, 3, -4, 5, 11, 8 };
            Polynomial polynomial = new Polynomial(factors);

            int expected = "8x^6 + 11x^5 + 5x^4 - 4x^3 + 3x^2 + 1x^0".GetHashCode();
            int actual = polynomial.GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PolynomialEqualsTest1()
        {
            int[] factorsA = { 1, 0, 3, -4, 5, 11, 8 };
            Polynomial polynomialA = new Polynomial(factorsA);

            int[] factorsB = { 11, 3, 1, 5, -4, 1, 8 };
            Polynomial polynomialB = new Polynomial(factorsB);

            bool expected = false;
            bool actual = polynomialA.Equals(polynomialB);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PolynomialEqualsTest2()
        {
            int[] factorsA = { 1, 0, 3, -4, 5, 11, 8 };
            Polynomial polynomialA = new Polynomial(factorsA);

            int[] factorsB = { 1, 0, 3, -4, 5, 11, 8 };
            Polynomial polynomialB = new Polynomial(factorsB);

            bool expected = true;
            bool actual = polynomialA.Equals(polynomialB);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PolynomialEqualsTest3()
        {
            int[] factorsA = { 1, 0, 3, -4, 5, 11, 8 };
            Polynomial polynomialA = new Polynomial(factorsA);

            Polynomial polynomialB = null;

            bool expected = false;
            bool actual = polynomialA.Equals(polynomialB);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PolynomialAdditionTest1()
        {
            int[] factorsA = { 1, 0, 3, -4, 5, 11, 8 };
            Polynomial polynomialA = new Polynomial(factorsA);

            int[] factorsB = { 2, 7, -8, 11 };
            Polynomial polynomialB = new Polynomial(factorsB);

            int[] factorsE = { 3, 7, -5, 7, 5, 11, 8 };
            Polynomial expected = new Polynomial(factorsE);
            Polynomial actual = polynomialB + polynomialA;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PolynomialAdditionTest2()
        {
            int[] factorsA = { 1, 0, 3, -4, 5, 11, 8 };
            Polynomial polynomialA = new Polynomial(factorsA);

            int[] factorsB = { 2, 7, -8, 11, 33, 180, 0, -33 };
            Polynomial polynomialB = new Polynomial(factorsB);

            int[] factorsE = { 3, 7, -5, 7, 38, 191, 8, -33 };
            Polynomial expected = new Polynomial(factorsE);
            Polynomial actual = polynomialB + polynomialA;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PolynomialAdditionOverflowTest()
        {
            int[] factorsA = { int.MaxValue, 13 };
            Polynomial polynomialA = new Polynomial(factorsA);

            int[] factorsB = { 1, 128, 33 };
            Polynomial polynomialB = new Polynomial(factorsB);

            Polynomial actual;

            Assert.Throws<OverflowException>(() => actual = polynomialB + polynomialA);
        }

        [TestCase]
        public void PolynomialSubtractionTest1()
        {
            int[] factorsA = { 1, 0, 3, -4, 5, 11, 8 };
            Polynomial polynomialA = new Polynomial(factorsA);

            int[] factorsB = { 2, 7, -8, 11 };
            Polynomial polynomialB = new Polynomial(factorsB);

            int[] factorsE = { 1, 7, -11, 15, -5, -11, -8 };
            Polynomial expected = new Polynomial(factorsE);
            Polynomial actual = polynomialB - polynomialA;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PolynomialSubtractionTest2()
        {
            int[] factorsA = { 1, 0, 3, -4, 5, 11, 8 };
            Polynomial polynomialA = new Polynomial(factorsA);

            int[] factorsB = { 2, 7, -8, 11 };
            Polynomial polynomialB = new Polynomial(factorsB);

            int[] factorsE = { -1, -7, 11, -15, 5, 11, 8 };
            Polynomial expected = new Polynomial(factorsE);
            Polynomial actual = polynomialA - polynomialB;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PolynomialMultiplicationTest1()
        {
            int[] factorsA = { 1, 5, 3 };
            Polynomial polynomialA = new Polynomial(factorsA);

            int[] factorsB = { 2, 8 };
            Polynomial polynomialB = new Polynomial(factorsB);

            int[] factorsE = { 2, 18, 46, 24 };
            Polynomial expected = new Polynomial(factorsE);
            Polynomial actual = polynomialA * polynomialB;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PolynomialMultiplicationTest2()
        {
            int[] factorsA = { 1, 7, 8 };
            Polynomial polynomialA = new Polynomial(factorsA);

            int[] factorsB = { 5, 3, 2, 7, 8 };
            Polynomial polynomialB = new Polynomial(factorsB);

            int[] factorsE = { 5, 38, 63, 45, 73, 112, 64 };
            Polynomial expected = new Polynomial(factorsE);
            Polynomial actual = polynomialA * polynomialB;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PolynomialMultiplicationOverflowTest()
        {
            int[] factorsA = { int.MinValue, -13 };
            Polynomial polynomialA = new Polynomial(factorsA);

            int[] factorsB = { int.MinValue, 0, 33 };
            Polynomial polynomialB = new Polynomial(factorsB);

            Polynomial actual;

            Assert.Throws<OverflowException>(() => actual = polynomialB * polynomialA);
        }

        [TestCase]
        public void PolynomialComparisonTest1()
        {
            int[] factorsA = { 1, 0, 3, -4, 5, 11, 8 };
            Polynomial polynomialA = new Polynomial(factorsA);

            int[] factorsB = { 1, 0, 3, -4, 5, 11, 8 };
            Polynomial polynomialB = new Polynomial(factorsB);

            bool expected = false;
            bool actual = polynomialB != polynomialA;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PolynomialComparisonTest2()
        {
            int[] factorsA = { 1, 0, 3, -4, 5, 11, 8 };
            Polynomial polynomialA = new Polynomial(factorsA);

            int[] factorsB = { 1, 0, 3, -4, 5, 11, 8 };
            Polynomial polynomialB = new Polynomial(factorsB);

            bool expected = true;
            bool actual = polynomialB == polynomialA;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PolynomialInitializingWithEmptyArrayTest()
        {
            int[] factors = { };

            Assert.Throws<ArgumentException>(() => new Polynomial(factors));
        }

        [TestCase]
        public void PolynomialInitializingWithNullArrayTest()
        {
            int[] factors = null;

            Assert.Throws<ArgumentNullException>(() => new Polynomial(factors));
        }
        #endregion
    }
}