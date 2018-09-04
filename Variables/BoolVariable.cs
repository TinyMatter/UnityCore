using UnityEngine;

namespace TinyMatter.Core {

    [CreateAssetMenu(menuName = "Variables/Bool")]
    public class BoolVariable : BaseVariable<bool> {
        [SerializeField] private bool persistValue;

        protected override void ValueChanged() {
            if (persistValue) {
                PlayerPrefs.SetInt(name, Value ? 1 : 0);
            }
        }

        public override void Reset() {
            if (persistValue) {
                _value = PlayerPrefs.GetInt(name) == 1;
            }
            else {
                base.Reset();
            }
        }
    }
}

