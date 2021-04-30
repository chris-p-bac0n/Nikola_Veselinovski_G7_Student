using Class01Models.Interfaces;
using System;

namespace Class01Models
{
    public class Teacher : User, ITeacher
    {
        public string Subject { get; set; }
        public Teacher(string id, string name, string username, string password, string subject) : base(id, name, username, password)
        {
            Subject = subject;
        }
        public override void PrintUser()
        {
            Console.WriteLine($"Subject: {Subject}");
        }
    }
}
