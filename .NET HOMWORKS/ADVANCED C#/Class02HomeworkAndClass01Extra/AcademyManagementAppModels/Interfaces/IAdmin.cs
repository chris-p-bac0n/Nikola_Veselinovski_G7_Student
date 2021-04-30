using System.Collections.Generic;

namespace AcademyManagementAppModels.Interfaces

{
    interface IAdmin
    {
        void RemoveUsers(List<User> users, string name);
        void AddUsers(List<User> users);
    }
}
