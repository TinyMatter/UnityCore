using UnityEngine;

namespace TinyMatter.Core.Sound {
    public class SoundEffectController : MonoBehaviour {
        [SerializeField] private BoolReference soundEffectsEnabled;

        private void Start() {
            if (!soundEffectsEnabled.Value) {
                Destroy(gameObject.GetComponent<GameObjectEventListenerSet>());
            }
        }
    }
}