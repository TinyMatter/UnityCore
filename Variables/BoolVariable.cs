using UnityEngine;

namespace TinyMatter.Core {

    [CreateAssetMenu(menuName = "Variables/Bool")]
    public class BoolVariable : BaseVariable<bool> {
        public override void UpdateFromRemote() {
            var remoteValue = RemoteSettings.GetBool(keyName, Value);
            
            initialValue = remoteValue;
        }
    }
}

