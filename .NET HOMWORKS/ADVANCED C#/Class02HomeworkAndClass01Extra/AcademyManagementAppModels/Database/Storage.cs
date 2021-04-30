using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyManagementAppModels.Database
{
    public static class Storage
    {
        public static List<User> users { get; set; }

        static Storage()
        {
            users = new List<User>
            {
                new Student("Miki", "Kwiki", "miki", "miki123", Enums.UserTypeEnum.Student, Enums.SubjectEnum.Geography),
                new Student("Timon", "Meerkat", "timon", "timon123", Enums.UserTypeEnum.Student, Enums.SubjectEnum.History),
                new Student("Pumba", "Warthog", "pumba", "pumba123", Enums.UserTypeEnum.Student, Enums.SubjectEnum.Geography),
                new Student("Simba", "Lion", "simba", "simba123", Enums.UserTypeEnum.Student, Enums.SubjectEnum.Math),
                new Student("Nemo", "Flipper", "nemo", "nemo123", Enums.UserTypeEnum.Student, Enums.SubjectEnum.History),
                new Student("Dori", "Fish", "dori", "dori123", Enums.UserTypeEnum.Student, Enums.SubjectEnum.Geography),
                new Trainer("John", "Wayne", "john", "john123", Enums.UserTypeEnum.Trainer),
                new Admin("Bruce", "Almighty", "bruce", "bruce123", Enums.UserTypeEnum.Admin)
            };
        }
    }
}
