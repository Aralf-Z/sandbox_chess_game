using FastGameDev.Record;
using FastGameDev.Utility.Inspector;

namespace Game
{
    [Inspectable("小队战场记录")]
    public class SquadBattlefieldRecord: RecordBase
    {
        public SquadBfEntity bf;
        public SquadEntity allySquad;
        public SquadEntity enemySquad;
        
        protected override void Init()
        {
            
        }
    }
}