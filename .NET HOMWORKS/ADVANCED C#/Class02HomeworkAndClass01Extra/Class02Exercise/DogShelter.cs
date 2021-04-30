using System;
using System.Collections.Generic;
using System.Text;

namespace Class02Exercise
{
    public static class DogShelter
    {
        public static List<Dog> dogs = new List<Dog>();
        public static void PrintAll(List<Dog> dogs)
        {
            foreach (Dog dog in dogs)
            {
                Console.WriteLine($"{dog.Id,15} | {dog.Name,15} | {dog.Color,15}");
            }
        }
    }
}
