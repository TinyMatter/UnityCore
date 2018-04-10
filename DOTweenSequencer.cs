using DG.Tweening;

namespace TinyMatter.CardClash.Core {
    public class DOTweenSequencer : ISequenceable {
        private readonly Sequence sequence;

        public DOTweenSequencer(Sequence sequence) {
            this.sequence = sequence;
        }
        
        public DOTweenSequencer() {
            this.sequence = DOTween.Sequence();
        }
        
        public ISequenceable AppendCallback(TweenCallback callback) {
            return new DOTweenSequencer(sequence.AppendCallback(callback));
        }

        public ISequenceable AppendInterval(float interval) {
            return new DOTweenSequencer(sequence.AppendInterval(interval));
        }

        public ISequenceable PrependCallback(TweenCallback callback) {
            return new DOTweenSequencer(sequence.PrependCallback(callback));
        }

        public ISequenceable InsertCallback(float atPosition, TweenCallback callback) {
            return new DOTweenSequencer(sequence.InsertCallback(atPosition, callback));
        }

        public ISequenceable OnComplete(TweenCallback action) {
            return new DOTweenSequencer(sequence.OnComplete(action));
        }

        public ISequenceable Append(Tween t) {
            return new DOTweenSequencer(sequence.Append(t));
        }
    }
}