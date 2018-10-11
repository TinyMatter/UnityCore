using DG.Tweening;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace TinyMatter.Core.UI {
    
    public class IntVariableTMPLabel : MonoBehaviour {
        [InfoBox("Leave blank if on this GameObject")]
        [SerializeField] private TMP_Text label;
        
        [SerializeField] private string stringFormat = "{0:n0}";

        [InfoBox("Use this if you want to adjust the number")] 
        [SerializeField] private int addToValue = 0;

        [SerializeField] private IntReference initialValue = new IntReference(0);
        [SerializeField] private bool animateToInitialValue = false;

        [SerializeField] private AnimationSetting animationSetting;

        private Tweener tween;

        private int currentValue = 0;
        
        private void Awake() {
            if (label == null) {
                label = GetComponent<TMP_Text>();    
            }
            
            Assert.IsNotNull(label);

            UpdateLabel(initialValue.Value + addToValue, animateToInitialValue);
        }
        
        private void UpdateLabel(int value, bool animated = false) {
            if (animated) {
                //tween 
                tween = DOTween.To(() => currentValue, val => {
                        currentValue = val;
                        label.text = string.Format(stringFormat, currentValue);
                    }, value, animationSetting.duration)
                    .SetSpeedBased(animationSetting.isSpeed)
                    .SetDelay(animationSetting.delay)
                    .SetEase(animationSetting);

                return;
            }
            
            //not animated
            currentValue = value;
            var text = string.Format(stringFormat, currentValue);
            label.text = text;
        }

        [UsedImplicitly]
        public void SetLabel(IntVariable intVariable) {
            SetLabel(intVariable.Value);
        }
        
        [UsedImplicitly]
        public void SetLabel(int value) {
            if (tween != null) {
                if (tween.IsPlaying()) {
                    tween.Kill();
                }    
            }
            
            UpdateLabel(value + addToValue);
        }
        
        [UsedImplicitly]
        public void AnimateLabel(IntVariable intVariable) {
            UpdateLabel(intVariable.Value + addToValue, true);
        }
    }
    
}