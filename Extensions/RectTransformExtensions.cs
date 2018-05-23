using UnityEngine;

namespace TinyMatter.Core.Extensions {
    
    public static class RectTransformExtensions {
        
        public static Vector3 WorldCenterPosition(this RectTransform _rectTransform) {
            var corners = new Vector3[4];
            _rectTransform.GetWorldCorners(corners);
            
            return (corners[0] + corners[2]) / 2f;
        }

        public static Vector3 WorldSize(this RectTransform _rectTransform) {
            var corners = new Vector3[4];
            _rectTransform.GetWorldCorners(corners);
            var height = corners[1].y - corners[0].y;
            var width = corners[2].x - corners[1].x;
            
            return new Vector3(width, height, 1f);
        }
        
    }
    
}