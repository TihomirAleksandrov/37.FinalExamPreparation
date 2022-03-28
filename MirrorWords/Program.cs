using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\#|\@)[A-Za-z]{3,}\1\1[A-Za-z]{3,}\1";

            string input = Console.ReadLine();
            List<Pairs> pairs = new List<Pairs>();

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string[] words = match.Value
                    .Split(new char[] { '@', '#' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string word1 = words[0];
                string word2 = words[1];

                char[] letters = word1.ToCharArray();
                List<char> lettersList = letters.Reverse().ToList();


                string reverseWord = string.Empty;
                
                foreach (char letter in lettersList)
                {
                    reverseWord += letter;
                }

                if (reverseWord == word2)
                {
                    pairs.Add(new Pairs(word1, word2));
                }
            }

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
                
                if (pairs.Count == 0)
                {
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    List<string> concatPairs = new List<string>();
                    foreach (Pairs pair in pairs)
                    {
                        concatPairs.Add($"{pair.Pair1} <=> {pair.Pair2}");
                    }

                    Console.WriteLine("The mirror words are:");
                    Console.WriteLine(string.Join(", ", concatPairs));
                }
            }
        }
    }

    public class Pairs
    {
        public Pairs(string pair1, string pair2)
        {
            Pair1 = pair1;
            Pair2 = pair2;
        }
        
        public string Pair1 { get; set; }

        public string Pair2 { get; set; }
    }
}
