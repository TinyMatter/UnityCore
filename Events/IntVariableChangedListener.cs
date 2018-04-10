using UnityEngine.Events;

namespace TinyMatter.CardClash.Core {
    [System.Serializable]
    public class IntChangedEvent : UnityEvent<IntVariable> {
    }
    
    public class IntVariableChangedListener : VariableChangedListener<IntVariable, IntChangedEvent> { }
}