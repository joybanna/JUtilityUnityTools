using System.Collections;
using System.Collections.Generic;
using System.Linq;
using J_Tools;
using UnityEngine;

namespace J_Tools
{
    public static class JRandom
    {
        public static T RandomWeight<T>(this IReadOnlyCollection<T> list) where T : IWeighted
        {
            if (list.IsNull() || list.Count == 0) return default;
            int totalWeight = list.Sum(item => item.Weight);
            int select = Random.Range(0, totalWeight);
            int sum = 0;
            foreach (var item in list)
            {
                for (var i = sum; i < item.Weight + sum; i++)
                {
                    if (i >= select) return item;
                }

                sum += item.Weight;
            }

            return list.First();
        }

        public static List<T> RandomSelects<T>(this IReadOnlyCollection<T> list, int count)
        {
            if (list.IsNull() || list.Count == 0 || count <= 0) return new List<T>();
            if (count >= list.Count) return list.ToList();
            List<T> tempList = list.ToList();
            tempList.ShuffleList();
            List<T> result = new List<T>();
            for (int i = 0; i < count; i++)
            {
                result.Add(tempList[i]);
            }

            return result;
        }
    }

    public interface IWeighted
    {
        int Weight { get; }
    }
}