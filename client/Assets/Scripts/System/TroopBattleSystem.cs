using FastGameDev.Core;
using FastGameDev.Syztem;

namespace Game
{
    public class TroopBattleSystem: SystemBase
    {
        protected override void Init()
        {
            
        }

        public void EnterBattle(TroopEntity ally, TroopEntity enemy, TroopsBattlefieldEntity field)
        {
            this.Module().Camera.ChangeCameraMode<CameraModeTroopsBf>();
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