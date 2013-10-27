using System;

namespace JamOween
{
	public partial class StartingWindow : Gtk.Window
	{
		public StartingWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();

		}
		protected void EasyGameStart (object sender, EventArgs e)
		{
			Constants.DECKSIZE = 39;
			//Player clan
			//Not Player clan
			//Witch
			//Ghost
			//Silver
			//Garlic
			Game.cardFrequencies = new System.Collections.Generic.Dictionary<char,double>{
				{'a',12},	
				{'b',9},	
				{'c',3},	
				{'d',2},	
				{'e',1},	
				{'f',1}};	
			StartGame();
		}		
		protected void MediumGameStart (object sender, EventArgs e)
		{
			Constants.DECKSIZE = 39;
			Game.cardFrequencies = new System.Collections.Generic.Dictionary<char,double>{
				{'a',11},	//Player clan
				{'b',11},	//Not Player clan
				{'c',3},	//Witch
				{'d',2},	//Ghost
				{'e',1},	//Silver
				{'f',1}};	//Garlic
			StartGame();
		}
		protected void HardGameStart (object sender, EventArgs e)
		{
			Constants.DECKSIZE = 39;
			Game.cardFrequencies = new System.Collections.Generic.Dictionary<char,double>{
				{'a',9},	//Player clan
				{'b',12},	//Not Player clan
				{'c',3},	//Witch
				{'d',2},	//Ghost
				{'e',1},	//Silver
				{'f',1}};	//Garlic
			StartGame();
		}
		private void StartGame ()
		{
			if (radbtn_werewolf.Active) {
				JamOween.Player.clan = 1;
			} else {
				JamOween.Player.clan = 0;
			}
			//JamOween.Player.clan;
			Game.init();
			MainWindow gWin = new MainWindow ();
			gWin.Show();
			this.Destroy();
		}



	}
}

