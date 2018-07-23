using UnityEngine;

namespace TinyMatter.GetFact.Game {
    public class TargetFramerateBehaviour : MonoBehaviour {
        [SerializeField] private int targetFramerate = 60;
        [SerializeField] private int vSyncCount = 1;

        private void Awake() {
            Application.targetFrameRate = targetFramerate;
            QualitySettings.vSyncCount = vSyncCount;
        }
    }
}