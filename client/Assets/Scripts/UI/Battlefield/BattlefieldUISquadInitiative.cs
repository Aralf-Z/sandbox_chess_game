 
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class BattlefieldUISquadInitiative : MonoBehaviour
    {
        // [SerializeField] private Text squadName;
        // [SerializeField] private Text squadInitiative;
        // [SerializeField] private Image buttonBottom;
        // [SerializeField] private Button clickButton;
        //
        // private ISquad mSquad;
        //
        // public bool IsCollected { get; set; }
        //
        // public void Set(ISquad squad)
        // {
        //     mSquad = squad;
        //     squadName.text = mSquad.Info.Name;
        //     squadInitiative.text = $"先攻：{squad.Resource[EmResource.Initiative]:F0}";
        //     OnMoving();
        // }
        //
        // public void OnNew()
        // {
        //     clickButton.onClick.AddListener(() => Sys.Battlefield.SelectSquad(mSquad));
        // }
        //
        // public void OnRequire()
        // {
        //     Sys.Battlefield.Evt_OnNextSquadMove += OnMoving;
        //     Sys.Battlefield.Evt_OnSquadSelect += OnSelect;
        // }
        //
        // public void OnRecycle()
        // {
        //     Sys.Battlefield.Evt_OnNextSquadMove -= OnMoving;
        //     Sys.Battlefield.Evt_OnSquadSelect -= OnSelect;
        // }
        //
        // private void OnMoving()
        // {
        //     buttonBottom.color = Mod.Battlefield.curMovingSquad == mSquad ? Color.cyan : Color.gray;
        // }
        //
        // private void OnSelect()
        // {
        //     OnMoving();
        //     if(Mod.Battlefield.curMovingSquad != mSquad)
        //         buttonBottom.color = Mod.Battlefield.selectedSquad == mSquad ? Color.green : Color.gray;
        // }
    }

}