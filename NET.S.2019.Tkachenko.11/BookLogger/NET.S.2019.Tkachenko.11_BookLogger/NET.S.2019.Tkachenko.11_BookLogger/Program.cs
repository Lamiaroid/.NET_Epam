using System;

namespace NET.S._2019.Tkachenko._11
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book(1, "valve", "gabe", 13, 2010, 100, 50.99);

            BookListService bls = new BookListService();
            bls.AddBook(1, "valve", "gabe", 13, 2010, 100, 50.99);
            bls.AddBook(1, "valve", "gabe", 13, 2010, 100, 50.99);

            bls.RemoveBook(1, "volvo", "gabe", 13, 2010, 100, 50.99);

            Console.ReadLine();
        }
    }
}
