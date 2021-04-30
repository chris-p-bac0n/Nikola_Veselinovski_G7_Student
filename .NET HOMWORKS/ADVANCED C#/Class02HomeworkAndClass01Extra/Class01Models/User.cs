using Class01Models.Interfaces;
using System;

namespace Class01Models
{
    public abstract class User : IUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public User(string id, string name, string username, string password)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
        }
        public virtual void PrintUser()
        {
            Console.WriteLine($"{Id,15} | {Name,15} | {Username,15}");
        }
    }
}
