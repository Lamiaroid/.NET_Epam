using AccountTypes;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Validation;
using BLL.Mappers;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private IRepository _accountRepository;

        private List<Account> _allAccounts = new List<Account>();

        public AccountService(IRepository accountRepository)
        {
            _accountRepository = accountRepository;

            foreach (var acc in _accountRepository.GetAllAccounts())
            {
                _allAccounts.Add(acc.ConvertToAccount());
            }
        }

        /// <summary>
        /// Adds new account to the list
        /// </summary>
        public void OpenNewAccount(string id, AccountType type, string name, string surname, int cash, int bonus)
        {
            AccountValidation.CheckInput(id, type, name, surname, cash, bonus);

            Account account = new Account(id, type, name, surname, cash, bonus);
            _allAccounts.Add(account);
            _accountRepository.AddAccount(account.ConvertToDalAccount());
        }

        /// <summary>
        /// Adds new account to the list
        /// </summary>
        public void OpenNewAccount(IAccountGenerateID generator, AccountType type, string name, string surname, int cash, int bonus)
        {
            if (generator == null)
            {
                throw new ArgumentNullException();
            }

            string id = generator.GenerateID();

            AccountValidation.CheckInput(id, type, name, surname, cash, bonus);

            Account account = new Account(id, type, name, surname, cash, bonus);
            _allAccounts.Add(account);
            _accountRepository.AddAccount(account.ConvertToDalAccount());
        }

        /// <summary>
        /// Removes account from the list by account id
        /// </summary>
        public void CloseAccount(string id)
        {
            AccountValidation.CheckInput(id);

            int position = findAccountPosition(id);
            if (position != -1)
            {
                _allAccounts.RemoveAt(position);
                _accountRepository.RemoveAccount(position);
            }
        }

        /// <summary>
        /// Removes account from the list by account
        /// </summary>
        public void CloseAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            int position = findAccountPosition(account);
            if (position != -1)
            {
                _allAccounts.RemoveAt(position);
                _accountRepository.RemoveAccount(position);
            }
        }

        /// <summary>
        /// Account replenishment with the given amount of cash by account id
        /// </summary>
        public void AccountReplenishment(string id, int cash)
        {
            AccountValidation.CheckInput(id);

            int position = findAccountPosition(id);
            if (position != -1)
            {
                _allAccounts[position].Replenish(cash);
                _accountRepository.UpdateAccount(_allAccounts[position].ConvertToDalAccount(), position);
            }
        }

        /// <summary>
        /// Account replenishment with the given amount of cash by account
        /// </summary>
        public void AccountReplenishment(Account account, int cash)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            int position = findAccountPosition(account);
            if (position != -1)
            {
                _allAccounts[position].Replenish(cash);
                _accountRepository.UpdateAccount(_allAccounts[position].ConvertToDalAccount(), position);
            }
        }

        /// <summary>
        /// Account write off with the given amount of cash by account id
        /// </summary>
        public void AccountWriteOff(string id, int cash)
        {
            AccountValidation.CheckInput(id);

            int position = findAccountPosition(id);
            if (position != -1)
            {
                _allAccounts[position].WriteOff(cash);
                _accountRepository.UpdateAccount(_allAccounts[position].ConvertToDalAccount(), position);
            }
        }

        /// <summary>
        /// Account write off with the given amount of cash by account
        /// </summary>
        public void AccountWriteOff(Account account, int cash)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            int position = findAccountPosition(account);
            if (position != -1)
            {
                _allAccounts[position].WriteOff(cash);
                _accountRepository.UpdateAccount(_allAccounts[position].ConvertToDalAccount(), position);
            }
        }

        /// <summary>
        /// Returns accounts list
        /// </summary>
        public List<Account> GetAllAccounts()
        {
            return _allAccounts;
        }

        // Finds account's position in list by id
        private int findAccountPosition(string id)
        {
            int counter = 0;

            foreach (Account account in _allAccounts)
            {
                if (account.ID == id)
                {
                    break;
                }
                counter++;
            }

            if (counter < _allAccounts.Count)
            {
                return counter;
            }

            return -1;
        }

        /// Finds account's position in list
        private int findAccountPosition(Account account)
        {
            int counter = 0;

            foreach (Account acc in _allAccounts)
            {
                if (account.ID == acc.ID)
                {
                    break;
                }
                counter++;
            }

            if (counter < _allAccounts.Count)
            {
                return counter;
            }

            return -1;
        }
    }
}