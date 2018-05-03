using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyMatter.CardClash.Core {
    public abstract class RuntimeDictionary<TKey, TValue> : ScriptableObject
    {
        [SerializeField] [Multiline] private string DeveloperDescription = "";
        
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

        public void Clear() {
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
    }
}