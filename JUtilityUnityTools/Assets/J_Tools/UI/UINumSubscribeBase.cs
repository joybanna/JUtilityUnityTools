using System;
using Sirenix.OdinInspector;
using DG.Tweening;
using J_Tools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UINumSubscribeBase : SerializedMonoBehaviour
{
    [SerializeField] protected bool isTMP;
    [SerializeField, ShowIf("isTMP")] protected TMP_Text tmpText;

    [SerializeField] protected bool isNative;
    [SerializeField, ShowIf("isNative")] protected Text nText;

    protected long currentValue;
    protected abstract long OriginalSource { get; }

    protected abstract void OnEnable();

    protected abstract void OnDisable();

    protected virtual void OnUpdate()
    {
        var c = OriginalSource;
        if (currentValue != c)
        {
            DOTween.To(() => currentValue, x => currentValue = x, c, 0.5f)
                .OnUpdate(() =>
                {
                    TextDisplay = isDontShowSIPrefix
                        ? currentValue.ToString("###,###")
                        : currentValue.GetPrefixSI();
                })
                .OnComplete(() => { currentValue = c; });
        }
        else
        {
            TextDisplay = isDontShowSIPrefix
                ? currentValue.ToString("###,###")
                : currentValue.GetPrefixSI();
        }
    }

    protected string TextDisplay
    {
        set
        {
            if (isTMP && tmpText) tmpText.text = value;
            if (isNative && nText) nText.text = value;
        }
    }

    [Button, ButtonGroup]
    private void FindTMPText()
    {
        var isFind = this.TryGetComponent<TMP_Text>(out var t);
        if (!isFind)
        {
            JDebug.SetMessage("Can't find tmp text");
            isTMP = false;
        }
        else
        {
            isTMP = true;
            tmpText = t;
        }
    }

    [Button, ButtonGroup]
    private void FindNativeText()
    {
        var isFind = this.TryGetComponent<Text>(out var t);
        if (!isFind)
        {
            JDebug.SetMessage("Can't find native text");
            isNative = false;
        }
        else
        {
            isNative = true;
            nText = t;
        }
    }

    [Button(ButtonSizes.Large), GUIColor(0, 0.5f, 0)]
    private void AutoFindText()
    {
        FindTMPText();
        FindNativeText();
    }

    [SerializeField] private bool isDontShowSIPrefix;
}