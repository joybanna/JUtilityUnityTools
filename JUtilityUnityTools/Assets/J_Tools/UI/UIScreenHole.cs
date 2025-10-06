using System;
using System.Collections;
using J_Tools;
using Sirenix.OdinInspector;
using UnityEngine;

public class UIScreenHole : MonoBehaviour
{
    public RectTransform groupUI;
    public ScreenOrientation orientation;
    private float _differanceW;
    private float _differanceH;
    private Coroutine _myRoutine;
    [SerializeField, ReadOnly] private bool isActive;

    [SerializeField] private Vector2 padding;

    public void InitScreenHole()
    {
        orientation = Screen.orientation;
        _differanceW = Screen.width - Screen.safeArea.width;
        _differanceH = Screen.height - Screen.safeArea.height;
        // JDebug.SetMessage($"differanceH : {differanceH} , {orientation}");
        SetCanvas(orientation);
        _myRoutine = StartCoroutine(HandleRotateScreen());
    }

    private void SetCanvas(ScreenOrientation screenOrientation)
    {
        switch (screenOrientation)
        {
            case ScreenOrientation.LandscapeLeft:
                groupUI.SetLeft(_differanceW);
                groupUI.SetRight(0);
                break;
            case ScreenOrientation.LandscapeRight:
                groupUI.SetRight(_differanceW);
                groupUI.SetLeft(0);
                break;
            case ScreenOrientation.Portrait:
                groupUI.SetTop((_differanceH * 0.5f) + padding.y);
                groupUI.SetBottom(0);
                break;
            case ScreenOrientation.PortraitUpsideDown:
                groupUI.SetBottom((_differanceH * 0.5f) + padding.y);
                groupUI.SetTop(0);
                break;
            default:
                return;
        }

        orientation = screenOrientation;
    }

    IEnumerator HandleRotateScreen()
    {
        isActive = true;
        while (isActive)
        {
            yield return new WaitForSeconds(1f);
            if (IsScreenChange(out var orientationChange))
            {
                SetCanvas(orientationChange);
            }
            else yield return new WaitForEndOfFrame();
        }
    }

    private bool IsScreenChange(out ScreenOrientation orientationChange)
    {
        var isChange = orientation != Screen.orientation;
        orientationChange = Screen.orientation;
        return isChange;
    }

    private void OnDisable()
    {
        isActive = false;
        if (_myRoutine != null) StopCoroutine(_myRoutine);
    }
}

public static class RectTransformExtensions
{
    public static void SetLeft(this RectTransform rt, float left)
    {
        rt.offsetMin = new Vector2(left, rt.offsetMin.y);
    }

    public static void SetRight(this RectTransform rt, float right)
    {
        rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
    }

    public static void SetTop(this RectTransform rt, float top)
    {
        rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
    }

    public static void SetBottom(this RectTransform rt, float bottom)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
    }
}