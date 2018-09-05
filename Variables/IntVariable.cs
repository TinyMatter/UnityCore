using Sirenix.OdinInspector;
using UnityEngine;

namespace TinyMatter.Core {
    
    [CreateAssetMenu(menuName = "Variables/Int")]
    public class IntVariable : BaseVariable<int> {
        [SerializeField] public bool persistValue;

        [Button]
        [ShowIf("persistValue")]
        public void ResetPersistentValue() {
            PlayerPrefs.DeleteKey(name);
        }
        
        protected override void ValueChanged() {
            if (persistValue) {
                PlayerPrefs.SetInt(name, Value);
            }
        }
        
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

