using System;
using System.Collections.Generic;
using System.IO;

namespace iQ
{
    class Program
    {
        static readonly string textFile = @"../../input.txt";
        static List<Player> players = new List<Player>();
        string[] stringSeparator = new string[] {", "};

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(textFile);

            var end = 0;
            var prevEnd = 0;

            while(end != -1)
            {
                prevEnd = end;
                end = Array.FindIndex(lines, end + 1, s => s.Equals(""));

                if (end != -1)
                {
                    createBoard(lines, prevEnd, end);
                }
                else 
                {
                    createBoard(lines, prevEnd, lines.Length);
                }
            }

            Console.ReadLine();
        }

        static void createBoard(string[] lines, int start, int end)
        {
            players = new List<Player>();

            if (lines[start].Equals(""))
            {
                start++;
            }

            for (int i=start; i<end; i+=2)
            {
                players.Add(new Player(lines[i], lines[i + 1]));
            }


            foreach (Player p in players)
            {
                Console.WriteLine("Name: " + p.name + " has a pair " + p.hasAPair());
            }

            Console.WriteLine("\n");
        }
    }
}

/*
 * Assumptions
 * 2 is the lowest card and Ace is the highest
 * Each player will have 5 cards in hand
 * 
 * 
 */