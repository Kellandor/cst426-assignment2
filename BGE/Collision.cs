/*
 * Names:   Nigel Hardy
 *          Phuc Pham
 * CST426 ASCII Game Engine
*/


using System.Collections;
using System.Collections.Generic;
using System;

namespace ASCIIGameEngine
{

    public class Collision
    {
        int width = 10;
        int height = 10;
        bool[,] collisionMatrix = new bool[10, 10];
        int counter = 0;
        int curr_x = 0;
        int curr_y = 0;
        int new_x = 1;
        int new_y = 1;

        public Collision()
        {
            MessageBus.getInstance().OnPlayerAttemptedMoveEvent += HandleMovementEvent;
            MessageBus.getInstance().OnNPCAttemptedMovedEvent += HandleMovementEvent;
            MessageBus.getInstance().OnSceneChangeEvent += HandleSceneObjects;

            for (int i = 0; i < height; i++)
            {
                collisionMatrix[i, 0] = true;
                collisionMatrix[height - 1, i] = true;
            }

            for (int i = 0; i < width; i++)
            {
                collisionMatrix[0, i] = true;
                collisionMatrix[i, width - 1] = true;
            }
        }
        public void HandleSceneObjects(SceneChangeEvent sce)
        {
            foreach (var item in sce.scene_objects)
            {
                if (item != null)
                {
                    collisionMatrix[item.x, item.y] = true;
                }
            }
        }
        public void HandleMovementEvent(AttemptMovementEvent e)
        {

            /* 
             * Check if movement is possible and send message back
             */
            if (e.destination_x < width && e.destination_y < height && e.destination_x >= 0 && e.destination_y >= 0)
            {
                if (!collisionMatrix[e.destination_x, e.destination_y])
                {
                    Console.Write("Entity " + e.id.ToString() + " moved to: ");
                    collisionMatrix[e.current_x, e.current_y] = false;
                    collisionMatrix[e.destination_x, e.destination_y] = true;
                    Console.WriteLine(e.destination_x.ToString() + "," + e.destination_y.ToString());
                    // accept movement event
                    if (e.id == 0)
                    {
                        MessageBus.getInstance().AddEvent(new PlayerMovementEvent(e.destination_x, e.destination_y));
                    }
                    else
                    {
                        MessageBus.getInstance().AddEvent(new MovementEvent(e.id, e.destination_x, e.destination_y));
                    }


                }
                else
                {
                    Console.Write("Entity " + e.id.ToString() + " couldn't move to: ");
                    Console.WriteLine(e.destination_x.ToString() + "," + e.destination_y.ToString());
                    // send collision event at this position
                    MessageBus.getInstance().AddEvent(new CollisionEvent(e.destination_x, e.destination_y));
                }
            }
        }


        private void printMatrix()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Console.Write(i.ToString() + "," + j.ToString() + ": " + collisionMatrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public void Update()
        {

            printMatrix();
            //counter++;
            //if (counter % 10000 == 0)
            //{
            //    MessageBus.getInstance().AddEvent(new AttemptMovementEvent(0, curr_x, curr_y, new_x, new_y));
            //    curr_x++;
            //    curr_y++;
            //    new_x++;
            //    new_y++;
            //}
        }
    }


}