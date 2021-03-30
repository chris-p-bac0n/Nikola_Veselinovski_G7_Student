using System;

namespace SumOfEven
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayWithNumbers = new int[0]; 

            while (arrayWithNumbers.Length < 6)
            {
                Console.WriteLine("Please enter a number:");
                string inputNumber = Console.ReadLine();
                bool successfulNumberConversion = int.TryParse(inputNumber, out int number);

                if (successfulNumberConversion == false)
                {
                    Console.WriteLine("You must enter a number!");
                }
                else
                {
                    Array.Resize(ref arrayWithNumbers, arrayWithNumbers.Length + 1);
                    arrayWithNumbers[arrayWithNumbers.Length - 1] = number;
                }    
            }

            int sumOfEvenNumbers = 0;

            foreach (int number in arrayWithNumbers)
            {
                if (number % 2 == 0)
                {
                    sumOfEvenNumbers += number;
                }
            }

            Console.WriteLine("The result is :" + sumOfEvenNumbers);

        }
                        
    }
}
