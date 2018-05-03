using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TinyMatter.CardClash.Core {
    
    public abstract class BaseVariable<T> : BaseVariableBase, IBaseVariable<T>, ISerializationCallbackReceiver, IOnChangeTriggerable {
        [Multiline] [SerializeField] private string DeveloperDescription = "";
        
        [SerializeField] private T initialValue;

        [SerializeField] [DisplayAsString] private T _value;

        public T Value => _value;

        public void SetValue(T value) {
            var previousValue = _value;
            
            _value = value;

            if (!EqualityComparer<T>.Default.Equals(previousValue, value)) {
                Raise();
            }
        }

        public void SetValue(IBaseVariable<T> value) {
            SetValue(value as BaseVariable<T>);
        }

        public void SetValue(BaseVariable<T> value) {
            SetValue(value.Value);
        }

        private readonly List<Action> changeListeners = new List<Action>();

        public void RegisterChangeListener(Action listener) {
            if (!changeListeners.Contains(listener))
                changeListeners.Add(listener);
        }

        public void UnregisterChangeListener(Action listener) {
            if (changeListeners.Contains(listener))
                changeListeners.Remove(listener);
        }
        
        private void Raise() {
            for (var i = changeListeners.Count - 1; i >= 0; i--)
                changeListeners[i].Invoke();
        }

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize() {
            //reset value
            Reset();
        }

        public override void Reset() {
            _value = initialValue;
        }
    }
    
}