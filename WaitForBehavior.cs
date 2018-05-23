using System.Collections;
using UnityEngine;

namespace TinyMatter.Core {
    public class WaitForBehavior : MonoBehaviour {
        public void WaitFor(float seconds, System.Action completion) {
            StartCoroutine(WaitForCoroutine(seconds, completion));
        }

        private IEnumerator WaitForCoroutine(float seconds, System.Action completion) {
            yield return new WaitForSeconds(seconds);
            completion.Invoke();
        }
    }
}