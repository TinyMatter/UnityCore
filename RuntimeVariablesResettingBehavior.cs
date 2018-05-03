using UnityEngine;

namespace TinyMatter.CardClash.Core {
    public class RuntimeVariablesResettingBehavior : MonoBehaviour {
        [SerializeField] private RuntimeSetSet setsToReset;
        [SerializeField] private RuntimeDictionarySet dictionariesToReset;
        [SerializeField] private VariableSet variablesToReset;

        private void OnDestroy() {
            setsToReset.Reset();
            dictionariesToReset.Reset();
            variablesToReset.Reset();
        }
    }
}