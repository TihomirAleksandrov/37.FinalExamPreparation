using System;
using System.Text;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\@\#+(?<product>[A-Z][A-Za-z\d]{4,}[A-Z])\@\#+";

            int barcodesNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < barcodesNum; i++)
            {
                string barcode = Console.ReadLine();

                Match match = Regex.Match(barcode, pattern);

                if (match.Success)
                {
                    string group = GetGroup(barcode);

                    Console.WriteLine($"Product group: {group}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }

        static string GetGroup(string barcode)
        {
            StringBuilder group = new StringBuilder();

            foreach (char c in barcode)
            {
                if (char.IsDigit(c))
                {
                    group.Append(c);
                }
            }

            if (group.Length == 0)
            {
                group.Append("00");
            }

            return group.ToString();
        }
    }
}
