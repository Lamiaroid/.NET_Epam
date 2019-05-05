using System.Collections.Generic;

namespace DAL.Interface.Interfaces
{
    public interface IRepository
    {
        void AddAccount(DalAccount account);
        void RemoveAccount(int position);
        void UpdateAccount(DalAccount account, int position);
        List<DalAccount> GetAllAccounts();
    }
}