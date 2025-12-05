using ConsoleTerminal.GameUI;
using RedSaw.CommandLineInterface;
using UnityEngine;

namespace ConsoleTerminal.Implementor
{
    public partial class DefaultCmd
    {
        private enum EmLogType
        {
            Info,
            Warning,
            Error,
        }
        
        private static GameConsole sGameConsole;
        
        private static GameConsole GC => sGameConsole ??= Object.FindFirstObjectByType<GameConsole>();
        
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