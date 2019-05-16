using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace iQ.Tests
{
    [TestClass()]
    public class CardsTests
    {
        String[] allRanks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        String[] allSuits = { "D", "C", "H", "S" };
        int[] allRanksValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        int[] allSuitsValues = { 1, 2, 3, 4 };
        String[] allSuitsNames = { "Diamonds", "Clubs", "Hearts", "Spades" };
        List<Card> allCards = new List<Card>();

        [TestInitialize()]
        public void setup()
        {
            foreach (String rank in allRanks)
            {
                foreach (String suit in allSuits)
                { 
                    allCards.Add(new Card(rank + suit)); //This creates a list with least to most powerful card.
                }
            }       
        }

        // Generating a predictable list and checking for the card ranks
        [TestMethod()]
        public void CheckAllCardRanks()
        {
            foreach (Card card in allCards)
            {
                var cardNum = card.card.Substring(0, card.card.Length - 1);
                var index = Array.IndexOf(allRanks, cardNum);

                Assert.IsTrue(card.rank == allRanksValues[index]);
            }
        }

        // Generating a predictable list and checking for the card suit ranks
        [TestMethod()]
        public void CheckAllCardSuitRanks()
        {
            foreach (Card card in allCards)
            {
                var cardSuit = card.card.Substring(card.card.Length - 1);
                var index = Array.IndexOf(allSuits, cardSuit);

                Assert.IsTrue(card.suitRank == allSuitsValues[index]);
            }
        }

        // Generating a predictable list and checking for the card suit names
        [TestMethod()]
        public void CheckAllCardSuitNames()
        {
            foreach (Card card in allCards)
            {
                var cardSuit = card.card.Substring(card.card.Length - 1);
                var index = Array.IndexOf(allSuits, cardSuit);

                Assert.AreEqual(card.suitName, allSuitsNames[index]);
            }
        }


        [TestMethod()]
        public void checkSetRank()
        {
            var temp = new Card();
            temp.SetRank("2");
            Assert.IsTrue(temp.rank == 1);

            temp.SetRank("3");
            Assert.IsTrue(temp.rank == 2);

            temp.SetRank("4");
            Assert.IsTrue(temp.rank == 3);

            temp.SetRank("5");
            Assert.IsTrue(temp.rank == 4);

            temp.SetRank("6");
            Assert.IsTrue(temp.rank == 5);

            temp.SetRank("7");
            Assert.IsTrue(temp.rank == 6);

            temp.SetRank("8");
            Assert.IsTrue(temp.rank == 7);

            temp.SetRank("9");
            Assert.IsTrue(temp.rank == 8);

            temp.SetRank("10");
            Assert.IsTrue(temp.rank == 9);

            temp.SetRank("J");
            Assert.IsTrue(temp.rank == 10);

            temp.SetRank("Q");
            Assert.IsTrue(temp.rank == 11);

            temp.SetRank("K");
            Assert.IsTrue(temp.rank == 12);

            temp.SetRank("A");
            Assert.IsTrue(temp.rank == 13);

        }

        [TestMethod()]
        public void checkSetSuit()
        {
            var temp = new Card();
            temp.SetSuit("D");
            Assert.IsTrue(temp.suitRank == 1);
            Assert.AreEqual(temp.suitName, "Diamonds");

            temp.SetSuit("C");
            Assert.IsTrue(temp.suitRank == 2);
            Assert.AreEqual(temp.suitName, "Clubs");

            temp.SetSuit("H");
            Assert.IsTrue(temp.suitRank == 3);
            Assert.AreEqual(temp.suitName, "Hearts");

            temp.SetSuit("S");
            Assert.IsTrue(temp.suitRank == 4);
            Assert.AreEqual(temp.suitName, "Spades");
        }
    }
}