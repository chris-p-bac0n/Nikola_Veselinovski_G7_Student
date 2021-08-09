using System;

namespace Exercise1
{
    public class Fish : Pet
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public Fish(string name, string type, int age, string color, string size) : base(name, "fish", age)
        {
            Color = color;
            Size = size;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"{Name}, {Type}, {Age}");
        }
    }
}
