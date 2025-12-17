using System;
using FastGameDev.Module;
using UnityEngine;

namespace Game
{
    public partial class BattlefieldUI : UIWindow
    {
        public override EmUIOrder Order => EmUIOrder.Normal;

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
        //     info.SetName(ae.Actor.Info.Name);
        // }

    }
}