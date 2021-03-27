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
            }
            else if (totalOrders <= 0)
            {
                Console.WriteLine("You must place at least 1 order!");
                Console.Beep();
            }
            else if (totalOrders > 30)
            {
                Console.WriteLine("You can't place more than 30 orders!");
                Console.Beep();
            }
            else
            {
                int regularOrderPrice;
                int eliteOrderPrice;
                double totalPrice = 0;
                bool orderElite;

                Console.WriteLine("What type of order would you like to continue with: \na) regular order \nb) elite  order");
                string orderType = Console.ReadLine();
                               
                if (orderType.ToLower() == "a" || orderType.ToLower() == "a)" || orderType.ToLower() == "regular" || orderType.ToLower() == "regular order")
                {
                    orderElite = false;
                }
                else if (orderType.ToLower() == "b" || orderType.ToLower() == "b)" || orderType.ToLower() == "elite" || orderType.ToLower() == "elite order")
                {
                    orderElite = true;
                }
                else
                {
                    Console.WriteLine("You must enter a valid order type!");
                    Console.Beep();

                    return;
                }

                switch (DayOfWeek.ToLower())
                {
                    case "monday":

                        regularOrderPrice = 300;
                        eliteOrderPrice = 450;

                        if (!orderElite)
                        {
                            totalPrice = regularOrderPrice * totalOrders;                                                       
                        }
                        else if (orderElite)
                        {
                            totalPrice = eliteOrderPrice * totalOrders;

                            if (totalOrders > 6)
                            {
                                totalPrice -= totalPrice * 20 / 100;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You must enter a valid order type!");
                            Console.Beep();
                        }
                        
                        break;

                    case "tuesday":

                        regularOrderPrice = 300;
                        eliteOrderPrice = 450;

                        if (!orderElite)
                        {
                            totalPrice = regularOrderPrice * totalOrders;
                        }
                        else if (orderElite)
                        {
                            totalPrice = eliteOrderPrice * totalOrders;

                            if (totalOrders > 6)
                            {
                                totalPrice -= totalPrice * 20 / 100;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You must enter a valid order type!");
                            Console.Beep();
                        }
                                                
                        break;

                    case "wednesday":

                        regularOrderPrice = 300;
                        eliteOrderPrice = 450;

                        if (!orderElite)
                        {
                            totalPrice = regularOrderPrice * totalOrders;
                        }
                        else if (orderElite)
                        {
                            totalPrice = eliteOrderPrice * totalOrders;

                            if (totalOrders > 6)
                            {
                                totalPrice -= totalPrice * 20 / 100;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You must enter a valid order type!");
                            Console.Beep();
                        }

                        break;

                    case "thursday":

                        regularOrderPrice = 350;
                        eliteOrderPrice = 500;

                        if (!orderElite)
                        {
                            totalPrice = regularOrderPrice * totalOrders;

                            if (totalOrders > 3)
                            {
                                totalPrice -= totalPrice * 30 / 100;
                            }
                        }
                        else if (orderElite)
                        {
                            totalPrice = eliteOrderPrice * totalOrders;

                            if (totalOrders > 6)
                            {
                                totalPrice -= totalPrice * 20 / 100;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You must enter a valid order type!");
                            Console.Beep();
                        }

                        break;

                    case "friday":

                        regularOrderPrice = 350;
                        eliteOrderPrice = 500;

                        if (!orderElite)
                        {
                            totalPrice = regularOrderPrice * totalOrders;

                            if (totalOrders > 3)
                            {
                                totalPrice -= totalPrice * 30 / 100;
                            }
                        }
                        else if (orderElite)
                        {
                            totalPrice = eliteOrderPrice * totalOrders;

                            if (totalOrders > 6)
                            {
                                totalPrice -= totalPrice * 20 / 100;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You must enter a valid order type!");
                            Console.Beep();
                        }

                        break;

                    case "saturday":

                        regularOrderPrice = 400;
                        eliteOrderPrice = 550;

                        if (!orderElite)
                        {
                            totalPrice = regularOrderPrice * totalOrders;

                            if (totalOrders > 5)
                            {
                                totalPrice -= totalPrice * 35 / 100;
                            }
                        }
                        else if (orderElite)
                        {
                            totalPrice = eliteOrderPrice * totalOrders;

                            if (totalOrders > 4)
                            {
                                totalPrice -= totalPrice * 40 / 100;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You must enter a valid order type!");
                            Console.Beep();
                        }

                        break;

                    case "sunday":

                        regularOrderPrice = 400;
                        eliteOrderPrice = 550;

                        if (!orderElite)
                        {
                            totalPrice = regularOrderPrice * totalOrders;

                            if (totalOrders > 5)
                            {
                                totalPrice -= totalPrice * 35 / 100;
                            }
                        }
                        else if (orderElite)
                        {
                            totalPrice = eliteOrderPrice * totalOrders;

                            if (totalOrders > 4)
                            {
                                totalPrice -= totalPrice * 40 / 100;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You must enter a valid order type!");
                            Console.Beep();
                        }

                        break;

                    default:
                        Console.WriteLine("You must ener a valid day of the week!");
                        Console.Beep();
                        break;                                                
                }
                Console.WriteLine("Congratulations, you have booked your " + (orderElite ? "elite" : "regular") + " order for " + totalPrice + " den.");
            }
        }
    }
}
