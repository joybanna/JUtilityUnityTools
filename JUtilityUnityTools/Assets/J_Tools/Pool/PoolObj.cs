using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace J_Tools
{
    [Serializable]
    public class PoolObj
    {
        public int id;
        public int initAmount;
        private Transform _content;
        private Queue<MonoBehaviourJPoolBase> _createdObjs;
        private MonoBehaviourJPoolBase _prefab;

        public PoolObj(MonoBehaviourJPoolBase prefab, Transform con, int am = 5)
        {
            _prefab = prefab;
            id = _prefab.GetInstanceID();
            initAmount = am;
            _content = con;
            _createdObjs = new Queue<MonoBehaviourJPoolBase>();
        }

        public PoolObj InitPool()
        {
            for (int i = initAmount - 1; i >= 0; i--) _createdObjs.Enqueue(CreateObj());
            return this;
        }

        private MonoBehaviourJPoolBase CreateObj()
        {
            var nObj = ReferenceEquals(_content, null)
                ? Object.Instantiate(_prefab)
                : Object.Instantiate(_prefab, _content);
            return nObj;
        }

        private const int maxRound = 10;

        public bool GetObj(out MonoBehaviourJPoolBase result)
        {
            var count = 0;
            while (count <= maxRound)
            {
                var isPick = Pick(out var r);
                if (isPick && r.PoolStatus == PoolStatus.Ready)
                {
                    result = r;
                    return true;
                }

                count++;
            }

            result = null;
            return false;
        }

        private bool Pick(out MonoBehaviourJPoolBase result)
        {
            if (_createdObjs.Count <= 0)
            {
                _createdObjs.Enqueue(CreateObj());
                result = null;
                return false;
            }
            else
            {
                result = _createdObjs.Dequeue();
                return true;
            }
        }
    }
}