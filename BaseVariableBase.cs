using UnityEngine;

namespace TinyMatter.CardClash.Core {
    public abstract class BaseVariableBase : ScriptableObject, IBaseVariable {
        public abstract void Reset();
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