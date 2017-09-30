using System;

namespace ASCIIGameEngine
{
	public class NPCManager
	{
		public const int MAX_NPC = 10;
		public NPC[] npcs = new NPC[MAX_NPC];
		public NPCManager ()
		{	
			for (int i=0; i<MAX_NPC; i++)
				npcs[i] = new NPC (i);
		}
		public void Update(){
			foreach (NPC n in npcs)
				n.Update ();
		}	
	}
}


