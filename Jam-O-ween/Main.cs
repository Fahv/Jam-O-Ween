using System;
using Gtk;

namespace JamOween
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Game g = new Game();
			Application.Run ();

		}
	}
}
