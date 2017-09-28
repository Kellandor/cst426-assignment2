using System.Collections;
using System.Collections.Generic;
namespace ASCIIGameEngine
{
	public class NPC : GameObject {
		int position_x = 80;
		int position_y = 0;
		
		public NPC() {
			// subscribe to types of messages you are interested in
			MessageBus.getInstance().OnGameEvent += HandleOnGameEvent;
		}

		public void HandleOnGameEvent(GameEvent e){
			// logic that handles messages coming from the bus.
		}
		// Update is called once per frame

		private void Move(){
			// some smart AI will calculate where I should move
			position_x--;
		}

		public void Update () {

			Move();
			// send message that npc moved
			MessageBus.getInstance().AddEvent (new NPCMovedEvent(position_x,position_y));
		}
	}
}
