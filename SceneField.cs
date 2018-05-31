﻿using System;
using UnityEngine;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace TinyMatter.Core {
    //source https://answers.unity.com/questions/242794/inspector-field-for-scene-asset.html

    [System.Serializable]
    public class SceneField {
        [SerializeField] private Object sceneAsset;
        [SerializeField] private string scenePath;

        public string ScenePath {
            get { return scenePath; }
        }

        // makes it work with the existing Unity methods (LoadLevel/LoadScene)
        public static implicit operator string(SceneField sceneField) {
            return sceneField.ScenePath;
        }
    }

    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(SceneField))]
    public class SceneFieldPropertyDrawer : PropertyDrawer {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginProperty(position, GUIContent.none, property);
            var sceneAsset = property.FindPropertyRelative("sceneAsset");
            var sceneName = property.FindPropertyRelative("scenePath");
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            if (sceneAsset != null) {
                EditorGUI.BeginChangeCheck();
                var value = EditorGUI.ObjectField(position, sceneAsset.objectReferenceValue, typeof(SceneAsset), false);
                if (EditorGUI.EndChangeCheck()) {
                    sceneAsset.objectReferenceValue = value;
                    if (sceneAsset.objectReferenceValue != null) {
                        var scenePath = AssetDatabase.GetAssetPath(sceneAsset.objectReferenceValue);
                        var assetsIndex = scenePath.IndexOf("Assets", StringComparison.Ordinal) + 7;
                        var extensionIndex = scenePath.LastIndexOf(".unity", StringComparison.Ordinal);
                        scenePath = scenePath.Substring(assetsIndex, extensionIndex - assetsIndex);
                        sceneName.stringValue = scenePath;
                    }
                }
            }

            EditorGUI.EndProperty();
        }
    }
    #endif
}