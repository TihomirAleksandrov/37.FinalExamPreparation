using System;
using System.Linq;
using System.Collections.Generic;

namespace ThePianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, PieceInfo> pieces = new Dictionary<string, PieceInfo>();
            
            int piecesNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < piecesNum; i++)
            {
                string[] piece = Console.ReadLine().Split("|").ToArray();

                string pieceName = piece[0];
                string composer = piece[1];
                string key = piece[2];

                pieces.Add(pieceName, new PieceInfo(composer, key));
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] splitInput = input.Split("|").ToArray();

                string command = splitInput[0];
                string piece = splitInput[1];

                if (command == "Add")
                {
                    string composer = splitInput[2];
                    string key = splitInput[3];
                    
                    if (pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(piece, new PieceInfo(composer, key));

                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (command == "Remove")
                {
                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);
                        
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (command == "ChangeKey")
                {
                    string newKey = splitInput[2];

                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece].Key = newKey;

                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }
    }

    public class PieceInfo
    {
        public PieceInfo(string composer, string key)
        {
            Composer = composer;

            Key = key;
        }

        public string Composer { get; set; }

        public string Key { get; set; }
    }
}
