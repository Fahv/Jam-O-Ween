using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	private bool clicked;
	private bool doneRound;
	private Gtk.Button firstClickedButton;
	private bool multiple;
	private bool witch;
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		resetBoardShown();
		updateLabels ();
		if (JamOween.Player.clan == 1) {
			lb_clan.Text = "You are part of a Werewolf Pack";
		} else {
			lb_clan.Text = "You are part of a Vampire Den";
		}
		clicked = false;
		doneRound = false;
		firstClickedButton = null;
		multiple = false;
		witch = false;
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void cardClicked (object sender, EventArgs e)
	{
		if (doneRound) {
			if(witch){
				resetBoardShown();
				witch = false;
			} else{
				resetBoard();
				resetBoard();
				resetBoard();
				resetBoard();
			}
			doneRound = false;
			if(JamOween.Game.getCardsLeftInDeck() == 0){
				gameOver(true);
			}
		}
		if (sender is Gtk.Button) {
			Gtk.Button tmp = (Gtk.Button)sender;
			int x = getButtonX(tmp);
			int y = getButtonY(tmp);
			tmp.Image = JamOween.Game.getCardAtPos(x,y).getImage();
			if(!clicked){
				clicked = true;
				firstClickedButton = tmp;
			}else if(firstClickedButton != tmp){
				//2nd click
				int x2 = getButtonX(firstClickedButton);
				int y2 = getButtonY(firstClickedButton);
				if(JamOween.Game.getCardAtPos(x,y).getCardType() ==JamOween.Game.getCardAtPos(x2,y2).getCardType()){
					if(JamOween.Player.clan == 0){
						if(JamOween.Game.getCardAtPos(x,y).getCardType() == 
					    JamOween.CardType.CardType_Vampire){
							if(multiple)
								JamOween.Game.score--;
							JamOween.Game.score--;
						} else if((JamOween.Game.getCardAtPos(x,y).getCardType() == 
					    JamOween.CardType.CardType_Warewolf)){
							if(multiple)
								JamOween.Game.score++;
							JamOween.Game.score++;
						} else if((JamOween.Game.getCardAtPos(x,y).getCardType() == 
					    	JamOween.CardType.CardType_Garlic)){
							gameOver(false);
						}
					} else {
						if(JamOween.Game.getCardAtPos(x,y).getCardType() == 
					    JamOween.CardType.CardType_Vampire){
							if(multiple)
								JamOween.Game.score++;
							JamOween.Game.score++;
						} else if((JamOween.Game.getCardAtPos(x,y).getCardType() == 
					    JamOween.CardType.CardType_Warewolf)){
							if(multiple)
								JamOween.Game.score--;
							JamOween.Game.score--;
						} else if((JamOween.Game.getCardAtPos(x,y).getCardType() == 
					    	JamOween.CardType.CardType_Silver)){
							gameOver(false);
						}
					}
					if(JamOween.Game.getCardAtPos(x,y).getCardType() == 
					    JamOween.CardType.CardType_Ghost){
						multiple = true;
						//JamOween.Game.shuffleCardsOnTable();
						//resetBoard();
					}
					if(JamOween.Game.getCardAtPos(x,y).getCardType() ==
					   	JamOween.CardType.CardType_Witch){
						witch = true;
					}
					
					   
					JamOween.Game.newCardAtPos(x,y);
					JamOween.Game.newCardAtPos(x2,y2);

					updateLabels();
				}
				clicked = false;
				doneRound = true;
			}
		}
	}

	private int getButtonX(Gtk.Button obj){
		if((obj.Name == "img_TL") ||(obj.Name == "img_TM") ||(obj.Name == "img_TR"))
			return 0;
		if((obj.Name == "img_ML") ||(obj.Name == "img_MM") ||(obj.Name == "img_MR"))
			return 1;
		if((obj.Name == "img_BL") ||(obj.Name == "img_BM") ||(obj.Name == "img_BR"))
			return 2;
		return -1;
	}
	private int getButtonY(Gtk.Button obj){
		if((obj.Name == "img_TL") ||(obj.Name == "img_ML") ||(obj.Name == "img_BL"))
			return 0;
		if((obj.Name == "img_TM") ||(obj.Name == "img_MM") ||(obj.Name == "img_BM"))
			return 1;
		if((obj.Name == "img_TR") ||(obj.Name == "img_MR") ||(obj.Name == "img_BR"))
			return 2;
		return -1;
	}

	private void updateLabels ()
	{
		lb_count.Text = "Number of cards left\nin the deck: " + JamOween.Game.getCardsLeftInDeck ().ToString ();
		lb_score.Text = "Score: " + JamOween.Game.score.ToString ();
	}
	private void resetBoard(){
		img_TL.Image = JamOween.Game.getCardAtPos(0,0).getImageNone();
		img_TM.Image = JamOween.Game.getCardAtPos(0,1).getImageNone();
		img_TR.Image = JamOween.Game.getCardAtPos(0,2).getImageNone();
		img_ML.Image = JamOween.Game.getCardAtPos(1,0).getImageNone();
		img_MM.Image = JamOween.Game.getCardAtPos(1,1).getImageNone();
		img_MR.Image = JamOween.Game.getCardAtPos(1,2).getImageNone();
		img_BL.Image = JamOween.Game.getCardAtPos(2,0).getImageNone();
		img_BM.Image = JamOween.Game.getCardAtPos(2,1).getImageNone();
		img_BR.Image = JamOween.Game.getCardAtPos(2,2).getImageNone();
	}
	private void resetBoardShown(){
		img_TL.Image = JamOween.Game.getCardAtPos(0,0).getImage();
		img_TM.Image = JamOween.Game.getCardAtPos(0,1).getImage();
		img_TR.Image = JamOween.Game.getCardAtPos(0,2).getImage();
		img_ML.Image = JamOween.Game.getCardAtPos(1,0).getImage();
		img_MM.Image = JamOween.Game.getCardAtPos(1,1).getImage();
		img_MR.Image = JamOween.Game.getCardAtPos(1,2).getImage();
		img_BL.Image = JamOween.Game.getCardAtPos(2,0).getImage();
		img_BM.Image = JamOween.Game.getCardAtPos(2,1).getImage();
		img_BR.Image = JamOween.Game.getCardAtPos(2,2).getImage();
	}
	private void gameOver(bool win){
		JamOween.Winner winWindow = new JamOween.Winner(win);
		winWindow.Show();
		this.Destroy();
	}


}
