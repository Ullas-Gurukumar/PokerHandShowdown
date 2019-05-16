using System;
using System.Collections.Generic;

namespace iQ
{
    public class Player
    {
        public String name;
        public List<Card> hand = new List<Card>();



        public Player(String name)
        {
            this.name = name;
        }

        public Player(String name, String cards)
        {
            this.name = name;
            createHand(cards.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
        }

        public void createHand(String[] cards)
        {
            hand = new List<Card>();
            foreach (String card in cards)
            {
                Card c = new Card(card);
                hand.Add(c);
            }
            sortHand();
        }

        public void sortHand()
        {
            compareCards compare = new compareCards();
            hand.Sort(compare);
        }

        public Boolean hasFlush()
        {
            return hand[0].suitRank == hand[1].suitRank && hand[0].suitRank == hand[2].suitRank &&
                hand[0].suitRank == hand[3].suitRank && hand[0].suitRank == hand[4].suitRank;
        }

        public Boolean hasThreeOfAKind()
        {
            if (hand[0].rank == hand[1].rank && hand[0].rank == hand[2].rank)
            {
                return true;
            }

            if (hand[1].rank == hand[2].rank && hand[1].rank == hand[3].rank)
            {
                return true;
            }

            if (hand[2].rank == hand[3].rank && hand[2].rank == hand[4].rank)
            {
                return true;
            }

            return false;
        }

        public Boolean hasAPair()
        {
            if (hand[0].rank == hand[1].rank)
            {
                return true;
            }

            if (hand[1].rank == hand[2].rank)
            {
                return true;
            }

            if (hand[2].rank == hand[3].rank)
            {
                return true;
            }

            if (hand[3].rank == hand[4].rank)
            {
                return true;
            }

            return false;
        }
    }

    class compareCards : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            return x.CompareTo(y);
        }
    }
}