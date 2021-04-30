namespace AcademyManagementAppModels.Interfaces
{
    interface IStudent : IUser
    {
        void PrintCurrentSubject();
        void PrintAllGrades();
    }
}
