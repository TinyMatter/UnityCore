using System;
using UnityEngine;

namespace TinyMatter.Core {

    [Serializable]
    public class GameObjectEventListener {
        [Tooltip("Event to register with.")]
        [SerializeField]
        public GameObjectEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        [SerializeField]
        public GameObjectEventResponse Response;

        public void OnEventRaised(GameObject gameObject) {
            Response.Invoke(gameObject);
        }

        public void Enable() {
            Event.RegisterListener(this);
        }

        public void Disable() {
            Event.UnregisterListener(this);
        }
    }
}