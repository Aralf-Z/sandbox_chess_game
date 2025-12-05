using System;
using UnityEngine;

namespace FastGameDev.Helper
{
    public class LogHelper: MonoBehaviour
    {
        public enum Level
        {
            None    = 0,
            Info    = 1,
            Warning = 2,
            Error   = 3,
            Debug   = 4,
        }
        
        public bool logTimeStamp = true;
        public Level level = Level.Debug;
        
        private static LogHelper sIns;

        private void Awake()
        {
            sIns = this;
        }

        private static void Log(string message, string title = null, Color color = default)
        {
            var hasColor = color != default;
            var timeStamp = sIns.logTimeStamp ? $"[{DateTime.Now.Hour:00}:{DateTime.Now.Minute:00}:{DateTime.Now.Second:00}:{DateTime.Now.Millisecond:000}] " : "";
            UnityEngine.Debug.Log($"{timeStamp}{(title == null ? "" : $"<{title}>")}{(hasColor ? $"<color={color.ColorToHex()}>" : "")}{message}{(hasColor ? "</color>" : "")}");
        }
        
        public static void Info(string message, string title = null)
        {
            if(sIns.level >=　Level.Info) Log($"{(title == null ? "" : $"<{title}>")}: {message}");
        }
        
        public static void Debug(string message, string title = null, Color color = default)
        {
            if(sIns.level >=　Level.Debug) Log(message, title, color);
        }

        public static void FrameDebug(string message, string title = null, Color color = default)
        {
            if(sIns.level >=　Level.Debug) Debug($"[f:{Time.frameCount}] {(title == null ? "" : $"<{title}>")}{message}: ", null, color);
        }

        public static void RealTimeDebug(string message, string title = null, Color color = default)
        {
            if(sIns.level >=　Level.Debug) Debug($"[t:{Time.realtimeSinceStartup:F3}] {(title == null ? "" : $"<{title}>")}{message}: ", null, color);
        }
    }
}