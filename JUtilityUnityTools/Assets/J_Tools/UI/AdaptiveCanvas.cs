using UnityEngine;
using UnityEngine.UI;

public class AdaptiveCanvas : MonoBehaviour
{
    private CanvasScaler canvasScaler;

    // Ratio
    // private float standardRatio = 1920f / 1080f;
    //
    // private float maxRatio = 2400f / 1080f;
    // private float minRatio = 2048f / 1536f;

    // Match
    // private float standardMatch = 0.5f;

    // private float maxMatch = 1f;

    // private float minMatch = 0f;
    public UIScreenHole uiScreenHole;

    void Awake()
    {
        canvasScaler = GetComponent<CanvasScaler>();
        uiScreenHole = GetComponent<UIScreenHole>();
        SetCanvasMatch();
        if (uiScreenHole != null) uiScreenHole.InitScreenHole();
    }

    private float CalcAspect()
    {
        var safeArea = Screen.safeArea;
        var ratio = safeArea.width / safeArea.height;
        return ratio;
    }

    private void SetCanvasMatch()
    {
        float ratio = CalcAspect();
        // Debug.Log("Ratio: " + ratio);
        if (ratio > 0.7f)
        {
            // float match = (ratio - standardRatio) / (maxRatio - standardRatio) * (maxMatch - standardMatch);
            // match += standardMatch;
            // if (match > 1) match = 0;
            canvasScaler.matchWidthOrHeight = 1;
        }
        else if (ratio < 0.5f)
        {
            canvasScaler.matchWidthOrHeight = 0;
        }

        Canvas.ForceUpdateCanvases();
    }
}