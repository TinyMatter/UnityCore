using UnityEngine;

namespace TinyMatter.Core.Sound {
    public class SoundEffectController : MonoBehaviour {
        [SerializeField] private BoolReference soundEffectsEnabled;
        [SerializeField] private GameObjectEventListenerSet gameObjectEventListener;
        [SerializeField] private GameEventListenerSet gameEventListener;

        private void Awake() {
            UpdateEventListeners();
        }

        public void SoundEffectsEnabledChanged() {
            UpdateEventListeners();
        }

        private void UpdateEventListeners() {
            gameObjectEventListener.enabled = soundEffectsEnabled;
            gameEventListener.enabled = soundEffectsEnabled;
        }
    }
}