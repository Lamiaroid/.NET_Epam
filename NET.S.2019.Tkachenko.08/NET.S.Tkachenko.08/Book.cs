using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace NET.S.Tkachenko._08
{
    static class BookValidation
    {
        /// <summary>
        /// Checks if the input for the new book was valid
        /// </summary>
        public static void CheckInput(int isbn, string author, string name, int edition, int editionYear, int pages, double price)
        {
            if (name == null || author == null)
            {
                throw new ArgumentNullException("Null string was found.");
            }

            if (isbn <= 0 || edition <= 0 || editionYear <= 0 || pages <= 0 || price < 0)
            {
                throw new ArgumentException("Invalid number was found.");
            }

            if (name == "" || author == "")
            {
                throw new ArgumentException("Empty string was found.");
            }
        }
    }

    /// <summary>
    /// Book service
    /// </summary>
    class BookListService
    {
        private const string _bookStorageName = "BookStorage";

        // Available book tags
        public enum BookTags
        {
            isbn,
            author,
            name, 
            edition,
            editionYear,
            pages,
            price,
        }

        public List<Book> AllBooks
        {
            get;
            private set;
        }

        public BookListService()
        {
            AllBooks = ReadData();
        }       

        /// <summary>
        /// Adds new book to the collection
        /// </summary>
        public void AddBook(int isbn, string author, string name, int edition, int editionYear, int pages, double price)
        {
            BookValidation.CheckInput(isbn, author, name, edition, editionYear, pages, price);

            int position = BookExists(isbn, author, name, edition, editionYear, pages, price);

            if (position == -1)
            {
                AllBooks.Add(new Book(isbn, author, name, edition, editionYear, pages, price));
            }
            else
            {
                throw new ArgumentException("Such book already exists.");
            }
        }

        /// <summary>
        /// Removes book from the collection
        /// </summary>
        public void RemoveBook(int isbn, string author, string name, int edition, int editionYear, int pages, double price)
        {
            BookValidation.CheckInput(isbn, author, name, edition, editionYear, pages, price);

            int position = BookExists(isbn, author, name, edition, editionYear, pages, price);

            if (position != -1)
            {
                AllBooks.RemoveAt(position);
            }
            else
            {
                throw new ArgumentException("The book wasn't found.");
            }
        }

        /// <summary>
        /// Checks if the books exists. Returns -1 if book was not found or it's position if book was found
        /// </summary>
        private int BookExists(int isbn, string author, string name, int edition, int editionYear, int pages, double price)
        {
            int position = 0;

            foreach (Book book in AllBooks)
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

        /// <summary>
        /// Finds books by one of available tags
        /// </summary>
        public List<Book> FindBookByTag(BookTags tagName, string tagValue)
        {
            if (tagValue == null)
            {
                throw new ArgumentNullException("Tag value can't be null.");
            }

            if (tagValue == "")
            {
                throw new ArgumentException("Tag value can't be empty.");
            }

            List<Book> foundBooks = new List<Book>();
            int tagDigitalValue;

            switch (tagName)
            {
                case BookTags.isbn:
                    foreach (Book book in AllBooks)
                    {
                        if (book.Isbn == int.Parse(tagValue))
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.author:
                    foreach (Book book in AllBooks)
                    {
                        if (book.Author == tagValue)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.name:
                    foreach (Book book in AllBooks)
                    {
                        if (book.Name == tagValue)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.edition:
                    tagDigitalValue = GetTagValueDigitalRepresentation(tagValue);

                    foreach (Book book in AllBooks)
                    {
                        if (book.Edition == tagDigitalValue)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.editionYear:
                    tagDigitalValue = GetTagValueDigitalRepresentation(tagValue);

                    foreach (Book book in AllBooks)
                    {
                        if (book.EditionYear == tagDigitalValue)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.pages:
                    tagDigitalValue = GetTagValueDigitalRepresentation(tagValue);

                    foreach (Book book in AllBooks)
                    {
                        if (book.Pages == tagDigitalValue)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.price:
                    double tagValuePrice;

                    try
                    {
                        tagValuePrice = double.Parse(tagValue);
                    }
                    catch
                    {
                        throw new ArgumentException("Invalid double value.");
                    }

                    foreach (Book book in AllBooks)
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

        // Gets digital representation of tag value (used in some int cases)
        private int GetTagValueDigitalRepresentation(string tagValue)
        {
            try
            {
                return int.Parse(tagValue);
            }
            catch
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Sorts books by one of available tags
        /// </summary>
        public void SortBooksByTag(BookTags tagName)
        {
            switch (tagName)
            {
                case BookTags.isbn:
                    AllBooks = AllBooks.OrderBy(orderTag => orderTag.Isbn).ToList();
                    break;

                case BookTags.name:
                    AllBooks = AllBooks.OrderBy(orderTag => orderTag.Name).ToList();
                    break;

                case BookTags.author:
                    AllBooks = AllBooks.OrderBy(orderTag => orderTag.Author).ToList();
                    break;

                case BookTags.edition:
                    AllBooks = AllBooks.OrderBy(orderTag => orderTag.Edition).ToList();
                    break;

                case BookTags.editionYear:
                    AllBooks = AllBooks.OrderBy(orderTag => orderTag.EditionYear).ToList();
                    break;

                case BookTags.pages:
                    AllBooks = AllBooks.OrderBy(orderTag => orderTag.Pages).ToList();
                    break;

                case BookTags.price:
                    AllBooks = AllBooks.OrderBy(orderTag => orderTag.Price).ToList();
                    break;
            }
        }

        // Reads books data from storage
        private List<Book> ReadData()
        {
            List<Book> foundBooks = new List<Book>();

            if (File.Exists(Directory.GetCurrentDirectory() + _bookStorageName))
            {
                try
                {
                    using (BinaryReader br = new BinaryReader(File.Open(Directory.GetCurrentDirectory() + _bookStorageName, FileMode.Open)))
                    {
                        while (br.PeekChar() > -1)
                        {
                            foundBooks.Add(new Book(br.ReadInt32(), br.ReadString(), br.ReadString(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadDouble()));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
            }

            return foundBooks;
        }

        /// <summary>
        /// Writes book data to storage
        /// </summary>
        public void SaveData()
        {
            try
            { 
                using (BinaryWriter bw = new BinaryWriter(File.Open(Directory.GetCurrentDirectory() + _bookStorageName, FileMode.Create)))
                {
                    foreach (Book book in AllBooks)
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
                throw new Exception();
            }
        }
    }

    class Book : IComparable
    {
        public int Isbn
        {
            get;
            private set;
        }

        public string Author
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public int Edition
        {
            get;
            private set;
        }

        public int EditionYear
        {
            get;
            private set;
        }

        public int Pages
        {
            get;
            private set;
        }

        public double Price
        {
            get;
            private set;
        }

        public Book(int isbn, string author, string name, int edition, int editionYear, int pages, double price)
        {
            BookValidation.CheckInput(isbn, author, name, edition, editionYear, pages, price);

            Isbn = isbn;
            Author = author;
            Name = name;
            Edition = edition;
            EditionYear = editionYear;
            Pages = pages;
            Price = price;
        }

        // Below can be found overloads of operators for the Book class
        public static bool operator <(Book bookA, Book bookB)
        {
            return bookA.Pages < bookB.Pages;
        }

        public static bool operator >(Book bookA, Book bookB)
        {
            return bookA.Pages > bookB.Pages;
        }

        public static bool operator <=(Book bookA, Book bookB)
        {
            return bookA.Pages <= bookB.Pages;
        }

        public static bool operator >=(Book bookA, Book bookB)
        {
            return bookA.Pages >= bookB.Pages;
        }

        public static bool operator ==(Book bookA, Book bookB)
        {
            return bookA.Pages == bookB.Pages;
        }

        public static bool operator !=(Book bookA, Book bookB)
        {
            return bookA.Pages != bookB.Pages;
        }

        // Below can be found overloads of the Object class methods
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType() || obj == null)
            {
                return false;
            }

            Book book = (Book)obj;

            return (book.Isbn == this.Isbn &&
                    book.Author == this.Author &&
                    book.Name == this.Name &&
                    book.Edition == this.Edition &&
                    book.EditionYear == this.EditionYear &&
                    book.Pages == this.Pages &&
                    book.Price == this.Price);
        }

        public override int GetHashCode()
        {
            const int number = 15;
            int hashCode = 3;
            hashCode = hashCode * Isbn.GetHashCode() + number;
            hashCode = hashCode * Author.GetHashCode() + number;
            hashCode = hashCode * Name.GetHashCode() + number;
            hashCode = hashCode * Edition.GetHashCode() + number;
            hashCode = hashCode * EditionYear.GetHashCode() + number;
            hashCode = hashCode * Pages.GetHashCode() + number;
            hashCode = hashCode * Price.GetHashCode() + number;
            return hashCode;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nAuthor: {Author}\nEdition: {Edition}\nEdition Year: {EditionYear}\nPages: {Pages}\nPrice: {Price}\nISBN: {Isbn}\n";
        }

        // Implementation of IComparable interface
        public int CompareTo(object obj)
        {
            Book book = obj as Book;

            if (book != null)
            {
                return this.Pages.CompareTo(book.Pages);
            }
            else
            {
                throw new Exception("Unreal to compare these two objects.");
            }
        }
    }
}