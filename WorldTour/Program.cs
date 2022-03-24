using System;
using System.Linq;

namespace WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string plannedStops = Console.ReadLine();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Travel")
            {
                string[] inputParts = input.Split(":").ToArray();

                string command = inputParts[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(inputParts[1]);
                    string newStop = inputParts[2];

                    if (index < plannedStops.Length && index >= 0)
                    {
                        plannedStops = plannedStops.Insert(index, newStop);
                        Console.WriteLine(plannedStops);
                        continue;
                    }
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(inputParts[1]);
                    int endIndex = int.Parse(inputParts[2]);
                    int removeCount = (endIndex - startIndex) + 1;

                    if (startIndex < plannedStops.Length && endIndex < plannedStops.Length && startIndex >= 0 && endIndex >= 0)
                    {
                        plannedStops = plannedStops.Remove(startIndex, removeCount);
                        Console.WriteLine(plannedStops);
                        continue;
                    }
                }
                else if (command == "Switch")
                {
                    string oldString = inputParts[1];
                    string newString = inputParts[2];

                    if (plannedStops.Contains(oldString))
                    {
                        plannedStops = plannedStops.Replace(oldString, newString);
                        Console.WriteLine(plannedStops);
                        continue;
                    }
                }

                Console.WriteLine(plannedStops);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {plannedStops}");
        }
    }
}
