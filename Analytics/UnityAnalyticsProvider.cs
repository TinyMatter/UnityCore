using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TinyMatter.Core.Analytics {
    [CreateAssetMenu(menuName = "Analytics/Unity Provider")]
    public class UnityAnalyticsProvider : AnalyticsProvider {
        [SerializeField] private bool debugMode = true;
        
        private static Dictionary<string, Dictionary<string, object>> eventParamDictionaries = new Dictionary<string, Dictionary<string, object>>();
        
        public override void SubmitEvent(string eventName, AnalyticsParameter[] parameters) {
            if (!eventParamDictionaries.ContainsKey(eventName)) {
                eventParamDictionaries[eventName] = new Dictionary<string, object>();
            }

            foreach (var parameter in parameters) {
                eventParamDictionaries[eventName][parameter.name] = parameter.GetValue();
            }

            if (debugMode) {
                var paramsDebugString = string.Join(", ", eventParamDictionaries[eventName].Select(kvp => kvp.Key + ": " + kvp.Value.ToString()));
                
                Debug.Log($"--- Analytics Event '{eventName}' submitted with params: {paramsDebugString}");
            }

            #if !UNITY_EDITOR
            var result = UnityEngine.Analytics.Analytics.CustomEvent(eventName, eventParamDictionaries[eventName]);

            if (debugMode) {
                Debug.Log($"--- Analytics Event '{eventName}' custom event result: {result}");
            }
            #endif
        }
    }
}