using System;
using System.Collections.Generic;
using System.Linq;

namespace SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] splitInput = input.Split(":|:").ToArray();

                string command = splitInput[0];
                string substring = string.Empty;

                if (command == "InsertSpace")
                {
                    int index = int.Parse(splitInput[1]);
                    message = InsertSpace(message, index);
                }
                else if (command == "Reverse")
                {
                    substring = splitInput[1];
                    if (message.Contains(substring))
                    {
                        message = RemoveSubstring(message, substring);
                        message = ReverseSubstring(message, substring);
                    }
                    else
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                }
                else if (command == "ChangeAll")
                {
                    substring = splitInput[1];
                    string replacement = splitInput[2];
                    message = ReplaceSubstring(message, substring, replacement);
                }

                Console.WriteLine(message);
            }

            Console.WriteLine($"You have a new text message: {message}");
        }

        static string InsertSpace(string message, int index)
        {
            return message.Insert(index, " ");
        }

        static string ReverseSubstring(string message, string substring)
        {           
            char[] letters = substring.ToCharArray();
            Array.Reverse(letters);
            string reversedSubstring = new string(letters);
            
            return message + reversedSubstring;
        }

        static string RemoveSubstring(string message, string substring)
        {
            int index = message.IndexOf(substring);
            return message.Remove(index, substring.Length);
        }

        static string ReplaceSubstring(string message, string substring, string replacement)
        {
            return message.Replace(substring, replacement);
        }
    }
}
