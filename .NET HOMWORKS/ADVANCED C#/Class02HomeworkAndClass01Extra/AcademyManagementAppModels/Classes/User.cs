using System;
using AcademyManagementAppModels.Interfaces;
using AcademyManagementAppModels.Enums;

namespace AcademyManagementAppModels
{
    public abstract class User : IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Username { get; set; }
        private string Password { get; set; }
        public int FailedLoginAttempts { get; set; }
        public bool Locked => FailedLoginAttempts >= 3;
        public UserTypeEnum UserType { get; private set; }
        public User(string firstName, string lastName, string username, string password, UserTypeEnum userType)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            UserType = userType;
            FailedLoginAttempts = 0;
        }
        public User Login(string username, string password)
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
