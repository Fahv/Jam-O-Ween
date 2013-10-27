using System;

namespace JamOween
{
	public partial class Winner : Gtk.Window
	{
		public Winner (bool win) : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			if (win) {
				lb_win1.Text = "Congratulation you won";
			} else {
				lb_win1.Text = "Game Over maybe in another life you will\n slaughter your enemies!";
			}
			lb_finalscore.Text = "Final Score: " + JamOween.Game.score.ToString();
		}
		protected void exit (object sender, EventArgs e)
		{
			Gtk.Application.Quit ();
		}		
		protected void PlayAgain (object sender, EventArgs e)
		{
			JamOween.StartingWindow sWin = new JamOween.StartingWindow();
			sWin.Show();
			this.Destroy();
		}


	}
}

