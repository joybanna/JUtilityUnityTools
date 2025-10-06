using System.Collections.Generic;
using UnityEngine;

namespace J_Tools
{
    public class JPoolManager : JSingleton<JPoolManager>
    {
        private static JPoolController Controller =>JPoolController.Instance;

        public JPoolManager()
        {
          
        }

        public void Register()
        {
        }
    }
}