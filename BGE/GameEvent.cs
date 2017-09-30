using System.Collections;
using System.Collections.Generic;

namespace ASCIIGameEngine
{
    public abstract class GameEvent
    {
    }

    public class InputEvent : GameEvent
    {
        public char key { get; set; }
        public InputEvent(char c)
        {
            key = c;
        }
    }

    public class PlayerHealthEvent : GameEvent
    {
        public double health { get; set; }
    }
    public class PlayerScoreEvent : GameEvent
    {
        public double score { get; set; }
    }

    public class AttemptMovementEvent : GameEvent
    {
        public int id { get; set; }
        public int current_x { get; set; }
        public int current_y { get; set; }
        public int destination_x { get; set; }
        public int destination_y { get; set; }
        public AttemptMovementEvent(int newid, int curr_x, int curr_y, int new_x, int new_y)
        {
            id = newid;
            current_x = curr_x;
            current_y = curr_y;
            destination_x = new_x;
            destination_y = new_y;
        }
    }

    public class PlayerAttemptMovementEvent : AttemptMovementEvent
    {
        public PlayerAttemptMovementEvent(int curr_x, int curr_y, int new_x, int new_y)
            : base(0, curr_x, curr_y, new_x, new_y)
        { }
    }

    public class NPCAttemptMovementEvent : AttemptMovementEvent
    {
        public NPCAttemptMovementEvent(int newid, int curr_x, int curr_y, int new_x, int new_y)
            : base(newid, curr_x, curr_y, new_x, new_y)
        { }
    }

    public class MovementEvent : GameEvent
    {
        public int id { get; set; }
        public int destination_x { get; set; }
        public int destination_y { get; set; }
        public MovementEvent(int newid, int x, int y)
        {
            id = newid;
            destination_x = x;
            destination_y = y;
        }
    }

    public class PlayerMovementEvent : MovementEvent
    {
        public PlayerMovementEvent(int x, int y)
            : base(0, x, y)
        { }
    }

    public class NPCMovementEvent : MovementEvent
    {
        public NPCMovementEvent(int newid, int x, int y)
            : base(newid, x, y)
        { }
    }

    public class AttackEvent : GameEvent
    {
        public int attack_x { get; set; }
        public int attack_y { get; set; }
        public string attackDescription { get; set; }
        public AttackEvent(int x, int y)
        {
            attack_x = x;
            attack_y = y;
        }
    }

    public class CollisionEvent : GameEvent
    {
        public int check_x { get; set; }
        public int check_y { get; set; }
        public CollisionEvent(int x, int y)
        {
            check_x = x;
            check_y = y;
        }
    }

    public class SceneChangeEvent : GameEvent
    {
        public List<GameObject> scene_objects { get; set; }
        public SceneChangeEvent(List<GameObject> objects)
        {
            scene_objects = objects;
        }
    }

    public class UIToRenderEvent : GameEvent
    {
        public string health { get; set; }
        public int score { get; set; }
        public UIToRenderEvent(string hp, int score)
        {
            health = hp;
            this.score = score;
        }
    }
}