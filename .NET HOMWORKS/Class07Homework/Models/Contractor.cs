namespace Models
{
    public class Contractor : Employee
    {
        public Contractor(string firstName, string lastName) : base(firstName, lastName,
            Role.Contractor, 0)
        {

        }

        public override double GetSalary()
        {            
            Salary = WorkHours * PayPerHour;
            return Salary;
        }
    }
}
