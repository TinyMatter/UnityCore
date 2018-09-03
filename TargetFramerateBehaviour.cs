using TinyMatter.Core.Layout;
using UnityEngine;

namespace TinyMatter.GetFact.Game {
    public class TargetFramerateBehaviour : MonoBehaviour {
        [SerializeField] private int vSyncCount = 1;

        [SerializeField] private DeviceConfigurator deviceConfigurator;

        private void Awake() {
            var currentDevice = deviceConfigurator.GetCurrentDevice();

            Application.targetFrameRate = currentDevice.frameRate;
            QualitySettings.vSyncCount = vSyncCount;
        }
    }
}