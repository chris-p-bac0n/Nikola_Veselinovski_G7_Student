using System;
namespace Models
{
    public class CEO : Employee
    {
        public Employee[] Employees { get; set; }

        public int Shares;

        private double SharesPrice;
        public CEO(string firstName, string lastName, int shares) : base(firstName, lastName,
        Role.CEO, 1500)
        {
            Shares = shares;
        }

        public void AddSharesPrice(double number)
        {
            SharesPrice = number;
        }
        public void PrintEmployees()
        {
            Console.WriteLine("Employees:");

            foreach (Employee employee in Employees)
            {
                Console.WriteLine(employee.FullName);
            }
        }
        public override double GetSalary()
        {
            Salary += Shares * SharesPrice;
            return Salary;
        }
    }
}
