using Sirenix.OdinInspector;
using UnityEngine;

namespace TinyMatter.Core {
    public abstract class BaseVariableBase : ScriptableObject, IBaseVariable {
        public abstract void Reset();
        
        [SerializeField] private bool remoteVariable;
        
        [SerializeField]
        [ShowIf("remoteVariable")]
        protected string keyName;

        public virtual void UpdateFromRemote() { }
    }

    public interface IBaseVariable {
        void Reset();
    }
    
    public interface IBaseVariable<T> : IBaseVariable {
        T Value { get; }
        void SetValue(T value);
        void SetValue(IBaseVariable<T> value);
    }
}