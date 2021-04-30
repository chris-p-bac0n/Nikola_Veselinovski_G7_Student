namespace AcademyManagementAppModels.Interfaces
{
    interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName => $"{FirstName} {LastName}";
        string Username { get; set; }
        int FailedLoginAttempts { get; set; }
        bool Locked => FailedLoginAttempts >= 3;
        User Login(string username, string password);
    }
}
