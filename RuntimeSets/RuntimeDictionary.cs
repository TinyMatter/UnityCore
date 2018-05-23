using System.Collections.Generic;
using UnityEngine;

namespace TinyMatter.Core {
    public abstract class RuntimeDictionary<TKey, TValue> : RuntimeDictionaryBase, IRuntimeDictionary<TKey, TValue>
    {
        [Multiline] [SerializeField] private string DeveloperDescription = "";

        public Dictionary<TKey, TValue> items = new Dictionary<TKey, TValue>();

        public void Add(TKey key, TValue value)
        {
            if (!items.ContainsKey(key)) {
                items.Add(key, value);
            }
        }

        public void Remove(TKey key)
        {
            if (items.ContainsKey(key))
                items.Remove(key);
        }

        public override void Clear() {
            items.Clear();
        }
        
        public TValue this[TKey key] {
            get { return items[key]; }
            set { items[key] = value; } 
        }
        
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var pair in items) {
                yield return pair;
            }
        }

        public bool TryGetValue(TKey key, out TValue value) {
            return items.TryGetValue(key, out value);
        }

        public bool ContainsKey(TKey key) {
            return items.ContainsKey(key);
        }
        
        public bool ContainsValue(TValue value) {
            return items.ContainsValue(value);
        }

        public int Count => items.Count;
    }
}
