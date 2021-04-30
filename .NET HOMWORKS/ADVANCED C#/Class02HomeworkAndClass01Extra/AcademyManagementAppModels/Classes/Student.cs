using System;
using System.Collections.Generic;
using AcademyManagementAppModels.Interfaces;
using AcademyManagementAppModels.Enums;

namespace AcademyManagementAppModels
{
    public class Student : User, IStudent
    {
        public Dictionary<SubjectEnum, GradeEnum> Grades = new Dictionary<SubjectEnum, GradeEnum>
        {
            {SubjectEnum.Geography, GradeEnum.A },
            {SubjectEnum.History, GradeEnum.B },
            {SubjectEnum.Math, GradeEnum.C }
        };
        public SubjectEnum ActiveSubject { get; set; }
        public Student(string firstName, string lastName, string username, string password, UserTypeEnum userType, SubjectEnum activeSubject) :
            base(firstName, lastName, username, password, UserTypeEnum.Student)
        {
            ActiveSubject = activeSubject;
        }
        public void PrintAllGrades()
        {
            Console.WriteLine($"Subject{15} | Grade");
            foreach (KeyValuePair<SubjectEnum, GradeEnum> entry in Grades)
            {
                Console.WriteLine($"{entry.Key,15} | {entry.Value}");
            }
        }
        public void PrintCurrentSubject()
        {
            Console.WriteLine($"Currently Listening: {ActiveSubject}");
        }
    }
}
