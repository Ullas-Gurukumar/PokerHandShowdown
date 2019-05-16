using System;

public class Card : IComparable<Card>
{
    public int suitRank;
    public int rank;
    public String card;
    public String suitName;
    public String rankName;

    public Card() { }

    public Card(String card)
    {
        this.card = card;
        SetRank(card.Substring(0, card.Length - 1));
        SetSuit(card.Substring(card.Length - 1));
    }

    //Assuming that the 
    public void SetRank(String r)
    {
        switch (r)
        {
            case "A":
                rank = 13;
                rankName = "Ace";
                break;
            case "K":
                rank = 12;
                rankName = "King";
                break;
            case "Q":
                rank = 11;
                rankName = "Queen";
                break;
            case "J":
                rank = 10;
                rankName = "Jack";
                break;
            default:
                rank = Int32.Parse(r) - 1;
                rankName = r;
                break;
        }
    }

    public void SetSuit(String s)
    {
        switch (s)
        {
            case "D":
                suitRank = 1;
                suitName = "Diamonds";
                break;
            case "C":
                suitRank = 2;
                suitName = "Clubs";
                break;
            case "H":
                suitRank = 3;
                suitName = "Hearts";
                break;
            case "S":
                suitRank = 4;
                suitName = "Spades";
                break;
        }
    }

    public int CompareTo(Card other)
    {
        var retVal = 0;
        if (this.rank == other.rank)
        {
            retVal = CompareSuitRank(other);
        }
        else
        {
            retVal = CompareRank(other);
        }

        return retVal;
    }

    public int CompareRank(Card other)
    {
        if (this.rank > other.rank)
        {
            return 1;
        } 
        else if (this.rank < other.rank)
        {
            return -1;
        }

        return 0;
    }

    public int CompareSuitRank(Card other)
    {
        if (this.suitRank > other.suitRank)
        {
            return 1;
        }
        else if (this.suitRank < other.suitRank)
        {
            return -1;
        }

        return 0;
    }
}
