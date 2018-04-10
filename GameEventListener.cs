using System;
using UnityEngine;
using UnityEngine.Events;

namespace TinyMatter.CardClash.Core {
    
    [Serializable]
    public class GameEventListener {
        
        [Tooltip("Event to register with.")]
        [SerializeField]
        public GameEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        [SerializeField]
        public UnityEvent Response;
        
        public void Enable() {
            Event.RegisterListener(this);
        }

        public void Disable() {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised() {
            Response.Invoke();
        }
    }
    
}