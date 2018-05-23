using UnityEngine.Events;

namespace TinyMatter.Core.Events {
    [System.Serializable]
    public class IntChangedEvent : UnityEvent<IntVariable> {
    }
    
    public class IntVariableChangedListener : VariableChangedListener<IntVariable, IntChangedEvent> { }
}