using System;
using System.Collections.Generic;
using System.Linq;

namespace numberToWords
{
    class Program
    {
        static void Main(string[] args)
        {


            //Console.WriteLine("Please input a number (only numbers bellow 1 billion and no negatives allowed)");
            //string input = Console.ReadLine();

            //if (cleanString(input).Length > 999999999)
            //{
            //    Console.WriteLine("only numbers bellow 1 billion");
            //}
            //else
            //{
            //    int inputNumber = parseStringToInt(cleanString(input));
            //    if (inputNumber == 0)
            //    {
            //        Console.WriteLine("zero");
            //    }
            //    else if (inputNumber < 0)
            //    {
            //        Console.WriteLine("no negatives allowed, good vibes only");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"{numbersToWords(inputNumber)}");
            //    }
            //}

            Console.WriteLine($"{wordsToNumber("fifty five")}");

        }

        public static class NumberToWordLexicon
        {
            public static string[] ones = new string[]
            {
                "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
            };

            public static string[] onesAndTens = new string[]
            {
                "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
            };

            public static string[] tens = new string[]
            {
                "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
            };

            public static string[] highTens = new string[]
            {
                "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety"
            };

            public static Dictionary<string, int> numberTable = new Dictionary<string, int>
            {
                {"zero",0},{"one",1},{"two",2},{"three",3},{"four",4},
                {"five",5},{"six",6},{"seven",7},{"eight",8},{"nine",9},
                {"ten",10},{"eleven",11},{"twelve",12},{"thirteen",13},
                {"fourteen",14},{"fifteen",15},{"sixteen",16},
                {"seventeen",17},{"eighteen",18},{"nineteen",19},{"twenty",20},
                {"thirty",30},{"forty",40},{"fifty",50},{"sixty",60},
                {"seventy",70},{"eighty",80},{"ninety",90}
            };
        }

        static int parseStringToInt(string inputString)
        {
            return Int32.Parse(inputString);
        }
        static string cleanString(string inputString)
        {
            return new string(inputString.Where(c => char.IsDigit(c)).ToArray());
        }

        static string hundredToWords(string inputString)
        {
            string finalHundredString = string.Empty;
            string modifiedInputString = string.Empty;

            for (int i = inputString.Length; i < 3; i++)
            {
                modifiedInputString += "0";
            }
            modifiedInputString += inputString;

            int hundreth = parseStringToInt(modifiedInputString[0].ToString());
            if (hundreth != 0)
            {
                finalHundredString += $"{NumberToWordLexicon.ones[hundreth - 1]} hundred";
            }

            int tenth = parseStringToInt(modifiedInputString.Remove(0, 1));
            if (tenth > 9 && tenth < 20)
            {
                Console.WriteLine(tenth);
                string spacingAndOther = finalHundredString == string.Empty ? $"{NumberToWordLexicon.onesAndTens[tenth]}" : $" and {NumberToWordLexicon.onesAndTens[tenth]}";
                finalHundredString += spacingAndOther;
            }
            else
            {
                int hightenth = parseStringToInt(modifiedInputString[1].ToString());
                if (hightenth != 0)
                {
                    string spacingAndOther = finalHundredString == string.Empty ? $"{NumberToWordLexicon.highTens[hightenth - 1]}" : $" and {NumberToWordLexicon.highTens[hightenth - 1]}";
                    finalHundredString += spacingAndOther;
                }

                int one = parseStringToInt(modifiedInputString[2].ToString());
                if (one != 0)
                {
                    string spacingAndOther = finalHundredString == string.Empty ? $"{NumberToWordLexicon.ones[one - 1]}" : $" {NumberToWordLexicon.ones[one - 1]}";
                    finalHundredString += spacingAndOther;
                }
            }
            return finalHundredString;
        }

        static string numbersToWords(int inputNumber)
        {
            string finalString = string.Empty;

            if ((inputNumber / 1000000) > 0)
            {
                finalString += hundredToWords((inputNumber / 1000000).ToString()) + " million ";
                inputNumber %= 1000000;
            }

            if ((inputNumber / 1000) > 0)
            {
                finalString += hundredToWords((inputNumber / 1000).ToString()) + " thousand ";
                inputNumber %= 1000;
            }

            if (inputNumber > 0)
            {
                finalString += hundredToWords(inputNumber.ToString());
            }

            return finalString;
        }

        static int wordsToNumber(string inputString)
        {
            int finalNumber = 0;
            string[] modifiedInputString = inputString.Trim().Split(" ");

            int indexOfMillion = Array.IndexOf(modifiedInputString, "million");
            int indexOfThousand = Array.IndexOf(modifiedInputString, "thousand");

            if (modifiedInputString.Contains("million"))
            {
                finalNumber += parseStringToInt(wordsToNumbersMillion(indexOfMillion, modifiedInputString));
            }

            if (modifiedInputString.Contains("thousand"))
            {
                finalNumber += parseStringToInt(wordsToNumbersThousand(indexOfMillion, indexOfThousand, modifiedInputString));
            }

            finalNumber += parseStringToInt(wordsToNumbersHundreds(indexOfMillion, indexOfThousand, modifiedInputString));

            return finalNumber;
        }

        static string wordsToHundreds(string[] inputStringArray)
        {
            int finalHundred = 0;
            for (int i = 0; i < inputStringArray.Length; i++)
            {
                int number = 0;

                if (NumberToWordLexicon.numberTable.TryGetValue(inputStringArray[i], out number))
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
                else continue;
            }
            return finalHundred.ToString();
        }

        static string wordsToNumbersMillion(int indexOfMillion, string[] modifiedInputString)
        {
            List<string> listOfWords = new List<string>();
            for (int i = 0; i < indexOfMillion; i++)
            {
                listOfWords.Add(modifiedInputString[i]);
            }

            string[] words = listOfWords.ToArray();
            string finalMillionString = wordsToHundreds(words);
            finalMillionString += "000000";

            return finalMillionString;
        }

        static string wordsToNumbersThousand(int indexOfMillion, int indexOfThousand, string[] modifiedInputString)
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

            string[] words = listOfWords.ToArray();
            string finalThousandsString = wordsToHundreds(words);
            finalThousandsString += "000";

            return finalThousandsString;
        }

        static string wordsToNumbersHundreds(int indexOfMillion, int indexOfThousand, string[] modifiedInputString)
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

            string[] words = listOfWords.ToArray();
            string finalHundredsString = wordsToHundreds(words);

            return finalHundredsString;
        }
    }
}
