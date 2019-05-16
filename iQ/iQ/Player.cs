using System;
using System.Collections.Generic;

namespace iQ
{
    internal class Player
    {
        public String name;
        public List<Card> hand = new List<Card>();

        public Player(String name)
        {
            this.name = name;
        }

        public Player(String name, String[] cards)
        {
            this.name = name;

            foreach (String card in cards)
            {
                hand.Add(new Card(card));
            }
        }

        public Boolean hasFlush()
        {
            return hand[0].suitRank == hand[1].suitRank && hand[0].suitRank == hand[2].suitRank &&
                hand[0].suitRank == hand[3].suitRank && hand[0].suitRank == hand[4].suitRank;
        }
    }
}