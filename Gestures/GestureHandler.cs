using DigitalRubyShared;
using UnityEngine;

namespace TinyMatter.CardClash.Gameplay {
    public abstract class GestureHandler : MonoBehaviour {

        protected abstract GestureRecognizer GetRecognizer();
        
        public System.Action<RaycastHit, GestureRecognizerState> hitHandler;

        public void RequireGestureHandlerToFail(GestureHandler otherHandler) {
            this.GetRecognizer().AddRequiredGestureRecognizerToFail(otherHandler.GetRecognizer());
        }
    }
}