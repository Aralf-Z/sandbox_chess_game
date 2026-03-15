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
        
        public List<Color> colors = new List<Color>()
        {
            Color.white,
            Color.white,
            Color.red,
            Color.yellow,
            Color.cyan
        };
        
        public bool logTimeStamp = true;
        public Level level = Level.Debug;
    }
}