using UnityEngine;

namespace TinyMatter.Core.Layout {
    [CreateAssetMenu(menuName = "Device Configuration/Platform Configurator")]
    public class MultiplatformDeviceConfigurator : DeviceConfigurator {

        [SerializeField]
        private IOSDeviceConfigurator iOSDeviceConfigurator;

        // TODO: Add more platforms here using technique from this forum post:
        //       https://forum.unity.com/threads/canvas-scaler-issues-with-iphone-x.505711/
        public override DeviceConfiguration GetCurrentDevice() {
            return iOSDeviceConfigurator.GetCurrentDevice();
        }
    }
}