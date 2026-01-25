using System.Collections.Generic;
using FastGameDev.Record;

namespace Game
{
    public class TroopsBattlefieldRecord: RecordBase
    {
        public TroopBfEntity bf;
        public TroopEntity allyTroop;
        public TroopEntity enemyTroop;
        public SquadEntity curActingSquad;
        public SquadEntity curSelectedSquad;
        
        protected override void Init()
        {
            
        }
    }
}