using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Adv_Code_15_4
{
//    --- Day 3: Perfectly Spherical Houses in a Vacuum ---
//Santa is delivering presents to an infinite two-dimensional grid of houses.

//He begins by delivering a present to the house at his starting location, and then an elf at the North Pole calls him via radio and tells him where to move next.Moves are always exactly one house to the north (^), south(v), east(>), or west(<). After each move, he delivers another present to the house at his new location.

//However, the elf back at the north pole has had a little too much eggnog, and so his directions are a little off, and Santa ends up visiting some houses more than once.How many houses receive at least one present?

//For example:

//> delivers presents to 2 houses: one at the starting location, and one to the east.
//^>v<delivers presents to 4 houses in a square, including twice to the house at his starting/ending location.
//^v^v^v^v^v delivers a bunch of presents to some very lucky children at only 2 houses.
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "santaInstructions.txt";

            using var sr = new StreamReader(fileName);

            string instructions = sr.ReadToEnd();

            List<int[]> listOfCoordinates = new List<int[]>();
            listOfCoordinates.Add(new int[] { 0, 0 });
            int[] currentCoordinates = new int[] { 0, 0 };

            foreach (var instruction in instructions)
            {
                switch (instruction)
                {
                    case '^':
                        currentCoordinates[0]++;
                        break;
                    case 'v':
                        currentCoordinates[0]--;
                        break;
                    case '>':
                        currentCoordinates[1]++;
                        break;
                    case '<':
                        currentCoordinates[1]--;
                        break;
                }

                bool coordinateFound = false;
                foreach (var coordinate in listOfCoordinates)
                {
                    if (coordinate[0] == currentCoordinates[0] && coordinate[1] == currentCoordinates[1]) coordinateFound = true;
                }
                
                if(!coordinateFound) listOfCoordinates.Add(new int[] { currentCoordinates[0], currentCoordinates[1] });
            }

            Console.WriteLine(listOfCoordinates.Count());
            Console.WriteLine(currentCoordinates[0]);
            Console.WriteLine(currentCoordinates[1]);
        }
    }
}
