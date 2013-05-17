using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
	public class PokerHandsChecker : IPokerHandsChecker
	{
		public const int HandSize = 5;

		public bool IsValidHand(IHand hand)
		{
			var isValid = true;
			if (hand.Cards.Count != HandSize)
			{
				isValid = false;
			}
			else if (!ContainsRepeatingCards(hand))
			{
				isValid = false;
			}
			return isValid;
		}

		private bool ContainsRepeatingCards(IHand hand)
		{
			var cards = hand.Cards;
			cards = cards.OrderBy(c => c.Suit).ThenBy(c => c.Face).ToList();
			for (int i = 0; i < cards.Count - 1; i++)
			{
				if (cards[i].Suit == cards[i + 1].Suit && cards[i].Face == cards[i + 1].Face)
				{
					return false;
				}
			}
			return true;
		}

		public bool IsStraightFlush(IHand hand)
		{
			bool isStraightFull = false;
			var cards = hand.Cards;
			cards = cards.OrderBy(c => c.Suit).ThenBy(c => c.Face).ToList();
			for (int i = 1; i <= 4; i++)
			{
				var selected = cards.Where(x => x.Suit == (CardSuit)(i)).ToList();
				if (selected.Count > 0 && selected.Count < 5)
				{
					isStraightFull = false;
				}
				else if (selected.Count == 5)
				{
					isStraightFull = AreSequence(selected);
				}
			}
			return isStraightFull;
		}

		private bool AreSequence(List<ICard> cards)
		{
			int countIncreasing = 0;
			int current;
			int next;
			for (int j = 0; j < cards.Count - 1; j++)
			{
				current = Convert.ToInt32(cards[j].Face);
				next = Convert.ToInt32(cards[j + 1].Face);
				if (current + 1 == next)
				{
					countIncreasing++;
				}
				if (j == 0 && cards[0].Face == CardFace.Two && cards[cards.Count - 1].Face == CardFace.Ace)
				{
					countIncreasing++;
				}
			}
			if (countIncreasing == 4)
			{
				return true;
			}
			return false;
		}

		public bool IsFourOfAKind(IHand hand)
		{
			var cards = hand.Cards.ToList();
			for (int i = 2; i <= 14; i++)
			{
				var count = cards.Count(x => x.Face == (CardFace)(i));
				if (count == 4)
				{
					return true;
				}
			}

			return false;
		}

		public bool IsFullHouse(IHand hand)
		{
			if (GetThreeOfAKind(hand) != -1 && ContainsOnePair(hand))
			{
				return true;
			}
			return false;
		}

		public bool IsFlush(IHand hand)
		{
			var cards = hand.Cards.ToList();
			for (int i = 0; i < cards.Count - 1; i++)
			{
				if (cards[i].Suit != cards[i + 1].Suit)
				{
					return false;
				}
			}
			return true;
		}

		public bool IsStraight(IHand hand)
		{
			var cards = hand.Cards.ToList();
			cards = cards.OrderBy(c => c.Face).ToList();
			return AreSequence(cards) && !IsFlush(hand);
		}

		public bool IsThreeOfAKind(IHand hand)
		{
			if (GetThreeOfAKind(hand) != -1 && !ContainsOnePair(hand))
			{
				return true;
			}
			return false;
		}

		private int GetThreeOfAKind(IHand hand)
		{
			var cards = hand.Cards.ToList();
			for (int i = 2; i <= 14; i++)
			{
				var count = cards.Count(x => x.Face == (CardFace)(i));
				if (count == 3)
				{
					return i;
				}
			}
			return -1;
		}

		public bool ContainsTwoPair(IHand hand)
		{
			int pairs = CountPairs(hand);
			return pairs == 2;
		}

		public bool ContainsOnePair(IHand hand)
		{
			int pairs = CountPairs(hand);
			return pairs == 1;
		}

		private int CountPairs(IHand hand)
		{
			var countOfPairs = 0;
			var cards = hand.Cards.ToList();
			for (int i = 2; i <= 14; i++)
			{
				var count = cards.Count(x => x.Face == (CardFace)(i));
				if (count == 4)
					countOfPairs = 0;
				else if (count == 2)
					countOfPairs++;
			}

			return countOfPairs;
		}

		public bool IsHighCard(IHand hand)
		{
			bool isHighHand = true;
			if (IsStraightFlush(hand))
				isHighHand = false;
			if (IsFourOfAKind(hand))
				isHighHand = false;
			if (IsFullHouse(hand))
				isHighHand = false;
			if (IsFlush(hand))
				isHighHand = false;
			if (IsStraight(hand))
				isHighHand = false;
			if (IsThreeOfAKind(hand))
				isHighHand = false;
			if (ContainsTwoPair(hand))
				isHighHand = false;
			if (ContainsOnePair(hand))
				isHighHand = false;
			return isHighHand;
		}

		public int CompareHands(IHand firstHand, IHand secondHand)
		{
			throw new NotImplementedException();
		}
	}
}