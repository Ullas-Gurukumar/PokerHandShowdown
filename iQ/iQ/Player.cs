using System;
using System.Collections.Generic;

namespace iQ
{
    public class Player
    {
        public String name;
        public List<Card> hand = new List<Card>();
        public int[] notSameSuitIndex = new int[3];
        public int[] sameSuitIndex = new int[3];

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

        // Sorts the hand, lowest being index 0 and highest being index 4
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

        // keeps track of where the three of a kind are and the other 2 cards
        public Boolean hasThreeOfAKind()
        {
            if (hand[0].rank == hand[1].rank && hand[0].rank == hand[2].rank)
            {
                sameSuitIndex[0] = 0;
                sameSuitIndex[1] = 1;
                sameSuitIndex[2] = 2;
                notSameSuitIndex[0] = 3;
                notSameSuitIndex[1] = 4;
                return true;
            }

            if (hand[1].rank == hand[2].rank && hand[1].rank == hand[3].rank)
            {
                sameSuitIndex[0] = 1;
                sameSuitIndex[1] = 2;
                sameSuitIndex[2] = 3;
                notSameSuitIndex[0] = 0;
                notSameSuitIndex[1] = 4;
                return true;
            }

            if (hand[2].rank == hand[3].rank && hand[2].rank == hand[4].rank)
            {
                sameSuitIndex[0] = 2;
                sameSuitIndex[1] = 3;
                sameSuitIndex[2] = 4;
                notSameSuitIndex[0] = 0;
                notSameSuitIndex[1] = 1;
                return true;
            }

            return false;
        }

        // keeps track of where the pair are and the other 3 cards
        public Boolean hasAPair()
        {
            if (hand[0].rank == hand[1].rank)
            {
                sameSuitIndex[0] = 0;
                sameSuitIndex[1] = 1;
                notSameSuitIndex[0] = 2;
                notSameSuitIndex[1] = 3;
                notSameSuitIndex[2] = 4;
                return true;
            }

            if (hand[1].rank == hand[2].rank)
            {
                sameSuitIndex[0] = 1;
                sameSuitIndex[1] = 2;
                notSameSuitIndex[0] = 0;
                notSameSuitIndex[1] = 3;
                notSameSuitIndex[2] = 4;
                return true;
            }

            if (hand[2].rank == hand[3].rank)
            {
                sameSuitIndex[0] = 2;
                sameSuitIndex[1] = 3;
                notSameSuitIndex[0] = 0;
                notSameSuitIndex[1] = 1;
                notSameSuitIndex[2] = 4;
                return true;
            }

            if (hand[3].rank == hand[4].rank)
            {
                sameSuitIndex[0] = 3;
                sameSuitIndex[1] = 4;
                notSameSuitIndex[0] = 0;
                notSameSuitIndex[1] = 1;
                notSameSuitIndex[2] = 2;
                return true;
            }

            return false;
        }

        // compares respective high card 
        public int CompareHighCards(Player other)
        {
            int retVal = 0;

            for (int i = hand.Count - 1; i >= 0 && retVal == 0; i++)
            {
                retVal = this.hand[i].CompareTo(other.hand[i]);
            }

            return retVal;
        }

        // compares respective high card without looking at suit
        public int CompareHighCardRanks(Player other)
        {
            int retVal = 0;

            for (int i = hand.Count - 1; i >= 0 && retVal == 0; i--)
            {
                retVal = this.hand[i].CompareRank(other.hand[i]);
            }

            return retVal;
        }

        // compares two playes and tells you who won or if it was a tie
        public int CompareTo(Player other)
        {
            int retVal = 0;

            if (this.hasFlush() && other.hasFlush())
            {
                retVal = CompareHighCardRanks(other);
            }
            else if (this.hasFlush() && !other.hasFlush())
            {
                retVal = 1;
            }
            else if (!this.hasFlush() && other.hasFlush())
            {
                retVal = -1;
            }
            else if (this.hasThreeOfAKind() && other.hasThreeOfAKind())
            {
                // checking for three of a kind cards with other three of a kind cards
                for (int i=2; i>=0 && retVal==0; i--)
                {
                    int cmp = hand[sameSuitIndex[i]].CompareTo(other.hand[other.sameSuitIndex[i]]);
                    if ( cmp != 0)
                    {
                        retVal = cmp;
                    }
                }

                if (retVal == 0)
                {
                    // checking for remaining cards with other remaining cards
                    for (int i = 1; i >= 0 && retVal == 0; i--)
                    {
                        int cmp = hand[notSameSuitIndex[i]].CompareTo(other.hand[other.notSameSuitIndex[i]]);
                        if (cmp != 0)
                        {
                            retVal = cmp;
                        }
                    }
                }
            }
            else if (this.hasThreeOfAKind() && !other.hasThreeOfAKind())
            {
                retVal = 1;
            }
            else if (!this.hasThreeOfAKind() && other.hasThreeOfAKind())
            {
                retVal = -1;
            }
            else if (this.hasAPair() && other.hasAPair())
            {
                // checking for the pair cards with other pair cards
                for (int i = 1; i >= 0 && retVal == 0; i--)
                {
                    int cmp = hand[sameSuitIndex[i]].CompareTo(other.hand[other.sameSuitIndex[i]]);
                    if (cmp != 0)
                    {
                        retVal = cmp;
                    }
                }

                if (retVal == 0)
                {
                    // checking for the non pair cards with other non pair cards
                    for (int i = 2; i >= 0 && retVal == 0; i--)
                    {
                        int cmp = hand[notSameSuitIndex[i]].CompareTo(other.hand[other.notSameSuitIndex[i]]);
                        if (cmp != 0)
                        {
                            retVal = cmp;
                        }
                    }
                }
            }
            else if (this.hasAPair() && !other.hasAPair())
            {
                retVal = 1;
            }
            else if (!this.hasAPair() && other.hasAPair())
            {
                retVal = -1;
            }
            else
            {
                for (int i = hand.Count-1; i >= 0 && retVal == 0; i--)
                {
                    int cmp = hand[i].CompareTo(other.hand[i]);
                    if (cmp != 0)
                    {
                        retVal = cmp;
                    }
                }
            }

            return retVal;
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