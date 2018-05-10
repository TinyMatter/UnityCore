using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TinyMatter.CardClash.Game {
    public abstract class DeviceConfigurator : SerializedScriptableObject {
        public abstract DeviceConfiguration GetCurrentDevice();
    }
}