using System.Collections.Generic;
using UnityEngine;

namespace TinyMatter.CardClash.Core {
    [CreateAssetMenu(menuName = "Events/Game Object")]
    public class GameObjectEvent : ScriptableObject {
        [Multiline] [SerializeField] private string DeveloperDescription = "";

        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameObjectEventListener> eventListeners =
            new List<GameObjectEventListener>();

        public void Raise(GameObject gameObject) {
            for (var i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(gameObject);
        }

        public void RegisterListener(GameObjectEventListener listener) {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(GameObjectEventListener listener) {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}