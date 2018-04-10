using UnityEngine.Events;

namespace TinyMatter.CardClash.Core {
    [System.Serializable]
    public class BoolChangedEvent : UnityEvent<BoolVariable> {
    }
    
    public class BoolVariableChangedListener : VariableChangedListener<BoolVariable, BoolChangedEvent> { }
}