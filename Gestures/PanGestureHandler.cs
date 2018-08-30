using System;
using System.Collections.Generic;
using DigitalRubyShared;
using UnityEngine;

namespace TinyMatter.Core.Gestures {

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

        [NonSerialized]
        public List<Vector3> registeredPoints = new List<Vector3>();

        private void PanGesture_StateUpdated(GestureRecognizer gestureRecognizer) {
            //get position in world space of touch
            var screenTouchPosition = new Vector3(gestureRecognizer.FocusX, gestureRecognizer.FocusY, 1f);
            var ray = unityService.mainCamera.ScreenPointToRay(screenTouchPosition);
            
            RaycastHit hit;

            Physics.Raycast(ray, out hit);

            #if UNITY_EDITOR
                if (hit.collider != null) {
                    switch (gestureRecognizer.State) {
                        case GestureRecognizerState.Possible:
                            break;
                        case GestureRecognizerState.Began:
                        case GestureRecognizerState.Executing:
                            registeredPoints.Add(hit.point);
                            break;
                        case GestureRecognizerState.Ended:
                            registeredPoints.Clear();
                            break;
                        case GestureRecognizerState.EndPending:
                            break;
                        case GestureRecognizerState.Failed:
                            registeredPoints.Clear();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            #endif


            hitHandler?.Invoke(hit, gestureRecognizer.State);
        }

        protected override GestureRecognizer GetRecognizer() {
            return gesture;
        }
    }
}