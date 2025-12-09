using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public partial class BattlefieldUI
    {
        // [SerializeField] private Button hiddenBtn;
        // [SerializeField] private Button squadAttackBtn;
        // [SerializeField] private Button squadSkillBtn;
        // [SerializeField] private Button squadRushBtn;
        // [SerializeField] private Button squadReorganizeBtn;
        // [SerializeField] private Button squadWaitBtn;
        // [SerializeField] private Button squadEscapeBtn;
        // [SerializeField] private Button squadEndActBtn;
        // [SerializeField] private Button endTurnBtn;
        //
        // [SerializeField] private Text currentSquadNameText;
        // [SerializeField] private Text selectedSquadNameText;
        //
        // [SerializeField] private BattlefieldUISquadInitiative squadInitiativeTemplate;
        // [SerializeField] private BattlefieldUISquadFloatInfo squadFloatInfoTemplate;
        // private MonoBehaviourPool<BattlefieldUISquadInitiative> mSquadInitiativePool;
        // private MonoBehaviourPool<BattlefieldUISquadFloatInfo> mSquadFloatInfoPool;
        //
        // [SerializeField] private RectTransform squadInfoRectTransf;
        //
        // private bool mIsHidden = true;
        //
        // private void SquadInfoOnInit()
        // {
        //     hiddenBtn.onClick.AddListener(() =>
        //     {
        //         mIsHidden = !mIsHidden;
        //         squadInfoRectTransf.DOAnchorPosY(mIsHidden ? -300 : 0, .5f);
        //         hiddenBtn.GetComponentInChildren<Text>().text = mIsHidden ? "展开" : "收起";
        //     });
        //     
        //     squadAttackBtn.onClick.AddListener(() => Sys.Battlefield.SquadSelectedAct(EmSquadAction.Attack));
        //     squadSkillBtn.onClick.AddListener(() => Sys.Battlefield.SquadSelectedAct(EmSquadAction.Skill));
        //     squadRushBtn.onClick.AddListener(() => Sys.Battlefield.SquadSelectedAct(EmSquadAction.Rush));
        //     squadReorganizeBtn.onClick.AddListener(() => Sys.Battlefield.SquadSelectedAct(EmSquadAction.Reorganize));
        //     squadWaitBtn.onClick.AddListener(() => Sys.Battlefield.SquadSelectedAct(EmSquadAction.Wait));
        //     squadEscapeBtn.onClick.AddListener(() => Sys.Battlefield.SquadSelectedAct(EmSquadAction.Escape));
        //     squadEndActBtn.onClick.AddListener(() =>
        //     {
        //         Sys.Battlefield.NextSquadMove();
        //     });
        //
        //     squadInitiativeTemplate.gameObject.SetActive(false);
        //     squadFloatInfoTemplate.gameObject.SetActive(false);
        //     mSquadInitiativePool = new MonoBehaviourPool<BattlefieldUISquadInitiative>(squadInitiativeTemplate.transform.parent, squadInitiativeTemplate.gameObject);
        //     mSquadFloatInfoPool = new MonoBehaviourPool<BattlefieldUISquadFloatInfo>(squadFloatInfoTemplate.transform.parent, squadFloatInfoTemplate.gameObject);
        // }
        //
        // private void SquadInfoOnOpen()
        // {
        //     squadInfoRectTransf.anchoredPosition = new Vector2(squadInfoRectTransf.anchoredPosition.x, mIsHidden ? -300 : 0);
        //     hiddenBtn.GetComponentInChildren<Text>().text = mIsHidden ? "展开" : "收起";
        //     
        //     Sys.Battlefield.Evt_OnSquadInitiativeRoll += OnSquadInitiativeRoll;
        //     Sys.Battlefield.Evt_OnSquadSelect += OnSquadSelect;
        //     Sys.Battlefield.Evt_OnNextSquadMove += OnNextSquadMove;
        //     Sys.Battlefield.Evt_OnSquadMoved += OnSquadMove;
        // }
        //
        // private void SquadInfoOnHide()
        // {
        //     Sys.Battlefield.Evt_OnSquadInitiativeRoll -= OnSquadInitiativeRoll;
        //     Sys.Battlefield.Evt_OnSquadSelect -= OnSquadSelect;
        //     Sys.Battlefield.Evt_OnNextSquadMove -= OnNextSquadMove;
        //     Sys.Battlefield.Evt_OnSquadMoved -= OnSquadMove;
        // }
        //
        // private void SquadInfoOnUpdate(float dt)
        // {
        //     mSquadFloatInfoPool.ClearLiving();
        //     foreach (var squad in Mod.Battlefield.squadsSorted)
        //     {
        //         var worldPos = Mod.Battlefield.curLegionBf.GetSquadEntity(squad).ObjectBind.Position;
        //         var pos = Mod.Battlefield.curLegionBf.CameraBind.WorldPos2UIPos(this, worldPos.x, worldPos.y);
        //         var floatInfo = mSquadFloatInfoPool.Require();
        //         floatInfo.SetSquad(squad);
        //         ((RectTransform)floatInfo.transform).anchoredPosition = new Vector2(pos.x, pos.y);
        //     }
        // }
        //
        // private void OnSquadSelect()
        // {
        //     selectedSquadNameText.text = $"当前选中：{Mod.Battlefield.selectedSquad.Info.Name}";
        // }
        //
        // private void OnNextSquadMove()
        // {
        //     currentSquadNameText.text = $"当前行动：{Mod.Battlefield.curMovingSquad.Info.Name}";
        // }
        //
        // private void OnSquadInitiativeRoll()
        // {
        //     mSquadInitiativePool.ClearLiving();
        //
        //     foreach (var squad in Mod.Battlefield.squadsSorted)
        //     {
        //         var ini = mSquadInitiativePool.Require();
        //         ini.Set(squad);
        //     }
        // }
        //
        // private void OnSquadMove()
        // {
        //     
        // }
        protected override void OnCreate()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnOpen()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnHide()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnClose()
        {
            throw new System.NotImplementedException();
        }
    }
}