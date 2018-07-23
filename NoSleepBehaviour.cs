using UnityEngine;

namespace TinyMatter.GetFact.Game {
    public class NoSleepBehaviour : MonoBehaviour {
        private void Awake() {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}