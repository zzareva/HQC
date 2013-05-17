using System;
using System.Collections.Generic;

namespace Poker
{
    class PokerExample
    {
        static void Main()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            Console.WriteLine(card);

			IList<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
			};
            IHand hand = new Hand( cards);
            Console.WriteLine(hand);

            IPokerHandsChecker checker = new PokerHandsChecker();
            //Console.WriteLine(checker.IsValidHand(hand));
            //Console.WriteLine(checker.IsOnePair(hand));
            //Console.WriteLine(checker.IsTwoPair(hand));

			Console.WriteLine(checker.IsStraight(hand));
        }
    }
}
