using System;

namespace ASCIIGameEngine
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Input input = new Input ();
			Player player = new Player ();
			NPCManager npcManager = new NPCManager ();	
			RenderEngine renEn = new RenderEngine ();
            Collision collision = new Collision();
            Scene scene = new Scene();
			// game loop
			while (true) {
				// process messages
				MessageBus.getInstance ().Update ();
				input.readInput ();
				// update player
				player.Update ();
                // update collision
                collision.Update();
				// update managers;
				npcManager.Update ();
				//update scene
				scene.Update();
				// render game
				renEn.Render ();
			}
		}
	}
}
