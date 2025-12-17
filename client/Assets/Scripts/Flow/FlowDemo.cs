using FastGameDev;
using FastGameDev.Core;
using FastGameDev.Helper;

namespace Game
{
    public class FlowDemo: FlowBase
    , IGetEntity
    , IGetModule
    , IGetSystem
    {
        public int allyId = 71001;
        public int enemyId = 70001;

        public string troopsBfAsset = "troops_battlefield";
        
        protected override void Init()
        {
            
        }

        protected override void Enter()
        {
            LogHelper.Info("Demo 开始", "流程");
            //todo
            //创建 "军团战斗地图"
            //创建 友方军团 和 敌方军团
            //敌方军团随机位置
            //我方军团随机位置
            //TroopsBattleSystem.EnterBattle()
            
            var entity = this.Entity();
            var tables = this.Module().Config.Tables;
            var tbf = entity.RequireMonoEntity<TroopsBattlefieldEntity>(troopsBfAsset);
            var allyTroop = entity.RequireNormalEntity<TroopEntity>(allyId);
            var enemyTroop =  entity.RequireNormalEntity<TroopEntity>(enemyId);
            
            this.System().Get<TroopBattleSystem>().EnterBattle(allyTroop, enemyTroop, tbf);
            this.Module().UI.Open<BattlefieldUI>();
        }

        protected override void Check()
        {
            
        }

        protected override void Exit()
        {
            
        }
    }
}