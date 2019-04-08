using System;
using System.Collections.Generic;
using System.IO;

namespace NET.S.Tkachenko._08
{
    static class AccountValidation
    {
        /// <summary>
        /// Checks if the input for the new account was valid
        /// </summary>
        public static void CheckInput(int id, AccountTypes type, string name, string surname, int cash, int bonus)
        {
            if (name == null || surname == null)
            {
                throw new ArgumentNullException("Null string was found.");
            }

            if (id <= 0 || cash < 0 || bonus < 0)
            {
                throw new ArgumentException("Invalid number was found.");
            }

            if (name == "" || surname == "")
            {
                throw new ArgumentException("Empty string was found.");
            }
        }
    }

    // Available account types
    public enum AccountTypes
    {
        Base = 5,
        Gold = 10,
        Platinum = 20,
    }

    class AccountSystem
    {
        private const string _accountStorageName = "AccountStorage";

        public List<BankAccount> AllAccounts
        {
            get;
            private set;
        }

        public AccountSystem()
        {
            AllAccounts = ReadData();
        }

        /// <summary>
        /// Adds new account to the collection
        /// </summary>
        public void OpenNewAccount(int id, AccountTypes type, string name, string surname, int cash, int bonus)
        {
            AccountValidation.CheckInput(id, type, name, surname, cash, bonus);

            AllAccounts.Add(new BankAccount(id, type, name, surname, cash, bonus));
        }

        /// <summary>
        /// Removes account from the collection
        /// </summary>
        public void CloseAccount(int id, AccountTypes type, string name, string surname, int cash, int bonus)
        {
            AccountValidation.CheckInput(id, type, name, surname, cash, bonus);

            int counter = 0;
            foreach (BankAccount account in AllAccounts)
            {
                if (account.ID == id &&
                    account.Type == type &&
                    account.Name == name &&
                    account.Surname == surname &&
                    account.Cash == cash &&
                    account.Bonus == bonus)
                {
                    break;
                }

                counter++;
            }

            if (counter < AllAccounts.Count)
            {
                AllAccounts.RemoveAt(counter);
            }
        }

        // Reads accounts data from file
        private List<BankAccount> ReadData()
        {
            List<BankAccount> foundBooks = new List<BankAccount>();

            if (File.Exists(Directory.GetCurrentDirectory() + _accountStorageName))
            {
                try
                {
                    using (BinaryReader br = new BinaryReader(File.Open(Directory.GetCurrentDirectory() + _accountStorageName, FileMode.Open)))
                    {
                        while (br.PeekChar() > -1)
                        {
                            foundBooks.Add(new BankAccount(br.ReadInt32(), (AccountTypes)br.ReadInt32(), br.ReadString(), br.ReadString(), br.ReadInt32(), br.ReadInt32()));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
            }

            return foundBooks;
        }

        /// <summary>
        /// Writes accounts data to file
        /// </summary>
        public void SaveData()
        {
            try
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(Directory.GetCurrentDirectory() + _accountStorageName, FileMode.Create)))
                {
                    foreach (BankAccount account in AllAccounts)
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
                throw new Exception();
            }
        }
    }

    class BankAccount
    {
        public int ID
        {
            get;
            private set;
        }

        public AccountTypes Type
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public string Surname
        {
            get;
            private set;
        }

        public int Cash
        {
            get;
            private set;
        }

        public int Bonus
        {
            get;
            private set;
        }

        public BankAccount(int id, AccountTypes type, string name, string surname, int cash, int bonus)
        {
            AccountValidation.CheckInput(id, type, name, surname, cash, bonus);

            ID = id;
            Type = type;
            Name = name;
            Surname = surname;
            Cash = cash;
            Bonus = bonus;
        }

        /// <summary>
        /// Account replenishment with the given amount of cash
        /// </summary>
        public void AccountReplenishment(int cash)
        {
            if (cash < 0)
            {
                throw new ArgumentException("Invalid amount of cash.");
            }

            try
            { 
                Cash = checked(Cash + cash);
            }
            catch
            {
                throw new OverflowException("You're trying to store too much money.");
            }

            try
            {
                Bonus = checked(Bonus + GetBonusPoints(cash));
            }
            catch
            {
                throw new OverflowException("There seems to be some problems with bonus points.");
            }
        }

        /// <summary>
        /// Account write off with the given amount of cash
        /// </summary>
        public void AccountWriteOff(int cash)
        {
            if (cash < 0)
            {
                throw new ArgumentException("Invalid amount of cash.");
            }

            if (Cash - cash >= 0)
            {
                Cash -= cash;
            }
            else
            {
                throw new ArgumentException("Not enough money.");
            }

            if (Bonus - GetBonusPoints(cash) < 0)
            {
                Bonus = 0;
            }
            else
            {
                Bonus -= GetBonusPoints(cash);
            }
        }

        // Gets string representation of all account info
        public override string ToString()
        {
            return $"ID: {ID}\nName: {Name}\nSurname: {Surname}\nAccount Type: {Type}\nCash: {Cash}\nBonus: {Bonus}\n";
        }

        // Bonus points logic
        private int GetBonusPoints(int cash) => ((Cash + cash) / Cash) * (int)Type;
    }
}