using AccountTypes;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace DAL.Repositories
{
    public class AccountRepository : IRepository
    {
        private const string _accountStorageName = "AccountStorage";

        private List<DalAccount> _allAccounts;

        public AccountRepository()
        {
            _allAccounts = ReadData();
        }

        /// <summary>
        /// Adds new account to the account storage
        /// </summary>
        public void AddAccount(DalAccount account)
        {
            AccountNullChecker(account);

            _allAccounts.Add(account);
            SaveData();
        }

        /// <summary>
        /// Removes account from the account storage
        /// </summary>
        public void RemoveAccount(int position)
        {
            _allAccounts.RemoveAt(position);
            SaveData();
        }

        /// <summary>
        /// Updares account in the account storage
        /// </summary>
        public void UpdateAccount(DalAccount account, int position)
        {
            AccountNullChecker(account);

            _allAccounts[position] = account;
            SaveData();
        }

        /// <summary>
        /// Receives all accounts from the account storage
        /// </summary>
        public List<DalAccount> GetAllAccounts()
        {
            _allAccounts = ReadData();
            return _allAccounts;
        }
    
        // Reads account data from accounts storage
        private List<DalAccount> ReadData()
        {
            List<DalAccount> foundAccounts = new List<DalAccount>();

            if (File.Exists(Directory.GetCurrentDirectory() + _accountStorageName))
            {
                try
                {
                    using (BinaryReader br = new BinaryReader(File.Open(Directory.GetCurrentDirectory() + _accountStorageName, FileMode.Open)))
                    {
                        while (br.PeekChar() > -1)
                        {
                            foundAccounts.Add(new DalAccount(br.ReadString(), (AccountType)br.ReadInt32(), br.ReadString(), br.ReadString(), br.ReadInt32(), br.ReadInt32()));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return foundAccounts;
        }

        // Saves account data to accounts storage
        private void SaveData()
        {
            try
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(Directory.GetCurrentDirectory() + _accountStorageName, FileMode.Create)))
                {
                    foreach (DalAccount account in _allAccounts)
                    {
                        bw.Write(account.ID);
                        bw.Write((int)account.Type);
                        bw.Write(account.Name);
                        bw.Write(account.Surname);
                        bw.Write(account.Cash);
                        bw.Write(account.Bonus);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AccountNullChecker(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}