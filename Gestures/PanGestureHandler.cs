using DigitalRubyShared;
using UnityEngine;

namespace TinyMatter.CardClash.Gameplay {

    public class PanGestureHandler : GestureHandler {
        
        [SerializeField]
        private int minimumNumberOfTouchesToTrack = 1;

        [SerializeField]
        private float thresholdUnits = 0.1f;

        private readonly PanGestureRecognizer gesture = new PanGestureRecognizer();

        private void Start() {
            FingersScript.Instance.AddGesture(gesture);
            gesture.MinimumNumberOfTouchesToTrack = minimumNumberOfTouchesToTrack;
            gesture.ThresholdUnits = thresholdUnits;
            gesture.AllowSimultaneousExecutionWithAllGestures();
            gesture.StateUpdated += PanGesture_StateUpdated;
        }

        private void OnDestroy() {
            gesture.StateUpdated -= PanGesture_StateUpdated;
        }

        private void PanGesture_StateUpdated(GestureRecognizer gestureRecognizer) {
            //get position in world space of touch
            Vector3 screenTouchPosition = new Vector3(gestureRecognizer.FocusX, gestureRecognizer.FocusY, 0f);
            Ray ray = Camera.main.ScreenPointToRay(screenTouchPosition);
            
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                hitHandler?.Invoke(hit, gestureRecognizer.State);
            }
        }

        protected override GestureRecognizer GetRecognizer() {
            return gesture;
        }
    }
}