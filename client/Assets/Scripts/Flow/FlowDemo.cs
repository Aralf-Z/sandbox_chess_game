using System.Linq;
using GameDev;
using GameDev.Core;
using GameDev.Helper;
using GameDev.Module;
using Game.Config;
using Game.Config.Character;

namespace Game
{
    public class FlowDemo: FlowBase
        , IGetEntity
        , IGetNote
        , IGetSystem
        , IGetModule
    {
        private GameNote Note => this.Note();
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
            Logger.LogInfo("Demo 开始", "流程");


            var tbf = EntityFactory.RequireTroopBf();
            var allyTroop = EntityFactory.RequireTroop(allyId);
            var enemyTroop =  EntityFactory.RequireTroop(enemyId);
            
            System.Get<TroopBattleSystem>().EnterBattle(tbf.Get<TroopBfGrid>(), allyTroop.Get<TroopInfo>(),allyTroop.Get<TroopSetup>(), allyTroop.Get<TroopContext>(),
                enemyTroop.Get<TroopInfo>(),enemyTroop.Get<TroopSetup>(), enemyTroop.Get<TroopContext>());
            
            UI.Open<BattlefieldUI>();
            UI.Open<DebugUI>();
            
            // var sbf = Entity.Require<SquadBfEntity>();
            // Note.Get<SquadBattlefieldNote>().bf = sbf;
            // System.Get<SquadBattleSystem>().Attack(allyTroop.Context.squads.First().Value, enemyTroop.Context.squads.First().Value);
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