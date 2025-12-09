using FastGameDev.Core;
using FastGameDev.Helper;

namespace Game.Flow
{
    public class FlowDemo: FlowBase
    , IGetEntity
    {
        protected override void Init()
        {
            
        }

        protected override void Enter()
        {
            LogHelper.Info("Demo 开始", "流程");
            //todo
            //创建 "军团战斗地图"
            var bf = this.Entity().RequireMonoEntity<TroopsBattlefieldEntity>("troops_battlefield");
            //创建 友方军团 和 敌方军团
            //敌方军团随机位置
            //我方军团随机位置
            //TroopsBattleSystem.EnterBattle()
        }

        protected override void Check()
        {
            
        }

        protected override void Exit()
        {
            
        }
    }
}