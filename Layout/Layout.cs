using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace TinyMatter.Core.Layout {
    public class Layout : MonoBehaviour {
        [BoxGroup("Events")]
        [SerializeField]
        private GameEvent layoutReadyEvent;

        [SerializeField] private RectTransform mainGroupTransform;
        [SerializeField] private DeviceConfigurator deviceConfigurator;
        [SerializeField] private ConfigurableCanvasScaler canvasScaler;

        [SerializeField] private Image mainBackgroundImage;
        [SerializeField] private Image headerBackgroundImage;

        private void Awake() {
            var device = deviceConfigurator.GetCurrentDevice();

            Debug.Log($"=== Configuring layout for {device.deviceName}");

            mainGroupTransform.offsetMin = new Vector2(mainGroupTransform.offsetMin.x, device.bottomInset);
            mainGroupTransform.offsetMax = new Vector2(mainGroupTransform.offsetMax.x, -device.topInset);

            canvasScaler.Configure(device);
        }

        public void Prepare() {
            Canvas.ForceUpdateCanvases();
        }

        public void PrepareForLevel(Level level) {
            if (level.world == null) {
                return;
            }

            mainBackgroundImage.sprite = level.world.mainBackground;
            headerBackgroundImage.sprite = level.world.headerBackground;
        }
    }
}
