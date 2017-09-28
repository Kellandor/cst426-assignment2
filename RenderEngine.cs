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
			MessageBus.getInstance().OnSceneChangedEvent += HandleSceneChangedEvent;
			MessageBus.getInstance ().OnNPCMovedEvent += HandleNPCMovedEvent;
			MessageBus.getInstance ().OnPlayerMovedEvent += HandlePlayerMovedEvent;
			MessageBus.getInstance ().OnUIToRenderEvent += HandleUItoRenderEvent;
		}

		public void HandleSceneChangedEvent(SceneChangedEvent e){
			//render scene
			Console.WriteLine("Camera moved. Re-Drawing Scene");
		}
		
		public void HandleNPCMovedEvent(NPCMovedEvent e){
			// render the almighty zodd and all his minions
			Console.WriteLine("Npc moved. Re-Drawing Npc");

		}
		
		public void HandlePlayerMovedEvent(PlayerMovedEvent e){
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

