using UnityEngine;

namespace TinyMatter.CardClash.Core {
    public class ColorReference : BaseReference<ColorVariable, Color> {
        public ColorReference(Color value) : base(value) { }
    }
}