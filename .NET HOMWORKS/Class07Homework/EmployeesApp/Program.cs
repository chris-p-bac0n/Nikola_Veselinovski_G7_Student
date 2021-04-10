using System;
using Models;

namespace EmployeesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] company = new Employee[5];
            company[0] = new Contractor("Bob", "Bobert");
            company[1] = new Contractor("Rick", "Rickert");
            company[2] = new Manager("Mona", "Monalisa", 2000);
            company[3] = new Manager("Igor", "Igorsky", 2000);
            company[4] = new SalesPerson("Lea", "Leova", 1500);

            company[0].Responsible = (Manager)company[2];
            company[1].Responsible = (Manager)company[2];
            company[4].Responsible = (Manager)company[3];

            Console.WriteLine(company[0].CurrentPosition());

            CEO ceo = new CEO("Ron", "Ronsky", 20);
            ceo.Employees = company;
            ceo.AddSharesPrice(50);

            Console.WriteLine($"CEO:\n{ceo.PrintInfo()};");            
            Console.WriteLine($"Salary of CEO is: {ceo.GetSalary()}");
            ceo.PrintEmployees();
        }
    }
}
