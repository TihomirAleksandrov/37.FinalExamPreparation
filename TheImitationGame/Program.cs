using System;
using System.Collections.Generic;
using System.Linq;

namespace T13._Plant_Discovery
{
    class Plant
    {
        public string Name { get; set; }
        public double Rarity { get; set; }
        public List<double> Rating { get; set; } = new List<double>();
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Plant> listOfPlants = new List<Plant>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plant = input[0];
                double rarity = double.Parse(input[1]);
                Plant searchedPlant = listOfPlants.FirstOrDefault(x => x.Name == plant);
                if (searchedPlant != null)
                {
                    searchedPlant.Rarity = rarity;
                    continue;
                }
                Plant newPlant = new Plant();
                {
                    newPlant.Name = plant;
                    newPlant.Rarity = rarity;
                    newPlant.Rating = new List<double>();
                }
                listOfPlants.Add(newPlant);
            }

            string updateInfo = string.Empty;
            while ((updateInfo = Console.ReadLine()) != "Exhibition")
            {
                char[] splitBy = new char[] { ':', '-' };
                string[] infoArgs = updateInfo.Split(splitBy, StringSplitOptions.RemoveEmptyEntries);
                string command = infoArgs[0];
                string plantName = infoArgs[1];
                if (command == "Rate")
                {
                    Plant plant = listOfPlants.FirstOrDefault(x => x.Name == plantName);
                    if (plant == null)
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    double rating = double.Parse(infoArgs[2]);
                    plant.Rating.Add(rating);
                }
                else if (command == "Update")
                {
                    Plant plant = listOfPlants.FirstOrDefault(x => x.Name == plantName);
                    if (plant == null)
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    double rarity = double.Parse(infoArgs[2]);
                    plant.Rarity = rarity;
                }
                else if (command == "Reset")
                {
                    Plant plant = listOfPlants.FirstOrDefault(x => x.Name == plantName);
                    if (plant == null)
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    plant.Rating.Clear();
                }
            }
            Console.WriteLine($"Plants for the exhibition:");
            foreach (var plant in listOfPlants)
            {
                Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {plant.Rating.Average():f2}");
            }
        }


    }
}
