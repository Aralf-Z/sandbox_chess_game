using System;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEditor;

namespace FastGameDev.Helper
{
    internal static class LogHelperJumper
    {
        // private const string kClassName = nameof(LogHelper) + ".cs"; //日志类名称
        //
        // [UnityEditor.Callbacks.OnOpenAsset(0)]
        // private static bool OnOpenAsset(int instanceID, int line)
        // {
        //     var stackTrace = GetStackTrace();
        //
        //     if (string.IsNullOrEmpty(stackTrace) || !stackTrace.Contains(kClassName)) return false;
        //
        //     var matches = Regex.Match(stackTrace, @"\(at (.+)\)", RegexOptions.IgnoreCase);
        //     while (matches.Success)
        //     {
        //         var pathline = matches.Groups[1].Value;
        //         if (!pathline.Contains(kClassName))
        //         {
        //             var splitIndex = pathline.LastIndexOf(":", StringComparison.Ordinal);
        //             var path = pathline[..splitIndex];
        //             line = Convert.ToInt32(pathline[(splitIndex + 1)..]);
        //             var fullPath = Application.dataPath[..Application.dataPath.LastIndexOf("Assets", StringComparison.Ordinal)];
        //             fullPath += path;
        //             UnityEditorInternal.InternalEditorUtility.OpenFileAtLineExternal(fullPath.Replace('/', '\\'), line);
        //             break;
        //         }
        //
        //         matches = matches.NextMatch();
        //     }
        //
        //     return true;
        // }
        //
        // private static string GetStackTrace()
        // {
        //     var consoleWindowType = typeof(EditorWindow).Assembly.GetType("UnityEditor.ConsoleWindow");
        //     var fieldInfo = consoleWindowType.GetField("ms_ConsoleWindow", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
        //     var consoleWindowInstance = fieldInfo!.GetValue(null);
        //
        //     if (consoleWindowInstance == null || EditorWindow.focusedWindow != (EditorWindow)consoleWindowInstance) return null;
        //
        //     fieldInfo = consoleWindowType.GetField("m_ActiveText", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        //
        //     return fieldInfo!.GetValue(consoleWindowInstance).ToString();
        // }
    }
}