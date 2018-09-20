using System.Collections.Generic;
using UnityEngine;

namespace TinyMatter.Core.Sound {
    public class SoundEffectController : MonoBehaviour {
        [SerializeField] private BoolReference soundEffectsEnabled;
        
        [SerializeField] private List<MonoBehaviour> soundEffectEventListeners = new List<MonoBehaviour>();

        private void Awake() {
            UpdateEventListeners();
        }

        public void SoundEffectsEnabledChanged() {
            UpdateEventListeners();
        }

        private void UpdateEventListeners() {
            foreach (var soundEffectEventListener in soundEffectEventListeners) {
                soundEffectEventListener.enabled = soundEffectsEnabled;
            }
        }
    }
}