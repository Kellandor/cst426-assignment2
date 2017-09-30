using System.Collections;
using System.Collections.Generic;
using System;



namespace ASCIIGameEngine
{
	public class UIManager {
		string playersHealth = "";
		int playersScore = 0;

		public	UIManager()	{	
			MessageBus.getInstance ().OnPlayerHealthEvent += HandlePlayerHealth;
			MessageBus.getInstance().OnPlayerScoreEvent += HandlePlayerScore;
		}	
		void HandlePlayerHealth(PlayerHealthEvent e){
			playersHealth = e.health.ToString ();
		}
		void HandlePlayerScore(PlayerScoreEvent e){
			playersHealth = e.score.ToString ();
		}
		private	void Update()	{
            //UIToRender(playersHealth, playersScore);

            MessageBus.getInstance().AddEvent(new UIToRenderEvent(playersHealth, playersScore));

		}
	}
}
