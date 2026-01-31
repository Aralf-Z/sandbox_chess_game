using System.Linq;
using FastGameDev;
using FastGameDev.Core;
using FastGameDev.Helper;
using FastGameDev.Module;
using Game.Config;

namespace Game
{
    public class FlowDemo: FlowBase
        , IGetEntity
        , IGetRecord
        , IGetSystem
        , IGetModule
    {
        private GameRecord Record => this.Record();
        private GameSystem System => this.System();
        private GameEntity Entity => this.Entity();
        private AssetModule Asset => this.Module().Asset;
        private UIModule UI => this.Module().UI;
        private Tables Tables => this.Module().Config.Tables;
        
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
            
            var tbf = Entity.Require<TroopBfEntity>();
            var allyTroop = Entity.Require<TroopEntity>(allyId);
            var enemyTroop =  Entity.Require<TroopEntity>(enemyId);
            
            System.Get<TroopBattleSystem>().EnterBattle(allyTroop, enemyTroop, tbf);
            
            var sbf = Entity.Require<SquadBfEntity>();
            Record.Get<SquadBattlefieldRecord>().bf = sbf;
            System.Get<SquadBattleSystem>().Attack(allyTroop.Context.squads.First().Value, enemyTroop.Context.squads.First().Value);
            
            //UI.Open<BattlefieldUI>();
        }

        protected override void Check()
        {
            
        }

        protected override void Exit()
        {
            
        }
    }
}