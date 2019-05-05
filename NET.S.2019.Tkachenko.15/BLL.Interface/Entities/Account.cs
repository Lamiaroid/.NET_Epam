using AccountTypes;
using System;

namespace BLL.Interface.Entities
{
    public class Account
    {
        public string ID
        {
            get;
            private set;
        }

        public AccountType Type
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

        public Account(string id, AccountType type, string name, string surname, int cash, int bonus)
        {
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
        public void Replenish(int cash)
        {
            if (cash <= 0)
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
        public void WriteOff(int cash)
        {
            if (cash <= 0)
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
        private int GetBonusPoints(int cash) => ((Cash + cash) / (Cash + 1)) * (int)Type;
    }
}