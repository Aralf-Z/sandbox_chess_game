using GameDev.Core;
using GameDev.Syztem;
using UnityEngine;

namespace Game
{
    public class SquadBattleSystem: SystemBase
    {
        private SquadBattlefieldNote mBfNote;
        
        protected override void Init()
        {
            mBfNote = this.Note().Get<SquadBattlefieldNote>();
        }

        public void Attack(SquadEntity attacker, SquadEntity defender)
        {
            mBfNote.allySquad = attacker.Info.stand is EmSquadStand.Ally ? attacker : defender;
            mBfNote.enemySquad = attacker.Info.stand is EmSquadStand.Enemy ? attacker : defender;

            foreach (var (pos, character) in mBfNote.allySquad.Context.characters)
            {
                switch (character)
                {
                    case AdventurerEntity ally: 
                        ally.Model.Transform.position = mBfNote.bf.SelfModel.GetWorldPos(EmSquadStand.Ally, pos.row, pos.column);
                        ally.Model.Go.GetComponentInChildren<SpriteRenderer>().sortingOrder = SpriteOrderDefine.SQUAD_BATTLEFIELD_CHARACTER + (100 - (int)ally.Model.Transform.position.y) * 10;
                        break;
                    case AllyEntity ally: 
                        ally.Model.Transform.position = mBfNote.bf.SelfModel.GetWorldPos(EmSquadStand.Ally, pos.row, pos.column);
                        ally.Model.Go.GetComponentInChildren<SpriteRenderer>().sortingOrder = SpriteOrderDefine.SQUAD_BATTLEFIELD_CHARACTER + (100 - (int)ally.Model.Transform.position.y) * 10;
                        break;
                }
            }
            foreach (var (pos, character) in mBfNote.enemySquad.Context.characters)
            {
                var enemy = ((EnemyEntity)character);
                enemy.Model.Transform.position = mBfNote.bf.SelfModel.GetWorldPos(EmSquadStand.Enemy, pos.row, pos.column);
                enemy.Model.Go.GetComponentInChildren<SpriteRenderer>().sortingOrder = SpriteOrderDefine.SQUAD_BATTLEFIELD_CHARACTER + (100 - (int)enemy.Model.Transform.position.y) * 10;
            }
            
            this.Module().Camera.ChangeCameraMode<CameraModeSquadBf>();
        }
    }
}