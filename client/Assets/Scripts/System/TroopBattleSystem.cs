using FastGameDev.Core;
using FastGameDev.Syztem;

namespace Game
{
    public class TroopBattleSystem: SystemBase
    {
        private TroopsBattlefieldRecord mBfRecord;
        
        protected override void Init()
        {
            
        }

        public void EnterBattle(TroopEntity ally, TroopEntity enemy, TroopsBattlefieldEntity field)
        {
            this.Module().Camera.ChangeCameraMode<CameraModeTroopsBf>();
            mBfRecord.allyTroop = ally;
            mBfRecord.enemyTroop = enemy;
            mBfRecord.battlefield = field;
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