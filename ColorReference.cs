using UnityEngine;

namespace TinyMatter.CardClash.Core {
    
    [System.Serializable]
    public class ColorReference : BaseReference<ColorVariable, Color> {
        public ColorReference(Color value) : base(value) { }
    }
}