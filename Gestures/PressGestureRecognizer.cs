using DigitalRubyShared;

namespace TinyMatter.Core.Gestures {

    /// <summary>
    /// A press that can be an instant tap or a long press, as long as the touch doesn't move more than the threshold 
    /// </summary>
    public class PressGestureRecognizer : GestureRecognizer {

        /// <summary>
        /// How many units away the long press can move before failing. After the long press begins,
        /// it is allowed to move any distance and stay executing. Default is 0.35.
        /// </summary>
        /// <value>The threshold in units</value>
        public float ThresholdUnits { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        public PressGestureRecognizer() {
            ThresholdUnits = 0.35f;
        }

        protected override void TouchesBegan(System.Collections.Generic.IEnumerable<GestureTouch> touches) {
            CalculateFocus(CurrentTrackedTouches, true);

            if (TrackedTouchCountIsWithinRange) {
                SetState(GestureRecognizerState.Began);
            }
        }

        protected override void TouchesMoved() {
            CalculateFocus(CurrentTrackedTouches);

            if (State == GestureRecognizerState.Failed) {
                return;
            }

            if (!TrackedTouchCountIsWithinRange) {
                SetState(GestureRecognizerState.Failed);
                return;
            }

            if (State == GestureRecognizerState.Began || State == GestureRecognizerState.Executing) {
                SetState(GestureRecognizerState.Executing);
            }

            //check distance
            var distance = Distance(DistanceX, DistanceY);
            if (distance > ThresholdUnits) {
                SetState(GestureRecognizerState.Failed);
            }

        }

        protected override void TouchesEnded() {
            if (State == GestureRecognizerState.Began || State == GestureRecognizerState.Executing) {
                CalculateFocus(CurrentTrackedTouches);
                SetState(GestureRecognizerState.Ended);
            }
            else {
                CalculateFocus(CurrentTrackedTouches);
                SetState(GestureRecognizerState.Failed);
            }
        }
        
    }
}