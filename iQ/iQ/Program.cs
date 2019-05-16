using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var Joe = "8S,8D,AD,QD,JH";
            var Bob = "AS,QS,8S,6S,4S";
            var Sally = "4S,4H,3H,QC,8C";

            var joe = new Player("Joe", Joe.Split(','));
            var bob = new Player("Bob", Bob.Split(','));
            var sally = new Player("Sally", Sally.Split(','));


            Console.ReadLine();
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

    public class Player
    {
        public String name;
        public Card[] hand;

        public Player(String name, String[] hand)
        {
            this.name = name;
            this.hand = new Card[5];

            for (int i=0; i<this.hand.Length; i++)
            {
                this.hand[i] = new Card(hand[i]);
            }

        }


    }
}

/*
 * Assumptions
 * 2 is the lowest card and Ace is the highest
 *  
 * 
 * 
 */