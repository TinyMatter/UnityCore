using System.Collections.Generic;
using UnityEngine;

namespace TinyMatter.Core {
    [CreateAssetMenu(menuName = "Variables/Set of Variables")]
    public class VariableSet : ScriptableObject {
        [SerializeField] private BaseVariableBase[] variables;

        public IEnumerator<BaseVariableBase> GetEnumerator() {
            return ((IEnumerable<BaseVariableBase>) variables).GetEnumerator();
        }

        public void Reset() {
            foreach (var variable in this) {
                variable.Reset();
            }
        }
    }
}