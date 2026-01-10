using FastGameDev.Core;

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
        
        public bool logTimeStamp = true;
        public Level level = Level.Debug;
    }
}