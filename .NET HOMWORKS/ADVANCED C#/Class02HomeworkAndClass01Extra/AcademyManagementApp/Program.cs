using System;
using System.Linq;
using AcademyManagementAppModels.Enums;
using AcademyManagementAppModels.Database;
using AcademyManagementAppModels;

namespace AcademyManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the academy! Please log in below");

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\nPlease enter username:");
                    string username = Console.ReadLine();
                    Console.WriteLine("\nPlease enter password");
                    string password = Console.ReadLine();

                    User loginUser = Storage.users.FirstOrDefault(x => x.Login(username, password) != null);

                    if (loginUser == null)
                    {
                        throw new Exception("Invalid username");
                    }
                    else if (loginUser != null)
                    {
                        UserUI((User)loginUser);
                    }            
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void UserUI(User loginUser)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\n\nWelcome {loginUser.FullName}\n\n");
                
                if(loginUser.UserType == UserTypeEnum.Student)
                {
                    Student loginStudent = (Student)loginUser;
                    loginStudent.PrintCurrentSubject();
                    Console.WriteLine("\n\n");
                    loginStudent.PrintAllGrades();
                    Console.WriteLine("\n\nPress enter to log out:");
                    Console.ReadLine();
                    return;
                }
                else if (loginUser.UserType == UserTypeEnum.Trainer)
                {
                    Trainer loginTrainer = (Trainer)loginUser;
                    Console.WriteLine("\n\nPlease choose an option:" +
                    "\n1) List of all students" +
                    "\n2) List of subject for student" +
                    "\n3) List of all subjects" +
                    "\n4) Log Out");
                    string userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            Console.Clear();
                            loginTrainer.PrintAllStudents(Storage.users);

                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("\nPlease enter student name:");
                            string studentNameInput = Console.ReadLine();

                            loginTrainer.PrintAllSubjectsOfStudent(Storage.users, studentNameInput);

                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;

                        case "3":
                            Console.Clear();
                            loginTrainer.PrintAllSubjects(Storage.users);
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;

                        case "4":
                            return;

                        default:
                            Console.Clear();
                            Console.WriteLine("Wrong input, press enter to try again");
                            Console.ReadLine();
                            break;
                    }
                }
                else if (loginUser.UserType == UserTypeEnum.Admin)
                {
                    Admin loginAdmin = (Admin)loginUser;
                    Console.WriteLine("\n\nPlease choose an option:" +
                    "\n1) Remove a user" +
                    "\n2) Add a user" +
                    "\n3) Log Out");
                    string userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("\nPlease enter student name:");
                            string nameToRemoveUserInput = Console.ReadLine();

                            loginAdmin.RemoveUsers(Storage.users, nameToRemoveUserInput);
                            break;

                        case "2":
                            Console.Clear();
                            loginAdmin.AddUsers(Storage.users);
                            break;

                        case "3":
                            return;

                        default:
                            Console.WriteLine("Wrong input, press enter to try again");
                            Console.ReadLine();
                            break;
                    }
                }
            }

        }

    }
}
