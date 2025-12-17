using System.Collections.Generic;
using FastGameDev.Record;

namespace Game
{
    public class TroopsBattlefieldRecord: RecordBase
    {
        public TroopsBattlefieldEntity battlefield;
        public Dictionary<GridPoint, SquadEntity> squads;
        public Dictionary<SquadEntity, GridPoint> squadsPoints;
        public TroopEntity allyTroop;
        public TroopEntity enemyTroop;
        public SquadEntity curActingSquad;
        public SquadEntity curSelectedSquad;
        
        protected override void Init()
        {
            squads = new Dictionary<GridPoint, SquadEntity>();
        }
    }
}