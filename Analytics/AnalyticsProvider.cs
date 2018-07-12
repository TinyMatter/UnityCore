using UnityEngine;

namespace TinyMatter.Core.Analytics {
    public abstract class AnalyticsProvider : ScriptableObject, IAnalyticsProvider {
        public abstract void SubmitEvent(string name, AnalyticsParameter[] parameters);
    }
}