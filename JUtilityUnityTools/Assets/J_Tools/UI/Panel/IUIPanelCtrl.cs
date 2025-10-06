using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using J_Tools;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UIElements;

public interface IUIPanelCtrl
{
    public List<IPanel> AllPanel { get; set; }
    public List<IPanel> OpeningPanel { get; set; }

    public void RegisterPanel<T>(UIPanelBase<T> panel);
    public void OnPanelOpen<T>(UIPanelBase<T> panel);
    public void OnPanelClose<T>(UIPanelBase<T> panel);

    public RectTransform BackplateGroup { get; }

    public void SetBackplate(RectTransform backplate, Transform oldParent, bool isOpen)
    {
        backplate.transform.SetParent(isOpen ? BackplateGroup : oldParent);
        // backplate.gameObject.SetActive(isOpen);
        DisplayFade(isOpen, backplate.gameObject, 0.15f);
    }
    
    public void DisplayFade(bool isActive, GameObject targetObj, float duration)
    {
        if (!targetObj.TryGetComponent<CanvasGroup>(out var canvasGroup))
        {
            canvasGroup = targetObj.AddComponent<CanvasGroup>();
        }

        if (isActive)
        {
            canvasGroup.alpha = 0;
            targetObj.SetActive(true);
            canvasGroup.DOFade(1, duration);
        }
        else
        {
            canvasGroup.DOFade(0, duration).OnComplete(() => { targetObj.SetActive(false); });
        }
    }
}

public class UIPanelCtrlBase : SerializedMonoBehaviour, IUIPanelCtrl
{
    public List<IPanel> AllPanel { get; set; }
    public List<IPanel> OpeningPanel { get; set; }
    public RectTransform BackplateGroup => backplateGroup;
    [SerializeField] private RectTransform backplateGroup;

    public void RegisterPanel<T>(UIPanelBase<T> panel)
    {
        if (AllPanel.IsEmptyCollection()) AllPanel = new List<IPanel>();
        var isCon = AllPanel.Contains(panel);
        if (isCon) return;
        AllPanel.Add(panel);
    }

    public virtual void OnPanelOpen<T>(UIPanelBase<T> panel)
    {
        if (OpeningPanel.IsEmptyCollection()) OpeningPanel = new List<IPanel>();
        OpeningPanel.Add(panel);
    }

    public virtual void OnPanelClose<T>(UIPanelBase<T> panel)
    {
        if (OpeningPanel.IsEmptyCollection()) return;
        OpeningPanel.Remove(panel);
    }

    public bool IsOpeningPanel()
    {
        if (OpeningPanel.IsEmptyCollection()) return false;
        return OpeningPanel.Count >= 1;
    }

    private readonly Vector3 less = Vector3.one * 0.1f;
    private readonly Vector3 newScale = Vector3.one * 1.1f;

    public Sequence DisplayAnimation(GameObject targetObj, float duration)
    {
        var tt = targetObj.transform;
        var originalScale = tt.localScale;
        tt.localScale = less;
        targetObj.gameObject.SetActive(true);

        var sq = DOTween.Sequence();
        sq.Append(targetObj.transform.DOScale(newScale, duration));
        sq.Append(targetObj.transform.DOScale(originalScale, 0.1f));
        sq.OnComplete(() => { targetObj.transform.localScale = originalScale; });
        sq.OnKill(() => { targetObj.transform.localScale = originalScale; });
        return sq;
    }

    public void DisplayFade(bool isActive, GameObject targetObj, float duration)
    {
        var isCanvasGroup = targetObj.TryGetComponent<CanvasGroup>(out var canvasGroup);
        if (!isCanvasGroup)
        {
            // targetObj.SetActive(isActive);
            targetObj.AddComponent<CanvasGroup>();
            targetObj.TryGetComponent<CanvasGroup>(out var canvasGroup2);
            canvasGroup = canvasGroup2;
        }

        if (isActive)
        {
            canvasGroup.alpha = 0;
            targetObj.SetActive(true);
            canvasGroup.DOFade(1, duration).OnComplete(() => targetObj.SetActive(true));
        }
        else
        {
            canvasGroup.DOFade(0, duration).OnComplete(() => { targetObj.SetActive(false); });
        }

    }
}