using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyMatter.CardClash.Core {
    public abstract class RuntimeDictionary<TKey, TValue> : ScriptableObject
    {
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
    }
}