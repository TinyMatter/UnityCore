﻿using Sirenix.OdinInspector;
using UnityEngine;

namespace TinyMatter.Core.Layout {
    [CreateAssetMenu(menuName = "Device Configuration/Device")]
    public class DeviceConfiguration : ScriptableObject {
        // Device Name
        public string deviceName;
        // Reference Resolution
        public Vector2 referenceResolution;

        public int frameRate = 60;
        // Width/Height Match
        [Range(0.0f, 1.0f)]
        [InfoBox("Corresponds to the Canvas Scaler's \"Match Width or Height\" ratio")]
        public float match = 0.5f;
        // UI Insets
        [FoldoutGroup("Insets")]
        public float bottomInset;
        
        [FoldoutGroup("Insets")]
        public float topInset;
    }
}