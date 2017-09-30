/* Daniel Crews
 * Daniel Kharlamov
 */
using System.Collections;
using System.Collections.Generic;
namespace ASCIIGameEngine
{
	public class NPC : GameObject {
		int position_x = 80;
		int position_y = 0;
        int npc_id = 0;

        AI strategies = new AI();

		public NPC(int id) {
            // subscribe to types of messages you are interested in
            MessageBus.getInstance().OnAttackEvent += HandleAttackEvent;
            MessageBus.getInstance().OnNPCMoveResponse += HandleMoveEvent;
            strategies.attackStrat = new AggressiveStrategy();
            strategies.navStrat = new FlexibleMovement();

            npc_id = id;
        }

		public void HandleAttackEvent(GameEvent e){
            
			// logic that handles messages coming from the bus.
		}

        public void HandleMoveEvent(NPCMovementEvent e) {
            // logic that handles messages coming from the bus.
            position_x = e.destination_x;
            position_y = e.destination_y;
        }


        private void Move(){
            // some smart AI will calculate where I should move
            MessageBus.getInstance().AddEvent(strategies.navStrat.findPath(position_x, position_x, npc_id));
        }

        private void Attack() {

            strategies.attackStrat.attack();

        }

        public void Update () {

			Move();

            Attack();

		}
	}
}
