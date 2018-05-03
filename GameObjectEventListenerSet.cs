using UnityEngine;

namespace TinyMatter.CardClash.Core {

    public class GameObjectEventListenerSet : MonoBehaviour {
        [SerializeField]
        private GameObjectEventListener[] eventListeners;

        private void OnEnable() {
            foreach (var listener in eventListeners) {
                listener.Enable();
            }
        }

        private void OnDisable() {
            foreach (var listener in eventListeners) {
                listener.Disable();
            }
        }
    }
}