using System;
using System.Collections.Generic;

namespace NET.S.Tkachenko._08
{
    class Program
    {
        static void Main(string[] args)
        {
            #region BookService test
            BookListService bookService = new BookListService();

            bookService.AddBook(12, "Kenkou Kross", "M.G.E.", 5, 2015, 105, 66.4);
            bookService.AddBook(173, "Avalonion", "Ave Maria", 7, 1995, 2022, 100);
            bookService.AddBook(158, "Avalon", "Tree on the wood", 2, 1443, 107, 1000);
            bookService.AddBook(1889, "Xeran", "X-19", 5, 2000, 539, 1);

            Console.WriteLine("----------All Books-----------");
            foreach (Book book in bookService.AllBooks)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("------------------------------");

            bookService.SortBooksByTag(BookListService.BookTags.author);
            Console.WriteLine("----Books sorted by author-----");
            foreach (Book book in bookService.AllBooks)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("------------------------------");

            List<Book> foundBooks = bookService.FindBookByTag(BookListService.BookTags.edition, "5");
            Console.WriteLine("-----Found books by tag-------");
            foreach (Book book in foundBooks)
            { 
                Console.WriteLine(book);
            }
            Console.WriteLine("------------------------------");

            bookService.RemoveBook(173, "Avalonion", "Ave Maria", 7, 1995, 2022, 100);
            Console.WriteLine("------Removed one book--------");
            foreach (Book book in bookService.AllBooks)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("------------------------------");

            bookService.SortBooksByTag(BookListService.BookTags.price);
            Console.WriteLine("----Books sorted by price-----");
            foreach (Book book in bookService.AllBooks)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("------------------------------");

            bookService.SaveData();
            #endregion
            
            #region AccountSystem test
            AccountSystem accountSystem = new AccountSystem();

            accountSystem.OpenNewAccount(1, AccountTypes.Base, "Alexey", "Sidorov", 100, 12);
            accountSystem.OpenNewAccount(2, AccountTypes.Platinum, "Alisa", "Sidorova", 0, 10);
            accountSystem.OpenNewAccount(3, AccountTypes.Gold, "John", "Newman", 0, 0);
            accountSystem.OpenNewAccount(4, AccountTypes.Base, "Alfred", "Brown", 113, 5);

            Console.WriteLine("----------All Accounts-----------");
            foreach (BankAccount account in accountSystem.AllAccounts)
            {
                Console.WriteLine(account);
            }
            Console.WriteLine("---------------------------------");

            accountSystem.CloseAccount(2, AccountTypes.Platinum, "Alisa", "Sidorova", 0, 10);
            Console.WriteLine("--------Close one account---------");
            foreach (BankAccount account in accountSystem.AllAccounts)
            {
                Console.WriteLine(account);
            }
            Console.WriteLine("---------------------------------");

            Console.WriteLine("--------Add some cash--------");
            foreach (BankAccount account in accountSystem.AllAccounts)
            {
                if (account.Name == "Alexey" &&
                    account.ID == 1 &&
                    account.Surname == "Sidorov")
                {
                    account.AccountReplenishment(100);
                }
            }          
            foreach (BankAccount account in accountSystem.AllAccounts)
            {
                Console.WriteLine(account);
            }
            Console.WriteLine("----------------------------");

            Console.WriteLine("---------Write Off some cash-----------");
            foreach (BankAccount account in accountSystem.AllAccounts)
            {
                if (account.Name == "Alfred" &&
                    account.ID == 4 &&
                    account.Surname == "Brown")
                {
                    account.AccountWriteOff(63);
                }
            }
            foreach (BankAccount account in accountSystem.AllAccounts)
            {
                Console.WriteLine(account);
            }
            Console.WriteLine("---------------------------------------");

            accountSystem.SaveData();
            #endregion

            Console.ReadLine();
        }
    }
}
