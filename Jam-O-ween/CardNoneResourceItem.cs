using System;

namespace JamOween
{
	public struct CardNoneResourceItem
	{
		Gtk.Image img;
		bool inUse;
	}

	public class CardNoneResourcePool{
		private static System.Collections.Generic.Queue<CardNoneResourceItem> pool;
		public CardNoneResourcePool ()
		{
			for (int i =0; i<Constants.PLAYAREA*2; i++) {
				CardNoneResourceItem tmp = new CardNoneResourceItem();

				//pool.Enqueue(new Gtk.Image.LoadFromResource("JamOween.img.Back.png"),
			}
		}
	}
}

