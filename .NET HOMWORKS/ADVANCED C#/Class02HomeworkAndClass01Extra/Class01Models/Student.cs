using Class01Models.Interfaces;
using System;

namespace Class01Models
{
    public class Student : User, IStudent
    {
        public string Grades { get; set; }
        public Student(string id, string name, string username, string password, string grades) : base (id, name, username, password)
        {
            Grades = grades;
        }
        public override void PrintUser()
        {
            Console.WriteLine($"Grades: {Grades}");
        }
    }
}
