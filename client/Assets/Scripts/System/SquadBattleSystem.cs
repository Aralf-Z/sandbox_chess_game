using System;
using FastGameDev.Core;
using FastGameDev.Syztem;

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
                        break;
                    case AllyEntity ally: 
                        ally.Model.Transform.position = mBfRecord.bf.SelfModel.GetWorldPos(EmSquadStand.Ally, pos.row, pos.column);
                        break;
                }
            }
            foreach (var (pos, character) in mBfRecord.enemySquad.Context.characters)
            {
                ((EnemyEntity)character).Model.Transform.position = mBfRecord.bf.SelfModel.GetWorldPos(EmSquadStand.Enemy, pos.row, pos.column);
            }
            
            this.Module().Camera.ChangeCameraMode<CameraModeSquadBf>();
        }
    }
}