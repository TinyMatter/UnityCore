using DG.Tweening;

namespace TinyMatter.CardClash.Core {
    public interface ISequenceable {
        ISequenceable AppendCallback(TweenCallback callback);
        ISequenceable AppendInterval(float interval);
        ISequenceable PrependCallback(TweenCallback callback);
        ISequenceable InsertCallback(float atPosition, TweenCallback callback);
        ISequenceable OnComplete(TweenCallback action);
        ISequenceable Append(Tween t);
    }
}