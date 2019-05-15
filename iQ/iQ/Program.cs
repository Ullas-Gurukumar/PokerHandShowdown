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

            var JoeHand = Joe.Split(',');
            var BobHand = Bob.Split(',');
            var SallyHand = Sally.Split(',');

            Console.WriteLine(isFlush(JoeHand));
            Console.WriteLine(isFlush(BobHand));
            Console.WriteLine(isFlush(SallyHand));


            Console.ReadLine();
        }

        static void getCards(String hand)
        {
            Card[] cards = new Card[5];
            foreach (String card in hand.Split(',')) ;
                
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

    public class Card
    {
        public int suit;
        public int rank;
        private String card;
        public Card(String card)
        {
            this.card = card;
            SetSuit(card[0]);
            SetRank(card[1]);
        }

        public void SetSuit(Char s)
        {
            switch(s)
            {
                case 'A':
                    rank = 13;
                    break;
                case 'K':
                    rank = 12;
                    break;
                case 'Q':
                    rank = 11;
                    break;
                case 'J':
                    rank = 10;
                    break;
                default:
                    rank = (int) Char.GetNumericValue(s);
                    break;
            }
        }

        public void SetRank(Char r)
        {
            switch (r)
            {
                case 'D':
                    rank = 1;
                    break;
                case 'C':
                    rank = 2;
                    break;
                case 'H':
                    rank = 3;
                    break;
                case 'S':
                    rank = 4;
                    break;
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