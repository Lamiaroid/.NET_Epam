using AccountTypes;
using System;

namespace BLL.Validation
{
    public static class AccountValidation
    {
        /// <summary>
        /// Checks if the input for the new account was valid
        /// </summary>
        public static void CheckInput(string id, AccountType type, string name, string surname, int cash, int bonus)
        {
            if (name == null || surname == null || id == null)
            {
                throw new ArgumentNullException("Null string was found.");
            }

            if (cash < 0 || bonus < 0)
            {
                throw new ArgumentException("Invalid number was found.");
            }

            if (name == "" || surname == "")
            {
                throw new ArgumentException("Empty string was found.");
            }
        }

        /// <summary>
        /// Checks if id was valid
        /// </summary>
        public static void CheckInput(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Null string was found.");
            }
        }
    }
}