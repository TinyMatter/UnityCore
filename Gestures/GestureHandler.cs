using DigitalRubyShared;
using TinyMatter.CardClash.Core;
using UnityEngine;

namespace TinyMatter.CardClash.Gameplay {
    public abstract class GestureHandler : MonoBehaviour {

        protected abstract GestureRecognizer GetRecognizer();
        
        public System.Action<RaycastHit, GestureRecognizerState> hitHandler;

        protected UnityService unityService;

        private void Awake() {
            unityService = UnityService.DefaultService();
        }

        public void RequireGestureHandlerToFail(GestureHandler otherHandler) {
            this.GetRecognizer().AddRequiredGestureRecognizerToFail(otherHandler.GetRecognizer());
        }
    }
}