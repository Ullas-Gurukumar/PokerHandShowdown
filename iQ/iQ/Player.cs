using System;
using System.Collections.Generic;

namespace iQ
{
    internal class Player
    {
        String name;
        List<Card> hand = new List<Card>();

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
    }
}