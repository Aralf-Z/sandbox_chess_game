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
            var timeStamp = Config.logTimeStamp ? $"[{DateTime.Now.Hour:00}:{DateTime.Now.Minute:00}:{DateTime.Now.Second:00}:{DateTime.Now.Millisecond:000}] " : "";
            UnityEngine.Debug.Log($"<color={color.ColorToHex()}>{timeStamp}{(title == null ? "" : $"[{title}]  ")}</color>{message}");
        }

        /// <summary>
        /// 运行日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="color"></param>
        public static void Info(string message, string title = null, Color color = default)
        {
            if(Config.level >=　LogHelperConfig.Level.Info) 
                Log(message, title, color == default ? Config.colors[(int)LogHelperConfig.Level.Info] : color);
        }

        /// <summary>
        /// 警告信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="color"></param>
        public static void Warning(string message, string title = null, Color color = default)
        {
            if(Config.level >= LogHelperConfig.Level.Warning) 
                Log(message, title, color == default ? Config.colors[(int)LogHelperConfig.Level.Warning] : color);
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="color"></param>
        public static void Error(string message, string title = null, Color color = default)
        {
            if(Config.level >= LogHelperConfig.Level.Error) 
                Log(message, title, color == default ? Config.colors[(int)LogHelperConfig.Level.Error] : color);
        }
        
        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="color"></param>
        public static void Debug(string message, string title = null, Color color = default)
        {
            if(Config.level >=　LogHelperConfig.Level.Debug) 
                Log(message, title, color == default ? Config.colors[(int)LogHelperConfig.Level.Debug] : color);
        }

        /// <summary>
        /// 包含帧信息的调试日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="color"></param>
        public static void FrameDebug(string message, string title = null, Color color = default)
        {
            if(Config.level >=　LogHelperConfig.Level.Debug) 
                Debug(message,$"[f:{Time.frameCount}] {(title == null ? "" : $"<{title}>")}", color);
        }

        /// <summary>
        /// 包含运行时间的调试日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="color"></param>
        public static void RealTimeDebug(string message, string title = null, Color color = default)
        {
            if(Config.level >=　LogHelperConfig.Level.Debug) 
                Debug(message,$"[t:{Time.realtimeSinceStartup:F3}] {(title == null ? "" : $"<{title}>")}", color);
        }
    }
}