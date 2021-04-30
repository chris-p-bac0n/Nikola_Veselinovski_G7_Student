using System;
namespace Class01Models.Interfaces
{
    interface IUser
    {
        string Id { get; set; }
        string Name { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        void PrintUser();
    }
}
