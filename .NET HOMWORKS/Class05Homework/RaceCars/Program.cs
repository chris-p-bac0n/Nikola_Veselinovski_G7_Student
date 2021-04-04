using System;
using RaceCars.Classes;

namespace RaceCars
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] cars = new object[4];
            //cars[0] = new Car("Hyundai", 2);
            //cars[1] = new Car("Mazda", 3);
            //cars[2] = new Car("Ferrari", 4);
            //cars[3] = new Car("Porsche", 5);
            Car hyundai = new Car();
            hyundai.Model = "Hyundai";
            hyundai.Speed = 2;
            cars[0] = hyundai;
            
            object[] drivers = new object[4];
            drivers[0] = new Driver("Bob", 2);
            drivers[1] = new Driver("Greg", 3);
            drivers[2] = new Driver("Jill", 4);
            drivers[3] = new Driver("Anne", 5);

            string inputCar1, inputDriver1, inputCar2, inputDriver2 = String.Empty;

            do
            {
                Console.WriteLine("Choose a car no.1:");
                foreach (Car car in cars) Console.WriteLine(car.Model);
                inputCar1 = Console.ReadLine();
            }
            while (!ValidateCar(inputCar1, cars));

            do
            {
                Console.WriteLine("Choose Driver:");
                foreach (Driver driver in drivers) Console.WriteLine(driver.Name);
                inputDriver1 = Console.ReadLine();
            }
            while (!ValidateDriver(inputDriver1, drivers));

            do
            {
                Console.WriteLine("Choose a car no.2:");
                foreach (Car car in cars) 
                    if (car.Model.ToLower() != inputCar1.ToLower())
                        Console.WriteLine(car.Model);
                inputCar2 = Console.ReadLine();
            }
            while (!ValidateCar(inputCar2, cars));

            do
            {
                Console.WriteLine("Choose Driver:");
                foreach (Driver driver in drivers)
                    if (driver.Name.ToLower() != inputDriver1.ToLower())
                        Console.WriteLine(driver.Name);
                inputDriver2 = Console.ReadLine();
            }
            while (!ValidateDriver(inputDriver2, drivers));
                        

        }
        static void RaceCars(Car car1, Car car2)
        {
            
            Console.WriteLine($"Car {car1.CalculateSpeed(d, car1)}");
        }

        static bool ValidateDriver(string input, object[] drivers)
        {
            bool choiceValid = false;

            foreach (Driver driver in drivers)
            {
                if (input.ToLower() == driver.Name.ToLower())
                {
                    choiceValid = true;
                    break;
                }
            }

            if (!choiceValid)
            {
                Console.WriteLine("There is no car by that name");
            }
            return choiceValid;
        }
        static bool ValidateCar(string input, object[] cars)
        {
            bool choiceValid = false;

            foreach (Car car in cars)
            {
                if (input.ToLower() == car.Model.ToLower())
                {
                    choiceValid = true;
                    break;
                }                 
            }

            if (!choiceValid)
            {
                Console.WriteLine("There is no car by that name");
            }
            return choiceValid;
        }
        static int DriverIndex(string input, object[] drivers)
        {
            int driverIndex = 0;

            foreach (Driver driver in drivers)
            {
                if (input.ToLower() == driver.Name.ToLower())
                {
                    driverIndex = Array.IndexOf(drivers, driver);
                    break;
                }
            }
            return driverIndex;
        }
        static int CarIndex(string input, object[] cars)
        {
            int carIndex = 0;

            foreach (Car car in cars)
            {
                if (input.ToLower() == car.Model.ToLower())
                {
                    carIndex = Array.IndexOf(cars, car);
                    break;
                }
            }
            return carIndex;
        }

    }
}
