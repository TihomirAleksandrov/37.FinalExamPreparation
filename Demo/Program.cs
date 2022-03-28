using System;
using System.Linq;
using System.Collections.Generic;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>{"apple", "car", "human", "beaver" };
            Random random = new Random();

            string word = words[random.Next(0, words.Count)];
            char[] letters = word.ToCharArray();
            List<char> guessedLetters = new List<char>();
            
            for (int i = 0; i < letters.Length; i++)
            {
                guessedLetters.Add('_');
            }

            int tries = 5;

            while (guessedLetters.Contains('_'))
            {
                Console.Write("Insert a letter:");
                char inputLetter = char.Parse(Console.ReadLine());

                List<int> indexes = new List<int>();

                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i] == inputLetter)
                    {
                        indexes.Add(i);
                    }
                }

                if (indexes.Count == 0)
                {
                    tries -= 1;
                    if (tries == 0)
                    {
                        Console.WriteLine("You died X_X");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect letter! {tries} tries left.");
                    }
                }
                else
                {
                    foreach (int i in indexes)
                    {
                        guessedLetters[i] = inputLetter;
                    }

                    Console.WriteLine(String.Join(" ", guessedLetters));
                }
            }
        }
    }
}
