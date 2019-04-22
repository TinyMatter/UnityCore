using System.Collections.Generic;
using RestSharp.Serializers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TinyMatter.Core.Layout {
    [CreateAssetMenu(menuName = "Device Configuration/iOS Configurator")]
    public class IOSDeviceConfigurator : DeviceConfigurator, ISerializationCallbackReceiver {
        [SerializeField] private DeviceConfiguration simulatedDevice;
        [SerializeField] private DeviceConfiguration defaultDevice;
        [ShowInInspector] private Dictionary<string, DeviceConfiguration> modelNameToDevices = new Dictionary<string, DeviceConfiguration>();

        [SerializeField, HideInInspector] private List<string> modelNameToDevicesKeys = new List<string>();
        [SerializeField, HideInInspector] private List<DeviceConfiguration> modelNameToDevicesValues = new List<DeviceConfiguration>();
        
        public override DeviceConfiguration GetCurrentDevice() {
            if (simulatedDevice != null) {
                return simulatedDevice;
            }
            
            if (modelNameToDevices.ContainsKey(SystemInfo.deviceModel)) {
                return modelNameToDevices[SystemInfo.deviceModel];
            }

            return defaultDevice;
        }

        public void OnBeforeSerialize() {
            modelNameToDevicesKeys.Clear();
            modelNameToDevicesValues.Clear();
            foreach (var valuePair in modelNameToDevices) {
                modelNameToDevicesKeys.Add(valuePair.Key);
                modelNameToDevicesValues.Add(valuePair.Value);
            }
        }

        public void OnAfterDeserialize() {
            modelNameToDevices = new Dictionary<string, DeviceConfiguration>();
            for (var i = 0; i != Mathf.Min(modelNameToDevicesKeys.Count, modelNameToDevicesValues.Count); i++) {
                modelNameToDevices.Add(modelNameToDevicesKeys[i], modelNameToDevicesValues[i]);
            }
        }
    }
}