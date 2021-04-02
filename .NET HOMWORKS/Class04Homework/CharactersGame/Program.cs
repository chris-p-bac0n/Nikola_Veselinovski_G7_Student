using System;

namespace CharactersGame
{
    class Program
    {
        static void Main(string[] args)
        {            
            string inputSentance = "";
            string inputCharacter = "";
            string inputTryAgainAnswer = "";
            string inputNumber = "";
            bool numberValidCheck = false;
            bool tryAgain = true;
            int loop1Count = 0;
            int loop2Count = 0;

            do
            {
                if (loop1Count > 0 && tryAgain)
                {
                    do
                    {
                        Console.WriteLine("Would you like to try again? (Y/N)");
                        inputTryAgainAnswer = Console.ReadLine();

                        if (inputTryAgainAnswer.ToLower() == "n")
                        {
                            tryAgain = false;
                            break;
                        }
                        else if (inputTryAgainAnswer.ToLower() == "y")
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    while (ValidateAnswer(inputTryAgainAnswer));
                }

                if (tryAgain == false)
                {
                    break;
                }

                Console.WriteLine("Please enter a sentance:");
                inputSentance = Console.ReadLine();

                loop1Count++;
            }

            while (!ValidateSentance(inputSentance));

            if (tryAgain == true)
            {
                do
                {
                    if (loop2Count > 0)
                    {
                        do
                        {
                            Console.WriteLine("Would you like to try again? (Y/N)");
                            inputTryAgainAnswer = Console.ReadLine();

                            if (inputTryAgainAnswer.ToLower() == "n")
                            {
                                tryAgain = false;
                                break;
                            }
                            else if (inputTryAgainAnswer.ToLower() == "y")
                            {
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        while (ValidateAnswer(inputTryAgainAnswer));
                    }

                    if (tryAgain == false)
                    {
                        break;
                    }

                    Console.WriteLine("Please enter a character:");
                    inputCharacter = Console.ReadLine();

                    loop2Count++;
                }

                while (!ValidateCharacter(inputCharacter));

                if (tryAgain == true)
                {
                    Console.WriteLine("The character is present in the sentence for a total of " + CharacterCount(inputSentance, inputCharacter) + " times!");

                    do
                    {
                        Console.WriteLine("Please enter a number: (Must not be larger than the sentence length)");
                        inputNumber = Console.ReadLine();
                        numberValidCheck = ValidateNumber(inputNumber, inputSentance);

                        if (numberValidCheck)
                        {
                            bool successfulNumberConversion = int.TryParse(inputNumber, out int number);
                            string sentanceSubStr = inputSentance.Substring(0, number);

                            Console.WriteLine($"The substring of the sentence is: \"{sentanceSubStr}\"");
                        }
                    }

                    while (!numberValidCheck);
                }
            }         
        }
        static bool ValidateSentance(string inputSentance)
        {
            bool sentanceValid = false;
            bool onlyWhiteSpace = false;

            onlyWhiteSpace = String.IsNullOrWhiteSpace(inputSentance);
            int numberOfLetters = 0;

            for (int i = 0; i < inputSentance.Length; i++)
            {
                if (Char.IsLetter(inputSentance, i) == true)
                {
                    numberOfLetters += 1;
                }
            }
            if (onlyWhiteSpace == true)
            {
                Console.WriteLine("You only entered white space or nothing at all, please enter a sentance!");
            }
            else if (numberOfLetters < 8)
            {
                Console.WriteLine("Please enter a sentance with at least 8 letters!");
            }
            else
            {
                sentanceValid = true;
            }

            return sentanceValid;
        }
        static bool ValidateCharacter(string inputCharacter)
        {
            bool characterValid = false;
            bool onlyWhiteSpace = false;

            onlyWhiteSpace = String.IsNullOrWhiteSpace(inputCharacter);
            int numberOfLetters = 0;

            for (int i = 0; i < inputCharacter.Length; i++)
            {
                if (Char.IsLetter(inputCharacter, i) == true)
                {
                    numberOfLetters += 1;
                }
            }
            if (onlyWhiteSpace == true)
            {
                Console.WriteLine("You only entered white space or nothing at all, please enter a character!");
            }
            else if (numberOfLetters > 1)
            {
                Console.WriteLine("Please enter only 1 character");
            }
            else
            {
                characterValid = true;
            }

            return characterValid;
        }
        static bool ValidateAnswer(string inputTryAgainAnswer)
        {
            bool answerValid = false;

            if (inputTryAgainAnswer.ToLower() == "y" || inputTryAgainAnswer.ToLower() == "n")
            {
                answerValid = true;
            }

            return answerValid;
        }
        static int CharacterCount(string inputSentance, string inputCharacter)
        {
            bool successfulCharConversion = char.TryParse(inputCharacter, out char countCharacter);

            int count = 0;
            foreach (char a in inputSentance)
                if (a == countCharacter) count++;

            return count;
        }

        static bool ValidateNumber(string inputNumber, string inputSentance)
        {
            bool numberValid = false;            
            bool successfulNumberConversion = int.TryParse(inputNumber, out int number);

            if (!successfulNumberConversion)
            {
                Console.WriteLine("Input is not valid! Must be a number!");
            }
            else if (number > inputSentance.Length)
            {
                Console.WriteLine("Number must not be larger than the sentence length!");
            }
            else
            {
                numberValid = true;
            }

            return numberValid;
        }
    }
}
