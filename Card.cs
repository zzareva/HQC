using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }
		/// <summary>
		/// Returns the Card as string
		/// </summary>
		/// <returns>The string value of the cards</returns>
		public override string ToString()
		{
			var cardToSting = "";
			switch (this.Face)
			{
				case CardFace.Two:
				case CardFace.Three:
				case CardFace.Four:
				case CardFace.Five:
				case CardFace.Six:
				case CardFace.Seven:
				case CardFace.Eight:
				case CardFace.Nine:
				case CardFace.Ten:
					cardToSting = Convert.ToInt32(this.Face).ToString();
					break;
				case CardFace.Jack:
				case CardFace.Queen:
				case CardFace.King:
				case CardFace.Ace:
					cardToSting = this.Face.ToString().Substring(0,1);
					break;
			}

			switch (this.Suit)
			{
				case CardSuit.Clubs:
					cardToSting += "♣";
					break;
				case CardSuit.Diamonds:
					cardToSting += "♦";
					break;
				case CardSuit.Hearts:
					cardToSting += "♥";
					break;
				case CardSuit.Spades:
					cardToSting += "♠";
					break;
			}
			return cardToSting;
        }
    }
}
