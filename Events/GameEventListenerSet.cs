using UnityEngine;

namespace TinyMatter.Core {
    public class GameEventListenerSet : MonoBehaviour {
        [SerializeField] public GameEventListener[] eventListeners;
        
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