using System;
using System.Linq;
using System.Text;

namespace PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] splitInput = input.Split().ToArray();

                string command = splitInput[0];

                if (command == "TakeOdd")
                {
                    password = TakeOdd(password);
                }
                else if (command == "Cut")
                {
                    int index = int.Parse(splitInput[1]);
                    int length = int.Parse(splitInput[2]);

                    password = password.Remove(index, length);
                }
                else if (command == "Substitute")
                {
                    string substring = splitInput[1];
                    string substitute = splitInput[2];

                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, substitute);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                        continue;
                    }
                }

                Console.WriteLine(password);
            }

            Console.WriteLine($"Your password is: {password}");
        }

        static string TakeOdd(string password)
        {
            StringBuilder newPassword = new StringBuilder();

            for (int i = 1; i < password.Length; i+=2)
            {
                newPassword.Append(password[i]);
            }

            return newPassword.ToString();
        }
    }
}
