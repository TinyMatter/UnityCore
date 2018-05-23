using System.Collections.Generic;
using UnityEngine;

namespace TinyMatter.Core {
    public abstract class RuntimeDictionaryBase : ScriptableObject, IRuntimeDictionary {
        public abstract void Clear();
    }

    public interface IRuntimeDictionary {
        void Clear();
    }

    public interface IRuntimeDictionary<TKey, TValue> : IRuntimeDictionary {
        void Add(TKey key, TValue value);
        void Remove(TKey key);
        bool ContainsKey(TKey key);
        IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
        bool TryGetValue(TKey key, out TValue value);
        int Count { get; }

        TValue this[TKey key] { get; set; }
    }
}