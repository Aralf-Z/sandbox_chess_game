using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ConsoleTerminal.GameUI
{
    /// <summary>default implementation of alternative options panel</summary>
    public class GameConsoleAlternativeOptionsPanel : MonoBehaviour
    {
        [SerializeField] private Text textPanel;

        private List<string> mOptions;

        public int SelectionIndex
        {
            set
            {
                textPanel.text = string.Empty;
                if (mOptions == null || mOptions.Count == 0) return;
                string output = string.Empty;
                for (int i = 0; i < mOptions.Count; i++)
                {
                    if (i == value)
                    {
                        output += $"<color=\"#92e8c0\">{mOptions[i]}</color>\n";
                        continue;
                    }

                    output += mOptions[i] + "\n";
                }

                textPanel.text = output;
            }
        }

        /// <summary>render current alternative options</summary>
        public void SetOptions(List<string> values)
        {
            this.mOptions = values;
        }
    }
}