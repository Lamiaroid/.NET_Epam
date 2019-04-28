using System;

namespace NET.S._2019.Tkachenko._13
{
    public class Book : IComparable
    {
        public Book(int isbn, string author, string name, int edition, int editionYear, int pages, double price)
        {
            BookValidation.CheckInput(isbn, author, name, edition, editionYear, pages, price);

            this.Isbn = isbn;
            this.Author = author;
            this.Name = name;
            this.Edition = edition;
            this.EditionYear = editionYear;
            this.Pages = pages;
            this.Price = price;
        }

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

            return book.Isbn == this.Isbn &&
                   book.Author == this.Author &&
                   book.Name == this.Name &&
                   book.Edition == this.Edition &&
                   book.EditionYear == this.EditionYear &&
                   book.Pages == this.Pages &&
                   book.Price == this.Price;
        }

        public override int GetHashCode()
        {
            const int number = 15;
            int hashCode = 3;
            hashCode = (hashCode * this.Isbn.GetHashCode()) + number;
            hashCode = (hashCode * this.Author.GetHashCode()) + number;
            hashCode = (hashCode * this.Name.GetHashCode()) + number;
            hashCode = (hashCode * this.Edition.GetHashCode()) + number;
            hashCode = (hashCode * this.EditionYear.GetHashCode()) + number;
            hashCode = (hashCode * this.Pages.GetHashCode()) + number;
            hashCode = (hashCode * this.Price.GetHashCode()) + number;
            return hashCode;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}\nAuthor: {this.Author}\nEdition: {this.Edition}\nEdition Year: {this.EditionYear}\nPages: {this.Pages}\nPrice: {this.Price}\nISBN: {this.Isbn}\n";
        }

        public string GetStringRepresentation(BookTags[] tags)
        {
            if (tags.Length > BookTagsInfo.existingTagsCount)
            {
                throw new ArgumentException($"There can't be more than {BookTagsInfo.existingTagsCount} tags.");
            }

            string bookInfo = string.Empty;

            foreach (BookTags tag in tags)
            {
                switch (tag)
                {
                    case BookTags.Isbn:
                        bookInfo += $"ISBN: {this.Isbn}\n";
                        break;

                    case BookTags.Name:
                        bookInfo += $"Name: {this.Name}\n";
                        break;

                    case BookTags.Author:
                        bookInfo += $"Author: {this.Author}\n";
                        break;

                    case BookTags.Edition:
                        bookInfo += $"Edition: {this.Edition}\n";
                        break;

                    case BookTags.EditionYear:
                        bookInfo += $"EditionYear: {this.EditionYear}\n";
                        break;

                    case BookTags.Pages:
                        bookInfo += $"Pages: {this.Pages}\n";
                        break;

                    case BookTags.Price:
                        bookInfo += $"Price: {this.Price}$\n";
                        break;
                }
            }

            return bookInfo;
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