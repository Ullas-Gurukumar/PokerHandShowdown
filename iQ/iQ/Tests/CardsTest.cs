using NUnit.Framework;
using System;
namespace iQ.Tests
{
    [TestFixture()]
    public class CardsTests
    {
        Card c;

        [SetUp]
        public void setup()
        {
            c = new Card("8D");
        }

        [Test()]
        public void TestCase()
        {
            Assert.True(c.rank == 7);
            Assert.True(c.rankName == "8");
            Assert.True(c.suitRank == 1);
            Assert.True(c.suitName == "Diamonds");
        }
    }
}
