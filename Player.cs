/* Daniel Crews
 * Daniel Kharlamov
 */
using System.Collections;
using System.Collections.Generic;
using System;
namespace ASCIIGameEngine {
    public class Player : GameObject {
        private int health;
        private int xp;
        private bool dirty_flag;

        public Player() {

            health = 100;
            xp = 0;
            dirty_flag = false;

            // subscribe to types of messages you are interested in
            MessageBus.getInstance().OnInputEvent += HandleOnInputEvent;
            MessageBus.getInstance().OnAttackEvent += HandleOnAttackEvent;
        }

        public void HandleOnInputEvent(InputEvent e) {
            // logic that handles input will be implemented later"
            dirty_flag = true;

            PlayerAttemptedMove potentialMove = new PlayerAttemptedMove(x,y);

            //TODO Bound movement 
            switch (e.key) {
                case 'w':
                    Console.WriteLine("Player Up");
                    potentialMove.position_y++;
                    break;
                case 's':
                    Console.WriteLine("Player Down");
                    potentialMove.position_y--;
                    break;
                case 'a':
                    Console.WriteLine("Player Left");
                    potentialMove.position_x--;
                    break;
                case 'd':
                    Console.WriteLine("Player Right");
                    potentialMove.position_x++;
                    break;
                default: break;
            }
            MessageBus.getInstance().AddEvent(potentialMove);

        }

        public void HandleOnAttackEvent(AttackEvent e) {

        }


        public void HandleOnPlayerMoveResponse(PlayerMoveResponse e) {

            this.x = e.position_x;
            this.y = e.position_y;

            Console.WriteLine("" + this.x + " " + this.y);

        }


        public void Update() {

            //Redraw player i guess


            //Console.WriteLine("Add event render event");
            //MessageBus.getInstance().AddEvent(RENDER EVENT GOES HERE!!!);

        }


    }
}