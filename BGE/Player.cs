/* Daniel Crews
 * Daniel Kharlamov
 */
using System.Collections;
using System.Collections.Generic;
using System;
namespace ASCIIGameEngine
{
    public class Player : GameObject
    {
        private int health;
        private int xp;
        private bool dirty_flag;

        public Player()
        {

            health = 100;
            xp = 0;
            dirty_flag = false;
            x = 1;
            y = 1;
            MessageBus.getInstance().AddEvent(new PlayerAttemptMovementEvent(0, 0, x, y));
            // subscribe to types of messages you are interested in
            MessageBus.getInstance().OnInputEvent += HandleOnInputEvent;
            MessageBus.getInstance().OnAttackEvent += HandleOnAttackEvent;
            MessageBus.getInstance().OnPlayerMoveResponse += HandleOnPlayerMoveResponse;
        }

        public void HandleOnInputEvent(InputEvent e)
        {
            // logic that handles input will be implemented later"
            dirty_flag = true;

            PlayerAttemptMovementEvent potentialMove = new PlayerAttemptMovementEvent(x, y, x, y);

            //TODO Bound movement 
            switch (e.key)
            {
                case 'w':
                    Console.WriteLine("Player Up");
                    potentialMove.destination_y++;
                    break;
                case 's':
                    Console.WriteLine("Player Down");
                    potentialMove.destination_y--;
                    break;
                case 'a':
                    Console.WriteLine("Player Left");
                    potentialMove.destination_x--;
                    break;
                case 'd':
                    Console.WriteLine("Player Right");
                    potentialMove.destination_x++;
                    break;
                default: break;
            }
            MessageBus.getInstance().AddEvent(potentialMove);

        }

        public void HandleOnAttackEvent(AttackEvent e)
        {

        }


        public void HandleOnPlayerMoveResponse(PlayerMovementEvent e)
        {

            this.x = e.destination_x;
            this.y = e.destination_y;
            Console.WriteLine("" + this.x + " " + this.y);

        }

        public void Update()
        {
            Console.WriteLine("Player x:" + this.x.ToString() + " y:" + this.y.ToString());

        }


    }
}