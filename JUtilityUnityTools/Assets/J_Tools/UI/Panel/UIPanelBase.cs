using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class UIPanelBase<T> : SerializedMonoBehaviour, IPanel
{
    public RectTransform MyPanel => myPanel;
    [SerializeField] protected RectTransform myPanel;
    protected IUIPanelCtrl myCtrl;

    protected abstract void Awake();
    public abstract T Init(IUIPanelCtrl ctrl);


    public virtual void OpenPanel()
    {
        DisplayAnimation(true, myPanel.gameObject, 0.15f);
        myCtrl.OnPanelOpen(this);
        // if (SoundControl.Instance) SoundControl.Instance.PlayOpenPopupSound();
    }

    public virtual void ClosePanel()
    {
        DisplayAnimation(false, myPanel.gameObject, 0.1f);
        myCtrl.OnPanelClose(this);
        // if (SoundControl.Instance) SoundControl.Instance.PlayClosePopupSound();
    }

    public virtual void RegisterPanel()
    {
        myCtrl.RegisterPanel(this);
    }

    private readonly Vector3 _less = Vector3.one * 0.6f;
    private Vector3 _popScale;

    public Sequence DisplayAnimation(bool isActive, GameObject targetObj, float duration, bool isCheckActive = false)
    {
        if (isActive)
        {
            if (targetObj.activeSelf && isCheckActive)
            {
                return null;
            }
            else
            {
                var originalScale = targetObj.transform.localScale;
                _popScale = originalScale * 1.05f;
                targetObj.transform.localScale = _less;
                targetObj.SetActive(true);

                var sq = DOTween.Sequence();
                sq.Append(targetObj.transform.DOScale(_popScale, duration));
                sq.Append(targetObj.transform.DOScale(originalScale, 0.2f));
                sq.OnComplete(() => { targetObj.transform.localScale = originalScale; });
                return sq;
            }
        }
        else
        {
            var originalScale = targetObj.transform.localScale;
            targetObj.transform.DOScale(0.6f, duration).SetEase(Ease.Linear).OnComplete(() =>
            {
                targetObj.SetActive(false);
                targetObj.transform.localScale = originalScale;
            });
            return null;
        }
    }
}

public abstract class UIPanelBaseWithBackPlate<T> : UIPanelBase<T>
{
    [SerializeField] protected RectTransform backPlate;
    private Transform originalParent;

    protected override void Awake()
    {
        backPlate.localScale = Vector3.one * 5;
        originalParent = backPlate.transform.parent;
    }

    public override void OpenPanel()
    {
        myCtrl.SetBackplate(backPlate, originalParent, true);
        base.OpenPanel();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
        // Debug.Log("originalParent: " + originalParent.name);
        myCtrl.SetBackplate(backPlate, originalParent, false);
    }
}