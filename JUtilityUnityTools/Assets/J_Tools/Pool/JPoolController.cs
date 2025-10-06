using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace J_Tools
{
    public class JPoolController : MonoBehaviour
    {
        public static JPoolController Instance
        {
            get
            {
                if (_instance != null) return _instance;
                var nObj = new GameObject
                {
                    name = "JPoolController"
                };
                _instance = nObj.AddComponent<JPoolController>();
                return _instance;
            }
        }

        private static JPoolController _instance;
        [SerializeField] private Transform content;
        private bool IsNullContent => ReferenceEquals(content, null);

        [ShowInInspector] public Dictionary<int, List<MonoBehaviourJPoolBase>> pools;

        private void Awake()
        {
            pools = new FlexibleDictionary<int, List<MonoBehaviourJPoolBase>>();
        }

        private void CreateObjPool(MonoBehaviourJPoolBase objP)
        {
            var nObj = IsNullContent ? Instantiate(objP) : Instantiate(objP, content);
            var id = objP.GetInstanceID();
            AssignObj(id, nObj);
        }

        private void AssignObj(int id, MonoBehaviourJPoolBase nObj)
        {
            var isCon = pools.ContainsKey(id);
            if (isCon)
            {
                if (pools[id].IsEmptyCollection())
                {
                    pools[id] = new List<MonoBehaviourJPoolBase> { nObj };
                }
                else
                {
                    pools[id].Add(nObj);
                }
            }
            else
            {
                pools.Add(id, new List<MonoBehaviourJPoolBase> { nObj });
            }
        }
    }

    // public class PoolObj
    // {
   
    // }
}