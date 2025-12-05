using System.Collections;
using System.Collections.Generic;
using RedSaw.CommandLineInterface;
using UnityEngine;

namespace ConsoleTerminal.GameUI
{
    public class CheatPanel: MonoBehaviour
    {
        [SerializeField] private CheatPanelSingleCheat singleCheat;
        [SerializeField] private Transform cheatContainer;
        
        private ConsoleController<LogType> mConsole;
        
        public void SetConsole(ConsoleController<LogType> console)
        {
            mConsole = console;
            StartCoroutine(RegisterCommands());
        }
        
        public void Open()
        {
            
        }
    
        public void Hide()
        {
           
        }
        
        #region CheatLogic
    
        private IEnumerator RegisterCommands()
        {
            foreach (var callable in mConsole.CommandSystem.Vm.AllCallables)
            {
                if (callable is Command cmd)
                {
                    var sc = GetACheat();
                    sc.SetCommand(cmd);
                    yield return null;
                }
            }
            
            singleCheat.gameObject.SetActive(false);
        }

        private CheatPanelSingleCheat GetACheat()
        {
            var go = Instantiate(singleCheat.gameObject, cheatContainer);
            var sc = go.GetComponent<CheatPanelSingleCheat>();
            sc.SetSubmitAct(OnClickSubmit);
            return sc;
        }
        
        private void OnClickSubmit(Command command, string paras)
        {
            var commandStr = $"{command.name} {paras}";
            mConsole.OnSubmit(commandStr);
        }
    
        #endregion
    }
}