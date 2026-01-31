using FastGameDev.Core;
using FastGameDev.Syztem;
using UnityEngine;

namespace Game
{
    public class SquadBattleSystem: SystemBase
    {
        private SquadBattlefieldRecord mBfRecord;
        
        protected override void Init()
        {
            mBfRecord = this.Record().Get<SquadBattlefieldRecord>();
        }
        
        public void Attack(SquadEntity attacker, SquadEntity defender)
        {
            mBfRecord.allySquad = attacker.Info.stand is EmSquadStand.Ally ? attacker : defender;
            mBfRecord.enemySquad = attacker.Info.stand is EmSquadStand.Enemy ? attacker : defender;

            foreach (var (pos, character) in mBfRecord.allySquad.Context.characters)
            {
                switch (character)
                {
                    case AdventurerEntity ally: 
                        ally.Model.Transform.position = mBfRecord.bf.SelfModel.GetWorldPos(EmSquadStand.Ally, pos.row, pos.column);
                        ally.Model.Go.GetComponentInChildren<SpriteRenderer>().sortingOrder = SpriteOrderDefine.SQUAD_BATTLEFIELD_CHARACTER + (100 - (int)ally.Model.Transform.position.y) * 10;
                        break;
                    case AllyEntity ally: 
                        ally.Model.Transform.position = mBfRecord.bf.SelfModel.GetWorldPos(EmSquadStand.Ally, pos.row, pos.column);
                        ally.Model.Go.GetComponentInChildren<SpriteRenderer>().sortingOrder = SpriteOrderDefine.SQUAD_BATTLEFIELD_CHARACTER + (100 - (int)ally.Model.Transform.position.y) * 10;
                        break;
                }
            }
            foreach (var (pos, character) in mBfRecord.enemySquad.Context.characters)
            {
                var enemy = ((EnemyEntity)character);
                enemy.Model.Transform.position = mBfRecord.bf.SelfModel.GetWorldPos(EmSquadStand.Enemy, pos.row, pos.column);
                enemy.Model.Go.GetComponentInChildren<SpriteRenderer>().sortingOrder = SpriteOrderDefine.SQUAD_BATTLEFIELD_CHARACTER + (100 - (int)enemy.Model.Transform.position.y) * 10;
            }
            
            this.Module().Camera.ChangeCameraMode<CameraModeSquadBf>();
        }
    }
}