using UnityEngine.UI;

namespace TinyMatter.CardClash.Game {
    public class ConfigurableCanvasScaler : CanvasScaler {
        public void Configure(DeviceConfiguration deviceConfiguration) {
            matchWidthOrHeight = deviceConfiguration.match;
            referenceResolution = deviceConfiguration.referenceResolution;
            
            Handle();
        }
    }
}