using UnityEngine;

namespace TinyMatter.Core {
    
    [CreateAssetMenu(menuName = "Variables/Int")]
    public class IntVariable : BaseVariable<int> {
        public void Increment(int amount = 1) {
            SetValue(Value + amount);
        }

        public void Decrement(int amount = 1) {
            SetValue(Value - amount);
        }

        public void ApplyChange(int amount) {
            Increment(amount);
        }

        public void ApplyChange(IntVariable amount) {
            ApplyChange(amount.Value);
        }
    }
}

