using NumberApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberApp.Services
{
    public class WordsToNumbers : IWordsToNumbers
    {
        public int ConvertWordsToNumbers(string input)
        {
            string[] modifiedInputString = input.Trim().Split(" ");
            if (input.Any(char.IsDigit))
            {
                throw new ArgumentException("Input doesn't meet the requirments");
            }
            else if (!modifiedInputString.Any(s => NumbersLexicon.numberTable.ContainsKey(s)))
            {
                throw new ArgumentException("Input doesn't meet the requirments");
            }
            else
            {
                return GetNumberFromWords(input, modifiedInputString);
            }
        }

        private int GetNumberFromWords(string inputString, string[] modifiedInputString)
        {
            int result = 0;
            int indexOfMillion = Array.IndexOf(modifiedInputString, "million");
            int indexOfThousand = Array.IndexOf(modifiedInputString, "thousand");

            if (modifiedInputString.Contains("million"))
            {
                result += Helpers.ParseStringToInt(WordsToNumbersMillion(indexOfMillion, modifiedInputString));
            }

            if (modifiedInputString.Contains("thousand"))
            {
                result += Helpers.ParseStringToInt(WordsToNumbersThousand(indexOfMillion, indexOfThousand, modifiedInputString));
            }

            result += Helpers.ParseStringToInt(WordsToNumbersHundreds(indexOfMillion, indexOfThousand, modifiedInputString));

            return result;
        }

        private string WordsToHundreds(string[] inputStringArray)
        {
            int finalHundred = 0;
            for (int i = 0; i < inputStringArray.Length; i++)
            {
                if (NumbersLexicon.numberTable.TryGetValue(inputStringArray[i], out int number))
                {
                    if (finalHundred == 0 && inputStringArray.Contains("hundred"))
                    {
                        finalHundred += number * 100;
                    }
                    else if (number != 0)
                    {
                        finalHundred += number;
                    }
                }
                else
                {
                    continue;
                }
            }
            return finalHundred.ToString();
        }

        private string WordsToNumbersMillion(int indexOfMillion, string[] modifiedInputString)
        {
            List<string> listOfWords = new List<string>();
            for (int i = 0; i < indexOfMillion; i++)
            {
                listOfWords.Add(modifiedInputString[i]);
            }

            string[] wordsToConvertToNumber = listOfWords.ToArray();
            string finalMillionString = WordsToHundreds(wordsToConvertToNumber);
            finalMillionString += "000000";

            return finalMillionString;
        }

        private string WordsToNumbersThousand(int indexOfMillion, int indexOfThousand, string[] modifiedInputString)
        {
            List<string> listOfWords = new List<string>();

            if (modifiedInputString.Contains("million"))
            {
                for (int i = indexOfMillion; i < indexOfThousand; i++)
                {
                    listOfWords.Add(modifiedInputString[i]);
                }
            }
            else
            {
                for (int i = 0; i < indexOfThousand; i++)
                {
                    listOfWords.Add(modifiedInputString[i]);
                }
            }

            string[] wordsToConvertToNumber = listOfWords.ToArray();
            string finalThousandsString = WordsToHundreds(wordsToConvertToNumber);
            finalThousandsString += "000";

            return finalThousandsString;
        }

        private string WordsToNumbersHundreds(int indexOfMillion, int indexOfThousand, string[] modifiedInputString)
        {
            List<string> listOfWords = new List<string>();

            if (modifiedInputString.Contains("thousand"))
            {
                for (int i = indexOfThousand; i < modifiedInputString.Length; i++)
                {
                    listOfWords.Add(modifiedInputString[i]);
                }
            }
            else if (modifiedInputString.Contains("million"))
            {
                for (int i = indexOfMillion; i < modifiedInputString.Length; i++)
                {
                    listOfWords.Add(modifiedInputString[i]);
                }
            }
            else
            {
                for (int i = 0; i < modifiedInputString.Length; i++)
                {
                    listOfWords.Add(modifiedInputString[i]);
                }
            }

            string[] wordsToConvertToNumber = listOfWords.ToArray();
            string finalHundredsString = WordsToHundreds(wordsToConvertToNumber);

            return finalHundredsString;
        }
    }
}
