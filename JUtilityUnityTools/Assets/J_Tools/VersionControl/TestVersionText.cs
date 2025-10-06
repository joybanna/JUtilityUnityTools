using System;
using System.Collections;
using System.Collections.Generic;
using J_Tools;
using TMPro;
using UnityEngine;

public class TestVersionText : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText;

    private void Awake()
    {
        var old = FindObjectOfType<TestVersionText>();
        if (old != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void SetText(VersionBuild versionBuild)
    {
        tmpText.text = $"{versionBuild} ver.";
    }
}