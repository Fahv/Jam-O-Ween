using System;


namespace JamOween
{
	public class Game
	{
		protected Card[][] cardsOnTable;
		public Game ()
		{
			cardsOnTable = new Card[3][];
			for (int x = 0; x< cardsOnTable.Length; x++) {
				cardsOnTable [x] = new Card[3];
			}
			init();
		}
		public void init ()
		{
			for (int x =0; x<3; x++) {
				for (int y=0; y<3; y++) {
					//CardType.CardType_None;
					cardsOnTable[x][y] = new Card(JamOween.CardType.CardType_Vampire);
				}
			}
		}
		public Card getCardAtPos(int x,int y){
			return cardsOnTable[x][y];
		}
	}
}

