using System;
using System.Collections.Generic;
using UnityEngine;

namespace J_Tools
{
    [RequireComponent(typeof(JPoolController))]
    public class JPoolPreload : MonoBehaviour
    {
        // [SerializeField] private List<PoolSetting> preloadSetting;

        public void Preload()
        {
        }
    }

    // [Serializable]
    // public struct PoolSetting
    // {
    //     public MonoBehaviourJPoolBase objPool;
    //     public int initAmount;
    //     public bool isDisableExpand;
    //
    //     public PoolSetting(MonoBehaviourJPoolBase objP)
    //     {
    //         objPool = objP;
    //         initAmount = 5;
    //         isDisableExpand = false;
    //     }
    // }
}