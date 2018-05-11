﻿using DG.Tweening;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using TinyMatter.CardClash.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace TinyMatter.Core.UI {
    
    public class IntVariableTMPLabel : MonoBehaviour {
        [InfoBox("Leave blank if on this GameObject")]
        [SerializeField] private TMP_Text label;
        
        [SerializeField] private string stringFormat = "{0:n0}";

        [SerializeField] private IntReference initialValue = new IntReference(0);

        [SerializeField] private AnimationSetting animationSetting;

        private int currentValue = 0;
        
        private void Awake() {
            if (label == null) {
                label = GetComponent<TMP_Text>();    
            }
            
            Assert.IsNotNull(label);
            
            UpdateLabel(initialValue.Value);
        }

        
        private void UpdateLabel(int value, bool animated = false) {
            if (animated) {
                //tween 
                DOTween.To(() => currentValue, val => {
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
            UpdateLabel(intVariable.Value);
        }
        
        [UsedImplicitly]
        public void AnimateLabel(IntVariable intVariable) {
            UpdateLabel(intVariable.Value, true);
        }
    }
    
}