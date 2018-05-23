using UnityEngine;

namespace TinyMatter.Core.Extensions {
    
    public static class ColorExtensions {

        public static Color CopyWithAlpha(this Color color, float alpha) {
            color.a = alpha;
            return color;
        }
        
    }
}