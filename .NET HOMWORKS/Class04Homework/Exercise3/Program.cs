using System;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool successfulNumberConversion = false;
            int n = 0;

            do
            {
                Console.WriteLine("Please enter a number");
                string inputNumber = Console.ReadLine();
                successfulNumberConversion = int.TryParse(inputNumber, out n);

                if (successfulNumberConversion == false || n < 1)
                {
                    Console.WriteLine("Invalid input! Please enter a number bigger than 0");
                }
            }
            while (successfulNumberConversion == false || n < 1);

            Substrings(n);

        }

        static void Substrings(int n)
        {
            string welcomeString = "Hello from SEDC Codecademy 2021";

            string newString = welcomeString.Substring(0, n);

            Console.WriteLine($"The first {n} characters are: \"{newString}\" \nAnd the lenth of that string is {newString.Length}");
        }
    }
}
