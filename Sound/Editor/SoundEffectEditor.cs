using TinyMatter.Core.Sound;
using UnityEditor;
using UnityEngine;

namespace TinyMatter.CardClash.Game {

    [CustomEditor(typeof(SoundEffect))]
    public class SoundEffectEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            var e = target as SoundEffect;

            if (GUILayout.Button("Play")) {
                if (e != null) e.Play();
            }
        }
    }

}
