using UnityEngine;

namespace TinyMatter.Core {
    public class RuntimeVariablesResettingBehavior : MonoBehaviour {
        [SerializeField] private RuntimeSetSet setsToReset;
        [SerializeField] private RuntimeDictionarySet dictionariesToReset;
        [SerializeField] private VariableSet variablesToReset;

        private void OnDestroy() {
            if (setsToReset != null){
                setsToReset.Reset();    
            }

            if (dictionariesToReset != null) {
                dictionariesToReset.Reset();    
            }

            if (variablesToReset != null) {
                variablesToReset.Reset();    
            }            
        }
    }
}