using UnityEditor;
using UnityEngine;

namespace TinyMatter.CardClash.Core {
    
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : Editor {
        
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            var e = target as GameEvent;
            if (GUILayout.Button("Raise")) {
                e?.Raise();
            }
            
        }
        
    }

}