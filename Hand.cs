using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
	public class Hand : IHand
	{
		private IList<ICard> cards;
		public IList<ICard> Cards
		{
			get
			{
				return this.cards;
			}
			private set
			{
				if (value == null || value.Count == 0)
				{
					throw new ArgumentNullException("The hand cannot be empty");
				}
				else if (value.Count > 5)
				{
					throw new ArgumentException("The hand cannot have more than 5 cards.");
				}
				this.cards = value;
			}
		}

		public Hand(IList<ICard> cards)
		{
			this.Cards = cards;
		}

		public override string ToString()
		{
			return String.Join(", ", this.Cards);
		}
	}
}