using AccountTypes;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;
using System;

namespace NET.S._2019.Tkachenko._15
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {      
            IAccountService service = resolver.Get<IAccountService>();
            IAccountGenerateID creator = resolver.Get<IAccountGenerateID>();

            service.OpenNewAccount(creator.GenerateID(), AccountType.Base, "Alexey", "Sidorov", 0, 0);
            service.OpenNewAccount(creator.GenerateID(), AccountType.Base, "John", "Newman", 1000, 10);
            service.OpenNewAccount(creator.GenerateID(), AccountType.Gold, "Keron", "Walsen", 250, 0);
            service.OpenNewAccount(creator.GenerateID(), AccountType.Base, "Alisa", "Dvachevskaya", 330, 50);
            
            var accounts = service.GetAllAccounts();

            foreach (var acc in accounts)
            {
                service.AccountReplenishment(acc, 100);
            }

            foreach (var acc in accounts)
            {
                Console.WriteLine(acc);
            }

            foreach (var acc in accounts)
            {
                service.AccountWriteOff(acc, 10);
            }

            foreach (var acc in accounts)
            {
                Console.WriteLine(acc);
            }

            Console.ReadLine();
        }
    }
}