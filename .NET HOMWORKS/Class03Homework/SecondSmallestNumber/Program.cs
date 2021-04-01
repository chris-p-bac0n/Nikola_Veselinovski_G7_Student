using System;

namespace SecondSmallestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            bool successfulNumberConversion = false;
            bool loopDone = false;
            int[] arrayWithNumbers = new int[] {};

            do
            {
                Console.WriteLine("Please enter a number (Enter N when you're done)");
                string inputNumber = Console.ReadLine();
                successfulNumberConversion = int.TryParse(inputNumber, out int number);

                if (inputNumber.ToLower() == "n")
                {
                    if (arrayWithNumbers.Length < 2)
                    {
                        Console.WriteLine("You must enter atleast 2 numbers for this to work!");

                        continue;
                    }
                    
                    loopDone = true;

                    Console.WriteLine($"Numbers: {PrintArray(arrayWithNumbers)}");
                    Console.WriteLine($"The second smallest number is: {SecondSmallestNumberCalc(arrayWithNumbers)}");

                    break;
                }
                else if (!successfulNumberConversion)
                {
                    Console.WriteLine("Invalid input! Please enter a number!");
                }
                else
                {
                    Array.Resize(ref arrayWithNumbers, arrayWithNumbers.Length + 1);
                    arrayWithNumbers[arrayWithNumbers.Length - 1] = number;
                }

            }
            while (loopDone == false);
        }
        static string PrintArray(int[] array)
        {
            string printedArrayString = "";

            foreach (int item in array)
            {
                if (item == array[(array.Length - 1)])
                {
                    printedArrayString += $"{item.ToString()}";
                }
                else
                {
                    printedArrayString += $"{item.ToString()}, ";
                }
                
            }

            return printedArrayString;
        }
        static int SecondSmallestNumberCalc(int[] array)
        {
            int first, second = array.Length;

            first = second = int.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < first)
                {
                    second = first;
                    first = array[i];
                }
                else if (array[i] < second && array[i] != first)
                    second = array[i];
            }

            return second;
        }
    }
}
