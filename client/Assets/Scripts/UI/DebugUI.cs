using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FastGameDev.Core;
using FastGameDev.Module;
using UnityEngine;
using UnityEngine.UI;


namespace Game
{
    public class DebugUI : UIWindow, IGetNote
    {
        public Text infoText;

        protected override void OnCreate()
        {
            
        }

        protected override void OnOpen()
        {
            
        }

        protected override void OnHide()
        {
            
        }

        protected override void OnClose()
        {
            
        }
        
        private void FixedUpdate()
        {
            var note = this.Note().Get<TroopBattlefieldNote>();
            
            infoText.text = $"curSquad: {note.curSquad?.Info.name}\n" +
                            $"selectedSquad: {note.selectedSquad?.Info.name}\n\n" +
                            $"action line: \n" +
                            $"{string.Join("\n", note.liveSquads.Select(x => $"{x.Info.name}: {x.Context.initiative}"))}";
        }

        public override EmUIOrder Order => EmUIOrder.Tip;
    }
 
}