using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TinyMatter.CardClash.Core {
    
    public abstract class BaseVariable<T> : ScriptableObject, ISerializationCallbackReceiver, IOnChangeTriggerable {
        [SerializeField] [Multiline] private string DeveloperDescription = "";
        
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

        public void SetValue(BaseVariable<T> value) {
            SetValue(value.Value);
        }

        #region IOnChangeTriggerable methods

        private readonly List<Action> changeListeners = new List<Action>();

        public void RegisterChangeListener(Action listener) {
            if (!changeListeners.Contains(listener))
                changeListeners.Add(listener);
        }

        public void UnregisterChangeListener(Action listener) {
            if (changeListeners.Contains(listener))
                changeListeners.Remove(listener);
        }        

        #endregion
        
        private void Raise() {
            for (var i = changeListeners.Count - 1; i >= 0; i--)
                changeListeners[i].Invoke();
        }
        
        
        #region serialisation

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize() {
            //reset value
            _value = initialValue;
        }
        
        #endregion
    }
    
}