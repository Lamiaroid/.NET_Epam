using AccountTypes;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;
using System;
using System.Linq;

namespace ConsolePL
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

            var creditNumbers = service.GetAllAccounts();

            foreach (var acc in creditNumbers)
            {
                service.AccountReplenishment(acc, 100);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            foreach (var acc in creditNumbers)
            {
                service.AccountWriteOff(acc, 10);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
