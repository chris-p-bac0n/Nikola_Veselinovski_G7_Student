using System;

namespace GuessTheSecretNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int secretNumber = 474;
            int numberGuess = 0;
            string inputNumberGuess = String.Empty;
            string inputTryAgainAnswer = String.Empty;
            bool tryAgain = true;
            int numberOfTries = 5;

            do
            {
                numberOfTries = 5;
                do
                {
                    Console.WriteLine("Guess the secret number!");
                    inputNumberGuess = Console.ReadLine();

                    if (ValidateNumber(inputNumberGuess))
                    {
                        numberOfTries--;

                        numberGuess = int.Parse(inputNumberGuess);

                        NumberGuessing(numberGuess, secretNumber, numberOfTries);

                        if (numberOfTries == 0 && numberGuess != secretNumber)
                        {
                            Console.WriteLine("Better luck next time!");
                        }
                    }
                }
                while (numberOfTries > 0 && numberGuess != secretNumber);

                if (numberGuess != secretNumber)
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
                else
                {
                    tryAgain = false;
                }
            }
            while (tryAgain);
        }
        static bool ValidateNumber(string inputNumber)
        {
            bool numberValid = false;
            bool successfulNumberConversion = int.TryParse(inputNumber, out int number);

            if (!successfulNumberConversion)
            {
                Console.WriteLine("Input is not valid! Must be a number!");
            }           
            else
            {
                numberValid = true;
            }

            return numberValid;
        }
        static void NumberGuessing (int inputNumber, int secretNumber, int numberOfTries)
        {
            if (inputNumber < secretNumber)
            {
                Console.WriteLine("The secret number is greater than the entered number");
            }
            else if (inputNumber > secretNumber)
            {
                Console.WriteLine("The secret number is less than the entered number");
            }
            else 
            {
                Console.WriteLine($"Congratulations you guessed the secret number {secretNumber}!");
            }

            int numberDiff = Math.Abs(secretNumber - inputNumber);

            if (numberDiff >= 50 && numberDiff <= 100)
            {
                Console.WriteLine($"You are close to the secret number and have {numberOfTries} number of tries left");
            }
            else if (numberDiff >= 1 && numberDiff <= 50)
            {
                Console.WriteLine($"You are very close and have {numberOfTries} number of tries left");
            }            
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
    }
}
