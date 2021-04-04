using System;

namespace AgeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool successfulDateConversion = false;

            do
            {                
                Console.WriteLine("Please enter your birtday date: (MM/DD/YYYY)");
                string inputBirthDate = Console.ReadLine();
                successfulDateConversion = DateTime.TryParse(inputBirthDate, out DateTime birthDate);

                if (!successfulDateConversion)
                {
                    Console.WriteLine("Please make sure you entered a correct date format: (MM/DD/YYYY)");
                    continue;
                }

                int userAge = AgeCalculator(birthDate);
                DateTime dateToday = DateTime.Today;

                if (dateToday.AddYears(-userAge) == birthDate)
                {
                    Console.WriteLine($"You are {userAge} years old and today is your birthday!");
                }
                else if (dateToday.AddYears(-userAge).AddDays(-1) == birthDate)
                {
                    Console.WriteLine($"You are {userAge} years old and yesterday was your birthday!");
                }
                else if (dateToday.AddYears(-userAge).AddDays(1) == birthDate)
                {
                    Console.WriteLine($"You are {userAge} years old and tommorrow is your birthday!");
                }
                else 
                {
                    Console.WriteLine($"You are {userAge} years old!");
                }
            }
            while (!successfulDateConversion);            
        }
        static int AgeCalculator(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            if (birthDate > today.AddYears(-age))
                age--;

            return age;
        }
    }
}
