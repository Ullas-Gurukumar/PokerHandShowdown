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
            String Joe = "8S, 8D, AD, QD, JH";
            String Bob = "AS, QS, 8S, 6S, 4S";
            String Sally = "4S, 4H, 3H, QC, 8C";

            var joe = new Player("Joe", Joe.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            var bob = new Player("Bob", Bob.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            var sally = new Player("Sally", Sally.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));

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
                players.Add(new Player(lines[i], lines[i + 1].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)));
            }


            Console.WriteLine("hahahah");
        }

        static bool isFlush(String[] hand)
        {
            foreach (String card in hand)
                if (hand[0][1] != card[1])
                {
                    return false;
                }

            return true;
        }

        static void isThreeOfAKind()
        {

        }

        static void isOnePair()
        {

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