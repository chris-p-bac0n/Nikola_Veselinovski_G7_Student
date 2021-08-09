using System;

namespace Exercise1
{
    public class Dog : Pet
    {
        public bool GoodBoi { get; set; }
        public string FavoriteFood { get; set; }
        public Dog(string name, string type, int age, bool goodBoi, string favoriteFood) : base(name, "dog", age)
        {
            GoodBoi = goodBoi;
            FavoriteFood = favoriteFood;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"{Name}, {Type}, {Age}");
        }
    }
}
