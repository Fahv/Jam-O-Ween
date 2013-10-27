using System;
using Gtk;

namespace JamOween
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			JamOween.StartingWindow sWin = new JamOween.StartingWindow();
			sWin.Show();
			Application.Run ();

		}
	}
}
