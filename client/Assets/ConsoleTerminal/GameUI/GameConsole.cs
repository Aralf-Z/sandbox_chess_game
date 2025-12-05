using ConsoleTerminal.Implementor;
using RedSaw.CommandLineInterface;
using UnityEngine;
using UnityEngine.Serialization;

namespace ConsoleTerminal.GameUI
{
    /// <summary>the final wrapper of CommandConsoleSystem build in Unity</summary>
    public class GameConsole : MonoBehaviour
    {
        [SerializeField] private GameConsoleRenderer consoleRenderer;

        [SerializeField] private CheatPanel cheatPanel;

        [SerializeField] private GameConsoleHeader headerBar;

        [SerializeField, Tooltip("the capacity of input history, at least 1")]
        private int inputHistoryCapacity = 20;

        [SerializeField, Tooltip("the capacity of command query cache, at least 1")]
        private int commandQueryCacheCapacity = 20;

        [SerializeField, Tooltip("alternative command options count, at least 1")]
        private int alternativeCommandCount = 8;

        [SerializeField, Tooltip("should output with time information of [HH:mm:ss]")]
        private bool shouldOutputWithTime = true;

        [SerializeField, Tooltip("should record failed command input")]
        private bool shouldRecordFailedCommand = true;

        [SerializeField, Tooltip("should receive unity message")]
        private bool shouldReceiveUnityMessage = true;

        [SerializeField, Tooltip("[debug] output virtual machine exception call stack")]
        private bool shouldOutputVmExceptionStack = true;

        private ConsoleController<LogType> mConsole;
        
        /// <summary>initialize console, call this function to initialize console </summary>
        public void Awake()
        {
            mConsole = new ConsoleController<LogType>(
                consoleRenderer,
                new UserInput(),
                new CommandCreator(),

                inputHistoryCapacity: inputHistoryCapacity,
                commandQueryCacheCapacity: commandQueryCacheCapacity,
                alternativeCommandCount: alternativeCommandCount,
                shouldRecordFailedCommand: shouldRecordFailedCommand,
                outputWithTime: shouldOutputWithTime,
                outputStackTraceOfCommandExecution: shouldOutputVmExceptionStack
            );
            
            cheatPanel.SetConsole(mConsole);

            if (shouldReceiveUnityMessage) 
                Application.logMessageReceived += UnityConsoleLog;
            
            var parentTransform = transform.GetComponent<RectTransform>();
            headerBar.Init(pos => parentTransform.position += (Vector3)pos);
        }

        private void Update()
        {
            mConsole.Update();
        }

        private void OnDestroy()
        {
            if (shouldReceiveUnityMessage)
                Application.logMessageReceived -= UnityConsoleLog;
        }

        private void UnityConsoleLog(string msg, string stack, LogType type)
        {
            mConsole.Output(msg, GetHexColor(type));
        }

        private string GetHexColor(LogType type)
        {
            return type switch
            {
                LogType.Error or LogType.Exception or LogType.Assert => "#b13c45",
                LogType.Warning => "yellow",
                _ => "#fffde3",
            };
        }

        public void Print(string msg, string hexColor)
        {
            mConsole.Output(msg, hexColor);
        }
        
        /// <summary>clear output of current console</summary>
        public void ClearOutput() => mConsole.ClearOutputPanel();
    }
}