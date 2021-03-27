using System;

namespace LargestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the first number:");
            string inputNumberOne = Console.ReadLine();

            Console.WriteLine("Please enter the second number:");
            string inputNumberTwo = Console.ReadLine();

            Console.WriteLine("Please enter the third number:");
            string inputNumberThree = Console.ReadLine();

            Console.WriteLine("Please enter the fourth number:");
            string inputNumberFour = Console.ReadLine();

            bool successfulNumberConversionOne = int.TryParse(inputNumberOne, out int numberOne);
            bool successfulNumberConversionTwo = int.TryParse(inputNumberTwo, out int numberTwo);
            bool successfulNumberConversionThree = int.TryParse(inputNumberThree, out int numberThree);
            bool successfulNumberConversionFour = int.TryParse(inputNumberFour, out int numberFour);

            if (
                !successfulNumberConversionOne ||
                !successfulNumberConversionTwo ||
                !successfulNumberConversionThree ||
                !successfulNumberConversionFour
                )
            {
                if (!successfulNumberConversionOne)
                {
                    Console.WriteLine("Your FIRST or more inputs are not valid numbers!");
                    Console.Beep();
                }
                else if (!successfulNumberConversionTwo)
                {
                    Console.WriteLine("Your SECOND or more inputs are not valid numbers!");
                    Console.Beep();
                }
                else if (!successfulNumberConversionThree)
                {
                    Console.WriteLine("Your THIRD or more inputs are not valid numbers!");
                    Console.Beep();
                }
                else
                {
                    Console.WriteLine("Your FOURTH input is not a valid number!");
                    Console.Beep();
                }
            }
            else
            {
                int largestNumber = numberOne;

                if (largestNumber < numberTwo)
                {
                    largestNumber = numberTwo;
                }

                if (largestNumber < numberThree)
                {
                    largestNumber = numberThree;
                }

                if (largestNumber < numberFour)
                {
                    largestNumber = numberFour;
                }

                Console.WriteLine("The largest of " + numberOne + ", " + numberTwo + ", " + numberThree + " and " + numberFour + " is: " + largestNumber);
            }
        }
    }
}
