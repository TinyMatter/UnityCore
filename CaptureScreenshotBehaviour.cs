using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TinyMatter.CardClash.Core {
    
    public class CaptureScreenshotBehaviour : MonoBehaviour {

        [SerializeField] private string path = "~/Desktop/";

        [Button("Take screenshot")]
        private void TakeScreenshot() {

            var currentDateTime = DateTime.Now.ToString("u");
            
            ScreenCapture.CaptureScreenshot($"{path}{Application.productName}-{currentDateTime}.png");
        }
        
    }
    
}