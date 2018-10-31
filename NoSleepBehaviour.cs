using UnityEngine;

namespace TinyMatter.GetFact.Game {
    public class NoSleepBehaviour : MonoBehaviour {
        [SerializeField] private bool persist = true;
        
        private void Awake() {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            if (persist) {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}