using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TinyMatter.CardClash.Core {
	
    public abstract class VariableChangedListener<TVariable, TEvent> : MonoBehaviour where TVariable : IOnChangeTriggerable where TEvent : UnityEvent<TVariable> {
        [Tooltip("Variable to listen to change events on.")]
        public TVariable Variable;

        [Tooltip("Response to invoke when Event is raised.")]
        public TEvent Response;

        private void OnEnable() {
            Variable.RegisterChangeListener(OnChange);
        }

        private void OnDisable() {
            Variable.UnregisterChangeListener(OnChange);
        }

        private void OnChange() {
            Response.Invoke(Variable);
        }
    }

    public interface IOnChangeTriggerable {
        void RegisterChangeListener(System.Action action);
        void UnregisterChangeListener(System.Action action);
    }
}