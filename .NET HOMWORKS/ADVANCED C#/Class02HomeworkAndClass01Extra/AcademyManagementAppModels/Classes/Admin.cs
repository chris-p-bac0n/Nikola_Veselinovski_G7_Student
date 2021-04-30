using System;
using System.Linq;
using System.Collections.Generic;
using AcademyManagementAppModels.Interfaces;
using AcademyManagementAppModels.Enums;

namespace AcademyManagementAppModels
{
    public class Admin : User, IAdmin
    {
        public Admin(string firstName, string lastName, string username, string password, UserTypeEnum userType) :
            base(firstName, lastName, username, password, UserTypeEnum.Admin)
        {

        }
        public void RemoveUsers(List<User> users, string name)
        {
            User userToRemove = null;
            userToRemove = users.FirstOrDefault(x => x.FirstName == name);

            if (userToRemove != this) users.Remove(userToRemove);
            else throw new Exception("You can't remove yourself, that would open up a blackhole and turn existence inside out!");
        }
        public void AddUsers(List<User> users)
        {
            Console.WriteLine("Insert First Name:");
            string newUserFirstName = Console.ReadLine();

            Console.WriteLine("Insert Last Name:");
            string newUserLastName = Console.ReadLine();

            Console.WriteLine("Insert Username:");
            string newUserUsername = Console.ReadLine();

            Console.WriteLine("Insert Password:");
            string newUserPassword = Console.ReadLine();
                        
            Console.WriteLine("Choose UserType (1/2/3):" +
                "\n1) Student" +
                "\n2) Trainer" +
                "\n3) Admin");
            string newUserUserTypeInput = Console.ReadLine();

            UserTypeEnum newUserUserType = 0;
            
            switch (newUserUserTypeInput)
            {
                case "1":
                    Console.WriteLine("Choose Active Subject (1/2/3):" +
                "\n1) Geography" +
                "\n2) History" +
                "\n3) Math");
                    string newUserActiveSubjectInput = Console.ReadLine();

                    SubjectEnum newUserActiveSubject = 0;

                    switch (newUserActiveSubjectInput)
                    {
                        case "1":
                            newUserActiveSubject = SubjectEnum.Geography;
                            break;
                        case "2":
                            newUserActiveSubject = SubjectEnum.History;
                            break;
                        case "3":
                            newUserActiveSubject = SubjectEnum.Math;
                            break;
                        default:
                            Console.WriteLine("Wrong input of Active Subject!");
                            return;
                    }

                    newUserUserType = UserTypeEnum.Student;
                    users.Add(new Student(newUserFirstName, newUserLastName, newUserUsername, newUserPassword, newUserUserType, newUserActiveSubject));
                    break;

                case "2":
                    newUserUserType = UserTypeEnum.Trainer;
                    users.Add(new Trainer(newUserFirstName, newUserLastName, newUserUsername, newUserPassword, newUserUserType));
                    break;

                case "3":
                    newUserUserType = UserTypeEnum.Admin;
                    users.Add(new Admin(newUserFirstName, newUserLastName, newUserUsername, newUserPassword, newUserUserType));
                    break;

                default:
                    Console.WriteLine("Wrong input of UserType!");
                    return;
            }
        }
    }
}
