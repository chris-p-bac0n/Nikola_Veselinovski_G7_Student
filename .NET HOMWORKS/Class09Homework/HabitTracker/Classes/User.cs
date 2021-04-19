using System;
using System.Collections.Generic;
using System.Text;

namespace HabitTracker
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<Habit> Habits = new List<Habit>();
        public User(string username, string password, string firstName, string lastName, DateTime dateOfBirth)
        {
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
    }

    
}
