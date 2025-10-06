using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace J_Tools
{
    public static class ExtensionCollections
    {
        public static bool IsEmptyCollection<T>(this ICollection<T> collection) =>
            collection.IsNull() || collection.Count.Equals(0);

        public static bool RemoveNullMemberCollection<T>(this ICollection<T> collection,
            out ICollection<T> removedItems)
        {
            removedItems = new List<T>();
            if (collection.IsEmptyCollection()) return false;
            var items = collection.ToList();
            removedItems = items.Where(item => !ReferenceEquals(item, null)).ToList();
            return removedItems.Count > 0;
        }


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

        public static List<T> AscendedList<T>(this List<T> list)
        {
            var output = new List<T>();
            for (int i = 0; i < list.Count; i++)
            {
                if (ReferenceEquals(list[i], null)) continue;
                output.Add(list[i]);
            }

            return output;
        }

        public static List<T> ShuffleList<T>(this List<T> list)
        {
            if (list.IsEmptyCollection()) return new List<T>();
            var output = new List<T>(list);
            int n = output.Count;
            while (n > 1)
            {
                int k = Random.Range(0, n--);
                T temp = output[n];
                output[n] = output[k];
                output[k] = temp;
            }

            return output;
        }
    }
}