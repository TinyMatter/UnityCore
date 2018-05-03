using JetBrains.Annotations;
using UnityEngine;

namespace TinyMatter.CardClash.Core {
    public class SelfDestructableBehavior : MonoBehaviour {
        [UsedImplicitly]
        public void SelfDestruct() {
            Destroy(gameObject);
        }
    }
}