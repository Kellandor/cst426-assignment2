/*
 * Names:   Ryan Blakeman
 *          Clay Evans
 * CST426 ASCII Game Engine
*/


using System.Collections;
using System.Collections.Generic;
using System;

namespace ASCIIGameEngine
{

    public class MessageBus
    {
        // queue of all events
        private Queue<GameEvent> _events;

        // using singleton, so there is only one message bus
        private MessageBus()
        {
            _events = new Queue<GameEvent>();
        }

        private static MessageBus instance;

        public static MessageBus getInstance()
        {
            if (instance == null)
            {
                instance = new MessageBus();
            }
            return instance;
        }

        // components can subscribe to all... 
        public event Action<GameEvent> OnGameEvent;

        // .. or just some messages
        public event Action<InputEvent> OnInputEvent;
        public event Action<PlayerHealthEvent> OnPlayerHealthEvent;
        public event Action<PlayerScoreEvent> OnPlayerScoreEvent;
        
        
        public event Action<PlayerAttemptedMove> OnPlayerAttemptedMoveEvent;
        public event Action<PlayerMoveResponse> OnPlayerMoveResponse;
        public event Action<NPCAttemptedMovedEvent> OnNPCAttemptedMovedEvent;
        public event Action<NPCMoveResponse> OnNPCMoveResponse;

        public event Action<AttackEvent> OnAttackEvent;
        public event Action<CollisionEvent> OnCollisionEvent;

        public event Action<SceneChangeEvent> OnSceneChangeEvent;

        public event Action<UIToRenderEvent> OnUIToRenderEvent;

        // public interface: anyone can add event of any type
        public void AddEvent(GameEvent evt)
        {
            _events.Enqueue(evt);
        }

        public void Update()
        {
            while (_events.Count > 0)
            {
                GameEvent evt = _events.Dequeue();
                // using reflection is a bit slow, but who cares
                OnGameEvent((GameEvent)evt);

                if (evt.GetType() == typeof(InputEvent))
                    OnInputEvent((InputEvent)evt);
                if (evt.GetType() == typeof(PlayerHealthEvent))
                    OnPlayerHealthEvent((PlayerHealthEvent)evt);
                if (evt.GetType() == typeof(PlayerScoreEvent))
                    OnPlayerScoreEvent((PlayerScoreEvent)evt);


                // Player and NPC related stuff
                if (evt.GetType() == typeof(InputEvent))
                    OnInputEvent((InputEvent)evt);

                if (evt.GetType() == typeof(PlayerAttemptedMove))
                    OnPlayerAttemptedMoveEvent((PlayerAttemptedMove)evt);

                if (evt.GetType() == typeof(PlayerMoveResponse))
                    OnPlayerMoveResponse((PlayerMoveResponse)evt);

                if (evt.GetType() == typeof(PlayerAttemptedMove))
                    OnPlayerAttemptedMoveEvent((PlayerAttemptedMove)evt);

                if (evt.GetType() == typeof(NPCAttemptedMovedEvent))
                    OnNPCAttemptedMovedEvent((NPCAttemptedMovedEvent)evt);

                if (evt.GetType() == typeof(NPCMoveResponse))
                    OnNPCMoveResponse((NPCMoveResponse)evt);



                if (evt.GetType() == typeof(AttackEvent))
                    OnAttackEvent((AttackEvent)evt);
                if (evt.GetType() == typeof(CollisionEvent))
                    OnCollisionEvent((CollisionEvent)evt);
                if (evt.GetType() == typeof(SceneChangeEvent))
                    OnSceneChangeEvent((SceneChangeEvent)evt);
                if (evt.GetType() == typeof(UIToRenderEvent))
                    OnUIToRenderEvent((UIToRenderEvent)evt);
                // this handles movement of npcs. there is 10 of them and they just move left
                // if (evt.GetType () == typeof(NPCMovedEvent))
                //  	OnNPCMovedEvent ((NPCMovedEvent)evt);
            }
        }
    }
} 