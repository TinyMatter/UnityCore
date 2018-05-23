using JetBrains.Annotations;
using UnityEngine;

namespace TinyMatter.Core {
    public class SelfDestructableBehavior : MonoBehaviour {
        [UsedImplicitly]
        public void SelfDestruct() {
            Destroy(gameObject);
        }
    }
}