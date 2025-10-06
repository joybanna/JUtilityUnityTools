#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using J_Tools;
using UnityEditor;
using UnityEngine;

namespace JEditor
{
    public class VersionControlEditor : EditorWindow
    {
        private static VersionControlEditor _instance;
        protected static Vector2 size = new(300f, 300f);
        private const string DATA_PATH = "VersionSetting";
        private VersionSetting _asset;
        private VersionBuild _versionBuild;
        private bool isText;

        [MenuItem("MyEditor/VersionSetting")]
        static void Init()
        {
            _instance = GetWindow<VersionControlEditor>(true, "--- VersionSetting ---", true);
            _instance.maxSize = size;
            _instance.minSize = size;
        }

        [Obsolete("Obsolete")]
        private void OnGUI()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            _asset = Resources.Load<VersionSetting>(DATA_PATH);

            if (ReferenceEquals(_asset, null))
            {
                JDebug.SetMessage($"VersionSetting Not found !! {DATA_PATH}");
                GUILayout.TextArea($"VersionSetting Not found !! {DATA_PATH}");
                if (GUILayout.Button("Create Version build setting"))
                {
                    _asset = CreateInstance<VersionSetting>();
                    _asset.SetVersion(VersionBuild.Internal);
                    _versionBuild = VersionBuild.Internal;
                    AssetDatabase.CreateAsset(_asset, "Assets/Resources/VersionSetting.asset");
                    AssetDatabase.SaveAssets();
                    EditorGUIUtility.PingObject(_asset);
                }
            }
            else
            {
                _versionBuild = _asset.VersionBuild;
                _versionBuild = (VersionBuild)UnityEditor.EditorGUILayout.EnumPopup("Version Build:", _versionBuild);
                _asset.SetVersion(_versionBuild);

                isText = GUILayout.Toggle(isText, "Is Show Text Version");
                _asset.SetTextShow(isText);
            }

            if (GUI.changed) EditorUtility.SetDirty(_asset);
            EditorGUILayout.EndVertical();
        }
    }
}
#endif