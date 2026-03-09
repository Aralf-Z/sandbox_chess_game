using System.Buffers;
using FastGameDev.Core;
using FastGameDev.Syztem;
using FastGameDev.Utility.Math;

namespace Game
{
    public class TroopBattleSystem: SystemBase
    {
        private TroopBattlefieldRecord mBfRecord;
        private Dice mDice;
        
        protected override void Init()
        {
            mBfRecord = this.Record().Get<TroopBattlefieldRecord>();

            mDice = new Dice();
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
            this.Module().Camera.ChangeCameraMode<CameraModeTroopBf>();

            var length = BattlefieldDefine.TROOP_BF_GRID_LENGTH;
            var startPoint = length % 2 == 0 ? length / 2 : length / 2 + 1;
            
            mBfRecord.curPoint = new GridPoint(startPoint, startPoint);
            
            RollSquadInitiative();
            
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
                    mBfRecord.liveSquads.Add(squad);
                    squad.Context.point = point;
                    allyTiles[index] = allyTiles[atCount--];
                }
                
                foreach (var squad in mBfRecord.enemyTroop.Setup.squads)
                {
                    var index = random.Next(etCount);
                    var point = enemyTiles[index];
                    mBfRecord.enemyTroop.Context.squads[point] = squad;
                    mBfRecord.liveSquads.Add(squad);
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
        
        public void ExitBattle()
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
            var dice = new Dices(20);
            
            foreach (var squad in mBfRecord.liveSquads)
            {
                var initiative = squad.Attribute.Int(PanelAttri.INITIATIVE) + mDice.RollSum(dice);
                squad.Context.initiative =  initiative;
            }
            
            SortLiveSquadsByInitiative();
            mBfRecord.selectedSquad = mBfRecord.curSquad = mBfRecord.liveSquads[0];//todo 长度可能会<1？
        }

        private void SortLiveSquadsByInitiative()
        {
            //todo 排序可能不会稳定，隐性的bug？
            mBfRecord.liveSquads.Sort((a, b) =>
                (a.Context.initiative * 10000 + a.Attribute.Float(PanelAttri.INITIATIVE))
                    .CompareTo(b.Context.initiative * 10000 + b.Attribute.Float(PanelAttri.INITIATIVE)));
        }
        
        private void SearchNextSquad()
        {
            var find = false;
            
            foreach (var squad in mBfRecord.liveSquads)
            {
                if (find)
                {
                    mBfRecord.selectedSquad = mBfRecord.curSquad = squad;
                    break;
                }
                find = squad == mBfRecord.curSquad;
            }
        }

        public void CurSquadAttack()
        {
            
        }
        
        public void CurSquadSkill()
        {
            
        }
        
        public void CurSquadRush()
        {
            
        }
        
        public void CurSquadReorganize()
        {
            
        }
        
        public void CurSquadWait()
        {
            
        }
        
        public void CurSquadEscape()
        {
            
        }
        
        public void CurSquadEnd()
        {
            
        }
    }
}