using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iQ.Tests
{
    [TestClass]
    public class PlayersTests
    {
        [TestMethod]
        public void checkAPair()
        {
            Player p = new Player("Test Player", "2D, 2D, 2D, 2D, 2D");
            Assert.IsTrue(p.hasAPair());

            p = new Player("Test Player", "2D, 3D, 4D, 5D, 6D");
            Assert.IsFalse(p.hasAPair());

            p = new Player("Test Player", "AD, AC, AC, QH, 6S");
            Assert.IsTrue(p.hasAPair());

            p = new Player("Test Player", "QD, AC, KC, QH, 6S");
            Assert.IsTrue(p.hasAPair());
        }

        [TestMethod]
        public void checkFlush()
        {
            Player p = new Player("Test Player", "2D, 2D, 2D, 2D, 2D");
            Assert.IsTrue(p.hasFlush());

            p = new Player("Test Player", "2D, 3D, 4D, 5D, 6D");
            Assert.IsTrue(p.hasFlush());

            p = new Player("Test Player", "AD, AC, AC, QH, 6S");
            Assert.IsFalse(p.hasFlush());

            p = new Player("Test Player", "QD, AC, KC, QH, 6S");
            Assert.IsFalse(p.hasFlush());
        }

        [TestMethod]
        public void checkThreeOfAKind()
        {
            Player p = new Player("Test Player", "2D, 2D, 2D, 2D, 2D");
            Assert.IsTrue(p.hasThreeOfAKind());

            p = new Player("Test Player", "2D, 3D, 4D, 5D, 6D");
            Assert.IsFalse(p.hasThreeOfAKind());

            p = new Player("Test Player", "AD, AC, AC, QH, 6S");
            Assert.IsTrue(p.hasThreeOfAKind());

            p = new Player("Test Player", "QD, AC, KC, QH, 6S");
            Assert.IsFalse(p.hasThreeOfAKind());
        }

        [TestMethod]
        public void checkSort()
        {
            Player p = new Player("Test Player", "2D, 2D, 2D, 2D, 2D");
            foreach (Card card in p.hand)
            {
                Assert.IsTrue(card.CompareTo(new Card("2D")) == 0);
            }

            p = new Player("Test Player", "2D, 3D, 4D, 5D, 6D");
            Assert.IsTrue(p.hand[0].CompareTo(new Card("2D")) == 0);
            Assert.IsTrue(p.hand[1].CompareTo(new Card("3D")) == 0);
            Assert.IsTrue(p.hand[2].CompareTo(new Card("4D")) == 0);
            Assert.IsTrue(p.hand[3].CompareTo(new Card("5D")) == 0);
            Assert.IsTrue(p.hand[4].CompareTo(new Card("6D")) == 0);

            p = new Player("Test Player", "AD, AC, AC, QH, 6S");
            Assert.IsTrue(p.hand[0].CompareTo(new Card("6S")) == 0);
            Assert.IsTrue(p.hand[1].CompareTo(new Card("QH")) == 0);
            Assert.IsTrue(p.hand[2].CompareTo(new Card("AD")) == 0);
            Assert.IsTrue(p.hand[3].CompareTo(new Card("AC")) == 0);
            Assert.IsTrue(p.hand[4].CompareTo(new Card("AC")) == 0);

            p = new Player("Test Player", "QD, AC, KC, QH, 6S");
            Assert.IsTrue(p.hand[0].CompareTo(new Card("6S")) == 0);
            Assert.IsTrue(p.hand[1].CompareTo(new Card("QD")) == 0);
            Assert.IsTrue(p.hand[2].CompareTo(new Card("QH")) == 0);
            Assert.IsTrue(p.hand[3].CompareTo(new Card("KC")) == 0);
            Assert.IsTrue(p.hand[4].CompareTo(new Card("AC")) == 0);
        }

        [TestMethod]
        public void checkCompareTo()
        {
            Player one = new Player("Test Player", "2D, 2D, 2D, 2D, 2D");
            Player two = new Player("Test Player", "2D, 2D, 2D, 2D, 2D");

            Assert.IsTrue(one.CompareTo(two) == 0);

            two = new Player("Test Player", "3D, 2D, 2D, 2D, 2D");
            Assert.IsTrue(one.CompareTo(two) == -1);

            one = new Player("Test Player", "3D, 3D, 2D, 2D, 2D");
            Assert.IsTrue(one.CompareTo(two) == 1);

            one = new Player("Test Player", "3D, AD, 2C, 2H, 2S");
            two = new Player("Test Player", "3D, 9D, 2C, 2H, 2S");
            Assert.IsTrue(one.CompareTo(two) == 1);


            one = new Player("Test Player", "3D, 7D, 2C, 2H, 2S");
            two = new Player("Test Player", "3D, 9D, 2C, 2H, 2S");
            Assert.IsTrue(one.CompareTo(two) == -1);
        }
    }
}
