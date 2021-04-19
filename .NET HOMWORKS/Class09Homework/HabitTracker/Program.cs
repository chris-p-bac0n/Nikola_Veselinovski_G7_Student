using System;
using System.Linq;

namespace HabitTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = String.Empty;
            int counter = 1;
            User[] users = new User[0];

            Array.Resize(ref users, users.Length + 1);
            users[users.Length - 1] = new User("kolemoticeto", "moticeto1", "kole", "moticeto", new DateTime(1994, 07, 25));
            users[users.Length - 1].Habits.Add(new Habit("kungfu", (Enums.Group)1, (Enums.Difficulty)3, (Enums.HabitType)1));
            users[users.Length - 1].Habits.Add(new Habit("tv", (Enums.Group)5, (Enums.Difficulty)1, (Enums.HabitType)2));

            while (true)
            {
                User activeUser = null;
                Console.Clear();
                Console.WriteLine("Hello and welcome to the Habit Tracker app!");
                Console.WriteLine("\n 00 Exit");
                Console.WriteLine("\nPlease choose an option:\n1) Register new user\n2) Log in as existing user");
                userInput = Console.ReadLine();

                if (userInput == "00") Environment.Exit(0);

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("0 Back\n 00 Exit");
                        RegisterUser(users);
                        break;
                    case "2":
                        try
                        {
                            Console.Clear();

                            if (counter > 3)
                            {
                                Console.Clear();
                                throw new Exception("Too many invalid login attempts, the program will close itself in 3 seconds");
                            }

                            Console.WriteLine("0 Back\n 00 Exit");
                            activeUser = UserLogin(users, counter);

                            if (users.Any(user => user == activeUser))
                            {
                                while (true)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Hello {activeUser.FirstName}!");
                                    Console.WriteLine("0 Back\n 00 Exit");
                                    Console.WriteLine("\nPlease choose action:\n1) Habits\n2) Statistics\n3) Edit Account");
                                    userInput = Console.ReadLine();

                                    if (userInput == "1")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Choose an option:\n1) Daily log\n2) Single log");
                                        string userInput2 = Console.ReadLine();

                                        if (userInput2 == "0") break;
                                        if (userInput2 == "00") Environment.Exit(0);

                                        if (userInput2 == "1") DailyLog(activeUser);
                                        else if (userInput2 == "2") SingleLog(activeUser);
                                        else
                                        {
                                            Console.WriteLine("Invalid input, press enter to continue");
                                            Console.ReadLine();
                                        }
                                    }
                                    else if (userInput == "2") HabitStatistics(activeUser);
                                    else if (userInput == "3") EditAccount(activeUser);
                                    else if (userInput == "0") break;
                                    else if (userInput == "00") Environment.Exit(0);
                                    else
                                    {
                                        Console.WriteLine("Invalid input, press enter to continue");
                                        Console.ReadLine();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);

                            if (ex.Message.Length > 1)
                            {
                                System.Threading.Thread.Sleep(3000);
                                Environment.Exit(0);
                            }

                            if (ex.Message.Length < 1)
                            {
                                counter++;
                            }
                        }

                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
        static void RegisterUser(User[] users)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0 Back\n 00 Exit");
                Console.WriteLine("\nPlease choose action:\n1) General info\n2) Set up account");
                string userInput = Console.ReadLine();

                if (userInput == "0") break;
                if (userInput == "00") Environment.Exit(0);

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("0 Back\n 00 Exit");
                        Console.WriteLine("\n[GENERAL INFO]");

                        Console.WriteLine("\nPlease enter a username");
                        string username = ValidateUsername();
                        if (username == "0") break;

                        Console.WriteLine("\nPlease enter a password");
                        string password = ValidatePassword();
                        if (password == "0") break;

                        Console.WriteLine("\nPlease enter first name");
                        string firstName = ValidateName();
                        if (firstName == "0") break;

                        Console.WriteLine("\nPlease enter last name");
                        string lastName = ValidateName();
                        if (lastName == "0") break;

                        Console.WriteLine("\nPlease enter your date of birth: (MM/DD/YYYY)");
                        DateTime dateOfBirth = AgeCalculator();
                        if (dateOfBirth == DateTime.Now) break;

                        Array.Resize(ref users, users.Length + 1);
                        users[users.Length - 1] = new User(username, password, firstName, lastName, dateOfBirth);
                        User activeUser = users[users.Length - 1];
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("0 Back\n 00 Exit");
                        Console.WriteLine("\n[SET UP YOUR ACCOUNT]");

                        Console.WriteLine("\nYou must enter atleast 1 good and 1 bad habit");
                        NewUserHabits(users);
                        break;

                    default:
                        Console.WriteLine("\nInvalid input please try again");
                        break;
                }
            }
        }
        static string ValidateUsername()
        {
            while (true)
            {
                string userInput = Console.ReadLine();

                if (userInput == "0") return userInput;
                if (userInput == "00") Environment.Exit(0);

                if (userInput.Trim().Length < 6)
                {
                    Console.WriteLine("Username must have atleast 6 characters");
                }
                else if (char.IsDigit(userInput.Trim()[0]))
                {
                    Console.WriteLine("Username must not start with a number");
                }
                else
                {
                    return userInput;
                }
            }
        }
        static string ValidatePassword()
        {
            while (true)
            {
                string userInput = Console.ReadLine();

                if (userInput == "0") return userInput;
                if (userInput == "00") Environment.Exit(0);

                if (userInput.Trim().Length < 6)
                {
                    Console.WriteLine("Password must have atleast 6 characters");
                }
                else if (!userInput.Any(char.IsDigit))
                {
                    Console.WriteLine("Password must contain a number");
                }
                else
                {
                    Console.WriteLine("Please confirm password:");
                    string userInputConfirm = Console.ReadLine();

                    if (userInput == userInputConfirm) return userInput;
                    else
                    {
                        Console.WriteLine("Passwords don't match, please start over:");
                        continue;
                    }
                }
            }
        }
        static string ValidateName()
        {
            while (true)
            {
                string userInput = Console.ReadLine();

                if (userInput == "0") return userInput;
                if (userInput == "00") Environment.Exit(0);

                if (userInput.Trim().Length < 2)
                {
                    Console.WriteLine("Name must have atleast 2 characters");
                }
                else if (userInput.Any(char.IsDigit))
                {
                    Console.WriteLine("Name must not contain a number");
                }
                else
                {
                    return userInput;
                }
            }
        }
        static DateTime AgeCalculator()
        {
            while (true)
            {
                string inputBirthDate = Console.ReadLine();
                bool successfulDateConversion = DateTime.TryParse(inputBirthDate, out DateTime birthDate);
                DateTime returnDate = DateTime.Now;

                if (inputBirthDate == "0") return returnDate;
                if (inputBirthDate == "00") Environment.Exit(0);

                if (!successfulDateConversion)
                {
                    Console.WriteLine("Please enter a valid date (MM/DD/YYYY)");
                    continue;
                }
                else
                {
                    DateTime today = DateTime.Today;
                    int age = today.Year - birthDate.Year;

                    if (birthDate > today.AddYears(-age))
                        age--;

                    if (age >= 5 && age < 122) return birthDate;
                    else Console.WriteLine("age must not be less than 5 or more than 122");
                }
            }
        }
        static void NewUserHabits(User[] users)
        {
            string habitTitle = String.Empty;
            bool finishedAdding = false;
            //Enums.Group group = (Enums.Group)ValidateHabitGroup();
            //Enums.HabitType typeGood = (Enums.HabitType)1;

            while (!finishedAdding)
            {
                bool finishedConfirmation = false;
                Console.WriteLine("Please enter habit title:");
                habitTitle = Console.ReadLine();

                if (habitTitle == "0") return;
                if (habitTitle == "00") Environment.Exit(0);

                int groupCheck = ValidateHabitGroup();
                if (groupCheck == 0) return;
                int difficultyCheck = ValidateHabitDifficulty();
                if (difficultyCheck == 0) return;
                int typeCheck = ValidateHabitType();
                if (typeCheck == 0) return;

                users[users.Length - 1].Habits.Add(new Habit
                    (
                    habitTitle,
                    (Enums.Group)groupCheck,
                    (Enums.Difficulty)difficultyCheck,
                    (Enums.HabitType)typeCheck
                    ));

                Console.WriteLine("Please choose an action:\n1) Add another habit\n2) Finished adding habits");
                string userInput = Console.ReadLine();

                if (userInput == "0") return;
                if (userInput == "00") Environment.Exit(0);

                while (!finishedConfirmation)
                {
                    switch (userInput)
                    {
                        case "1":
                            finishedConfirmation = true;
                            break;

                        case "2":
                            if (!users[users.Length - 1].Habits.Any(Habit => Habit.Type == Enums.HabitType.Good) || !users[users.Length - 1].Habits.Any(Habit => Habit.Type == Enums.HabitType.Bad))
                            {
                                Console.WriteLine("You must have atleast 1 good and 1 bad habit!");
                                finishedConfirmation = true;
                            }
                            else
                            {
                                Console.WriteLine("You have been registered as a new user!");
                                finishedAdding = true;
                                finishedConfirmation = true;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid input, please try again");
                            break;
                    }
                }
            }
        }
        static int ValidateHabitGroup()
        {
            Console.WriteLine("Please choose habit group:" +
                    "\n1) Exercise and sports\n2) Study and learning\n3) Activities and hobbies\n4) Work and career\n5) Home and personal\n6) Other");

            while (true)
            {
                string userInput = Console.ReadLine();
                int enumOption = 0;

                if (userInput == "0") return enumOption;
                if (userInput == "00") Environment.Exit(0);

                switch (userInput)
                {
                    case "1":
                        enumOption = 1;
                        return enumOption;
                    case "2":
                        enumOption = 2;
                        return enumOption;
                    case "3":
                        enumOption = 3;
                        return enumOption;
                    case "4":
                        enumOption = 4;
                        return enumOption;
                    case "5":
                        enumOption = 5;
                        return enumOption;
                    case "6":
                        enumOption = 6;
                        return enumOption;
                    default:
                        Console.WriteLine("Invalid input please try again:");
                        break;
                }
            }
        }
        static int ValidateHabitDifficulty()
        {
            Console.WriteLine("Please choose habit difficulty:" +
                    "\n1) Low\n2) Medium\n3) High");

            while (true)
            {
                string userInput = Console.ReadLine();
                int enumOption = 0;

                if (userInput == "0") return enumOption;
                if (userInput == "00") Environment.Exit(0);

                switch (userInput)
                {
                    case "1":
                        enumOption = 1;
                        return enumOption;
                    case "2":
                        enumOption = 2;
                        return enumOption;
                    case "3":
                        enumOption = 3;
                        return enumOption;
                    default:
                        Console.WriteLine("Invalid input please try again:");
                        break;
                }
            }
        }
        static int ValidateHabitType()
        {
            Console.WriteLine("Please choose habit type:" +
                    "\n1) Good\n2) Bad");

            while (true)
            {
                string userInput = Console.ReadLine();
                int enumOption = 0;

                if (userInput == "0") return enumOption;
                if (userInput == "00") Environment.Exit(0);

                switch (userInput)
                {
                    case "1":
                        enumOption = 1;
                        return enumOption;
                    case "2":
                        enumOption = 2;
                        return enumOption;
                    default:
                        Console.WriteLine("Invalid input please try again:");
                        break;
                }
            }
        }
        static User UserLogin(User[] users, int counter)
        {
            string userInput1 = String.Empty;
            string userInput2 = String.Empty;


            while (true)
            {
                //counter++;

                Console.WriteLine("Please enter your username:");
                userInput1 = Console.ReadLine();

                if (userInput1 == "0") throw new Exception("");
                if (userInput1 == "00") Environment.Exit(0);

                Console.WriteLine("Please enter your password:");
                userInput2 = Console.ReadLine();

                foreach (User user in users)
                {
                    if (userInput1 == user.Username && userInput2 == user.Password)
                    {
                        User activeUser = user;
                        return activeUser;
                    }
                    else
                    {
                        if (counter < 3)
                            Console.WriteLine($"Wrong user credentials, you have {3 - counter} tries left, press ENTER to continue");
                        userInput2 = Console.ReadLine();
                        throw new Exception("");
                    }
                }
            }
        }
        static void HabitsLog(User activeUser)
        {
            while (true)
            {
                Console.WriteLine("Please choose:\n1) Daily log\n2) Single log");

                string userInput = Console.ReadLine();

                if (userInput == "0") return;
                if (userInput == "00") Environment.Exit(0);

                switch (userInput)
                {
                    case "1":

                    case "2":


                    default:
                        Console.WriteLine("Invalid input please try again:");
                        break;
                }
            }
        }
        static void DailyLog(User activeUser)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0 Back\n 00 Exit");
                Console.WriteLine("\nAll habits:");

                Console.WriteLine("\nGood Habits:");
                foreach (Habit habit in activeUser.Habits)
                {
                    if (habit.Type == Enums.HabitType.Good)
                    {
                        Console.WriteLine($"" +
                            $"\nHabit Title: {habit.Title}" +
                            $"\nHabit Group: {habit.Group}" +
                            $"\nHabit Difficulty: {habit.Difficulty}" +
                            $"\nHabit Type: {habit.Type}" +
                            $"\nHabit Date: {habit.Date}" +
                            $"\nHabit Completed: {habit.IsCompleted}");
                    }
                }

                Console.WriteLine("\n\nBad Habits:");
                foreach (Habit habit in activeUser.Habits)
                {
                    if (habit.Type == Enums.HabitType.Bad)
                    {
                        Console.WriteLine($"" +
                            $"\nHabit Title: {habit.Title}" +
                            $"\nHabit Group: {habit.Group}" +
                            $"\nHabit Difficulty: {habit.Difficulty}" +
                            $"\nHabit Type: {habit.Type}" +
                            $"\nHabit Date: {habit.Date}" +
                            $"\nHabit Completed: {habit.IsCompleted}");
                    }
                }

                Console.WriteLine("\n\nEnter habit title:");

                string userInput = Console.ReadLine();

                if (userInput == "0") return;
                if (userInput == "00") Environment.Exit(0);

                if (activeUser.Habits.Any(habit => habit.Title.ToLower() == userInput.ToLower()))
                {
                    foreach (Habit habit in activeUser.Habits)
                    {
                        if (habit.Title.ToLower() == userInput.ToLower())
                        {
                            Console.WriteLine($"Add record for habit {habit.Title}, Current Completion: {habit.IsCompleted}\nYour completion true or false:");
                            string userInput2 = Console.ReadLine();

                            switch (userInput2.ToLower())
                            {
                                case "true":
                                    habit.IsCompleted = true;
                                    Console.WriteLine("Record completion updated successfully! Press ENTER to continue");
                                    Console.ReadLine();
                                    break;
                                case "false":
                                    habit.IsCompleted = false;
                                    Console.WriteLine("Record completion updated successfully! Press ENTER to continue");
                                    Console.ReadLine();
                                    break;
                                case "0":
                                    return;
                                case "00":
                                    Environment.Exit(0);
                                    break;
                                default:
                                    Console.WriteLine("Invalid input please try again:");
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Habit not found, try again. Press ENTER to continue");
                    Console.ReadLine();
                    continue;
                }
            }
        }
        static void SingleLog(User activeUser)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0 Back\n 00 Exit");
                Console.WriteLine("\nAll habits:");

                Console.WriteLine("\nGood Habits:");
                foreach (Habit habit in activeUser.Habits)
                {
                    if (habit.Type == Enums.HabitType.Good)
                    {
                        Console.WriteLine($"" +
                            $"\nHabit Title: {habit.Title}" +
                            $"\nHabit Group: {habit.Group}" +
                            $"\nHabit Difficulty: {habit.Difficulty}" +
                            $"\nHabit Type: {habit.Type}" +
                            $"\nHabit Date: {habit.Date}" +
                            $"\nHabit Completed: {habit.IsCompleted}");
                    }
                }

                Console.WriteLine("\n\nBad Habits:");
                foreach (Habit habit in activeUser.Habits)
                {
                    if (habit.Type == Enums.HabitType.Bad)
                    {
                        Console.WriteLine($"" +
                            $"\nHabit Title: {habit.Title}" +
                            $"\nHabit Group: {habit.Group}" +
                            $"\nHabit Difficulty: {habit.Difficulty}" +
                            $"\nHabit Type: {habit.Type}" +
                            $"\nHabit Date: {habit.Date}" +
                            $"\nHabit Completed: {habit.IsCompleted}");
                    }
                }

                Console.WriteLine("\n\nEnter habit title:");

                string userInput = Console.ReadLine();

                if (userInput == "0") return;
                if (userInput == "00") Environment.Exit(0);

                if (activeUser.Habits.Any(habit => habit.Title.ToLower() == userInput.ToLower()))
                {
                    foreach (Habit habit in activeUser.Habits)
                    {
                        if (habit.Title.ToLower() == userInput.ToLower())
                        {
                            Console.WriteLine($"Add record for habit {habit.Title}, Current Date: {habit.Date}\nYour date in DAT/MONTH/YEAR format:");
                            string userInput2 = Console.ReadLine();

                            bool successfulDateConversion = DateTime.TryParse(userInput2, out DateTime recordDate);

                            if (userInput2 == "0") continue;

                            if (successfulDateConversion)
                            {
                                habit.Date = recordDate;
                                Console.WriteLine("Records Date updated successfully! Press enter to continue");
                                Console.Read();
                            }
                            else
                            {
                                Console.WriteLine("Wrong date input");
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Habit not found, try again. Press ENTER to continue");
                    Console.ReadLine();
                    continue;
                }
            }
        }
        static void HabitStatistics(User activeUser)
        {
            while (true)
            {
                int counterGood, counterBad, counterCompleeted, counterMissed;
                counterGood = counterBad = counterCompleeted = counterMissed = 0;
                double completedPercentage = 0;
                double missedPercentage = 0;

                Console.Clear();
                Console.WriteLine("0 Back\n 00 Exit");

                Console.WriteLine("\nChoose an option" +
                    "\n1)Good habits" +
                    "\n2)Bad habits" +
                    "\n3)Weekly statistics" +
                    "\n4)All time statistics" +
                    "\n5)---- ALL STATISTICS ----");

                string userInput = Console.ReadLine();

                if (userInput == "0") return;
                if (userInput == "00") Environment.Exit(0);

                switch (userInput)
                {
                    case "1":
                        counterGood = counterBad = counterCompleeted = counterMissed = 0;
                        foreach (Habit habit in activeUser.Habits)
                        {
                            if (habit.Type == Enums.HabitType.Good)
                            {
                                counterGood++;
                                Console.WriteLine($"" +
                                    $"\nHabit Title: {habit.Title}" +
                                    $"\nHabit Group: {habit.Group}" +
                                    $"\nHabit Difficulty: {habit.Difficulty}" +
                                    $"\nHabit Type: {habit.Type}" +
                                    $"\nHabit Date: {habit.Date}" +
                                    $"\nHabit Completed: {habit.IsCompleted}");
                            }
                        }
                        Console.WriteLine($"Total Good Habits Completed: {counterGood}");
                        Console.WriteLine("Press Enter to continue:");
                        Console.ReadLine();
                        break;
                    case "2":
                        counterGood = counterBad = counterCompleeted = counterMissed = 0;
                        foreach (Habit habit in activeUser.Habits)
                        {
                            if (habit.Type == Enums.HabitType.Bad)
                            {
                                counterBad++;
                                Console.WriteLine($"" +
                                    $"\nHabit Title: {habit.Title}" +
                                    $"\nHabit Group: {habit.Group}" +
                                    $"\nHabit Difficulty: {habit.Difficulty}" +
                                    $"\nHabit Type: {habit.Type}" +
                                    $"\nHabit Date: {habit.Date}" +
                                    $"\nHabit Completed: {habit.IsCompleted}");
                            }
                        }
                        Console.WriteLine($"Total Bad Habits Completed: {counterBad}");
                        Console.WriteLine("Press Enter to continue:");
                        Console.ReadLine();
                        break;
                    case "3":
                        counterGood = counterBad = counterCompleeted = counterMissed = 0;
                        foreach (Habit habit in activeUser.Habits)
                        {
                            if (habit.Date.Month == DateTime.Now.Month &&
                                habit.Date.Year == DateTime.Now.Year &&
                                DateTime.Now.Day - habit.Date.Day <= 7 &&
                                habit.IsCompleted == true) counterCompleeted++;
                            else counterMissed++;
                        }
                        Console.WriteLine("Statistics about || completed | missed || Habits during this week:");
                        Console.WriteLine($"Completed: {counterCompleeted}");
                        Console.WriteLine($"Missed: {counterMissed}");
                        Console.WriteLine("Press Enter to continue:");
                        Console.ReadLine();
                        break;
                    case "4":
                        counterGood = counterBad = counterCompleeted = counterMissed = 0;
                        foreach (Habit habit in activeUser.Habits)
                        {
                            if (habit.IsCompleted == true) counterCompleeted++;
                            else counterMissed++;
                        }
                        if (counterCompleeted != 0)
                            completedPercentage = (((counterCompleeted + counterMissed) / counterCompleeted) * 100);
                        else
                            completedPercentage = 0;

                        if (counterMissed != 0)
                            missedPercentage = (((counterCompleeted + counterMissed) / counterCompleeted) * 100);
                        else
                            missedPercentage = 0;

                        Console.WriteLine($"Completed: {completedPercentage}%");
                        Console.WriteLine($"Missed: {missedPercentage}%");
                        Console.WriteLine("Press Enter to continue:");
                        Console.ReadLine();
                        break;
                    case "5":
                        counterGood = counterBad = counterCompleeted = counterMissed = 0;
                        foreach (Habit habit in activeUser.Habits)
                        {
                            if (habit.Type == Enums.HabitType.Good)
                            {
                                counterGood++;
                                Console.WriteLine($"" +
                                    $"\nHabit Title: {habit.Title}" +
                                    $"\nHabit Group: {habit.Group}" +
                                    $"\nHabit Difficulty: {habit.Difficulty}" +
                                    $"\nHabit Type: {habit.Type}" +
                                    $"\nHabit Date: {habit.Date}" +
                                    $"\nHabit Completed: {habit.IsCompleted}");
                            }
                        }
                        Console.WriteLine($"Total Good Habits Completed: {counterGood}");

                        counterGood = counterBad = counterCompleeted = counterMissed = 0;
                        foreach (Habit habit in activeUser.Habits)
                        {
                            if (habit.Type == Enums.HabitType.Bad)
                            {
                                counterBad++;
                                Console.WriteLine($"" +
                                    $"\nHabit Title: {habit.Title}" +
                                    $"\nHabit Group: {habit.Group}" +
                                    $"\nHabit Difficulty: {habit.Difficulty}" +
                                    $"\nHabit Type: {habit.Type}" +
                                    $"\nHabit Date: {habit.Date}" +
                                    $"\nHabit Completed: {habit.IsCompleted}");
                            }
                        }
                        Console.WriteLine($"Total Good Habits Completed: {counterBad}");

                        counterGood = counterBad = counterCompleeted = counterMissed = 0;
                        foreach (Habit habit in activeUser.Habits)
                        {
                            if (habit.Date.Month == DateTime.Now.Month &&
                                habit.Date.Year == DateTime.Now.Year &&
                                DateTime.Now.Day - habit.Date.Day <= 7) counterCompleeted++;
                            else counterMissed++;
                        }
                        Console.WriteLine("Statistics about || completed | missed || Habits during this week:");
                        Console.WriteLine($"Completed: {counterCompleeted}");
                        Console.WriteLine($"Missed: {counterMissed}");

                        counterGood = counterBad = counterCompleeted = counterMissed = 0;
                        foreach (Habit habit in activeUser.Habits)
                        {
                            if (habit.IsCompleted == true) counterCompleeted++;
                            else counterMissed++;
                        }
                        if (counterCompleeted != 0)
                            completedPercentage = (((counterCompleeted + counterMissed) / counterCompleeted) * 100);
                        else
                            completedPercentage = 0;

                        if (counterMissed != 0)
                            missedPercentage = (((counterCompleeted + counterMissed) / counterMissed) * 100);
                        else
                            missedPercentage = 0;

                        Console.WriteLine($"Completed: {completedPercentage}%");
                        Console.WriteLine($"Missed: {missedPercentage}%");
                        Console.WriteLine("Press Enter to continue:");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid Input, press Enter to continue");
                        Console.ReadLine();
                        break;
                }

            }
        }
        static void EditAccount(User activeUser)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0 Back\n 00 Exit");
                Console.WriteLine("\nPlease choose:\n1) Add habit\n2) Remove habit \n3) Edit info \n4) Change password");

                string userInput = Console.ReadLine();

                if (userInput == "0") return;
                if (userInput == "00") Environment.Exit(0);

                switch (userInput)
                {
                    case "1":
                        AddHabit(activeUser);
                        break;
                    case "2":
                        RemoveHabit(activeUser);
                        break;
                    case "3":
                        ValidateName();
                        break;
                    case "4":
                        NewPassword(activeUser);
                        break;
                    default:
                        Console.WriteLine("Invalid input, pres ENTER to continue");
                        Console.ReadLine();
                        break;
                }
            }            
        }
        static void AddHabit(User activeUser)
        {
            Console.Clear();
            Console.WriteLine("0 Back\n 00 Exit");
            string habitTitle = String.Empty;
            
            Console.WriteLine("\nPlease enter habit title:");
            habitTitle = Console.ReadLine();

            if (habitTitle == "0") return;
            if (habitTitle == "00") Environment.Exit(0);

            int groupCheck = ValidateHabitGroup();
            if (groupCheck == 0) return;
            int difficultyCheck = ValidateHabitDifficulty();
            if (difficultyCheck == 0) return;
            int typeCheck = ValidateHabitType();
            if (typeCheck == 0) return;

            activeUser.Habits.Add(new Habit
                (
                habitTitle,
                (Enums.Group)groupCheck,
                (Enums.Difficulty)difficultyCheck,
                (Enums.HabitType)typeCheck
                ));
            Console.WriteLine("Habit succesfully added");
        }
        static void RemoveHabit(User activeUser)
        {
            Console.Clear();
            Console.WriteLine("0 Back\n 00 Exit");
            string habitTitle = String.Empty;

            Console.WriteLine("\nPlease enter habit title:");
            habitTitle = Console.ReadLine();

            if (habitTitle == "0") return;
            if (habitTitle == "00") Environment.Exit(0);


            foreach (Habit habit in activeUser.Habits)
            {
                if (habitTitle == habit.Title)
                {
                    activeUser.Habits.Remove(habit);
                    Console.WriteLine("Habit succesfully added, press Enter to continue");
                    Console.ReadLine();
                    return;
                }
            }

            Console.WriteLine("No such habit found");
        }
        static void EditInfo(User activeUser)
        {            
            activeUser.FirstName = ValidateName();
        }
        static void ChangePassword(User activeUser)
        {
            Console.Clear();
            Console.WriteLine("0 Back\n 00 Exit");
            string habitTitle = String.Empty;

            Console.WriteLine("\nPlease enter habit title:");
            habitTitle = Console.ReadLine();

            if (habitTitle == "0") return;
            if (habitTitle == "00") Environment.Exit(0);

            int groupCheck = ValidateHabitGroup();
            if (groupCheck == 0) return;
            int difficultyCheck = ValidateHabitDifficulty();
            if (difficultyCheck == 0) return;
            int typeCheck = ValidateHabitType();
            if (typeCheck == 0) return;

            activeUser.Habits.Add(new Habit
                (
                habitTitle,
                (Enums.Group)groupCheck,
                (Enums.Difficulty)difficultyCheck,
                (Enums.HabitType)typeCheck
                ));
            Console.WriteLine("Habit succesfully added");
        }
        static string NewPassword(User activeUser)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0 Back\n 00 Exit");
                Console.WriteLine("\nPlease enter old password");
                string oldPasswordInput = Console.ReadLine();

                if(oldPasswordInput != activeUser.Password)
                {
                    Console.WriteLine("Incorrect password please try again!");
                    continue;
                }

                Console.WriteLine("Please enter new password");
                string userInput = Console.ReadLine();

                if (userInput == "0") return userInput;
                if (userInput == "00") Environment.Exit(0);

                if (userInput.Trim().Length < 6)
                {
                    Console.WriteLine("Password must have atleast 6 characters");
                }
                else if (!userInput.Any(char.IsDigit))
                {
                    Console.WriteLine("Password must contain a number");
                }
                else
                {
                    Console.WriteLine("Please confirm password:");
                    string userInputConfirm = Console.ReadLine();

                    if (userInput == userInputConfirm) return userInput;
                    else
                    {
                        Console.WriteLine("Passwords don't match, please start over:");
                        continue;
                    }
                }
            }
        }
    }
    }

