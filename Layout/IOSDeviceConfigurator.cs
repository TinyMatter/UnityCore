using System.Collections.Generic;
using UnityEngine;

namespace TinyMatter.Core.Layout {
    [CreateAssetMenu(menuName = "Device Configuration/iOS Configurator")]
    public class IOSDeviceConfigurator : DeviceConfigurator {
        [SerializeField] private DeviceConfiguration simulatedDevice;
        [SerializeField] private DeviceConfiguration defaultDevice;
        [SerializeField] private Dictionary<string, DeviceConfiguration> modelNameToDevices = new Dictionary<string, DeviceConfiguration>();

        public override DeviceConfiguration GetCurrentDevice() {
            if (simulatedDevice != null) {
                return simulatedDevice;
            }
            
            if (modelNameToDevices.ContainsKey(SystemInfo.deviceModel)) {
                return modelNameToDevices[SystemInfo.deviceModel];
            }

            return defaultDevice;
        }
    }
}