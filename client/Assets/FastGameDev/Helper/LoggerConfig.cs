using System.Collections.Generic;
using FastGameDev.Core;
using UnityEngine;

namespace FastGameDev.Helper
{
    public class LogHelperConfig: AppConfig<LogHelperConfig>
    {
        public enum Level
        {
            None    = 0,
            Info    = 1,
            Warning = 2,
            Error   = 3,
            Debug   = 4,
        }

        public List<string> colors = new ()
        {
            "#FFFFFF",//白色
            "#FFFFFF",//白色
            "#FF0000",//红色
            "#FFFF00",//黄色
            "#00FFFF",//蓝绿色
        };
        
        public bool logTimeStamp = true;
        public Level level = Level.Debug;
        
        
    }
}