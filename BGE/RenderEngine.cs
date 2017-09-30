using System;

//written by Brandon Shimizu, Jason Ferrer, Lorenzo Hernandez

namespace ASCIIGameEngine
{
	
	public class RenderEngine
	{
		const int width = 80;
		const int height = 80;
		private char[,] screen = new char[height, width];

		public RenderEngine(){
			for (int i = 0; i < height; i++)
				for (int j = 0; j < width; j++)
					screen [i,j] = '0';
			MessageBus.getInstance().OnSceneChangeEvent += HandleSceneChangedEvent;
			MessageBus.getInstance ().OnNPCMoveResponse += HandleNPCMovedEvent;
			MessageBus.getInstance ().OnPlayerMoveResponse += HandlePlayerMovedEvent;
			MessageBus.getInstance ().OnUIToRenderEvent += HandleUItoUpdateEvent;
		}

		public void HandleSceneChangedEvent(SceneChangeEvent e){
			//render scene
			Console.WriteLine("Camera moved. Re-Drawing Scene");
		}
		
		public void HandleNPCMovedEvent(NPCMovementEvent e){
			// render the almighty zodd and all his minions
			Console.WriteLine("Npc moved. Re-Drawing Npc");

		}
		
		public void HandlePlayerMovedEvent(PlayerMovementEvent e){
			// render you
			Console.WriteLine("Player moved. Re-Drawing Player");

		}
		
		public void HandleUItoUpdateEvent(UIToRenderEvent e){
			Console.WriteLine("UI values have changed. Re-Drawing UI objects");
		}

		public void Render(){

			Console.WriteLine ("Rendering Screen");
			
			/*
			 * for (int i = 0; i < height; i++) {
				for (int j = 0; j < width; j++)
					Console.Write (screen [i,j]);
				Console.Write ("\n");
			}*/
						
		}		
	}
}

