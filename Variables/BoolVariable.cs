using UnityEngine;

namespace TinyMatter.Core {

    [CreateAssetMenu(menuName = "Variables/Bool")]
    public class BoolVariable : BaseVariable<bool> {
        [SerializeField] public bool persistValue;

        protected override void ValueChanged() {
            if (persistValue) {
                PlayerPrefs.SetInt(name, Value ? 1 : 0);
            }
        }
    }
}

