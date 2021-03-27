using System;

namespace SwapNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the first number:");
            string inputNumberOne = Console.ReadLine();

            Console.WriteLine("Please enter the second number:");
            string inputNumberTwo = Console.ReadLine();

            bool successfulNumberConversionOne = int.TryParse(inputNumberOne, out int numberOne);
            bool successfulNumberConversionTwo = int.TryParse(inputNumberTwo, out int numberTwo);

            if (!successfulNumberConversionOne || !successfulNumberConversionTwo)
            {
                if (!successfulNumberConversionOne)
                {
                    Console.WriteLine("Your FIRST or both inputs are not valid numbers!");
                    Console.Beep();
                }
                else
                {
                    Console.WriteLine("Your SECOND or both inputs are not valid numbers!");
                    Console.Beep();
                }
            }
            else
            {
                int extra = numberOne;
                numberOne = numberTwo;
                numberTwo = extra;

                Console.WriteLine("First Number: " + numberOne);
                Console.WriteLine("Second Number: " + numberTwo);
            }
        }
    }
}
