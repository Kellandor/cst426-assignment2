using System.Collections;
using System.Collections.Generic;
using System;


/* Garred Murphy */

namespace ASCIIGameEngine
{
	public class UIManager {
		string playersHealth = "";  //health probably should not be stored as a string.  
        int playersScore = 0;  //And score probably should not be stored as an int because elsewhere in the code these are both writen as doubles. 
                               //  I didn't want to change the code the others had written so i left it as it was.
        public UIManager()	{	
			MessageBus.getInstance ().OnPlayerHealthEvent += HandlePlayerHealth;
			MessageBus.getInstance().OnPlayerScoreEvent += HandlePlayerScore;
		}
		void HandlePlayerHealth(PlayerHealthEvent e){
			playersHealth = e.health.ToString ();
		}
		void HandlePlayerScore(PlayerScoreEvent e){
			playersScore = (int)e.score;  //
		}
		private	void Update()	{

            MessageBus.getInstance().AddEvent(new UIToRenderEvent(playersHealth, playersScore));

		}
	}
}
