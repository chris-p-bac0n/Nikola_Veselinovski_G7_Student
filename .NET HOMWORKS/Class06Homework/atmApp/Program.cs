using System;
using atmApp.Classes;

namespace atmApp
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[3]
            {
                new User("Miki", "Kwiki", 850, 6452, 6845647598452465),
                new User("Johny", "Begood", 1500, 8467, 1658354875952465),
                new User("John", "Wayne", 2750, 9752, 8624578413569872)
            };

            do
            {
                Console.WriteLine("Welcome to the ATM app");
                Console.WriteLine("Choose an option (nubmer): \n1) Access your account \n2) Register an account");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        string stringCardNumber = String.Empty;
                        string stringPin = String.Empty;
                        bool userFound = false;
                        int userIndex = 0;

                        do
                        {
                            Console.WriteLine("Please enter your card number:");
                            stringCardNumber = Console.ReadLine();
                            //ValidateCardNumber(stringCardNumber);
                        }
                        while (!ValidateCardNumber(stringCardNumber));

                        do
                        {
                            Console.WriteLine("Pin:");
                            stringPin = Console.ReadLine();
                            //ValidatePin(stringPin);
                        }
                        while (!ValidatePin(stringPin));

                        long cardNumber = long.Parse(RemoveDash(stringCardNumber));
                        int pin = int.Parse(stringPin);

                        for (int i = 0; i < users.Length - 1; i++)
                        {
                            if (users[i].CardNumber == cardNumber && users[i].CheckPin(pin))
                            {
                                Console.WriteLine($"Hello {users[i].Name} {users[i].Surname}!");
                                userIndex = i;
                                userFound = true;
                                break;
                            }                            
                        }

                        if (!userFound)
                            Console.WriteLine("Card number or pin invalid!");


                        if (userFound)
                        {
                            bool userFinished = false;
                            bool validateContinuation = false;
                            do
                            {
                                bool parseSuccess;
                                int withdrawAmount;
                                int depositAmount;
                                Console.WriteLine("Choose an option (nubmer): \n1) Check Balance \n2) Cash Withdrawal \n3) Cash Deposit");
                                input = Console.ReadLine();

                                switch (input)
                                {
                                    case "1":
                                        Console.WriteLine($"Your balance is {users[userIndex].CheckBalance()}$");
                                        break;

                                    case "2":
                                        do
                                        {
                                            Console.WriteLine("Enter amount to withdraw:");
                                            string stringWithdrawAmount = Console.ReadLine();
                                            parseSuccess = int.TryParse(stringWithdrawAmount, out withdrawAmount);

                                            if (!parseSuccess)
                                                Console.WriteLine("Please enter a valid number");
                                        }
                                        while (!parseSuccess);

                                        if (withdrawAmount < users[userIndex].CheckBalance())
                                        {
                                            users[userIndex].Withdraw(withdrawAmount);
                                            Console.WriteLine($"You withdrew {withdrawAmount}$. You have {users[userIndex].CheckBalance()}$ left on your account");
                                        }
                                        else
                                            Console.WriteLine("Insuficient funds for operation");
                                        break;

                                    case "3":
                                        do
                                        {
                                            Console.WriteLine("Enter amount to deposit:");
                                            string stringWithdrawAmount = Console.ReadLine();
                                            parseSuccess = int.TryParse(stringWithdrawAmount, out depositAmount);

                                            if (!parseSuccess)
                                                Console.WriteLine("Please enter a valid number");
                                        }
                                        while (!parseSuccess);
                                        users[userIndex].Deposit(depositAmount);
                                        Console.WriteLine($"You deposited {depositAmount}$. You have {users[userIndex].CheckBalance()}$ left on your account");
                                        break;
                                    default:
                                        Console.WriteLine("Wrong input");
                                        break;
                                }

                                do
                                {
                                    Console.WriteLine("Do you want to do another action? (Y/N)");
                                    input = Console.ReadLine();
                                    switch (input.ToLower())
                                    {
                                        case "y":
                                            validateContinuation = true;
                                            break;

                                        case "n":
                                            validateContinuation = true;
                                            userFinished = true;
                                            Console.WriteLine("Thank you for using our bank and goodbye!");
                                            break;

                                        default:
                                            Console.WriteLine("Wrong input");
                                            break;
                                    }
                                }
                                while (!validateContinuation);
                            }
                            while (!userFinished);
                        }


                        break;


                    case "2":

                        AddNewUser(users);

                        break;

                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            }
            while (true);


        }
        static void AddNewUser(User[] users)
        {
            string stringCardNumber = String.Empty;
            string name = String.Empty;
            string surname = String.Empty;
            string stringPin = String.Empty;
            string confirmPin = String.Empty;

            do
            {
                Console.WriteLine("Card number:");
                stringCardNumber = Console.ReadLine();
                //ValidateCardNumberNewUser(stringCardNumber, users);
            }
            while (!ValidateCardNumberNewUser(stringCardNumber, users));

            Console.WriteLine("Name:");
            name = Console.ReadLine();

            Console.WriteLine("Surname:");
            surname = Console.ReadLine();

            do
            {
                Console.WriteLine("Pin:");
                stringPin = Console.ReadLine();
                Console.WriteLine("Confirm pin:");
                confirmPin = Console.ReadLine();
                //ValidatePinNewUser(stringPin, confirmPin);
            }
            while (!ValidatePinNewUser(stringPin, confirmPin));

            long cardNumber = long.Parse(RemoveDash(stringCardNumber));
            int pin = int.Parse(stringPin);

            User newUser = new User(name, surname, 0, pin, cardNumber);
            Array.Resize(ref users, users.Length + 1);
            users[users.Length - 1] = newUser;
            Console.WriteLine("Registration complete!");
        }

        static string RemoveDash(string stringCardNumber)
        {
            string CardNumber = stringCardNumber.Replace("-", string.Empty);

            return CardNumber;
        }
        static bool ValidateCardNumber(string stringCardNumber)
        {
            bool cardNumberValid = true;
            string NoDashCardNumber = stringCardNumber.Replace("-", string.Empty);

            if (NoDashCardNumber.Length < 16 || NoDashCardNumber.Length > 16)
            {
                Console.WriteLine("Card number format should be XXXX-XXXX-XXXX-XXXX");
                return !cardNumberValid;
            }

            bool successParse = long.TryParse(NoDashCardNumber, out long cardNumber);

            if (!successParse)
            {
                Console.WriteLine("Card number format should be XXXX-XXXX-XXXX-XXXX");
                return !cardNumberValid;
            }

            return cardNumberValid;
        }

        static bool ValidateCardNumberNewUser(string stringCardNumber, User[] users)
        {
            bool cardNumberValid = true;
            string NoDashCardNumber = stringCardNumber.Replace("-", string.Empty);

            if (NoDashCardNumber.Length < 16 || NoDashCardNumber.Length > 16)
            {
                Console.WriteLine("Card number format should be XXXX-XXXX-XXXX-XXXX");
                return !cardNumberValid;
            }

            bool successParse = long.TryParse(NoDashCardNumber, out long cardNumber);

            if (!successParse)
            {
                Console.WriteLine("Card number format should be XXXX-XXXX-XXXX-XXXX");
                return !cardNumberValid;
            }

            foreach (User user in users)
            {
                if (user.CardNumber == cardNumber)
                {
                    Console.WriteLine("That card number already exists, try another");
                    return !cardNumberValid;
                }
            }

            return cardNumberValid;
        }

        static bool ValidatePinNewUser(string pin, string confirmPin)
        {
            bool pinValid = true;

            if (pin.Length < 4 || pin.Length > 19)
            {
                Console.WriteLine("Pin number format should be XXXX");
                return !pinValid;
            }

            bool successParse1 = int.TryParse(pin, out int pinNumber);
            bool successParse2 = int.TryParse(confirmPin, out int confirmPinNumber);

            if (!successParse1)
            {
                Console.WriteLine("Pin number format should be XXXX");
                return !pinValid;
            }

            if (pinNumber != confirmPinNumber)
            {
                Console.WriteLine("Pin and confirmed pin do not match");
                return !pinValid;
            }

            return pinValid;
        }
        static bool ValidatePin(string pin)
        {
            bool pinValid = true;

            if (pin.Length < 4 || pin.Length > 19)
            {
                Console.WriteLine("Pin number format should be XXXX");
                return !pinValid;
            }

            bool successParse1 = int.TryParse(pin, out int pinNumber);

            if (!successParse1)
            {
                Console.WriteLine("Pin number format should be XXXX");
                return !pinValid;
            }

            return pinValid;
        }

    }
}
