using TinyMatter.Core;
using UnityEditor;
using UnityEngine;

namespace TinyMatter.CardClash.Core {
    
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : UnityEditor.Editor {
        
        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            var e = target as GameEvent;

            if (GUILayout.Button("Raise")) {
                e?.Raise();
            }

            GUI.enabled = true;

            if (GUILayout.Button("Find Listeners")) {
                FindListenersInScene(e);
            }
            
        }

        private void FindListenersInScene(GameEvent gameEvent) {
            var gameEventListenerSets = FindObjectsOfType<GameEventListenerSet>();

            foreach (var listenerSet in gameEventListenerSets) {
                foreach (var eventListener in listenerSet.eventListeners) {
                    if (eventListener.Event == gameEvent) {
                        Debug.Log($"{gameEvent.name} has a listener on {listenerSet.gameObject}");
                    }
                }
            }
        }
    }

}