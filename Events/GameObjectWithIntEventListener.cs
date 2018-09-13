using System;
using TinyMatter.CardClash.Gameplay;
using UnityEngine;

namespace TinyMatter.Core {

    [Serializable]
    public class GameObjectWithIntEventListener {
        [Tooltip("Event to register with.")]
        [SerializeField]
        public GameObjectWithIntEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        [SerializeField]
        public GameObjectWithIndexEvent Response;

        public void OnEventRaised(GameObject gameObject, int index) {
            Response.Invoke(gameObject, index);
        }

        public void Enable() {
            Event.RegisterListener(this);
        }

        public void Disable() {
            Event.UnregisterListener(this);
        }
    }
}