using System;
using System.Collections.Generic;
using System.IO;

namespace iQ
{
    class Program
    {
        static readonly string textFile = @"../../input.txt";
        static List<Player> players = new List<Player>();

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(textFile);

            var end = 0;
            var prevEnd = 0;

            while (end != -1) 
            {
                // finds the beginning and end of the board
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

            Console.ReadLine(); // to prevent terminal from closing
        }

        static void createBoard(string[] lines, int start, int end)
        {
            players = new List<Player>();

            if (lines[start].Equals(""))
            {
                start++;
            }

            // starts creating all the players and also prints out the inputs
            for (int i = start; i < end; i += 2)
            {
                players.Add(new Player(lines[i], lines[i + 1]));
                Console.WriteLine(lines[i] + "\n" + lines[i + 1]);
            }

            // checks if every player is the winner
            foreach (Player p in players)
            {
                int numWins = 0;
                int numTies = 0;
                foreach (Player other in players)
                {
                    if (!p.Equals(other))
                    {
                        int val = p.CompareTo(other);
                        if (val == 0)
                        {
                            numTies++;
                        }
                        else if (val == 1)
                        {
                            numWins++;
                        }
                    }
                }

                // won against every other player
                if (numWins == players.Count - 1)
                {
                    Console.WriteLine("\n" + p.name + " WINS!!\n\n");
                }
                else if (numTies > 0) //there was a tie
                {
                    Console.WriteLine("\n" + p.name + " tied!!\n\n");
                }
            }
        }
    }
}