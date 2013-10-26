using System;

namespace JamOween
{
	public class Card
	{
		private CardType cType;
		public Card ()
		{
			cType = CardType.CardType_None;
		}
		public Card (CardType cType)
		{
			this.cType = cType;
		}
	}
}

