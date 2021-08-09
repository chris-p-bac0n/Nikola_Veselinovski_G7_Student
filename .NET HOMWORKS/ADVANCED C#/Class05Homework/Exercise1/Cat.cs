using System;

namespace Exercise1
{
    public class Cat : Pet
    {
        public bool Lazy { get; set; }
        public int LivesLeft { get; set; }
        public Cat(string name, string type, int age, bool lazy, int livesLeft) : base(name, "cat", age)
        {
            Lazy = lazy;
            LivesLeft = livesLeft;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"{Name}, {Type}, {Age}");
        }
    }
}
