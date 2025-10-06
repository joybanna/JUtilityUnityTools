using UnityEngine;

namespace J_Tools
{
    public static class ExtensionString
    {
        public static string Bold(this string str)
        {
            return "<b>" + str + "</b>";
        }

        public static string Italic(this string str)
        {
            return "<i>" + str + "</i>";
        }

        public static string Underline(this string str)
        {
            return "<u>" + str + "</u>";
        }

        public static string Color(this string str, Color color)
        {
            return $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>{str}</color>";
        }
    }
}