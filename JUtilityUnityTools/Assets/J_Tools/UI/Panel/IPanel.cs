using UnityEngine;

public interface IPanel
{
    public RectTransform MyPanel { get; }

    public void OpenPanel();
    public void ClosePanel();
    public void RegisterPanel();
}