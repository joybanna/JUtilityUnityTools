using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace J_Tools
{
    [CreateAssetMenu(fileName = "VersionSetting", menuName = "ScriptableObjects/VersionSetting", order = 2)]
    public class VersionSetting : ScriptableObject
    {
        [SerializeField] private VersionBuild versionBuild;
        [SerializeField] private bool isText;
        public VersionBuild VersionBuild => versionBuild;
        public bool IsText => isText;


#if UNITY_EDITOR
        [Obsolete("Obsolete")]
        public void SetVersion(VersionBuild ver)
        {
            versionBuild = ver;
            SetDirty();
        }

        [Obsolete("Obsolete")]
        public void SetTextShow(bool isTextShow)
        {
            isText = isTextShow;
            SetDirty();
        }
#endif
    }

    public enum VersionBuild
    {
        Internal = 0,
        Production = 1,
    }
}