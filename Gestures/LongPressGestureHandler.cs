using DigitalRubyShared;
using UnityEngine;

namespace TinyMatter.CardClash.Gameplay {
    public class LongPressGestureHandler : GestureHandler {

        [SerializeField] private int minimumTouches = 1;
        [SerializeField] private float minimumDurationSeconds = 0.6f;
        [SerializeField] private float maximumMovementDistance = 0.35f;
        
        [SerializeField] private GestureHandler[] requiredToFail;
        
        private LongPressGestureRecognizer gesture = new LongPressGestureRecognizer();

        protected override GestureRecognizer GetRecognizer() {
            return gesture;
        }
        
        private void Start() {
            //add gesture
            gesture = new LongPressGestureRecognizer();
            FingersScript.Instance.AddGesture(gesture);
            
            gesture.AllowSimultaneousExecutionWithAllGestures();
            
            gesture.MinimumNumberOfTouchesToTrack = minimumTouches;
            gesture.MinimumDurationSeconds = minimumDurationSeconds;
            gesture.ThresholdUnits = maximumMovementDistance;
                        
            gesture.StateUpdated += LongPressGesture_StateUpdated;

            foreach (var gestureHandler in requiredToFail) {
                RequireGestureHandlerToFail(gestureHandler);
            }
        }

        private void OnDestroy() {
            gesture.StateUpdated -= LongPressGesture_StateUpdated;
        }

        private void LongPressGesture_StateUpdated(GestureRecognizer gestureRecognizer) {
            var screenTouchPosition = new Vector3(gestureRecognizer.FocusX, gestureRecognizer.FocusY, 0f);
            var ray = unityService.mainCamera.ScreenPointToRay(screenTouchPosition);
    
            RaycastHit hit;
            
            Physics.Raycast(ray, out hit);

            hitHandler?.Invoke(hit, gestureRecognizer.State);
        }
        
    }
}