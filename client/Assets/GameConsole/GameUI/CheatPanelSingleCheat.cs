using System;
using RedSaw.CommandLineInterface;
using UnityEngine;
using UnityEngine.UI;

namespace ConsoleTerminal.GameUI
{
    public class CheatPanelSingleCheat : MonoBehaviour
    {
        [SerializeField] private InputField inputTxt;
        [SerializeField] private Button submitBtn;
        [SerializeField] private Text descriptionTxt;
        
        private Command mCommand;
        
        public void SetSubmitAct(Action<Command, string> submitAct)
        {
            submitBtn.onClick.AddListener(() => submitAct?.Invoke(mCommand, inputTxt.text));
            inputTxt.onSubmit.AddListener(text => submitAct?.Invoke(mCommand, text));
        }

        public void SetCommand(Command command)
        {
            mCommand = command;
            descriptionTxt.text = $"控制台命令：“{command.name}”;\n描述：{command.description}";
        }
    }
}