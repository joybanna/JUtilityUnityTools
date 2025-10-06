using System.Collections;
using System.Collections.Generic;
using System.Linq;
using J_Tools;
using UnityEngine;

namespace J_Tools
{
    public static class JWeight
    {
        public static T WeightSelect<T>(this IReadOnlyCollection<T> list) where T : IWeighted
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
        
    }

    public interface IWeighted
    {
        int Weight { get; }
    }
}