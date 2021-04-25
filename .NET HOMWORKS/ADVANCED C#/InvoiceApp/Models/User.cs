using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class User : Account
    {
        private int Balance { get; set; }
        public List<Invoice> Invoices = new List<Invoice>();
        public User(string firstName, string lastName, string userName, string password, int balance) :
            base(firstName, lastName, userName, password, AccountTypeEnum.User)
        {
            Balance = balance;
        }

        public void IncreaseBalance()
        {
            Console.WriteLine("How much would you like to depoist into your balance?");
            string amountToDeposit = Console.ReadLine();
            bool successfullConversion = int.TryParse(amountToDeposit, out int deposit);

            if (successfullConversion && deposit > 0) Balance += deposit;
            else Console.WriteLine("Invalid number!");
        }

        public void PayInvoice()
        {
            Console.WriteLine("Please enter Invoice number:");
            string inputInvoiceNumber = Console.ReadLine();
            bool successfullConversion = int.TryParse(inputInvoiceNumber, out int invoiceNumber);

            if (invoiceNumber < 100000 || invoiceNumber > 999999)
            {
                Console.WriteLine("Wrong format! The invoice format is 6 numbers");
                    return;
            }

            foreach (Invoice invoice in Invoices)
            {
                if (invoice.InvoiceNumber == invoiceNumber)
                {
                    if (invoice.InvoicePayedInfo() == InvoicePayedEnum.Payed)
                    {
                        Console.WriteLine("Invoice already payed!");
                        return;
                    }
                    else
                    {
                        if ((Balance - invoice.AmountToPay) >= 0)
                        {
                            Balance -= invoice.AmountToPay;
                            invoice.MarkInvoiceAsPayed();
                            Console.WriteLine("Invoice successfully payed!");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Insuficient funds, can't pay invoice");
                            return;
                        }
                    }
                }                                             
            }
            Console.WriteLine("Invoice not found, please check invoice number and try again");         
        }
        public void OverviewInvoices()
        {
            Console.WriteLine($"{"Invoice Number",15} | {"Invoice Company",15} | {"Invoice Due Date",15} | {"Invoice Amount",15} | {"Invoice Status",15}");

            foreach (Invoice invoice in Invoices)
            {                
                Console.WriteLine($"{invoice.InvoiceNumber, 15} | {invoice.Company, 15} | {invoice.DueDate.Date.ToString("dd/MM/yyyy"), 15} | {invoice.AmountToPay, 15} | {invoice.InvoicePayedInfo(),15}");
            }
        }
        public int CheckBalance()
        {
            return Balance;
        }
    }
}
