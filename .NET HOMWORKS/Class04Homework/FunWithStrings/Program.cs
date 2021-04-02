using System;

namespace FunWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a sentance:");
            string inputString = Console.ReadLine();

            FunWithStrings(inputString);
        }
        static void FunWithStrings(string inputString)
        {
            Console.WriteLine(ReverseString(inputString));
            Console.WriteLine(VowelsCount(inputString));
            Console.WriteLine(PalindromeCheck(inputString));
            Console.WriteLine(LargestWord(inputString));
            Console.WriteLine(SmallestWord(inputString));
            Console.WriteLine(NumberOfWords(inputString));
            Console.WriteLine(MostUsedChar(inputString));
        }

        static string ReverseString(string inputString)
        {
            char[] reverseArray = inputString.ToCharArray();
            Array.Reverse(reverseArray);
            return new string(reverseArray);
        }
        static string VowelsCount(string inputString)
        {
            int vowels = 0;

            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == 'a' || inputString[i] == 'e' || inputString[i] == 'i' || inputString[i] == 'o' || inputString[i] == 'u' || inputString[i] == 'A' || inputString[i] == 'E' || inputString[i] == 'I' || inputString[i] == 'O' || inputString[i] == 'U')
                {
                    vowels++;
                }
            }

            return $"The total number of vowels in the string is: {vowels}";
        }
        static string PalindromeCheck(string inputString)
        {
            char[] reverseArray = inputString.ToCharArray();
            Array.Reverse(reverseArray);

            if (new string(reverseArray) == inputString)
            {
                return "The string is a palindrome";
            }
            else
            {
                return "The string is not a palindrome";
            }            
        }

        static string LargestWord(string inputString)
        {
            string[] stringArray = inputString.Split(' ');

            var shortString = stringArray[0];
            var longString = stringArray[0];

            foreach (string a in stringArray)
            {
                if (shortString.Length > a.Length)
                {
                    shortString = a;
                }
                if (longString.Length < a.Length)
                {
                    longString = a;
                }
            }
            return $"The largest word is: {longString}";

        }
        static string SmallestWord(string inputString)
        {
            string[] stringArray = inputString.Split(' ');
                        
                var shortString = stringArray[0];
                var longString = stringArray[0];

                foreach (string a in stringArray)
                {
                    if (shortString.Length > a.Length)
                    {
                        shortString = a;
                    }
                    if (longString.Length < a.Length)
                    {
                        longString = a;
                    }
                }
                return $"The smallest word is: {shortString}";         
        }
        static string NumberOfWords(string inputString)
        {
            string[] stringArray = inputString.Split(' '); 
            
            return $"The number of words is: {stringArray.Length}";
        }
        static string MostUsedChar(string inputString)
        {
            int[] charCount = new int[256];
            int length = inputString.Length;
            for (int i = 0; i < length; i++)
            {
                charCount[inputString[i]]++;
            }
            int maxCount = -1;
            char character = ' ';
            for (int i = 0; i < length; i++)
            {
                if (Char.IsWhiteSpace(inputString[i])) continue;

                if (maxCount < charCount[inputString[i]])
                {
                    maxCount = charCount[inputString[i]];
                    character = inputString[i];
                }
            }

            return $"The most used character is: {character} and it occurs {maxCount} times";
        }    
    }
}
