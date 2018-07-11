using UnityEngine;

namespace TinyMatter.Core.Analytics {
    public abstract class AnalyticsParameter : ScriptableObject {
        #if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
        #endif
        
        public abstract object GetValue();
    }
}