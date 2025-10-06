#if UNITY_EDITOR
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace J_Tools
{
    public class TestFuncWindow : OdinEditorWindow
    {
        [MenuItem("MyEditor/TestFuncWindow")]
        private static void OpenWindow()
        {
            GetWindow<TestFuncWindow>().Show();
        }
    }
}
#endif