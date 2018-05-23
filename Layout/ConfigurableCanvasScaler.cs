using UnityEngine.UI;

namespace TinyMatter.Core.Layout {
    public class ConfigurableCanvasScaler : CanvasScaler {
        public void Configure(DeviceConfiguration deviceConfiguration) {
            matchWidthOrHeight = deviceConfiguration.match;
            referenceResolution = deviceConfiguration.referenceResolution;
            
            Handle();
        }
    }
}