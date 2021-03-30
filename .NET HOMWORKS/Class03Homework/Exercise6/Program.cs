using System;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayWithNames = new string[1];

            Console.WriteLine("Please enter a name");
            string inputName = Console.ReadLine();
            arrayWithNames[0] = inputName;

            string inputEnterAnotherName = "";

            do
            {
                Console.WriteLine("Do you want to enter another name ? (Y / N)");
                inputEnterAnotherName = Console.ReadLine();
                                
                if (inputEnterAnotherName.ToLower() == "y")
                {
                    Console.WriteLine("Please enter a name");
                    inputName = Console.ReadLine();

                    Array.Resize(ref arrayWithNames, arrayWithNames.Length + 1);
                    arrayWithNames[arrayWithNames.Length - 1] = inputName;
                }
                else if (inputEnterAnotherName.ToLower() == "n")
                {
                    foreach (string name in arrayWithNames)
                    {
                        Console.WriteLine(name);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input ! Please enter (Y / N)");
                    inputEnterAnotherName = "y";
                }

            }
            while (inputEnterAnotherName.ToLower() == "y");
        }
    }
}
