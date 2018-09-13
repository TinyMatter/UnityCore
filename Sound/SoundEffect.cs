using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;

namespace TinyMatter.Core.Sound {

    [CreateAssetMenu(menuName = "Sounds/Effect")]
    public class SoundEffect : ScriptableObject {
        [CanBeNull] public AudioClip audioClip;

        [Range(0f, 1f)]
        [SerializeField]
        protected float volume = 1f;
        [Range(0f, 1f)]
        [SerializeField]
        protected float volumeVariance = 0f;

        protected float startVolume = 0f;

        [Range(.1f, 3f)]
        [SerializeField]
        protected float pitch = 1f;
        [Range(0f, 1f)]
        [SerializeField]
        protected float pitchVariance = 0f;

        protected float startPitch = 1f;

        [Range(0f, 2f)]
        [SerializeField]
        protected float delay = 0f;
        [Range(0f, 1f)]
        [SerializeField] private float delayVariance = 0f;

        protected float playDelay;

        [SerializeField] protected AudioMixerGroup mixerGroup;

        [SerializeField] protected bool hapticFeedback;

        [SerializeField]
        [ShowIf("hapticFeedback")]
        protected iOSHapticFeedback.iOSFeedbackType hapticFeedbackType;


        [UsedImplicitly]
        public void Play() {
            PlayOnObject(soundEffectController.gameObject);
        }

        [UsedImplicitly]
        public void PlayOnObject(GameObject gameObject) {
            PrepareAudioSourceForPlayingOnGameObject(gameObject, PlayOneShotOnAudioSource);
        }

        public void PlayOnObjectWithRisingIndexPitch(GameObject gameObject, int index) {
            PrepareAudioSourceForPlayingOnGameObject(gameObject, source => {
                startVolume = volume * (1f + Random.Range(-volumeVariance / 2f, volumeVariance / 2f));
                source.volume = startVolume;

                source.pitch = pitch + (pitchVariance * index);

                source.PlayOneShot(audioClip);

                PlayHapticFeedback();
            });
        }

        private SoundEffectController _soundEffectController;

        private SoundEffectController soundEffectController {
            get {
                if (_soundEffectController != null) {
                    return _soundEffectController;
                }

                return _soundEffectController = FindObjectOfType<SoundEffectController>();
            }
        }

        private void PrepareAudioSourceForPlayingOnGameObject(GameObject gameObject, System.Action<AudioSource> callback) {
            var audioSourceComponent = gameObject.GetComponent<AudioSource>();

            if (audioSourceComponent == null) {
                audioSourceComponent = gameObject.AddComponent<AudioSource>();
                audioSourceComponent.outputAudioMixerGroup = mixerGroup;
            }

            var waitForComponent = gameObject.GetComponent<WaitForBehavior>();

            if (waitForComponent == null) {
                waitForComponent = gameObject.AddComponent<WaitForBehavior>();
            }

            playDelay = Mathf.Max((delay * Random.Range(-pitchVariance / 2f, pitchVariance / 2f)), 0);

            if (playDelay > 0f) {
                waitForComponent.WaitFor(playDelay, () => { callback.Invoke(audioSourceComponent); });
            }
            else {
                callback.Invoke(audioSourceComponent);
            }
        }

        protected void PlayOneShotOnAudioSource(AudioSource source) {
            startVolume = volume * (1f + Random.Range(-volumeVariance / 2f, volumeVariance / 2f));
            source.volume = startVolume;

            startPitch = pitch * (1f + Random.Range(-pitchVariance / 2f, pitchVariance / 2f));
            source.pitch = startPitch;

            source.PlayOneShot(audioClip);

            PlayHapticFeedback();
        }

        protected void PlayHapticFeedback() {
            if (hapticFeedback) {
                iOSHapticFeedback.Instance.Trigger(hapticFeedbackType);
            }
        }
    }

}