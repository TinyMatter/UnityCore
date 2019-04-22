using Sirenix.OdinInspector;
using UnityEngine;

namespace TinyMatter.Core.Layout {
    public abstract class DeviceConfigurator : ScriptableObject {
        public abstract DeviceConfiguration GetCurrentDevice();
    }
}