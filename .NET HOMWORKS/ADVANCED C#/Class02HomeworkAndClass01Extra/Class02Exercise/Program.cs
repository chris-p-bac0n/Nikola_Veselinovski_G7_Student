using System;

namespace Class02Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog Barnie = new Dog(564, "Barnie", "White");
            Dog Doogie = new Dog(123, "Doogie", "Black");
            Dog Josie = new Dog(-25, "Josie", "Black and White");

            if (Barnie.Validate()) DogShelter.dogs.Add(Barnie);
            if (Doogie.Validate()) DogShelter.dogs.Add(Doogie);
            if (Josie.Validate()) DogShelter.dogs.Add(Josie);
        }
    }
}
