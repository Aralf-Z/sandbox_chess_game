using FastGameDev.Core;
using FastGameDev.Module;
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
        
        protected override void OnCreate()
        {
            var sys = this.System().Get<TroopBattleSystem>();
            
            attackBtn.onClick.AddListener(sys.CurSquadAttack);
            skillBtn.onClick.AddListener(sys.CurSquadSkill);
            rushBtn.onClick.AddListener(sys.CurSquadRush);
            reorganizeBtn.onClick.AddListener(sys.CurSquadReorganize);
            waitBtn.onClick.AddListener(sys.CurSquadWait);
            escapeBtn.onClick.AddListener(sys.CurSquadEscape);
            endBtn.onClick.AddListener(sys.CurSquadEnd);
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