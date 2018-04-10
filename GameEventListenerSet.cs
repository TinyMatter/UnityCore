using System.Collections.Generic;
using UnityEngine;

namespace TinyMatter.CardClash.Core {
    public class GameEventListenerSet : MonoBehaviour {
        [SerializeField]
        private GameEventListener[] eventListeners;
        
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