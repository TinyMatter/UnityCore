using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyMatter.CardClash.Core {
    public abstract class RuntimeSet<T> : ScriptableObject, IOnChangeTriggerable
    {
        public List<T> items = new List<T>();
        
        public int Count => items.Count;
        
        public int IndexOf(T thing) {
            return items.IndexOf(thing);
        }

        public void Add(T thing)
        {
            if (!items.Contains(thing)) {
                items.Add(thing);
                Raise();
            }
                
        }

        public void Remove(T thing)
        {
            if (items.Contains(thing)) {
                items.Remove(thing);
                Raise();
            }
        }
        
        public void Clear() {
           items.Clear();
           Raise();
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
                yield return item;
        }
        
        public T this[int i] => items[i];

        private readonly List<Action> changeListeners = new List<Action>();

        public void RegisterChangeListener(Action listener) {
            if (!changeListeners.Contains(listener))
                changeListeners.Add(listener);
        }

        public void UnregisterChangeListener(Action listener) {
            if (changeListeners.Contains(listener))
                changeListeners.Remove(listener);
        }
        
        public void Raise() {
            for (int i = changeListeners.Count - 1; i >= 0; i--)
                changeListeners[i].Invoke();
        }
    }
}