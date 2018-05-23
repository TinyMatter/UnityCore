using UnityEngine;

namespace TinyMatter.Core {
    [CreateAssetMenu(menuName = "Animation/Curve")]
    public class AnimationSettingCurve : ScriptableObject {
        public AnimationCurve curve;
    }
}