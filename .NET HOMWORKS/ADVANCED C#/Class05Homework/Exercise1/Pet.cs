
namespace Exercise1
{
    public abstract class Pet
    {
        public string Name { get; set; }
        public string Type { get; private set; }
        public int Age { get; set; }
        public abstract void PrintInfo();
        public Pet(string name, string type, int age)
        {
            Name = name;
            Type = type;
            Age = age;
        }
    }
}
