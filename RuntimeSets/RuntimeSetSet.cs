using System.Collections.Generic;
using UnityEngine;

namespace TinyMatter.Core {
    [CreateAssetMenu(menuName = "Runtime Set/Set of Sets")]
    public class RuntimeSetSet : ScriptableObject {
        [SerializeField] private RuntimeSetBase[] sets;

        public IEnumerator<RuntimeSetBase> GetEnumerator() {
            return ((IEnumerable<RuntimeSetBase>) sets).GetEnumerator();
        }

        public void Reset() {
            foreach (var set in this) {
                set.Clear();
            }
        }
    }
}