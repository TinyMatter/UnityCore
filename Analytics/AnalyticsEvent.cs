using Sirenix.OdinInspector;
using TinyMatter.CardClash.Analytics;
using UnityEngine;

namespace TinyMatter.Core.Analytics {
    [CreateAssetMenu(menuName = "Analytics/Event")]
    public class AnalyticsEvent : ScriptableObject {
        #if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
        #endif
        
        [SerializeField] private AnalyticsProvider provider;
        [SerializeField] private AnalyticsParameter[] parameters;

        [Button, DisableInEditorMode]
        public void Trigger() {            
            provider.SubmitEvent(name, parameters);
        }
    }
}