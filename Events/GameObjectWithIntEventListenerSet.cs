using UnityEngine;

namespace TinyMatter.Core {

    public class GameObjectWithIntEventListenerSet : MonoBehaviour {
        [SerializeField]
        private GameObjectWithIntEventListener[] eventListeners;

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