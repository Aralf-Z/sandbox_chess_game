using System.Buffers;
using FastGameDev.Core;
using FastGameDev.Syztem;

namespace Game
{
    public class TroopBattleSystem: SystemBase
    {
        private TroopsBattlefieldRecord mBfRecord;
        
        protected override void Init()
        {
            mBfRecord = this.Record().Get<TroopsBattlefieldRecord>();
        }

        public void EnterBattle(TroopEntity ally, TroopEntity enemy, TroopBfEntity battlefield)
        {
            //todo temp code

            battlefield.Model.name = "troops_bf";
            battlefield.Model.Load();
            TroopInit(ally);
            TroopInit(enemy);
            
            //record
            mBfRecord.allyTroop = ally;
            mBfRecord.enemyTroop = enemy;
            mBfRecord.bf = battlefield;

            SetSquadsPositionOnBattlefield();
            foreach (var (_, squad) in ally.Context.squads)
            {
                squad.Model.name = "squad";
                squad.Model.Load();
                squad.Model.Transform.position = battlefield.SelfModel.GetWorldPosition(squad.Context.point);
            }
            foreach (var (_, squad) in enemy.Context.squads)
            {
                squad.Model.name = "squad";
                squad.Model.Load();
                squad.Model.Transform.position = battlefield.SelfModel.GetWorldPosition(squad.Context.point);
            }
            
            //related mode
            this.Module().Camera.ChangeCameraMode<CameraModeTroopsBf>();
            
            battlefield.Enter();
        }

        private void TroopInit(TroopEntity troop)
        {
            //SetUp => Context
            foreach (var squad in troop.Setup.squads)
            {
                squad.Context.characters.Clear();
                foreach (var (pos, character) in squad.Setup.characters)
                { squad.Context.characters.Add(pos, character); }
            }
            
            //Load Model
            foreach (var (_, squad) in troop.Context.squads)
            {
                squad.Model.name = "squad";
                squad.Model.Load();
            }
        }
        
        private void SetSquadsPositionOnBattlefield()
        {
            const int length = BattlefieldDefine.TROOP_BF_GRID_LENGTH;
            const int costMax = BattlefieldDefine.TROOP_BF_TILE_COST_MAX;
            const int tilesMaxLength = length * length;
            
            var random = new System.Random();
            var tbTile = this.Module().Config.Tables.TbTroopBfTile;
            var allyTiles = ArrayPool<GridPoint>.Shared.Rent(tilesMaxLength);
            var enemyTiles = ArrayPool<GridPoint>.Shared.Rent(tilesMaxLength);
            var atCount = 0;
            var etCount = 0;
            
            try
            {
                for (var x = 1; x <= length; x++)
                {
                    for (var y = 1; y <= length; y++)
                    {
                        var position = new GridPoint(x, y);
                        var cost = tbTile[mBfRecord.bf.Grid[position]].Cost;
                        
                        if (x <= BattlefieldDefine.ALLY_ENEMY_ROW_DIVISION)
                        {
                            if (cost <= costMax) allyTiles[atCount++] = position; 
                        }
                        else
                        {
                            if (cost <= costMax) enemyTiles[etCount++] = position;
                        }
                    }
                }
                
                foreach (var squad in mBfRecord.allyTroop.Setup.squads)
                {
                    var index = random.Next(atCount);
                    var point = allyTiles[index];
                    mBfRecord.allyTroop.Context.squads[point] = squad;
                    squad.Context.point = point;
                    allyTiles[index] = allyTiles[atCount--];
                }
                
                foreach (var squad in mBfRecord.enemyTroop.Setup.squads)
                {
                    var index = random.Next(etCount);
                    var point = enemyTiles[index];
                    mBfRecord.enemyTroop.Context.squads[point] = squad;
                    squad.Context.point = point;
                    enemyTiles[index] = enemyTiles[etCount--];
                }
            }
            finally
            {
                ArrayPool<GridPoint>.Shared.Return(allyTiles,true);
                ArrayPool<GridPoint>.Shared.Return(enemyTiles, true);
            }
        }
        
        public void ExiteBattle()
        {
            
        }

        public void SelectSquad(SquadEntity squad)
        {
            
        }

        public void SelectedSquadMove()
        {
            
        }

        public void CurrentSquadMove()
        {
            
        }

        public int SquadMoveCost(SquadEntity squad, GridPoint moveTo)
        {
            return 0;
        }

        public void AttackSquad(SquadEntity attacker, SquadEntity defender)
        {
            
        }

        public void NextSquadMove()
        {
            
        }

        private void RollSquadInitiative()
        {
            
        }
    }
}