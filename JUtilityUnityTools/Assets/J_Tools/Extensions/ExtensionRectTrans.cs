using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public static class ExtensionRectTrans
{
    public enum AnchorSqrt
    {
        Center = 0,
        TopLeft = 1,
        TopCenter = 2,
        TopRight = 3,
        Left = 4,
        Right = 5,
        BottomLeft = 6,
        BottomCenter = 7,
        BottomRight = 8,
    }

    public static RectTransform SetAnchorBottomLeft(this RectTransform rec)
    {
        rec.anchorMax = new Vector2(0, 0);
        rec.anchorMin = new Vector2(0, 0);
        rec.pivot = new Vector2(0, 0);
        return rec;
    }

    public static RectTransform SetAnchorBottomRight(this RectTransform rec)
    {
        rec.anchorMax = new Vector2(1, 0);
        rec.anchorMin = new Vector2(1, 0);
        rec.pivot = new Vector2(1, 0);
        return rec;
    }

    public static RectTransform SetAnchorBottomCenter(this RectTransform rec)
    {
        rec.anchorMax = new Vector2(0.5f, 0);
        rec.anchorMin = new Vector2(0.5f, 0);
        rec.pivot = new Vector2(0.5f, 0);
        return rec;
    }

    public static RectTransform SetAnchorTopLeft(this RectTransform rec)
    {
        rec.anchorMax = new Vector2(0, 1);
        rec.anchorMin = new Vector2(0, 1);
        rec.pivot = new Vector2(0, 1);
        return rec;
    }

    public static RectTransform SetAnchorTopRight(this RectTransform rec)
    {
        rec.anchorMax = new Vector2(1, 1);
        rec.anchorMin = new Vector2(1, 1);
        rec.pivot = new Vector2(1, 1);
        return rec;
    }

    public static RectTransform SetAnchorTopCenter(this RectTransform rec)
    {
        rec.anchorMax = new Vector2(0.5f, 1);
        rec.anchorMin = new Vector2(0.5f, 1);
        rec.pivot = new Vector2(0.5f, 1);
        return rec;
    }

    public static RectTransform SetAnchorMiddleCenter(this RectTransform rec)
    {
        rec.anchorMax = new Vector2(0.5f, 0.5f);
        rec.anchorMin = new Vector2(0.5f, 0.5f);
        rec.pivot = new Vector2(0.5f, 0.5f);
        return rec;
    }

    public static AnchorSqrt GetAnchorSqrt(this Vector2 pos)
    {
        if (pos is { x: < 0, y: > 0 })
            return AnchorSqrt.TopLeft;
        else if (pos is { x: 0, y: > 0 })
            return AnchorSqrt.TopCenter;
        else if (pos is { x: > 0, y: > 0 })
            return AnchorSqrt.TopRight;
        else if (pos is { y: 0, x: < 0 })
            return AnchorSqrt.Left;
        else if (pos is { y: 0, x: 0 })
            return AnchorSqrt.Center;
        else if (pos is { y: 0, x: > 0 })
            return AnchorSqrt.Right;
        else if (pos is { y: > 1, x: < 0 })
            return AnchorSqrt.BottomLeft;
        else if (pos is { y: > 1, x: 0 })
            return AnchorSqrt.BottomCenter;
        else if (pos is { y: > 1, x: > 0 })
            return AnchorSqrt.BottomRight;
        else return AnchorSqrt.Center;
    }
    //   }
}