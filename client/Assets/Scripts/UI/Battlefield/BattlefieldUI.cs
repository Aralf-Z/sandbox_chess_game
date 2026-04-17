using System;
using GameDev.Core;
using GameDev.Module;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public partial class BattlefieldUI : UIWindow
    , IGetSystem
    , IGetNote
    {
        public override EmUIOrder Order => EmUIOrder.Normal;
        
        public Button attackBtn;
        public Button skillBtn;
        public Button rushBtn;
        public Button reorganizeBtn;
        public Button waitBtn;
        public Button escapeBtn;
        public Button endBtn;
        
        public TroopBattleSystem mSystem;
        public TroopBattlefieldNote mNote;
        
        protected override void OnCreate()
        {
            mSystem = this.System().Get<TroopBattleSystem>();
            mNote = this.Note().Get<TroopBattlefieldNote>();
            
            attackBtn.onClick.AddListener(mSystem.CurSquadAttack);
            skillBtn.onClick.AddListener(mSystem.CurSquadSkill);
            rushBtn.onClick.AddListener(mSystem.CurSquadRush);
            reorganizeBtn.onClick.AddListener(mSystem.CurSquadReorganize);
            waitBtn.onClick.AddListener(mSystem.CurSquadWait);
            escapeBtn.onClick.AddListener(mSystem.CurSquadEscape);
            endBtn.onClick.AddListener(mSystem.CurSquadEnd);
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

        // private BattlefieldUIActorFloatInfo actorFloatInfoTemplate;
        //
        // private IObjectPool<BattlefieldUIActorFloatInfo>  mActorPool;
        //
        // private void Update()
        // {
        //     var dt = Time.deltaTime;
        //     SquadInfoOnUpdate(dt);
        // }
        //
        // protected override void OnInit()
        // {
        //     SquadInfoOnInit();
        //     actorFloatInfoTemplate.gameObject.SetActive(false);
        //     mActorPool = new MonoBehaviourPool<BattlefieldUIActorFloatInfo>(actorFloatInfoTemplate.transform.parent, actorFloatInfoTemplate.gameObject);
        // }
        //
        // protected override void OnOpen(object data)
        // {
        //     SquadInfoOnOpen();
        // }
        //
        // protected override void OnHide()
        // {
        //     SquadInfoOnHide();
        // }
        //
        // public void SetInfo(IActorEntity ae)
        // {
        //     var pos = Mod.Battlefield.curSquadBf.CameraBind.WorldPos2UIPos(this, ae.ObjectBind.Position.x, ae.ObjectBind.Position.y);
        //     var info = mActorPool.Require();
        //     ((RectTransform)info.transform).anchoredPosition = new Vector2(pos.x, pos.y);
        //     info.SetName(ae.Actor.LogInfo.Name);
        // }

    }
}