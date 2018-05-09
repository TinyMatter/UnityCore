using DigitalRubyShared;
using UnityEngine;

namespace TinyMatter.CardClash.Gameplay {
    public class TapGestureHandler : GestureHandler {
        
        [SerializeField]
        private int numberOfTapsRequired = 1;

        [SerializeField] private bool immediatelySendBeganEvent = false;

        [SerializeField] private GestureHandler[] requiredToFail;
        
        private TapGestureRecognizer gesture = new TapGestureRecognizer();

        protected override GestureRecognizer GetRecognizer() {
            return gesture;
        }

        private void Start() {
            //add double tap gesture
            gesture = new TapGestureRecognizer();
            FingersScript.Instance.AddGesture(gesture);
            gesture.NumberOfTapsRequired = numberOfTapsRequired;
            gesture.AllowSimultaneousExecutionWithAllGestures();
            gesture.SendBeginState = immediatelySendBeganEvent;
            gesture.StateUpdated += TapGesture_StateUpdated;

            foreach (var gestureHandler in requiredToFail) {
                RequireGestureHandlerToFail(gestureHandler);
            }
        }

        private void OnDestroy() {
            gesture.StateUpdated -= TapGesture_StateUpdated;
        }

        private void TapGesture_StateUpdated(GestureRecognizer gestureRecognizer) {
            Vector3 screenTouchPosition = new Vector3(gestureRecognizer.FocusX, gestureRecognizer.FocusY, 0f);
            Ray ray = Camera.main.ScreenPointToRay(screenTouchPosition);
    
            RaycastHit hit;
            
            Physics.Raycast(ray, out hit);

            hitHandler?.Invoke(hit, gestureRecognizer.State);
        }
    }
}