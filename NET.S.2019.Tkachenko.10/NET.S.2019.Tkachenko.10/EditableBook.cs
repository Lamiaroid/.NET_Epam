namespace NET.S._2019.Tkachenko._10
{
    using System;

    // Book with editable properties
    internal class EditableBook : Book
    {
        private int isbn;
        private string author;
        private string name;
        private int edition;
        private int editionYear;
        private int pages;
        private double price;

        public EditableBook(Book book)
            : base(book.Isbn, book.Author, book.Name, book.Edition, book.EditionYear, book.Pages, book.Price)
        {
            this.isbn = book.Isbn;
            this.author = book.Author;
            this.name = book.Name;
            this.edition = book.Edition;
            this.editionYear = book.EditionYear;
            this.pages = book.Pages;
            this.price = book.Price;
        }

        public new int Isbn
        {
            get
            {
                return this.isbn;
            }

            set
            {
                if (this.isbn < 0)
                {
                    throw new ArgumentException("Isbn can't be less than 0.");
                }

                this.isbn = value;
            }
        }

        public new string Author
        {
            get
            {
                return this.author;
            }

            set
            {
                if (this.author == null || this.author == string.Empty)
                {
                    throw new ArgumentException("Invalid author.");
                }

                this.author = value;
            }
        }

        public new string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name == null || this.name == string.Empty)
                {
                    throw new ArgumentException("Invalid name.");
                }

                this.name = value;
            }
        }

        public new int Edition
        {
            get
            {
                return this.edition;
            }

            set
            {
                if (this.edition <= 0)
                {
                    throw new ArgumentException("Edition can't be less than 0 or equal to it.");
                }

                this.edition = value;
            }
        }

        public new int EditionYear
        {
            get
            {
                return this.editionYear;
            }

            set
            {
                if (this.editionYear <= 0)
                {
                    throw new ArgumentException("Edition year can't be less than 0 or equal to it.");
                }

                this.editionYear = value;
            }
        }

        public new int Pages
        {
            get
            {
                return this.pages;
            }

            set
            {
                if (this.pages <= 0)
                {
                    throw new ArgumentException("Pages can't be less than 0 or equal to it.");
                }

                this.pages = value;
            }
        }

        public new double Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (this.price < 0)
                {
                    throw new ArgumentException("Price can't be less than 0.");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}\nAuthor: {this.Author}\nEdition: {this.Edition}\nEdition Year: {this.EditionYear}\nPages: {this.Pages}\nPrice: {this.Price}\nISBN: {this.Isbn}\n";
        }
    }
}