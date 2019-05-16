using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
