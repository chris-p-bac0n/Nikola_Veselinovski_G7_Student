using System;
using System.IO;
using System.Linq;

namespace Adv_Code_15_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "santaInstructions.txt";

            using var sr = new StreamReader(fileName);

            string instructions = sr.ReadToEnd();

            int deliveryFloor = 0;
            int instructionIndexForBasement = 0;

            for (int i = 0; i < instructions.Length; i++)
            {
                var woo =  instructions[i] == '(' ? deliveryFloor++ : deliveryFloor--;
                
                if(deliveryFloor == -1)
                {
                    instructionIndexForBasement = i;
                    break;
                }
            }

            

            Console.WriteLine($"The char index where santa goes to the basement is {instructionIndexForBasement + 1}");
        }
    }
}
