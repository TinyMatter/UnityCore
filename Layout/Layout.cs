using UnityEngine;
using Sirenix.OdinInspector;
using TinyMatter.CardClash.Core;
using TinyMatter.CardClash.Game;
using UnityEngine.UI;

public class Layout : MonoBehaviour {
    [BoxGroup("Events")]
    [SerializeField]
    private GameEvent layoutReadyEvent;

    [SerializeField] private RectTransform mainGroupTransform;
    [SerializeField] private DeviceConfigurator deviceConfigurator;
    [SerializeField] private ConfigurableCanvasScaler canvasScaler;

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
}
