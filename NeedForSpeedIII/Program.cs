using System;
using System.Linq;
using System.Collections.Generic;

namespace NeedForSpeedIII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, CarInfo> cars = new Dictionary<string, CarInfo>();

            int carsNum = int.Parse(Console.ReadLine());

            cars = AddCars(cars, carsNum);

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] splittedInput = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = splittedInput[0];
                string carName = splittedInput[1];

                if (command == "Drive")
                {
                    int distance = int.Parse(splittedInput[2]);
                    int fuel = int.Parse(splittedInput[3]);

                    DriveCar(cars, carName, distance, fuel);
                }
                else if (command == "Refuel")
                {
                    int fuel = int.Parse(splittedInput[2]);

                    RefuelCar(cars, carName, fuel);
                }
                else if (command == "Revert")
                {
                    int kilometers = int.Parse(splittedInput[2]);

                    RevertMileage(cars, carName, kilometers);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }

        static Dictionary<string, CarInfo> AddCars(Dictionary<string, CarInfo> cars, int carsNum)
        {
            for (int i = 0; i < carsNum; i++)
            {
                string[] carInfo = Console.ReadLine().Split("|").ToArray();

                string carName = carInfo[0];
                int mileage = int.Parse(carInfo[1]);
                int fuel = int.Parse(carInfo[2]);

                cars.Add(carName, new CarInfo(mileage, fuel));
            }

            return cars;
        }

        static void DriveCar(Dictionary<string, CarInfo> cars, string carName, int distance, int fuel)
        {
            if (cars[carName].Fuel >= fuel)
            {
                cars[carName].Fuel -= fuel;
                cars[carName].Mileage += distance;

                Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                if (cars[carName].Mileage >= 100000)
                {
                    Console.WriteLine($"Time to sell the {carName}!");
                    cars.Remove(carName);
                }
            }
            else
            {
                Console.WriteLine("Not enough fuel to make that ride");
            }
        }

        static void RefuelCar(Dictionary<string, CarInfo> cars, string carName, int fuel)
        {
            int totalFuel = cars[carName].Fuel + fuel;

            if (totalFuel > 75)
            {
                fuel = 75 - cars[carName].Fuel;
                cars[carName].Fuel = 75;
            }
            else
            {
                cars[carName].Fuel = totalFuel;
            }

            Console.WriteLine($"{carName} refueled with {fuel} liters");
        }

        static void RevertMileage(Dictionary<string, CarInfo> cars, string carName, int kilometers)
        {
            int mileageLeft = cars[carName].Mileage - kilometers;

            if (mileageLeft < 10000)
            {
                cars[carName].Mileage = 10000;
            }
            else
            {
                cars[carName].Mileage = mileageLeft;
                Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
            }
        }
    }

    public class CarInfo
    {
        public CarInfo(int mileage, int fuel)
        {
            Mileage = mileage;
            Fuel = fuel;
        }

        public int Mileage { get; set; }

        public int Fuel { get; set; }
    }
}
