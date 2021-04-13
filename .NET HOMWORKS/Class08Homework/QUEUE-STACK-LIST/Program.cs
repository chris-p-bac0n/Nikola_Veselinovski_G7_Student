using System;
using System.Collections.Generic;

namespace QUEUE_STACK_LIST
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCollectionType = String.Empty;
            int collectionType = 0;
            Queue<int> numbersQueue = new Queue<int>();
            Stack<int> numbersStack = new Stack<int>();
            List<int> numbersList = new List<int>();

            while (collectionType == 0 || collectionType > 3)
            {
                Console.WriteLine("Please chose how to store the numbers:\n1) Queue\n2) Stack\n3) List");
                inputCollectionType = Console.ReadLine();
                bool isNumber = int.TryParse(inputCollectionType, out collectionType);

                if (collectionType == 0 || collectionType > 3) Console.WriteLine("Invalid choice");
            }

            string inputAnother = String.Empty;

            while (inputAnother.ToLower() != "n")
            {
                Console.WriteLine("Please input a number:");
                string inputNumber = Console.ReadLine();
                bool isNumber = int.TryParse(inputNumber, out int number);

                if (isNumber)
                {
                    switch (collectionType)
                    {
                        case 1:
                            numbersQueue.Enqueue(number);
                            break;

                        case 2:
                            numbersStack.Push(number);
                            break;

                        case 3:
                            numbersList.Add(number);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Input not a number");
                    continue;
                }

                while (true)
                {
                    Console.WriteLine("Do you want to input another number? : (Y/N)");
                    inputAnother = Console.ReadLine();

                    if (inputAnother.ToLower() == "n") break;
                    else if (inputAnother.ToLower() == "y") break;
                    else
                    {
                        Console.WriteLine("Invalid choice"); 
                            continue;
                    }
                }       
            }

            switch (collectionType)
            {
                case 1:
                    foreach (int number in numbersQueue)
                    {
                        Console.WriteLine(number);
                    }                    
                    break;

                case 2:
                    foreach (int number in numbersStack)
                    {
                        Console.WriteLine(number);
                    }
                    break;

                case 3:
                    foreach (int number in numbersList)
                    {
                        Console.WriteLine(number);
                    }
                    break;
            }
        }
    }
}
