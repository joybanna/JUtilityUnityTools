using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace J_Tools
{
    public static class J_Extension
    {
        public static bool IsEmptyCollection<T>(this ICollection<T> collection) =>
            collection.IsNull() || collection.Count.Equals(0);

        public static bool IsNull<T>([CanBeNull] this T obj) => ReferenceEquals(obj, null);

        public static List<T> ClearGameObjInList<T>(this List<T> list) where T : MonoBehaviour
        {
            if (list.IsEmptyCollection())
            {
                if (list.IsNull()) list = new List<T>();
                else list.Clear();
            }
            else
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (list[i] == null) continue;
                    Object.Destroy(list[i].gameObject);
                }

                list.Clear();
            }


            return list;
        }

        public static List<T> RemoveNullMemberList<T>(this List<T> list) where T : MonoBehaviour
        {
            // var count = list.Count;

            // for (var i = 0; i < count; i++)
            // {
            //     if (list[i].IsNull()) list.RemoveAt(i);
            // }
            list = list.Where(item => !ReferenceEquals(item, null)).ToList();
            return list;
        }


        public static List<T> FindOfType<T>() => Object.FindObjectsOfType<MonoBehaviour>().OfType<T>().ToList();

        public static List<T> DescendedList<T>(this List<T> list)
        {
            var output = new List<T>();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (ReferenceEquals(list[i], null)) continue;
                output.Add(list[i]);
            }

            return output;
        }

        public static string FormatName(this string str)
        {
            str = str.ToLower();
            var charsToRemove = new string[] { " ", "-", "_" };
            foreach (var c in charsToRemove)
            {
                str = str.Replace(c, string.Empty);
            }

            return str;
        }

        public static Color SetAlphaColor(this Color old, float alpha = 1)
        {
            alpha = alpha > 1 ? 1 : alpha;
            alpha = alpha < 0 ? 0 : alpha;
            return new Color(old.r, old.g, old.b, alpha);
        }
    }
}