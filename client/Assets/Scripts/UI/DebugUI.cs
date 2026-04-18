using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameDev.Core;
using GameDev.Module;
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
            var note = this.Note().Get<TroopBattleNote>();
            
            infoText.text = $"curSquad: {note.currentSquad?.info.name}\n" +
                            $"selectedSquad: {note.selectedSquad?.info.name}\n\n" +
                            $"action line: \n" +
                            $"{string.Join("\n", note.liveSquads.Select(x => $"{x.info.name}: {x.ctx.initiative}"))}";
        }

        public override EmUIOrder Order => EmUIOrder.Tip;
    }
 
}