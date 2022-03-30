using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\#|\|)(?<name>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";

            string input = Console.ReadLine();
            int totalCalories = 0;

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                int calories = int.Parse(match.Groups["calories"].Value);

                totalCalories += calories;
            }

            int daysWithFood = totalCalories / 2000;

            Console.WriteLine($"You have food to last you for: {daysWithFood} days!");

            foreach (Match match in matches)
            {
                string name = match.Groups["name"].Value;
                string expDate = match.Groups["date"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);

                Console.WriteLine($"Item: {name}, Best before: {expDate}, Nutrition: {calories}");
            }
        }
    }
}
