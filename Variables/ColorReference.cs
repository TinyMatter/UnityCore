using UnityEngine;

namespace TinyMatter.Core {
    
    [System.Serializable]
    public class ColorReference : BaseReference<ColorVariable, Color> {
        public ColorReference(Color value) : base(value) { }
    }
}