using Sirenix.OdinInspector;
using UnityEngine;

namespace TinyMatter.Core.Analytics {
    [CreateAssetMenu(menuName = "Analytics/Event")]
    public class AnalyticsEvent : ScriptableObject {
        #if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
        #endif
        
        [SerializeField] private AnalyticsProvider[] providers;
        [SerializeField] private AnalyticsParameter[] parameters;

        [Button, DisableInEditorMode]
        public void Trigger() {
            foreach (var provider in providers) {
                provider.SubmitEvent(name, parameters);
            }
        }
    }
}