using System.Collections.Generic;
using Class01Models;

namespace Class01Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher("t01", "Pero", "pero", "pero123", "math"),
                new Teacher("t02", "Johnny", "johnny", "johnny123", "geography")
            };

            List<Student> students = new List<Student>
            {
                new Student("s01", "Miki", "miki", "miki123", "C-"),
                new Student("s02", "Mini", "mini", "mini123", "A+")
            };

            teachers[0].PrintUser();
            teachers[1].PrintUser();
            students[0].PrintUser();
            students[1].PrintUser();
        }
    }
}
