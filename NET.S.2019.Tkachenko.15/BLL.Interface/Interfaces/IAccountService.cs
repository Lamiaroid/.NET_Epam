using AccountTypes;
using BLL.Interface.Entities;
using System.Collections.Generic;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        void OpenNewAccount(string id, AccountType type, string name, string surname, int cash, int bonus);
        void OpenNewAccount(IAccountGenerateID generator, AccountType type, string name, string surname, int cash, int bonus);
        void CloseAccount(string id);
        void CloseAccount(Account account);
        void AccountReplenishment(string id, int cash);
        void AccountReplenishment(Account account, int cash);
        void AccountWriteOff(string id, int cash);
        void AccountWriteOff(Account account, int cash);
        List<Account> GetAllAccounts();
    }
}