using AccountTypes;

namespace DAL.Interface.Interfaces
{
    public class DalAccount
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

        public DalAccount(string id, AccountType type, string name, string surname, int cash, int bonus)
        {
            ID = id;
            Type = type;
            Name = name;
            Surname = surname;
            Cash = cash;
            Bonus = bonus;
        }
    }
}