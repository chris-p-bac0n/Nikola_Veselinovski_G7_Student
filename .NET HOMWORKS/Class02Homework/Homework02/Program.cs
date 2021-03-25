using System;

namespace Homework02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the first number:");
            string inputNumberOne = Console.ReadLine();

            Console.WriteLine("Please enter the second number:");
            string inputNumberTwo = Console.ReadLine();

            Console.WriteLine("Please choose an operation (+, -, *, /):");
            string inputOperation = Console.ReadLine();

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
                return;
            }
            else
            {
                switch (inputOperation)
                {
                    case "+":
                        double result = numberOne + numberTwo;
                        Console.WriteLine("The result is: " + result);
                        break;
                    case "-":
                        result = numberOne - numberTwo;
                        Console.WriteLine("The result is: " + result);
                        break;
                    case "*":
                        result = numberOne * numberTwo;
                        Console.WriteLine("The result is: " + result);
                        break;
                    case "/":
                        result = numberOne / (double) numberTwo;
                        Console.WriteLine("The result is: " + result);
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        Console.Beep();
                        break;
                }
            }
        }
    }
}
