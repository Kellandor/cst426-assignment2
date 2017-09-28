using System.Collections;
using System.Collections.Generic;
using System;

namespace ASCIIGameEngine
{
	public class UIManager {
		string playersHealth = "";

		public	UIManager()	{	
			MessageBus.getInstance ().OnPlayerHealthEvent += HandlePlayerHealth;
		}	
		void HandlePlayerHealth(PlayerHealthEvent e){
			playersHealth = e.health.ToString ();
		}	
		private	void Update()	{	
			Console.WriteLine ("Player's health:" + playersHealth);
		}
	}
}
