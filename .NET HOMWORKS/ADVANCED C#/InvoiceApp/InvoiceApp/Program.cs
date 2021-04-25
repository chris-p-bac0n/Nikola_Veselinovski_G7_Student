using System;
using System.Collections.Generic;
using System.Linq;
using Models;
namespace InvoiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>
            {
                new User("Miki", "Mikinson", "miki", "kwiki", 1500),
                new User("John", "Wayne", "john", "west", 2800),
                new User("Dexter", "Morgan", "dexx", "killgore", 5000)                
            };

            List<Admin> admins = new List<Admin>
            {                
                new Admin("Jimmy", "Hendrix", "jimm", "guitar", CompanyNameEnums.BEG),
                new Admin("Donald", "Duck", "don", "dck", CompanyNameEnums.EVN),
                new Admin("Mike", "Tyson", "iron", "mike", CompanyNameEnums.Vodovod)
            };

            users[0].Invoices.Add(new Invoice(CompanyNameEnums.BEG, 1500, 30));
            users[0].Invoices.Add(new Invoice(CompanyNameEnums.EVN, 500, 30));
            users[1].Invoices.Add(new Invoice(CompanyNameEnums.BEG, 1100, 30));
            users[1].Invoices.Add(new Invoice(CompanyNameEnums.Vodovod, 1800, 30));
            users[2].Invoices.Add(new Invoice(CompanyNameEnums.BEG, 1500, 30));
            users[2].Invoices.Add(new Invoice(CompanyNameEnums.EVN, 1500, 30));
            users[2].Invoices.Add(new Invoice(CompanyNameEnums.Vodovod, 1500, 30));

            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter username:");
                    string username = Console.ReadLine();
                    Console.WriteLine("Please enter password");
                    string password = Console.ReadLine();

                    Account loginUser = users.FirstOrDefault(x => x.Login(username, password) != null);
                    Account loginAdmin = admins.FirstOrDefault(x => x.Login(username, password) != null);

                    if (loginUser == null && loginAdmin == null)
                    {
                        throw new Exception("Invalid username");
                    }

                    if (loginUser != null)
                    {
                        UserUI((User)loginUser);
                    }
                    else if (loginAdmin != null)
                    {
                        AdminUI(users, (Admin)loginAdmin);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void UserUI(User loginUser)
        {
            
            while (true)
            {
                Console.WriteLine($"\n\nWelcome {loginUser.FullName}\n\nAccount Balance: {loginUser.CheckBalance()}");
                Console.WriteLine("\n\nPlease choose an option:" +
                    "\n1) Check Invoices" +
                    "\n2) Add To Balance" +
                    "\n3) Pay Invoice" +
                    "\n4) Log Out");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        loginUser.OverviewInvoices();
                        break;

                    case "2":
                        loginUser.IncreaseBalance();
                        break;

                    case "3":
                        loginUser.PayInvoice();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("\n\nInvalid input, press enter to continue:");
                        Console.ReadLine();
                        break;
                }
            }
            
        }

        static void AdminUI(List<User> users, Admin loginAdmin)
        {
            Console.WriteLine($"\n\nWelcome {loginAdmin.FullName}");
            loginAdmin.PrintCompoanyInvoices(users);
            return;
        }
    }
}