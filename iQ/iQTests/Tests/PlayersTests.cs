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
            Player p = new Player("Test Player");
            p.createHand("2D, 2D, 2D, 2D, 2D".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsTrue(p.hasAPair());

            p.createHand("2D, 3D, 4D, 5D, 6D".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsFalse(p.hasAPair());

            p.createHand("AD, AC, AC, QH, 6S".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsTrue(p.hasAPair());

            p.createHand("QD, AC, KC, QH, 6S".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsTrue(p.hasAPair());
        }

        [TestMethod]
        public void checkFlush()
        {
            Player p = new Player("Test Player");
            p.createHand("2D, 2D, 2D, 2D, 2D".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsTrue(p.hasFlush());

            p.createHand("2D, 3D, 4D, 5D, 6D".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsTrue(p.hasFlush());

            p.createHand("AD, AC, AC, QH, 6S".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsFalse(p.hasFlush());

            p.createHand("QD, AC, KC, QH, 6S".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsFalse(p.hasFlush());
        }

        [TestMethod]
        public void checkThreeOfAKind()
        {
            Player p = new Player("Test Player");
            p.createHand("2D, 2D, 2D, 2D, 2D".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsTrue(p.hasThreeOfAKind());

            p.createHand("2D, 3D, 4D, 5D, 6D".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsFalse(p.hasThreeOfAKind());

            p.createHand("AD, AC, AC, QH, 6S".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsTrue(p.hasThreeOfAKind());

            p.createHand("QD, AC, KC, QH, 6S".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsFalse(p.hasThreeOfAKind());
        }

        [TestMethod]
        public void checkSort()
        {
            Player p = new Player("Test Player");
            p.createHand("2D, 2D, 2D, 2D, 2D".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            foreach (Card card in p.hand)
            {
                Assert.IsTrue(card.CompareTo(new Card("2D")) == 0);
            }

            p.createHand("3D, 4D, 2D, 6D, 5D".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsTrue(p.hand[0].CompareTo(new Card("2D")) == 0);
            Assert.IsTrue(p.hand[1].CompareTo(new Card("3D")) == 0);
            Assert.IsTrue(p.hand[2].CompareTo(new Card("4D")) == 0);
            Assert.IsTrue(p.hand[3].CompareTo(new Card("5D")) == 0);
            Assert.IsTrue(p.hand[4].CompareTo(new Card("6D")) == 0);

            p.createHand("AD, AC, AC, QH, 6S".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsTrue(p.hand[0].CompareTo(new Card("6S")) == 0);
            Assert.IsTrue(p.hand[1].CompareTo(new Card("QH")) == 0);
            Assert.IsTrue(p.hand[2].CompareTo(new Card("AD")) == 0);
            Assert.IsTrue(p.hand[3].CompareTo(new Card("AC")) == 0);
            Assert.IsTrue(p.hand[4].CompareTo(new Card("AC")) == 0);

            p.createHand("QD, AC, KC, QH, 6S".Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            Assert.IsTrue(p.hand[0].CompareTo(new Card("6S")) == 0);
            Assert.IsTrue(p.hand[1].CompareTo(new Card("QD")) == 0);
            Assert.IsTrue(p.hand[2].CompareTo(new Card("QH")) == 0);
            Assert.IsTrue(p.hand[3].CompareTo(new Card("KC")) == 0);
            Assert.IsTrue(p.hand[4].CompareTo(new Card("AC")) == 0);
        }
    }
}
