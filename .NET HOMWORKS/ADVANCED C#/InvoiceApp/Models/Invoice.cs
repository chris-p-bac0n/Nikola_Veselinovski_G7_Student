using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Models
{
    public class Invoice
    {
        public int InvoiceNumber { get; set; }
        public CompanyNameEnums Company { get; set; }
        public int InvoiceAmount { get; set; }
        public int AmountToPay => InvoiceAmount + PenaltyPaymentAmount(DueDate);
        public DateTime IssueDate => DateTime.Now;
        public int DaysToPay { get; set; }
        public DateTime DueDate => IssueDate.AddDays(DaysToPay);
        public string IssueDateInfo => $"{IssueDate.ToString("MMM", CultureInfo.InvariantCulture)}.{IssueDate.Year}";
        private InvoicePayedEnum InvoicePayed { get; set; }
               

        public Invoice(CompanyNameEnums company, int invoiceAmount, int daysToPay)
        {
            Company = company;
            InvoiceAmount = invoiceAmount;
            DaysToPay = daysToPay;
            InvoicePayed = InvoicePayedEnum.Unpayed;
            InvoiceNumber = InvoiceNumberGenerator();
        }

        private int PenaltyPaymentAmount(DateTime dueDate)
        {
            int daysLate = (DateTime.Now - dueDate).Days *10;

            if (daysLate > 0) return daysLate;
            else return 0;
        }

        public InvoicePayedEnum InvoicePayedInfo()
        {
            return InvoicePayed;
        }

        public void MarkInvoiceAsPayed()
        {
            InvoicePayed = InvoicePayedEnum.Payed;
        }

        private int InvoiceNumberGenerator()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(100000, 999999);
            return randomNumber;
        }
    }
}
