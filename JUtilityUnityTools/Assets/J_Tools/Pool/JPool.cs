using JetBrains.Annotations;
using UnityEngine;

namespace J_Tools
{
    public enum PoolStatus
    {
        Ready = 0,
        Using = 1,
        Pending = 2,
    }

    public interface IJPool
    {
        public T RegisterPool<T>([CanBeNull] Transform parent, Vector3 pos = default);
        public void ReturnToPool();
        public void DestroyThis();
        public PoolStatus PoolStatus { get; set; }
    }

    public class MonoBehaviourJPoolBase : MonoBehaviour, IJPool
    {
        public T RegisterPool<T>([CanBeNull] Transform parent, Vector3 pos = default)
        {
            throw new System.NotImplementedException();
        }

        public void ReturnToPool()
        {
            throw new System.NotImplementedException();
        }

        public void DestroyThis()
        {
            throw new System.NotImplementedException();
        }

        public PoolStatus PoolStatus { get; set; }
    }
}