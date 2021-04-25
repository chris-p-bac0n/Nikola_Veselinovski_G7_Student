using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Admin : Account
    {
        public CompanyNameEnums Company { get; set; }
        public Admin(string firstName, string lastName, string userName, string password, CompanyNameEnums companyName) :
            base(firstName, lastName, userName, password, AccountTypeEnum.Administrator)
        {
            Company = companyName;
        }

        public void PrintCompoanyInvoices(List<User> users)
        {
            Console.WriteLine($"{"Invoice Number",15} | {"Invoice Company",15} | {"Invoice Issue Date",15} | {"Invoice Due Date",15} | {"Invoice Amount",15} | {"Invoice Status",15}");

            foreach (User user in users)
            {
                foreach (Invoice invoice in user.Invoices)
                {
                    if (invoice.Company == Company)
                    {
                        Console.WriteLine($"{invoice.InvoiceNumber,15} | {invoice.Company,15} | {invoice.IssueDateInfo,15} | {invoice.DueDate.ToString("dd/MM/yyyy"),15} | {invoice.AmountToPay,15} | {invoice.InvoicePayedInfo(),15}");
                    }
                }
            }

        }
    }

    
}
