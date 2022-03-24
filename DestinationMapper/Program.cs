using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int travelPoints = 0;
            string input = Console.ReadLine();
            List<string> validDestinations = new List<string>();

            string pattern = @"([\=|\/]{1})[A-Z]{1}[A-Za-z]{2,}\1";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string destination = match.Value.ToString();

                if (destination.Contains("/"))
                {
                    destination = destination.Trim('/');
                }
                else
                {
                    destination = destination.Trim('=');
                }

                travelPoints += destination.Length;
                validDestinations.Add(destination);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", validDestinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
