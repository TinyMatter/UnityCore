namespace TinyMatter.Core.Analytics {
    public interface IAnalyticsProvider {
        void SubmitEvent(string name, AnalyticsParameter[] parameters);
    }
}