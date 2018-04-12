using UnityEngine;

namespace TinyMatter.Extensions {
    
    public static class ColorExtensions {

        public static Color CopyWithAlpha(this Color color, float alpha) {
            color.a = alpha;
            return color;
        }
        
    }
}