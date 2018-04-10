using DigitalRubyShared;
using UnityEngine;

namespace TinyMatter.CardClash.Gameplay {
    public class TapGestureHandler : GestureHandler {
        
        [SerializeField]
        private int numberOfTapsRequired = 1;
        
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
            gesture.StateUpdated += TapGesture_StateUpdated;
        }

        private void OnDestroy() {
            gesture.StateUpdated -= TapGesture_StateUpdated;
        }

        private void TapGesture_StateUpdated(GestureRecognizer gestureRecognizer) {
            Vector3 screenTouchPosition = new Vector3(gestureRecognizer.FocusX, gestureRecognizer.FocusY, 0f);
            Ray ray = Camera.main.ScreenPointToRay(screenTouchPosition);
    
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit)) {
                if (hitHandler != null) {
                    hitHandler.Invoke(hit, gestureRecognizer.State);   
                }
            }
        }
    }
}