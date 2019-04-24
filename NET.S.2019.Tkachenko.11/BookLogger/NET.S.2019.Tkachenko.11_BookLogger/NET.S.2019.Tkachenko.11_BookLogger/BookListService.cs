namespace NET.S._2019.Tkachenko._11
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using NLog;

    /// <summary>
    /// Book service
    /// </summary>
    public class BookListService
    {
        private static readonly Logger bookLogger = LogManager.GetCurrentClassLogger();
        private const string BookStorageName = "BookStorage";

        public BookListService()
        {
            this.AllBooks = this.ReadData();
        }

        public List<Book> AllBooks
        {
            get;
            private set;
        }

        /// <summary>
        /// Adds new book to the collection
        /// </summary>
        /// <param name="isbn">Isbn</param>
        /// <param name="author">Author</param>
        /// <param name="name">Name</param>
        /// <param name="edition">Edition</param>
        /// <param name="editionYear">Edition year</param>
        /// <param name="pages">Number of pages</param>
        /// <param name="price">Price</param>
        public void AddBook(int isbn, string author, string name, int edition, int editionYear, int pages, double price)
        {
            BookValidation.CheckInput(isbn, author, name, edition, editionYear, pages, price);

            int position = this.BookExists(isbn, author, name, edition, editionYear, pages, price);

            if (position == -1)
            {
                this.AllBooks.Add(new Book(isbn, author, name, edition, editionYear, pages, price));
            }
            else
            {
                bookLogger.Error($"Such book already exists. ISBN: {isbn}; Author: {author}; Name: {name}; Edition: {edition}; Edition year: {editionYear}; Number of pages: {pages}; Price: {price};");
                throw new ArgumentException("Such book already exists.");
            }
        }

        /// <summary>
        /// Removes book from the collection
        /// </summary>
        /// <param name="isbn">Isbn</param>
        /// <param name="author">Author</param>
        /// <param name="name">Name</param>
        /// <param name="edition">Edition</param>
        /// <param name="editionYear">Edition year</param>
        /// <param name="pages">Number of pages</param>
        /// <param name="price">Price</param>
        public void RemoveBook(int isbn, string author, string name, int edition, int editionYear, int pages, double price)
        {
            BookValidation.CheckInput(isbn, author, name, edition, editionYear, pages, price);

            int position = this.BookExists(isbn, author, name, edition, editionYear, pages, price);

            if (position != -1)
            {
                this.AllBooks.RemoveAt(position);
            }
            else
            {
                bookLogger.Error($"The book wasn't found. ISBN: {isbn}; Author: {author}; Name: {name}; Edition: {edition}; Edition year: {editionYear}; Number of pages: {pages}; Price: {price};");
                throw new ArgumentException("The book wasn't found.");
            }
        }

        /// <summary>
        /// Finds books by one of available tags
        /// </summary>
        /// <param name="tagName">Tag name</param>
        /// <param name="tagValue">Tag value</param>
        /// <returns>List of found books</returns>
        public List<Book> FindBookByTag(BookTags tagName, string tagValue)
        {
            if (tagValue == null)
            {
                bookLogger.Error($"There was an attempt to enter a null tag");
                throw new ArgumentNullException("Tag value can't be null.");
            }

            if (tagValue == string.Empty)
            {
                bookLogger.Error($"There was an attempt to enter an empty tag");
                throw new ArgumentException("Tag value can't be empty.");
            }

            List<Book> foundBooks = new List<Book>();
            int tagDigitalValue;

            switch (tagName)
            {
                case BookTags.Isbn:
                    foreach (Book book in this.AllBooks)
                    {
                        if (book.Isbn == int.Parse(tagValue))
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.Author:
                    foreach (Book book in this.AllBooks)
                    {
                        if (book.Author == tagValue)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.Name:
                    foreach (Book book in this.AllBooks)
                    {
                        if (book.Name == tagValue)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.Edition:
                    tagDigitalValue = this.GetTagValueDigitalRepresentation(tagValue);

                    foreach (Book book in this.AllBooks)
                    {
                        if (book.Edition == tagDigitalValue)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.EditionYear:
                    tagDigitalValue = this.GetTagValueDigitalRepresentation(tagValue);

                    foreach (Book book in this.AllBooks)
                    {
                        if (book.EditionYear == tagDigitalValue)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.Pages:
                    tagDigitalValue = this.GetTagValueDigitalRepresentation(tagValue);

                    foreach (Book book in this.AllBooks)
                    {
                        if (book.Pages == tagDigitalValue)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.Price:
                    double tagValuePrice;

                    try
                    {
                        tagValuePrice = double.Parse(tagValue);
                    }
                    catch
                    {
                        bookLogger.Error("There was an attempt to convert string to double, but it failed due to invalid double value.");
                        throw new ArgumentException("Invalid double value.");
                    }

                    foreach (Book book in this.AllBooks)
                    {
                        if (book.Price == tagValuePrice)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;
            }

            return foundBooks;
        }

        /// <summary>
        /// Sorts books by one of available tags
        /// </summary>
        /// <param name="tagName">Tag name</param>
        public void SortBooksByTag(BookTags tagName)
        {
            switch (tagName)
            {
                case BookTags.Isbn:
                    this.AllBooks = this.AllBooks.OrderBy(orderTag => orderTag.Isbn).ToList();
                    break;

                case BookTags.Name:
                    this.AllBooks = this.AllBooks.OrderBy(orderTag => orderTag.Name).ToList();
                    break;

                case BookTags.Author:
                    this.AllBooks = this.AllBooks.OrderBy(orderTag => orderTag.Author).ToList();
                    break;

                case BookTags.Edition:
                    this.AllBooks = this.AllBooks.OrderBy(orderTag => orderTag.Edition).ToList();
                    break;

                case BookTags.EditionYear:
                    this.AllBooks = this.AllBooks.OrderBy(orderTag => orderTag.EditionYear).ToList();
                    break;

                case BookTags.Pages:
                    this.AllBooks = this.AllBooks.OrderBy(orderTag => orderTag.Pages).ToList();
                    break;

                case BookTags.Price:
                    this.AllBooks = this.AllBooks.OrderBy(orderTag => orderTag.Price).ToList();
                    break;
            }
        }

        /// <summary>
        /// Writes book data to storage
        /// </summary>
        public void SaveData()
        {
            try
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(Directory.GetCurrentDirectory() + BookStorageName, FileMode.Create)))
                {
                    foreach (Book book in this.AllBooks)
                    {
                        bw.Write(book.Isbn);
                        bw.Write(book.Author);
                        bw.Write(book.Name);
                        bw.Write(book.Edition);
                        bw.Write(book.EditionYear);
                        bw.Write(book.Pages);
                        bw.Write(book.Price);
                    }
                }
            }
            catch (Exception ex)
            {
                bookLogger.Fatal(ex.Message);
                throw new Exception();
            }
        }

        // Reads books data from storage
        private List<Book> ReadData()
        {
            List<Book> foundBooks = new List<Book>();

            if (File.Exists(Directory.GetCurrentDirectory() + BookStorageName))
            {
                try
                {
                    using (BinaryReader br = new BinaryReader(File.Open(Directory.GetCurrentDirectory() + BookStorageName, FileMode.Open)))
                    {
                        while (br.PeekChar() > -1)
                        {
                            foundBooks.Add(new Book(br.ReadInt32(), br.ReadString(), br.ReadString(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadDouble()));
                        }
                    }
                }
                catch (Exception ex)
                {
                    bookLogger.Fatal(ex.Message);
                    throw new Exception();
                }
            }

            return foundBooks;
        }

        /// <summary>
        /// Checks if the books exists. Returns -1 if book was not found or it's position if book was found
        /// </summary>
        /// <param name="isbn">Isbn</param>
        /// <param name="author">Author</param>
        /// <param name="name">Name</param>
        /// <param name="edition">Edition</param>
        /// <param name="editionYear">Edition year</param>
        /// <param name="pages">Number of pages</param>
        /// <param name="price">Price</param>
        /// <returns>The book position if it exists, -1 if not</returns>
        private int BookExists(int isbn, string author, string name, int edition, int editionYear, int pages, double price)
        {
            int position = 0;

            foreach (Book book in this.AllBooks)
            {
                if (book.Isbn == isbn &&
                    book.Name == name &&
                    book.Author == author &&
                    book.Edition == edition &&
                    book.EditionYear == editionYear &&
                    book.Pages == pages &&
                    book.Price == price)
                {
                    return position;
                }

                position++;
            }

            return -1;
        }

        // Gets digital representation of tag value (used in some int cases)
        private int GetTagValueDigitalRepresentation(string tagValue)
        {
            try
            {
                return int.Parse(tagValue);
            }
            catch
            {
                bookLogger.Error("There was an attempt to convert string to integer, but it failed due to invalid integer value.");
                throw new ArgumentException();
            }
        }
    }
}