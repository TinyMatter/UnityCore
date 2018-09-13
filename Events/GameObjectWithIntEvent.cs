using System.Collections.Generic;
using UnityEngine;

namespace TinyMatter.Core {
    [CreateAssetMenu(menuName = "Events/Game Object and Int")]
    public class GameObjectWithIntEvent : ScriptableObject {
        [Multiline] [SerializeField] private string DeveloperDescription = "";

        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameObjectWithIntEventListener> eventListeners =
            new List<GameObjectWithIntEventListener>();

        public void Raise(GameObject gameObject, int index) {
            for (var i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(gameObject, index);
        }

        public void RegisterListener(GameObjectWithIntEventListener listener) {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(GameObjectWithIntEventListener listener) {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}