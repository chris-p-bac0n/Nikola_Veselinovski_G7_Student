using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Adv_Code_15_5
{
    //    --- Day 3: Perfectly Spherical Houses in a Vacuum ---
    //    --- Part Two ---
    //The next year, to speed up the process, Santa creates a robot version of himself, Robo-Santa, to deliver presents with him.

    //Santa and Robo-Santa start at the same location(delivering two presents to the same starting house), then take turns moving based on instructions from the elf, who is eggnoggedly reading from the same script as the previous year.

    //This year, how many houses receive at least one present?

    //For example:

    //^v delivers presents to 3 houses, because Santa goes north, and then Robo-Santa goes south.
    //^>v<now delivers presents to 3 houses, and Santa and Robo-Santa end up back where they started.
    //^v^v^v^v^v now delivers presents to 11 houses, with Santa going one direction and Robo-Santa going the other.
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "santaInstructions.txt";

            using var sr = new StreamReader(fileName);

            string instructions = sr.ReadToEnd();

            List<int[]> listOfCoordinates = new List<int[]>();
            listOfCoordinates.Add(new int[] { 0, 0 });
            int[] santaCurrentCoordinates = new int[] { 0, 0 };
            int[] roboSantaCurrentCoordinates = new int[] { 0, 0 };

            bool santaFlag = true;
            foreach (var instruction in instructions)
            {
                if (santaFlag)
                {
                    switch (instruction)
                    {
                        case '^':
                            santaCurrentCoordinates[0]++;
                            break;
                        case 'v':
                            santaCurrentCoordinates[0]--;
                            break;
                        case '>':
                            santaCurrentCoordinates[1]++;
                            break;
                        case '<':
                            santaCurrentCoordinates[1]--;
                            break;
                    }

                    bool coordinateFound = false;
                    foreach (var coordinate in listOfCoordinates)
                    {
                        if (coordinate[0] == santaCurrentCoordinates[0] && coordinate[1] == santaCurrentCoordinates[1]) coordinateFound = true;
                    }

                    if (!coordinateFound) listOfCoordinates.Add(new int[] { santaCurrentCoordinates[0], santaCurrentCoordinates[1] });

                    santaFlag = !santaFlag;
                } else
                {
                    switch (instruction)
                    {
                        case '^':
                            roboSantaCurrentCoordinates[0]++;
                            break;
                        case 'v':
                            roboSantaCurrentCoordinates[0]--;
                            break;
                        case '>':
                            roboSantaCurrentCoordinates[1]++;
                            break;
                        case '<':
                            roboSantaCurrentCoordinates[1]--;
                            break;
                    }

                    bool coordinateFound = false;
                    foreach (var coordinate in listOfCoordinates)
                    {
                        if (coordinate[0] == roboSantaCurrentCoordinates[0] && coordinate[1] == roboSantaCurrentCoordinates[1]) coordinateFound = true;
                    }

                    if (!coordinateFound) listOfCoordinates.Add(new int[] { roboSantaCurrentCoordinates[0], roboSantaCurrentCoordinates[1] });

                    santaFlag = !santaFlag;
                }
            }

            Console.WriteLine(listOfCoordinates.Count());
        }
    }
}
