using System.Collections.Generic;
using UnityEngine;

namespace TinyMatter.Core {
    public abstract class RuntimeSetBase : ScriptableObject, IRuntimeSet {
        public abstract int Count { get; }
        public abstract void Clear();
    }

    public interface IRuntimeSet {
        int Count { get; }
        void Clear();
    }

    public interface IRuntimeSet<T> : IRuntimeSet {
        T this[int i] { get; }

        int IndexOf(T thing);
        void Add(T thing);
        void Remove(T thing);

        IEnumerator<T> GetEnumerator();
    }
}