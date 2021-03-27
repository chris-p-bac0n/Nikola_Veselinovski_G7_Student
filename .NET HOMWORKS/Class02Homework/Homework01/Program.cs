using System;

namespace Homework01
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
                    Console.WriteLine("Your FIRST input is not a number!");
                    Console.Beep();
                } else {
                    Console.WriteLine("Your SECOND input is not a number!");
                    Console.Beep();
                }
            }
            else
            {
                int numberToDisplay = numberOne > numberTwo ? numberOne : numberTwo;

                Console.WriteLine("The larger number is " + numberToDisplay + "!");

                if (numberToDisplay % 2 == 0)
                {
                    Console.WriteLine("And that number is even!");
                }
                else
                {
                    Console.WriteLine("And that number is odd");
                }
            }
            }
    }
}
