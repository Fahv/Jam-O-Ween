using System;
using Gtk;

namespace JamOween
{
	public class Card
	{
		private CardType cType;
		private Gtk.Image img_ghost;
		private Gtk.Image img_vampire;
		private Gtk.Image img_warewolf;
		private Gtk.Image img_none;
		private Gtk.Image img_witch;

		public Card ()
		{
			cType = CardType.CardType_None;
		}
		public Card (CardType cType)
		{
			this.cType = cType;
			//Gdk.Pixbuf.LoadFromResource("JamOween.img.Ghost.png");
			//img_ghost = new Gtk.Image("Ghost.png");
			img_ghost = Gtk.Image.LoadFromResource("JamOween.img.Ghost.png");
			img_vampire = Gtk.Image.LoadFromResource("JamOween.img.Vampire.png");
			img_warewolf = Gtk.Image.LoadFromResource("JamOween.img.Warewolf.png");
			img_none = Gtk.Image.LoadFromResource("JamOween.img.Back.png");
			img_witch = Gtk.Image.LoadFromResource("JamOween.img.Witch.png");
			//img_ghost = new Gtk.Image.LoadFromResource("JamOween.img.Ghost.png");
			//else if (cType == CardType.CardType_Vampire) {
			//	img = new Gtk.Image (System.Reflection.Assembly.GetEntryAssembly ().
			//	GetManifestResourceStream ("JamOween.img.Vampire.png")
			//	);
			//}
			//if(cType == CardType.CardType_Warewolf)
			//	img = CardImages.IMAGE_WAREWOLF();
		}
		public Gtk.Image getImage ()
		{
			if(cType == CardType.CardType_Ghost)
				return img_ghost;
			if(cType == CardType.CardType_Vampire)
				return img_vampire;
			if(cType == CardType.CardType_Warewolf)
				return img_warewolf;
			if(cType == CardType.CardType_Witch)
				return img_witch;
			return img_none;
		}
		public Gtk.Image getImageNone ()
		{
			return img_none;
		}
		public CardType getCardType ()
		{
			return cType;
		}
	}
}

