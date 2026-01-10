using System;
using UnityEngine;

namespace FastGameDev.Helper
{
    [ExecuteAlways]
    public class LogHelper
    {
        private static LogHelperConfig Config => LogHelperConfig.Ins;
        
        private static void Log(string message, string title = null, Color color = default)
        {
            var hasColor = color != default;
            var timeStamp = Config.logTimeStamp ? $"[{DateTime.Now.Hour:00}:{DateTime.Now.Minute:00}:{DateTime.Now.Second:00}:{DateTime.Now.Millisecond:000}] " : "";
            UnityEngine.Debug.Log($"{timeStamp}{(title == null ? "" : $"<{title}>")}{(hasColor ? $"<color={color.ColorToHex()}>" : "")}{message}{(hasColor ? "</color>" : "")}");
        }
        
        public static void Info(string message, string title = null)
        {
            if(Config.level >=　LogHelperConfig.Level.Info) Log($"{(title == null ? "" : $"<{title}>")}: {message}");
        }

        public static void Warning(string message, string title = null)
        {
            if(Config.level >= LogHelperConfig.Level.Warning) Log($"{(title == null ? "" : $"<{title}>")}: {message}");
        }
        
        public static void Error(string message, string title = null)
        {
            if(Config.level >= LogHelperConfig.Level.Error) Log($"{(title == null ? "" : $"<{title}>")}: {message}");
        }
        
        public static void Debug(string message, string title = null, Color color = default)
        {
            if(Config.level >=　LogHelperConfig.Level.Debug) Log(message, title, color);
        }

        public static void FrameDebug(string message, string title = null, Color color = default)
        {
            if(Config.level >=　LogHelperConfig.Level.Debug) Debug($"[f:{Time.frameCount}] {(title == null ? "" : $"<{title}>")}{message}: ", null, color);
        }

        public static void RealTimeDebug(string message, string title = null, Color color = default)
        {
            if(Config.level >=　LogHelperConfig.Level.Debug) Debug($"[t:{Time.realtimeSinceStartup:F3}] {(title == null ? "" : $"<{title}>")}{message}: ", null, color);
        }
    }
}