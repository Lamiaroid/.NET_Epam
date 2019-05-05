using BLL.Interface.Entities;
using DAL.Interface.Interfaces;

namespace BLL.Mappers
{
    public static class Mapper
    {
        /// <summary>
        /// Converts BLL Account to DAL Account
        /// </summary>
        public static Account ConvertToAccount(this DalAccount dalAccount)
        {
            return new Account(dalAccount.ID, dalAccount.Type, dalAccount.Name, dalAccount.Surname, dalAccount.Cash, dalAccount.Bonus);
        }

        /// <summary>
        /// Converts DAL Account to BLL Account
        /// </summary>
        public static DalAccount ConvertToDalAccount(this Account account)
        {
            return new DalAccount(account.ID, account.Type, account.Name, account.Surname, account.Cash, account.Bonus);
        }
    }
}