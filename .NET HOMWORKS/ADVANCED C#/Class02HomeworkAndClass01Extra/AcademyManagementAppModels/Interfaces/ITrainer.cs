using System.Collections.Generic;

namespace AcademyManagementAppModels.Interfaces
{
    interface ITrainer : IUser
    {
        void PrintAllStudents(List<User> users);
        void PrintAllSubjectsOfStudent(List<User> users, string name);
        void PrintAllSubjects(List<User> users);
    }
}
