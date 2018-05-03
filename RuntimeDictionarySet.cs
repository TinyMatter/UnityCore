using System.Collections.Generic;
using UnityEngine;

namespace TinyMatter.CardClash.Core {
    [CreateAssetMenu(menuName = "Runtime Dict/Set of Dictionaries")]
    public class RuntimeDictionarySet : ScriptableObject {
        [SerializeField] private RuntimeDictionaryBase[] dictionaries;

        public IEnumerator<RuntimeDictionaryBase> GetEnumerator() {
            return ((IEnumerable<RuntimeDictionaryBase>) dictionaries).GetEnumerator();
        }

        public void Reset() {
            foreach (var dictionary in this) {
                dictionary.Clear();
            }
        }
    }
}