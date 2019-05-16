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

    public class Card : IComparable<Card>
    {
        public int suitRank;
        public int rank;
        private String card;
        public String suitName;
        public String rankName;

        public Card(String card)
        {
            this.card = card;
            SetRank(card[0]);
            SetSuit(card[1]);
        }

        //Assuming that the 
        public void SetRank(Char s)
        {
            switch(s)
            {
                case 'A':
                    rank = 13;
                    rankName = "Ace";
                    break;
                case 'K':
                    rank = 12;
                    rankName = "King";
                    break;
                case 'Q':
                    rank = 11;
                    rankName = "Queen";
                    break;
                case 'J':
                    rank = 10;
                    rankName = "Jack";
                    break;
                default:
                    rank = (int) Char.GetNumericValue(s) - 1;
                    rankName = Char.ToString(s);
                    break;
            }
        }

        public void SetSuit(Char r)
        {
            switch (r)
            {
                case 'D':
                    suitRank = 1;
                    suitName = "Diamonds";
                    break;
                case 'C':
                    suitRank = 2;
                    suitName = "Clubs";
                    break;
                case 'H':
                    suitRank = 3;
                    suitName = "Hearts";
                    break;
                case 'S':
                    suitRank = 4;
                    suitName = "Spades";
                    break;
            }
        }

        public int CompareTo(Card other)
        {
            bool sameRank = this.rank == other.rank;

            if (sameRank)
            {
                if (this.suitRank > other.suitRank)
                {
                    return -1;
                } 
                else if (this.suitRank < other.suitRank)
                {
                    return 1;
                }
            }
            else
            {
                if (this.rank > other.rank)
                {
                    return -1;
                } 
                else if (this.rank < other.rank)
                {
                    return 1;
                }
            }

            return 0;
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