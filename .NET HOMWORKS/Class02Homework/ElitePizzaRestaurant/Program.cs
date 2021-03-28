using System;

namespace ElitePizzaRestaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which day would you like to book a table on our restaurant:");
            string DayOfWeek = Console.ReadLine();

            Console.WriteLine("Enter the number of total booked orders:");
            string inputTotalOrders = Console.ReadLine();

            bool successfulNumberConversionOne = int.TryParse(inputTotalOrders, out int totalOrders);

            if (!successfulNumberConversionOne)
            {
                Console.WriteLine("You must enter valid number!");
                Console.Beep();

                return;
            }
            else if (totalOrders <= 0)
            {
                Console.WriteLine("You must place at least 1 order!");
                Console.Beep();

                return;
            }
            else if (totalOrders > 30)
            {
                Console.WriteLine("You can't place more than 30 orders!");
                Console.Beep();

                return;
            }
            else
            {
                int regularOrderPrice;
                int eliteOrderPrice;
                double totalPriceElite = 0;
                double totalPriceRegular = 0;
                                
                switch (DayOfWeek.ToLower())
                {
                    case "monday":
                    case "tuesday":
                    case "wednesday":

                        regularOrderPrice = 300;
                        eliteOrderPrice = 450;

                        totalPriceRegular = regularOrderPrice * totalOrders;
                        totalPriceElite = eliteOrderPrice * totalOrders;

                        if (totalOrders > 6)
                        {
                            totalPriceElite -= totalPriceElite * 20 / 100;
                        }

                        break;

                    case "thursday":
                    case "friday":

                        regularOrderPrice = 350;
                        eliteOrderPrice = 500;

                        totalPriceRegular = regularOrderPrice * totalOrders;
                        totalPriceElite = eliteOrderPrice * totalOrders;

                        if (totalOrders > 3)
                        {
                            totalPriceRegular -= totalPriceRegular * 30 / 100;
                        }

                        if (totalOrders > 6)
                        {
                            totalPriceElite -= totalPriceElite * 20 / 100;
                        }

                        break;

                    case "saturday":
                    case "sunday":

                        regularOrderPrice = 400;
                        eliteOrderPrice = 550;

                        totalPriceRegular = regularOrderPrice * totalOrders;
                        totalPriceElite = eliteOrderPrice * totalOrders;

                        if (totalOrders > 5)
                        {
                            totalPriceRegular -= totalPriceRegular * 35 / 100;
                        }

                        if (totalOrders > 4)
                        {
                            totalPriceElite -= totalPriceElite * 40 / 100;
                        }

                        if (totalOrders > 6)
                        {
                            totalPriceElite -= totalPriceElite * 20 / 100;
                        }

                        break;

                    default:
                        Console.WriteLine("You must ener a valid day of the week!");
                        Console.Beep();

                        break;                                                
                }

                if (totalPriceRegular != 0)
                {
                    Console.WriteLine("The calculated price for a regular order would be: " + totalPriceRegular + "\nThe calculated price for elite order would be: " + totalPriceElite);
                    Console.WriteLine("What type of order would you like to continue with: \na) regular order \nb) elite  order");
                    string orderType = Console.ReadLine();

                    if (orderType.ToLower() == "a" || orderType.ToLower() == "a)" || orderType.ToLower() == "regular" || orderType.ToLower() == "regular order")
                    {
                        Console.WriteLine("Congratulations, you have booked your regular order for " + totalPriceRegular + " den.");
                    }
                    else if (orderType.ToLower() == "b" || orderType.ToLower() == "b)" || orderType.ToLower() == "elite" || orderType.ToLower() == "elite order")
                    {
                        Console.WriteLine("Congratulations, you have booked your elite order for " + totalPriceElite + " den.");
                    }
                    else
                    {
                        Console.WriteLine("You must enter a valid order type!");
                        Console.Beep();
                    }
                }                                
            }
        }
    }
}
