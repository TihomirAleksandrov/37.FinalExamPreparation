using System;
using System.Linq;

namespace TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] splitInput = input.Split("|").ToArray();

                string command = splitInput[0];

                if (command == "Move")
                {
                    int lettersNum = int.Parse(splitInput[1]);

                    message = MoveLetters(message, lettersNum);
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(splitInput[1]);
                    string value = splitInput[2];

                    message = message.Insert(index, value);
                }
                else if (command == "ChangeAll")
                {
                    string substring = splitInput[1];
                    string replacement = splitInput[2];
                    message = message.Replace(substring, replacement);
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }

        static string MoveLetters(string message, int lettersNum)
        {
            string substring = string.Empty;

            for (int i = 0; i < lettersNum; i++)
            {
                substring += message[i];
            }

            message = message.Remove(0, lettersNum);

            return message + substring;
        }

        
    }
}
