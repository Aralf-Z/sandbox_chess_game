using System;
using System.Buffers;
using GameDev.Core;
using GameDev.Entity;
using GameDev.Syztem;
using GameDev.Utility.Math;
using UnityEngine;

namespace Game
{
    public class TroopBattleSystem: SystemBase
    {
        public event Action Evt_OnCurrentPointChanged;
        
        private TroopBattlefieldNote mBfNote;
        private Dice mDice;
        
        protected override void Init()
        {
            mBfNote = this.Note().Get<TroopBattlefieldNote>();

            mDice = new Dice();
        }

        public void EnterBattle(TroopBfGrid grid, TroopInfo allyInfo, TroopSetup allySetup, TroopContext allyCtx, TroopInfo enemyInfo, TroopSetup enemySetup, TroopContext enemyCtx)
        {
            //todo temp code
            
            //note
            mBfNote.grid = grid;
            mBfNote.allyInfo = allyInfo;
            mBfNote.enemyInfo = enemyInfo;
            
            SetSquadsPosOnBf(allySetup, enemySetup);
            
            var tModel = grid.GetSibling<TroopBfModel>();
            TroopInit(tModel, allySetup, allyCtx);
            TroopInit(tModel, enemySetup, enemyCtx);
            
            //related mode
            RollSquadInitiative();
            this.Module().Camera.ChangeCameraMode<CameraModeTroopBf>();
            
            void TroopInit(TroopBfModel model, TroopSetup setup, TroopContext ctx)
            {
                //Setup => Context
                
                foreach (var squad in setup.squads)
                {
                    var squadSetup = squad.Get<SquadSetup>();
                    var squadCtx = squad.Get<SquadContext>();
                    var squadModel = squad.Get<SquadModel>();
                
                    squadCtx.characters.Clear();
                    foreach (var (pos, character) in squadSetup.characters)
                    {
                        squadCtx.characters.Add(pos, character);
                        squadModel.SetIn(character);
                    }
                }

                foreach (var (pos, squad) in ctx.squads)
                {
                    var sqModel = squad.Get<WorldModel>();
                    sqModel.Position = model.GetWorldPosition(pos);
                }
            }
        }
        
        private void SetSquadsPosOnBf(TroopSetup ally, TroopSetup enemy)
        {
            const int length = BattlefieldDefine.TROOP_BF_GRID_LENGTH;
            const int costMax = BattlefieldDefine.TROOP_BF_TILE_COST_MAX;
            const int tilesMaxLength = length * length;
            
            var allyCtx = mBfNote.allyInfo.GetSibling<TroopContext>();
            var enemyCtx = mBfNote.enemyInfo.GetSibling<TroopContext>();
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
                        var cost = tbTile[mBfNote.grid[position]].Cost;
                        
                        if (y <= BattlefieldDefine.ALLY_ENEMY_ROW_DIVISION)
                        {
                            if (cost <= costMax) allyTiles[atCount++] = position; 
                        }
                        else
                        {
                            if (cost <= costMax) enemyTiles[etCount++] = position;
                        }
                    }
                }
                
                foreach (var squad in ally.squads)
                {
                    var index = random.Next(atCount);
                    var point = allyTiles[index];
                    var ctx = squad.Get<SquadContext>();
                    allyCtx.squads[point] = squad;
                    mBfNote.liveSquads.Add(new SquadBattleAspect(squad));
                    ctx.point = point;
                    allyTiles[index] = allyTiles[atCount--];
                }
                
                foreach (var squad in enemy.squads)
                {
                    var index = random.Next(etCount);
                    var point = enemyTiles[index];
                    var ctx = squad.Get<SquadContext>();
                    enemyCtx.squads[point] = squad;
                    mBfNote.liveSquads.Add(new SquadBattleAspect(squad));
                    ctx.point = point;
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

        // public void SelectSquad(SquadEntity squad)
        // {
        //     
        // }
        //
        // public void SelectedSquadMove()
        // {
        //     
        // }
        //
        // public void CurrentSquadMove()
        // {
        //     
        // }
        //
        // public int SquadMoveCost(SquadEntity squad, GridPoint moveTo)
        // {
        //     return 0;
        // }
        //
        // public void AttackSquad(SquadEntity attacker, SquadEntity defender)
        // {
        //     
        // }

        public void NextSquadMove()
        {
            
        }

        private void RollSquadInitiative()
        {
            var dice = new Dices(20);
            
            foreach (var squad in mBfNote.liveSquads)
            {
                var initiative = squad.attri.Int(PanelAttri.INITIATIVE) + mDice.RollSum(dice);
                squad.ctx.initiative =  initiative;
            }
            
            // todo 排序可能不会稳定，隐性的bug？
            mBfNote.liveSquads.Sort((a, b) =>
                (a.ctx.initiative * 10000 + a.attri.Float(PanelAttri.INITIATIVE))
                .CompareTo(b.ctx.initiative * 10000 + b.attri.Float(PanelAttri.INITIATIVE)));
            
            mBfNote.selectedSquad = mBfNote.currentSquad = mBfNote.liveSquads[0];//todo 长度可能会<1？
            SelectTile(mBfNote.selectedSquad.ctx.point);
        }
        
        private void SearchNextSquad()
        {
            var find = false;
            
            foreach (var squad in mBfNote.liveSquads)
            {
                if (find)
                {
                    mBfNote.selectedSquad = mBfNote.currentSquad = squad;
                    break;
                }
                find = squad == mBfNote.currentSquad;
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

        public void SelectTile(GridPoint point)
        {
            var x = Mathf.Clamp(point.X, 1, BattlefieldDefine.TROOP_BF_GRID_LENGTH);
            var y = Mathf.Clamp(point.Y, 1, BattlefieldDefine.TROOP_BF_GRID_LENGTH);
            
            mBfNote.currentPoint = new GridPoint(x,y);
            Evt_OnCurrentPointChanged?.Invoke();
        }
    }
}