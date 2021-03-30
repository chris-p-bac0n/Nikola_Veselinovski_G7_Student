using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsArray = new string[] { "one", "two", "three", "four", "five" };
            double[] decimalArray = new double[] { 0.56, 7.23, 1.66, 2.13, 75.68 };
            char[] charactersArray = new char[] { 'B', '3', 'w', '6', 'q' };
            bool[] booleanArray = new bool[] { true, true, false, true, false };
            int[,] arraysWithNumbersArray = new int[,] { { 68, 85 }, { 2, 13 }, { 9, 1 }, { 64, 8 }, { 57, 6 } };

            foreach (string element in wordsArray)
            {
                Console.WriteLine(element);
            }

            foreach (double element in decimalArray)
            {
                Console.WriteLine(element);
            }

            foreach (char element in charactersArray)
            {
                Console.WriteLine(element);
            }

            foreach (bool element in booleanArray)
            {
                Console.WriteLine(element);
            }

            foreach (int element in arraysWithNumbersArray)
            {
                Console.WriteLine(element);
            }

        }
    }
}
