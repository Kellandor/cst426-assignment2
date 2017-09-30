using System;
using System.Collections.Generic;

//written by Brandon Shimizu, Jason Ferrer, Lorenzo Hernandez

namespace ASCIIGameEngine
{
    public class Scene
    {

        bool dirty_flag = false;
        const int height = 80;
        const int width = 80;
        List<GameObject> scene_objects = new List<GameObject>();
        private int first_x, first_y;

        public Scene()
        {
            MessageBus.getInstance().OnPlayerAttemptedMoveEvent += HandlePlayerRequestMoveEvent;
            MessageBus.getInstance().OnPlayerMoveResponse += HandlePlayerMovedEvent;

            // add two rocks
            GameObject rock = new GameObject();
            rock.x = 2;
            rock.y = 3;
            scene_objects.Add(rock);

            GameObject rock2 = new GameObject();
            rock2.x = 5;
            rock2.y = 4;
            scene_objects.Add(rock2);
        }

        public void HandlePlayerRequestMoveEvent(PlayerAttemptMovementEvent e)
        {
            // detect if player is requesting movement
            //check player id

            first_x = e.current_x;
            first_y = e.current_y;
            Console.WriteLine("Player is trying to move.");

        }

        public void HandlePlayerMovedEvent(MovementEvent e)
        {
            // move scene according to player
            Console.WriteLine("Player moved. Re-Drawing Scene");
            if (first_x == e.destination_x && first_y == e.destination_y)
            {
                return;
            }
            if (first_x - e.destination_x > 0)
            {
                Console.WriteLine("Scene moved right with player.");
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        //ayyyy must be the money
                    }
                }
            }
            else
            {
                Console.WriteLine("Scene moved left with player.");
            }
        }

        public void Update()
        {
            MessageBus.getInstance().AddEvent(new SceneChangeEvent(scene_objects));
            scene_objects = new List<GameObject>();
        }
    }
}