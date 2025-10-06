using UnityEngine;

namespace J_Tools
{
    public static class ExtensionColor
    {
        public static Color GetColorFromHtml(this string str, bool includeAlpha = true)
        {
            if (ColorUtility.TryParseHtmlString(str, out var color))
            {
                return new Color(color.r, color.g, color.b, includeAlpha ? color.a : 1f);
            }
            else
            {
                Debug.LogWarning($"String '{str}' is not a valid color. Returning white.");
                return Color.white;
            }
        }

        public static string ToHtmlString(this Color color, bool includeAlpha = true)
        {
            return includeAlpha
                ? $"#{ColorUtility.ToHtmlStringRGBA(color)}"
                : $"#{ColorUtility.ToHtmlStringRGB(color)}";
        }

        public static Color WithAlpha(this Color color, float alpha)
        {
            return new Color(color.r, color.g, color.b, alpha);
        }

        public static Color Inverted(this Color color)
        {
            return new Color(1f - color.r, 1f - color.g, 1f - color.b, color.a);
        }
    }
}