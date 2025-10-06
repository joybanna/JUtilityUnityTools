using System;
using System.Collections;
using System.Collections.Generic;
using J_Tools;
using UnityEngine;

public class DisableOnProduction : MonoBehaviour
{
    private void OnEnable()
    {
        this.gameObject.SetActive(VersionControl.Instance.CurrentBuild == VersionBuild.Internal);
    }
}