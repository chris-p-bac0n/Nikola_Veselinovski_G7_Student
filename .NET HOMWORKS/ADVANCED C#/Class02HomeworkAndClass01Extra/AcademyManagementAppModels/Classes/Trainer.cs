using System;
using System.Collections.Generic;
using AcademyManagementAppModels.Interfaces;
using AcademyManagementAppModels.Enums;

namespace AcademyManagementAppModels
{
    public class Trainer : User, ITrainer
    {
        public Trainer(string firstName, string lastName, string username, string password, UserTypeEnum userType) :
            base(firstName, lastName, username, password, UserTypeEnum.Trainer)
        {

        }
        public void PrintAllStudents(List<User> users)
        {
            Console.WriteLine("List of all students:");
            foreach (User student in users)
            {
                if (student.UserType != UserTypeEnum.Student) continue;

                Console.WriteLine($"{student.FirstName}");
            }
        }
        public void PrintAllSubjectsOfStudent(List<User> users, string name)
        {
            foreach (User student in users)
            {
                if (student.UserType != UserTypeEnum.Student) continue;

                Student studentUser = (Student)student;

                if (student.FirstName == name)
                {
                    Console.WriteLine($"{student.FullName}");
                    studentUser.PrintAllGrades();
                    return;
                }
            }
            throw new Exception("No user with that name found!");
        }
        public void PrintAllSubjects(List<User> users)
        {
            int geoCount = 0;
            int histCount = 0;
            int mathCount = 0;

            foreach (User student in users)
            {
                if (student.UserType != UserTypeEnum.Student) continue;

                Student studentUser = (Student)student;

                if (studentUser.ActiveSubject == SubjectEnum.Geography) geoCount++;
                else if (studentUser.ActiveSubject == SubjectEnum.History) histCount++;
                else if(studentUser.ActiveSubject == SubjectEnum.Math) mathCount++;
            }

            Console.WriteLine($"Subject{15} | Attendees" +
                $"\n{SubjectEnum.Geography,15} | {geoCount}" +
                $"\n{SubjectEnum.History,15} | {histCount}"+
                $"\n{SubjectEnum.Math,15} | {mathCount}");
        }
    }
}
