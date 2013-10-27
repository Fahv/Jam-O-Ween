using System;


namespace JamOween
{
	public static class Game
	{
		private static Card[][] cardsOnTable;
		private static System.Collections.Generic.Queue<Card> deck;
		public static int score;
		public static System.Collections.Generic.Dictionary<char,double> cardFrequencies;
		public static void init ()
		{
			score = 0;
			cardsOnTable = new Card[Constants.PLAYAREA][];
			deck = new System.Collections.Generic.Queue<Card> (Constants.DECKSIZE);
			var sb = new ShuffleBag (88000);

			int amount = 0;
			foreach (var card in cardFrequencies) {
				amount = (int)card.Value *10;
				sb.Add(card.Key,amount);
			}
			for (int i=0; i<Constants.DECKSIZE; i++) {
				char tempR = sb.Next();
				if(tempR == 'a'){
					if(Player.clan == 1){
						deck.Enqueue(new Card(CardType.CardType_Vampire));
					}else{
						deck.Enqueue(new Card(CardType.CardType_Warewolf));
					}
				}else if(tempR == 'b'){
					if(Player.clan == 1){
						deck.Enqueue(new Card(CardType.CardType_Vampire));
					}else{
						deck.Enqueue(new Card(CardType.CardType_Warewolf));
					}
				}else if(tempR == 'c'){
					deck.Enqueue(new Card(CardType.CardType_Witch));
				}else if(tempR == 'd'){
					deck.Enqueue(new Card(CardType.CardType_Ghost));
				}else{
					if(Player.clan == 0){
						deck.Enqueue(new Card(CardType.CardType_Vampire));
					}else{
						deck.Enqueue(new Card(CardType.CardType_Warewolf));
					}
				}
			}
			for (int x = 0; x< cardsOnTable.Length; x++) {
				cardsOnTable [x] = new Card[Constants.PLAYAREA];
			}
			for (int x =0; x<Constants.PLAYAREA; x++) {
				for (int y=0; y<Constants.PLAYAREA; y++) {
					cardsOnTable[x][y] = deck.Dequeue();
				}
			}
		}
		public static Card getCardAtPos (int x, int y)
		{
			if (((x >= 0) && (x < Constants.PLAYAREA)) ||
				((y >= 0) && (y < Constants.PLAYAREA)))
				return cardsOnTable [x] [y];
			else {
				return null;
			}
		}
		public static int getCardsLeftInDeck ()
		{
			return deck.Count;
		}
		public static bool newCardAtPos (int x, int y)
		{
			if (((x >= 0) && (x < Constants.PLAYAREA)) ||
				((y >= 0) && (y < Constants.PLAYAREA))) {
				if (deck.Count > 0) {
					cardsOnTable [x] [y] = deck.Dequeue ();
					return true;
				}
			}
			return false;
		}
		public static void shuffleCardsOnTable(){
			Card tmp0 = cardsOnTable[0][0];
			Card tmp1 = cardsOnTable[0][1];
			Card tmp2 = cardsOnTable[0][2];
			Card tmp3 = cardsOnTable[1][0];
			Card tmp4 = cardsOnTable[1][1];
			Card tmp5 = cardsOnTable[1][2];
			Card tmp6 = cardsOnTable[2][0];
			Card tmp7 = cardsOnTable[2][1];
			Card tmp8 = cardsOnTable[2][2];
			cardsOnTable[0][0] = tmp1;
			cardsOnTable[0][1] = tmp2;
			cardsOnTable[0][2] = tmp3;
			cardsOnTable[1][0] = tmp4; 
			cardsOnTable[1][1] = tmp5;
			cardsOnTable[1][2] = tmp6;
			cardsOnTable[2][0] = tmp7;
			cardsOnTable[2][1] = tmp8;
			cardsOnTable[2][2] = tmp0;
		}
	}
}

