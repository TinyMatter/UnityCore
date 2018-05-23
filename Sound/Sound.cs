using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Audio;

namespace TinyMatter.Core.Sound {
    
    [CreateAssetMenu(menuName = "Sounds/Track")]
    public class Sound : ScriptableObject {
        public AudioClip audioClip;
        
        [Range(0f, 1f)]
        [SerializeField] private float volume = 1f;
        [Range(0f, 1f)]
        [SerializeField] private float volumeVariance = 0f;

        private float startVolume = 0f; 

        [Range(.1f, 3f)]
        [SerializeField] private float pitch = 1f;
        [Range(0f, 1f)]
        [SerializeField] private float pitchVariance = 0f;

        private float startPitch = 1f;
        
        [SerializeField] private bool loop;

        [SerializeField] private bool playOnAwake;

        [SerializeField] private AudioMixerGroup mixerGroup;

        private AudioSource source;

        public void Init(GameObject gameObject) {
            source = gameObject.AddComponent<AudioSource>();
            source.clip = audioClip;
            source.loop = loop;
            source.playOnAwake = playOnAwake;
            source.outputAudioMixerGroup = mixerGroup;
        }
        
        [UsedImplicitly]
        public void Play() {
            //no source, can't play
            Assert.IsNotNull(source);
            
            startVolume = volume * (1f + Random.Range(-volumeVariance / 2f, volumeVariance / 2f));
            source.volume = startVolume;
            
            startPitch = pitch * (1f + Random.Range(-pitchVariance / 2f, pitchVariance / 2f));
            source.pitch = startPitch;

            source.Play();
        }

        public void Stop() {
            //no source, can't play
            Assert.IsNotNull(source);
            
            source.Stop();
        }

        public void Pause() {
            //no source, can't play
            Assert.IsNotNull(source);
            
            source.Pause();
        }

        public void AdjustVolume(float volumeScale) {
            source.volume = startVolume * volumeScale;
        }
        
    }
    
}