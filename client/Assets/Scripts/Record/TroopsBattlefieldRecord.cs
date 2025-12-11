using FastGameDev.Record;

namespace Game
{
    public class TroopsBattlefieldRecord: RecordBase
    {
        public TroopsBattlefieldEntity battlefield;
        public TroopEntity allyTroop;
        public TroopEntity enemyTroop;
        public SquadEntity curActingSquad;
        public SquadEntity curSelectedSquad;
        
        protected override void Init()
        {
            
        }
    }
}