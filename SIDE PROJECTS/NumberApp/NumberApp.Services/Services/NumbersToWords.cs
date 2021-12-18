using NumberApp.Services.Interfaces;
using System;
using System.Linq;

namespace NumberApp.Services
{
    public class NumbersToWords : INumbersToWords
    {
        public string ConvertNumbersToWords(string input)
        {
            if (!input.Any(char.IsDigit))
            {
                throw new ArgumentException("Input doesn't meet the requirments");
            }
            string numbersFromInput = Helpers.GetAllNumbersFromString(input);
            if (numbersFromInput.Length > 9)
            {
                throw new ArgumentOutOfRangeException("Input number is too high");
            }
            else
            {
                int inputNumber = Helpers.ParseStringToInt(numbersFromInput);
                if (inputNumber == 0)
                {
                    return "zero";
                }
                else if (inputNumber < 0)
                {
                    throw new ArgumentException("Input doesn't meet the requirments");
                }
                else
                {
                    return GetWordsFromNumbers(inputNumber);
                }
            }
        }

        private string GetWordsFromNumbers(int inputNumber)
        {
            string finalString = string.Empty;

            if ((inputNumber / 1000000) > 0)
            {
                finalString += HundredToWords((inputNumber / 1000000).ToString()) + " million ";
                inputNumber %= 1000000;
            }

            if ((inputNumber / 1000) > 0)
            {
                finalString += HundredToWords((inputNumber / 1000).ToString()) + " thousand ";
                inputNumber %= 1000;
            }

            if (inputNumber > 0)
            {
                finalString += HundredToWords(inputNumber.ToString());
            }

            return finalString;
        }

        private string HundredToWords(string inputString)
        {
            string finalHundredString = string.Empty;
            string modifiedInputString = string.Empty;

            for (int i = inputString.Length; i < 3; i++)
            {
                modifiedInputString += "0";
            }
            modifiedInputString += inputString;

            int hundreth = Helpers.ParseStringToInt(modifiedInputString[0].ToString());
            if (hundreth != 0)
            {
                finalHundredString += $"{NumbersLexicon.ones[hundreth - 1]} hundred";
            }

            int tenth = Helpers.ParseStringToInt(modifiedInputString.Remove(0, 1));
            if (tenth > 9 && tenth < 20)
            {
                finalHundredString += finalHundredString == string.Empty ? $"{NumbersLexicon.onesAndTens[tenth]}" : $" and {NumbersLexicon.onesAndTens[tenth]}"; ;
            }
            else
            {
                int hightenth = Helpers.ParseStringToInt(modifiedInputString[1].ToString());
                if (hightenth != 0)
                {
                    finalHundredString += finalHundredString == string.Empty ? $"{NumbersLexicon.highTens[hightenth - 1]}" : $" and {NumbersLexicon.highTens[hightenth - 1]}";
                }

                int singleNumber = Helpers.ParseStringToInt(modifiedInputString[2].ToString());
                if (singleNumber != 0)
                {
                    string spacingAndOther = finalHundredString == string.Empty ? $"{NumbersLexicon.ones[singleNumber - 1]}" : $" {NumbersLexicon.ones[singleNumber - 1]}";
                    finalHundredString += spacingAndOther;
                }
            }
            return finalHundredString;
        }
    }
}
