using System;

namespace StudentGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] studentsG1 = new string[] { "Zdravko", "Petko", "Stanko", "Branko", "Trajko" };
            string[] studentsG2 = new string[] { "Niko", "Miko", "Kiko", "Manji", "Fiko" };

            bool successfulNumberConversion = false;
            int groupNumber = 0;
            do
            {
                Console.WriteLine("Enter student group: ( there are 1 and 2 )");
                string inputNumber = Console.ReadLine();
                successfulNumberConversion = int.TryParse(inputNumber, out groupNumber);

                if (successfulNumberConversion == false || groupNumber > 2 || groupNumber < 1)
                {
                    Console.WriteLine("Invalid input! Please enter 1 or 2");
                }

            }
            while (successfulNumberConversion == false || groupNumber > 2 || groupNumber < 1);

            if (groupNumber == 1)
            {
                Console.WriteLine("The Students in G1 are:");

                foreach (string student in studentsG1)
                {
                    Console.WriteLine(student);
                }
            }
            else
            {
                Console.WriteLine("The Students in G2 are:");

                foreach (string student in studentsG2
                    )
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}
