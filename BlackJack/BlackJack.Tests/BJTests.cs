using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJack.Tests {

    [TestClass]
    public class BJTests
    {

        List<Card> deckList;
        Game game;

        [TestInitialize]
        public void TestInitializer()
        {
            var rnd = new Random();
            game = new Game();
            deckList = game.Deck;
        }


        [TestMethod]
        public void HandTest()
        {

            var hand = game.DealNewHand(2);
            var testCard = hand[0];

            Assert.IsFalse(game.Deck.Contains(testCard));
        }

        [TestMethod]
        public void GetHandsValueTestNoAce()
        {
            var testHand = new List<Card>();
            testHand.Add(new Card { Id = 12, Face = 12, Suite = 'h' }); // queen of Hearts!
            testHand.Add(new Card { Id = 2, Face = 2, Suite = 'h' });  // Stephen's favourtie card

            var result = game.GetHandsValue(testHand);

            Assert.AreEqual(12, result);
        }
        [TestMethod]
        public void GetHandsValueTestOneAce()
        {
            var testHand = new List<Card>();
            testHand.Add(new Card { Id = 27, Face = 1, Suite = 's' }); // Ace of Spades!
            testHand.Add(new Card { Id = 2, Face = 2, Suite = 'h' });  // Stephen's favourtie card

            var result = game.GetHandsValue(testHand);

            Assert.AreEqual(13, result);
        }

        [TestMethod]
        public void GetHandsValueTestOneAceOneTen()
        {
            var testHand = new List<Card>();
            testHand.Add(new Card { Id = 27, Face = 1, Suite = 's' }); // Ace of Spades!
            testHand.Add(new Card { Id = 10, Face = 10, Suite = 'h' }); // 10 of hearts
            testHand.Add(new Card { Id = 2, Face = 2, Suite = 'h' });  // Stephen's favourtie card

            var result = game.GetHandsValue(testHand);

            Assert.AreEqual(13, result);
        }
        [TestMethod]
        public void GetHandsValueTestTwoAces()
        {
            var testHand = new List<Card>();
            testHand.Add(new Card { Id = 27, Face = 1, Suite = 's' }); // Ace of Spades!
            testHand.Add(new Card { Id = 1, Face = 1, Suite = 'h' });  // Ace of Hearts

            var result = game.GetHandsValue(testHand);

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void HitMeTest()
        {
            var testHand = game.DealNewHand(2);

            var handAfterHit = game.HitMe(testHand);

            var lastCardinHand = handAfterHit[handAfterHit.Count - 1];

            Assert.IsFalse(game.Deck.Contains(lastCardinHand));
        }

    }
}
