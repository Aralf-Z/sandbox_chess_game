using FastGameDev;
using FastGameDev.Core;
using FastGameDev.Helper;

namespace Game.Flow
{
    public class FlowDemo: FlowBase
    , IGetEntity
    , IGetModule
    {
        public int allyId = 71001;
        public int enemyId = 70001;

        public string troopsBfAsset = "troops_battlefield";
        public string 
        
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
            var bf = entity.RequireMonoEntity<TroopsBattlefieldEntity>(troopsBfAsset);
            foreach (var (squadName, squadStances) in tables.TbCampaign[allyId].Squads)
            {
                var squad = entity.RequireNormalEntity<SquadEntity>();
                squad.Info = new SquadInfo(squadName);
                //todo squad content
            }
            foreach (var (squadName, squadStances) in tables.TbCampaign[enemyId].Squads)
            {
                
            }
        }

        protected override void Check()
        {
            
        }

        protected override void Exit()
        {
            
        }
    }
}