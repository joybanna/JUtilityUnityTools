using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

namespace J_Tools
{
    public static class JDebug
    {
        public static bool IsDisableJDebug
        {
            get => _isDisableJDebug;
            set => _isDisableJDebug = value;
        }

        private static bool _isDisableJDebug;

        public static bool IsConsoleLog
        {
            get => _isConsoleLog;
            set => _isConsoleLog = value;
        }

        private static bool _isConsoleLog;

        // ReSharper disable Unity.PerformanceAnalysis
        public static void SetMessage(string message, Color color = default, bool isDebug = true)
        {
            if (_isDisableJDebug) return;
            if (!isDebug) return;
            var m = (color == default)
                ? message
                : $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>{message}</color>";
            MonoBehaviour.print(m);
            if (_isConsoleLog) Debug.Log(m);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public static void SetWarningMessage(string message, bool isDebug)
        {
            if (_isDisableJDebug) return;
            if (!isDebug) return;
            var m = $"<color=#{ColorUtility.ToHtmlStringRGBA(Color.yellow)}> ?? WARNING : {message}</color>";
            MonoBehaviour.print(m);
            if (_isConsoleLog) Debug.Log(m);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public static void SetErrorMessage(string message, bool isForceBrake = false, bool isDebug = true)
        {
            if (_isDisableJDebug) return;
            if (!isDebug) return;
            var m = $"<color=#{ColorUtility.ToHtmlStringRGBA(Color.red)}> ?? ERROR : {message}</color>";
            MonoBehaviour.print(m);
            if (_isConsoleLog) Debug.Log(m);
            if (isForceBrake) Debug.Break();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public static void RayToTarget(Transform origin, Vector3 target, Color color, bool isShow = true,
            float duration = 0.5f)
        {
            if (!isShow) return;
            Debug.DrawLine(origin.position, target, color, duration);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public static void MethodName(UnityAction method,
            [Optional] string add,
            [Optional] Color color,
            [Optional] bool isDebug)
        {
            var message = $"{method.Method.Name} : {add}";
            SetMessage(message, color, isDebug);
        }
    }
}