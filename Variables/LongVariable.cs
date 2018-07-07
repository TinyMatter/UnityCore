using UnityEngine;

namespace TinyMatter.Core {
    [CreateAssetMenu(menuName = "Variables/Long")]
    public class LongVariable : BaseVariable<long> {
        public override void UpdateFromRemote() {
            var remoteValue = RemoteSettings.GetLong(keyName, Value);
            
            initialValue = remoteValue;
        }
    }
}