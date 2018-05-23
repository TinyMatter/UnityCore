using UnityEngine.Events;

namespace TinyMatter.Core.Events {
    [System.Serializable]
    public class BoolChangedEvent : UnityEvent<BoolVariable> {
    }
    
    public class BoolVariableChangedListener : VariableChangedListener<BoolVariable, BoolChangedEvent> { }
}