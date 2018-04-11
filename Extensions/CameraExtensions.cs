using UnityEngine;


namespace TinyMatter.Extensions {
    
    public static class CameraExtensions {
    
        /// <summary>
        /// Returns the camera distance for a desired frustrum height
        /// </summary>
        /// <returns>The distance from camera</returns>
        /// <param name="camera">Camera.</param>
        /// <param name="frustumHeight">Frustum height.</param>
        public static float DistanceForFrustrumHeight(this Camera camera, float frustumHeight) {
            return frustumHeight * 0.5f / Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        }
    
        /// <summary>
        /// Returns the camera distance for a desired frustrum width
        /// </summary>
        /// <returns>The distance from camera</returns>
        /// <param name="camera">Camera.</param>
        /// <param name="frustumWidth">Frustum width.</param>
        public static float DistanceForFrustrumWidth(Camera camera, float frustumWidth) {
            var frustumHeight = frustumWidth / camera.aspect;
            return camera.DistanceForFrustrumHeight(frustumHeight);
        }
    
    
        /// <summary>
        /// Returns the frustrum height for a camera distance
        /// </summary>
        /// <returns>The frustum height from a camera distance.</returns>
        /// <param name="camera">Camera.</param>
        /// <param name="distance">Distance.</param>
        public static float FrustumHeightForDistance(this Camera camera, float distance) {
            return 2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        }
    
    
        /// <summary>
        /// Returns the frustrum width for a camera distance
        /// </summary>
        /// <returns>The frustum width from a camera distance.</returns>
        /// <param name="camera">Camera.</param>
        /// <param name="distance">Distance.</param>
        public static float FrustumWidthForDistance(this Camera camera, float distance) {
            var frustumHeight = camera.FrustumHeightForDistance(distance);
            return frustumHeight * camera.aspect;
        }
    }
    
}
