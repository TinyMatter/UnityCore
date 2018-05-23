using DigitalRubyShared;
using UnityEngine;

namespace TinyMatter.Core.Gestures {
    
    public class PressGestureHandler : GestureHandler {
        
        [SerializeField] private int minimumTouches = 1;
        [SerializeField] private float maximumMovementDistance = 0.35f;
        
        [SerializeField] private GestureHandler[] requiredToFail;
        
        private PressGestureRecognizer gesture = new PressGestureRecognizer();

        protected override GestureRecognizer GetRecognizer() {
            return gesture;
        }
        
        private void Start() {
            //add gesture
            gesture = new PressGestureRecognizer();
            FingersScript.Instance.AddGesture(gesture);
            
            gesture.AllowSimultaneousExecutionWithAllGestures();
            
            gesture.MinimumNumberOfTouchesToTrack = minimumTouches;
            gesture.ThresholdUnits = maximumMovementDistance;
                        
            gesture.StateUpdated += PressGesture_StateUpdated;

            foreach (var gestureHandler in requiredToFail) {
                RequireGestureHandlerToFail(gestureHandler);
            }
        }

        private void OnDestroy() {
            gesture.StateUpdated -= PressGesture_StateUpdated;
        }

        private void PressGesture_StateUpdated(GestureRecognizer gestureRecognizer) {
            var screenTouchPosition = new Vector3(gestureRecognizer.FocusX, gestureRecognizer.FocusY, 0f);
            var ray = unityService.mainCamera.ScreenPointToRay(screenTouchPosition);
    
            RaycastHit hit;
            
            Physics.Raycast(ray, out hit);

            hitHandler?.Invoke(hit, gestureRecognizer.State);
        }
        
    }
}