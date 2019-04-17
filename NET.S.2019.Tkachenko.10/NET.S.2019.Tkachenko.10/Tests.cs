namespace NET.S._2019.Tkachenko._10
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        #region JaggedArraySortByRowsSumsTests
        [TestCase]
        public void JaggedArraySortByRowsSumsTest1()
        {
            int[][] data =
            {
                new int[4] { 4, 5, 6, 11 },
                new int[2] { 7, 9 },
                new int[3] { 1, 2, 6 }
            };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected =
            {
                new int[3] { 1, 2, 6 },
                new int[2] { 7, 9 },
                new int[4] { 4, 5, 6, 11 }
            };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.AscendingOrder.ElementsSumInRowsComparator());

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsTest2()
        {
            int[][] data =
            {
                new int[4] { 4, 5, 6, 11 },
                new int[2] { 7, 9 },
                new int[3] { 1, 2, 6 }
            };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected =
            {
                new int[4] { 4, 5, 6, 11 },
                new int[2] { 7, 9 },
                new int[3] { 1, 2, 6 }
            };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.DescendingOrder.ElementsSumInRowsComparator());

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsTest3()
        {
            int[][] data =
            {
                new int[6] { 4, 5, 6, 11, 18, -11 },
                new int[5] { 7, 9, 0, 5, 1 },
                new int[6] { 1, 2, 6, 1, -1, 3 },
                new int[1] { 5 },
                new int[2] { -19, 22 },
                new int[4] { 100, 100, -150, 88 }
            };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected =
            {
                new int[2] { -19, 22 },
                new int[1] { 5 },
                new int[6] { 1, 2, 6, 1, -1, 3 },
                new int[5] { 7, 9, 0, 5, 1 },
                new int[6] { 4, 5, 6, 11, 18, -11 },
                new int[4] { 100, 100, -150, 88 }
            };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.AscendingOrder.ElementsSumInRowsComparator());

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsTest4()
        {
            int[][] data =
            {
                new int[6] { 4, 5, 6, 11, 18, -11 },
                new int[5] { 7, 9, 0, 5, 1 },
                new int[6] { 1, 2, 6, 1, -1, 3 },
                new int[1] { 5 },
                new int[2] { -19, 22 },
                new int[4] { 100, 100, -150, 88 }
            };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected =
            {
                new int[4] { 100, 100, -150, 88 },
                new int[6] { 4, 5, 6, 11, 18, -11 },
                new int[5] { 7, 9, 0, 5, 1 },
                new int[6] { 1, 2, 6, 1, -1, 3 },
                new int[1] { 5 },
                new int[2] { -19, 22 }
            };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.DescendingOrder.ElementsSumInRowsComparator());

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsTest5()
        {
            int[][] data =
            {
                new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                new int[7] { 4, 5, 6, -13, -22, 33, -17 }
            };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected =
            {
                new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                new int[7] { 4, 5, 6, -13, -22, 33, -17 }
            };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.AscendingOrder.ElementsSumInRowsComparator());

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsTest6()
        {
            int[][] data =
            {
                new int[5] { 0, 0, 0, 0, 0 },
                new int[3] { 11, 33, -44 },
                new int[5] { 0, 0, 0, 0, 0 },
                new int[2] { -7, 7 },
                new int[5] { 0, 0, 0, 0, 0 }
            };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected =
            {
                new int[5] { 0, 0, 0, 0, 0 },
                new int[3] { 11, 33, -44 },
                new int[5] { 0, 0, 0, 0, 0 },
                new int[2] { -7, 7 },
                new int[5] { 0, 0, 0, 0, 0 }
            };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.DescendingOrder.ElementsSumInRowsComparator());

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsEmptyTest()
        {
            int[][] data = { };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            Assert.Throws<ArgumentException>(() => jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.AscendingOrder.ElementsSumInRowsComparator()));
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsNullTest()
        {
            int[][] data = null;
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            Assert.Throws<ArgumentNullException>(() => jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.AscendingOrder.ElementsSumInRowsComparator()));
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsRowEmptyTest()
        {
            int[][] data =
            {
                new int[3] { 19, 22, 33 },
                new int[0] { },
                new int[3] { 19, 22, 33 }
            };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            Assert.Throws<ArgumentException>(() => jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.DescendingOrder.ElementsSumInRowsComparator()));
        }

        [TestCase]
        public void JaggedArraySortByRowsSumsRowNullTest()
        {
            int[][] data =
            {
                null,
                new int[1] { 17 },
                new int[3] { 19, 22, 33 }
            };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            Assert.Throws<ArgumentNullException>(() => jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.DescendingOrder.ElementsSumInRowsComparator()));
        }
        #endregion
        #region JaggedArraySortByMinElementsInRowsTests
        [TestCase]
        public void JaggedArraySortByMinElementsInRowsTest1()
        {
            int[][] data = { new int[4] { 4, 5, 6, 11 },
                             new int[2] { 7, 9 },
                             new int[3] { 1, 2, 6 } };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected = { new int[3] { 1, 2, 6 },
                                 new int[4] { 4, 5, 6, 11 },
                                 new int[2] { 7, 9 } };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.AscendingOrder.MinElementsInRowsComparator());

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMinElementsInRowsTest2()
        {
            int[][] data = { new int[4] { 4, 5, 6, 11 },
                             new int[2] { 7, 9 },
                             new int[3] { 1, 2, 6 } };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected = { new int[2] { 7, 9 },
                                 new int[4] { 4, 5, 6, 11 },
                                 new int[3] { 1, 2, 6 } };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.DescendingOrder.MinElementsInRowsComparator());

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
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected = { new int[4] { 100, 100, -150, 88 },
                                 new int[2] { -19, 22 },
                                 new int[6] { 4, 5, 6, 11, 18, -11 },
                                 new int[6] { 1, 2, 6, 1, -1, 3 },
                                 new int[5] { 7, 9, 0, 5, 1 },
                                 new int[1] { 5 } };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.AscendingOrder.MinElementsInRowsComparator());

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
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected = { new int[1] { 5 },
                                 new int[5] { 7, 9, 0, 5, 1 },
                                 new int[6] { 1, 2, 6, 1, -1, 3 },
                                 new int[6] { 4, 5, 6, 11, 18, -11 },
                                 new int[2] { -19, 22 },
                                 new int[4] { 100, 100, -150, 88 } };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.DescendingOrder.MinElementsInRowsComparator());

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMinElementsInRowsTest5()
        {
            int[][] data = { new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                             new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                             new int[7] { 4, 5, 6, -13, -22, 33, -17 } };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected = { new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                                 new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                                 new int[7] { 4, 5, 6, -13, -22, 33, -17 } };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.AscendingOrder.MinElementsInRowsComparator());

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
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected = { new int[5] { 0, 0, 0, 0, 0 },
                                 new int[3] { 0, 0, 0 },
                                 new int[5] { 0, 0, 0, 0, 0 },
                                 new int[2] { 0, 0 },
                                 new int[5] { 0, 0, 0, 0, 0 } };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.DescendingOrder.MinElementsInRowsComparator());

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMinElementsInRowsEmptyTest()
        {
            int[][] data = { };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            Assert.Throws<ArgumentException>(() => jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.AscendingOrder.MinElementsInRowsComparator()));
        }

        [TestCase]
        public void JaggedArraySortByMinElementsInRowsNullTest()
        {
            int[][] data = null;
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            Assert.Throws<ArgumentNullException>(() => jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.AscendingOrder.MinElementsInRowsComparator()));
        }

        [TestCase]
        public void JaggedArraySortByMinElementsInRowsRowEmptyTest()
        {
            int[][] data = { new int[3] { 19, 22, 33 },
                             new int[0] { },
                             new int[3] { 19, 22, 33 } };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            Assert.Throws<ArgumentException>(() => jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.AscendingOrder.MinElementsInRowsComparator()));
        }

        [TestCase]
        public void JaggedArraySortByMinElementsInRowsRowNullTest()
        {
            int[][] data = { null,
                             new int[1] { 17 },
                             new int[3] { 19, 22, 33 } };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            Assert.Throws<ArgumentNullException>(() => jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.DescendingOrder.MinElementsInRowsComparator()));
        }
        #endregion
        #region JaggedArraySortByMaxElementsInRowsTests
        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsTest1()
        {
            int[][] data = { new int[3] { 1, 2, 6 },
                             new int[2] { 7, 9 },
                             new int[4] { 4, 5, 6, 11 } };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected = { new int[3] { 1, 2, 6 },
                                 new int[2] { 7, 9 },
                                 new int[4] { 4, 5, 6, 11 } };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.AscendingOrder.MaxElementsInRowsComparator());

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsTest2()
        {
            int[][] data = { new int[4] { 4, 5, 6, 11 },
                             new int[2] { 7, 9 },
                             new int[3] { 1, 2, 6 } };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected = { new int[4] { 4, 5, 6, 11 },
                                 new int[2] { 7, 9 },
                                 new int[3] { 1, 2, 6 } };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.DescendingOrder.MaxElementsInRowsComparator());

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
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected = { new int[1] { 5 },
                                 new int[6] { 1, 2, 6, 1, -1, 3 },
                                 new int[5] { 7, 9, 0, 5, 1 },
                                 new int[6] { 4, 5, 6, 11, 18, -11 },
                                 new int[2] { -19, 22 },
                                 new int[4] { 100, 100, -150, 88 } };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.AscendingOrder.MaxElementsInRowsComparator());

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
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected = { new int[4] { 100, 100, -150, 88 },
                                 new int[2] { -19, 22 },
                                 new int[6] { 4, 5, 6, 11, 18, -11 },
                                 new int[5] { 7, 9, 0, 5, 1 },
                                 new int[6] { 1, 2, 6, 1, -1, 3 },
                                 new int[1] { 5 } };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.DescendingOrder.MaxElementsInRowsComparator());

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsTest5()
        {
            int[][] data = { new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                             new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                             new int[7] { 4, 5, 6, -13, -22, 33, -17 } };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected = { new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                                 new int[7] { 4, 5, 6, -13, -22, 33, -17 },
                                 new int[7] { 4, 5, 6, -13, -22, 33, -17 } };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.AscendingOrder.MaxElementsInRowsComparator());

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
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            int[][] expected = { new int[5] { 0, 0, 0, 0, 0 },
                                 new int[3] { 0, 0, 0 },
                                 new int[5] { 0, 0, 0, 0, 0 },
                                 new int[2] { 0, 0 },
                                 new int[5] { 0, 0, 0, 0, 0 } };
            int[][] actual = jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.DescendingOrder.MaxElementsInRowsComparator());

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsEmptyTest()
        {
            int[][] data = { };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            Assert.Throws<ArgumentException>(() => jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.AscendingOrder.MaxElementsInRowsComparator()));
        }

        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsNullTest()
        {
            int[][] data = null;
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            Assert.Throws<ArgumentNullException>(() => jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.AscendingOrder.MaxElementsInRowsComparator()));
        }

        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsRowEmptyTest()
        {
            int[][] data = { new int[3] { 19, 22, 33 },
                             new int[0] { },
                             new int[3] { 19, 22, 33 } };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            Assert.Throws<ArgumentException>(() => jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.DescendingOrder.MaxElementsInRowsComparator()));
        }

        [TestCase]
        public void JaggedArraySortByMaxElementsInRowsRowNullTest()
        {
            int[][] data = { null,
                             new int[1] { 17 },
                             new int[3] { 19, 22, 33 } };
            JaggedArrayOperations jaggedArray = new JaggedArrayOperations(data);

            Assert.Throws<ArgumentNullException>(() => jaggedArray.SortWithTheHelpOfComparator(new JaggedArrayOperations.DescendingOrder.MaxElementsInRowsComparator()));
        }
        #endregion
        #region BookStringRepresentationTests
        [TestCase]
        public void BookStringRepresentationTest1()
        {
            Book book = new Book(19573924, "Author", "Name", 2, 2019, 100, 55.5);
            BookTags[] bookTags = new BookTags[]
            {
                BookTags.Name,
                BookTags.Price,
                BookTags.Edition
            };

            string expected = "Name: Name\nPrice: 55,5$\nEdition: 2\n";
            string actual = book.GetStringRepresentation(bookTags);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BookStringRepresentationTest2()
        {
            Book book = new Book(19573924, "Author", "Name", 2, 2019, 100, 55.5);
            BookTags[] bookTags = new BookTags[]
            {
                BookTags.Price,
                BookTags.Name,
                BookTags.Author,
                BookTags.EditionYear
            };

            string expected = "Price: 55,5$\nName: Name\nAuthor: Author\nEditionYear: 2019\n";
            string actual = book.GetStringRepresentation(bookTags);

            Assert.AreEqual(expected, actual);
        }
        #endregion
        #region EditableBookTests
        [TestCase]
        public void EditableBookTest1()
        {
            Book book = new Book(19573924, "Author", "Name", 2, 2019, 100, 55.5);
            EditableBook editableBook = new EditableBook(book);
            editableBook.Author = "New Author";
            editableBook.Price = 10;

            bool expected = true;
            bool actual = editableBook.Price == 10 && editableBook.Author == "New Author";

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EditableBookTest2()
        {
            Book book = new Book(19573924, "Author", "Name", 2, 2019, 100, 55.5);
            EditableBook editableBook = new EditableBook(book);
            editableBook.Name = "New Name";
            editableBook.Author = "New Author";
            editableBook.Price = 50;
            editableBook.EditionYear = 1995;

            bool expected = true;
            bool actual = editableBook.Price == 50 && editableBook.Author == "New Author" && editableBook.Name == "New Name" && editableBook.EditionYear == 1995;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EditableBookTest3()
        {
            Book book = new Book(19573924, "Author", "Name", 2, 2019, 100, 55.5);
            EditableBook editableBook = new EditableBook(book);
            editableBook.Name = "New Name";
            editableBook.Author = "New Author1";
            editableBook.Price = 50;
            editableBook.EditionYear = 1995;

            bool expected = false;
            bool actual = editableBook.Price == 50 && editableBook.Author == "New Author" && editableBook.Name == "New Name" && editableBook.EditionYear == 1995;

            Assert.AreEqual(expected, actual);
        }
        #endregion
        #region GCDAfterRefactoringTests
        [TestCase]
        public void EuclideanAlgorithmTest1()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 3;
            int actual = gcdFinder.Find(true, 3, 6);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclideanAlgorithmTest2()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 3;
            int actual = gcdFinder.Find(true, 18, 6, 3);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclideanAlgorithmTest3()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 106;
            int actual = gcdFinder.Find(true, 106, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclideanAlgorithmTest4()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 1;
            int actual = gcdFinder.Find(true, 105, 95, 107, 22, 14);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclideanAlgorithmTest5()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 1;
            int actual = gcdFinder.Find(true, int.MaxValue, 17);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclideanAlgorithmTest6()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 17;
            int actual = gcdFinder.Find(true, -34, 68, -136, 17, -272);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclideanAlgorithmTest7()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 1221;
            int actual = gcdFinder.Find(true, -0, 0, -0, 1221, 0, -0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclideanAlgorithmTest8()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 1;
            int actual = gcdFinder.Find(true, 123451, 1231246, -34698693, 12364568, -124752344, -1231245, 9999999);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclideanAlgorithmTest9()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 100;
            int actual = gcdFinder.Find(true, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclideanAlgorithmMinimalIntTest1()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.Find(true, 256, int.MinValue), "Value can't be equal to minimal integer.");
        }

        [TestCase]
        public void EuclideanAlgorithmWithMinimalIntTest2()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.Find(true, int.MaxValue, int.MinValue), "Value can't be equal to minimal integer.");
        }

        [TestCase]
        public void EuclideanAlgorithmOneArgumentTest()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.Find(true, 11), "There should be at least 2 numbers.");
        }

        [TestCase]
        public void EuclideanAlgorithmZeroArgumentsTest()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.Find(true), "There should be at least 2 numbers.");
        }

        [TestCase]
        public void EuclideanAlgorithmZeroArgumentAllZerosTest1()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.Find(true, 0, 0), "All arguments can't be equal to 0 at the same time.");
        }

        [TestCase]
        public void EuclideanAlgorithmZeroArgumentAllZerosTest2()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.Find(true, 0, 0, 0, 0, 0, 0, 0, 0), "All arguments can't be equal to 0 at the same time.");
        }
        #endregion
        #region GCD_BinaryGCDAlgorithmTests
        [TestCase]
        public void BinaryGCDAlgorithmTest1()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 3;
            int actual = gcdFinder.Find(false, 3, 6);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmTest2()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 3;
            int actual = gcdFinder.Find(false, 18, 6, 3);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmTest3()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 106;
            int actual = gcdFinder.Find(false, 106, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmTest4()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 1;
            int actual = gcdFinder.Find(false, 105, 95, 107, 22, 14);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmTest5()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 1;
            int actual = gcdFinder.Find(false, int.MaxValue, 17);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmTest6()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 17;
            int actual = gcdFinder.Find(false, -34, 68, -136, 17, -272);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmTest7()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 1221;
            int actual = gcdFinder.Find(false, -0, 0, -0, 1221, 0, -0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmTest8()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 1;
            int actual = gcdFinder.Find(false, 123451, 1231246, -34698693, 12364568, -124752344, -1231245, 9999999);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmTest9()
        {
            GCDFinder gcdFinder = new GCDFinder();

            int expected = 100;
            int actual = gcdFinder.Find(false, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDAlgorithmMinimalIntTest1()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.Find(false, 256, int.MinValue), "Value can't be equal to minimal integer.");
        }

        [TestCase]
        public void BinaryGCDAlgorithmWithMinimalIntTest2()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.Find(false, int.MaxValue, int.MinValue), "Value can't be equal to minimal integer.");
        }

        [TestCase]
        public void BinaryGCDnAlgorithmOneArgumentTest()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.Find(false, 11), "There should be at least 2 numbers.");
        }

        [TestCase]
        public void BinaryGCDAlgorithmZeroArgumentsTest()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.Find(false), "There should be at least 2 numbers.");
        }

        [TestCase]
        public void BinaryGCDAlgorithmZeroArgumentAllZerosTest1()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.Find(false, 0, 0), "All arguments can't be equal to 0 at the same time.");
        }

        [TestCase]
        public void BinaryGCDAlgorithmZeroArgumentAllZerosTest2()
        {
            GCDFinder gcdFinder = new GCDFinder();

            Assert.Throws<ArgumentException>(() => gcdFinder.Find(false, 0, 0, 0, 0, 0, 0, 0, 0), "All arguments can't be equal to 0 at the same time.");
        }
        #endregion
    }
}