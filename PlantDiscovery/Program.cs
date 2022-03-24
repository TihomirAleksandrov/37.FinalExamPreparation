using System;
using System.Linq;
using System.Collections.Generic;

namespace PlantDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int plantsNum = int.Parse(Console.ReadLine());
            Dictionary<string, PlantInfo> plants = new Dictionary<string, PlantInfo>();

            for (int i = 0; i < plantsNum; i++)
            {
                string[] plant = Console.ReadLine().Split("<->").ToArray();
                string plantName = plant[0];
                double plantRarity = double.Parse(plant[1]);

                plants.Add(plantName, new PlantInfo(plantRarity));
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] inputParts = input.Split(new char[] {' ', ':', '-'}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = inputParts[0];
                string plantName = inputParts[1];

                if (plants.ContainsKey(plantName))
                {
                    if (command == "Rate")
                    {
                        double rating = double.Parse(inputParts[2]);

                        plants[plantName].Rating.Add(rating);
                    }
                    else if (command == "Update")
                    {
                        double rarity = double.Parse(inputParts[2]);
                        plants[plantName].Rarity = rarity;
                    }
                    else if (command == "Reset")
                    {
                        plants[plantName].Rating = new List<double>();
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants)
            {
                double averageRating = 0;
                if (plant.Value.Rating.Count > 0)
                {
                    averageRating = plant.Value.Rating.Average();
                }
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {averageRating:f2}");
            }
        }
    }

    public class PlantInfo
    {
        public PlantInfo(double rarity)
        {
            Rarity = rarity;
            Rating = new List<double>();
        }
        
        public double Rarity { get; set; }

        public List<double> Rating { get; set; }
    }
}
