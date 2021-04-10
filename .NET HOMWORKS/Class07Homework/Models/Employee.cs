using System;

namespace Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public double WorkHours { get; set; }
        public int PayPerHour { get; set; }
        public Manager Responsible { get; set; }
        public Role Role { get; set; }
        protected double Salary { get; set; }

        public Employee(string firstName, string lastName, Role role, double salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Salary = salary;
        }

        public string PrintInfo()
        {
            return $"{FullName} - {Salary}";
        }

        public virtual double GetSalary()
        {
            return Salary;
        }

        public virtual string CurrentPosition()
        {
            return $"Manager is of the {Role} department";
        }
    }
}
