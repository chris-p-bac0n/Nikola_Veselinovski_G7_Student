using System;

namespace Models
{
    public class Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Username { get; set; }
        private string Password { get; set; }
        private int FailedLoginAttempts { get; set; }
        public bool Locked => FailedLoginAttempts >= 3;
        public AccountTypeEnum AccountType { get; private set; }

        public Account(string firstName, string lastName, string userName, string password, AccountTypeEnum accountType)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = userName;
            Password = password;
            AccountType = accountType;
            FailedLoginAttempts = 0;
        }

        public Account Login(string username, string password)
        {
            if (Username != username)
            {
                return null;
            }

            if (Locked)
            {
                throw new Exception("Account locked");
            }

            if (Password != password)
            {
                FailedLoginAttempts++;
                throw new Exception("Wrong password");
            }

            FailedLoginAttempts = 0;

            return this;
        }
    }
}
