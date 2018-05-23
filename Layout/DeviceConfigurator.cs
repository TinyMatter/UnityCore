using Sirenix.OdinInspector;

namespace TinyMatter.Core.Layout {
    public abstract class DeviceConfigurator : SerializedScriptableObject {
        public abstract DeviceConfiguration GetCurrentDevice();
    }
}