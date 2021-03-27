using System;

namespace DaysConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of days you wish to convert:");
            string inputDays = Console.ReadLine();

            bool successfulNumberConversionOne = int.TryParse(inputDays, out int numberOfInputDays);

            if (!successfulNumberConversionOne)
            {
                Console.WriteLine("Your input is not a valid number!");
                Console.Beep();
            }
            else
            {
                int days, years, weeks;
                days = numberOfInputDays;

                years = days / 365;
                weeks = (days % 365) / 7;
                days = days - ((years * 365) + (weeks * 7));

                if (days == years && years == weeks)
                {
                    Console.WriteLine("You've entered a special number of days!");
                }
                else
                {
                    Console.WriteLine("Years:" + years);
                    Console.WriteLine("Weeks:" + weeks);
                    Console.WriteLine("Days:" + days);
                }
            }
        }
    }
}
