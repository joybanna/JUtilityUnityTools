using System.Collections;
using System.Collections.Generic;
using J_Tools;
using UnityEngine;

public class VersionControl : JSingleton<VersionControl>
{
    private const string DATA_PATH = "VersionSetting";
    private const string PREFAB_PATH = "VersionControl/TestVersionText";
    private readonly VersionSetting _asset;

    public VersionBuild CurrentBuild => _asset == null ? VersionBuild.Production : _asset.VersionBuild;

    public VersionControl()
    {
        _asset = Resources.Load<VersionSetting>(DATA_PATH);
        if (_asset.VersionBuild == VersionBuild.Production) return;
        if (!_asset.IsText) return;
        var prefab = Resources.Load<TestVersionText>(PREFAB_PATH);
        var t = Object.Instantiate(prefab);
        t.SetText(_asset.VersionBuild);
    }
}