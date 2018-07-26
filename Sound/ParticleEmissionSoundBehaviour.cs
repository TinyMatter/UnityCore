using TinyMatter.Core.Sound;
using UnityEngine;

namespace TinyMatter.GetFact.Game {
    
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticleEmissionSoundBehaviour : MonoBehaviour {

        private new ParticleSystem particleSystem;
        private int aliveParticles;

        [SerializeField] private SoundEffect birthSoundEffect;
        [SerializeField] private SoundEffect deathSoundEffect;

        private void Awake() {
            particleSystem = GetComponent<ParticleSystem>();
        }

        private void Update() {
            var count = particleSystem.particleCount;
            if (count == aliveParticles) {
                return;
            }

            if (count > aliveParticles) {
                if (birthSoundEffect != null) {
                    birthSoundEffect.PlayOnObject(gameObject);
                }
            }
            else {
                if (deathSoundEffect != null) {
                    deathSoundEffect.PlayOnObject(gameObject);
                }
            }

            aliveParticles = count;
        }
        
    }
}