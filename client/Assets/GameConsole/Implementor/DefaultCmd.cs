using GameConsole.GameUI;
using RedSaw.CommandLineInterface;
using UnityEngine;

namespace GameConsole.Implementor
{
    public partial class DefaultCmd
    {
        private enum EmLogType
        {
            Info,
            Warning,
            Error,
        }
        
        private static GameConsolePanel sGameConsolePanel;
        
        private static GameConsolePanel GC => sGameConsolePanel ??= Object.FindFirstObjectByType<GameConsolePanel>();
        
        [Command(desc: "[打印]-字符串")]
        private static void Print(string str, EmLogType logType = EmLogType.Info)
        {
            var hexColor = logType switch
            {
                EmLogType.Error => "red",
                EmLogType.Warning => "yellow",
                _ => "white",
            };
            
            GC.Print(str, hexColor);
        }
    }
}