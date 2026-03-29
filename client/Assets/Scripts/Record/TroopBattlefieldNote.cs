using System.Collections.Generic;
using GameDev.Note;
using GameDev.Utility.Inspector;

namespace Game
{
    [Inspectable("军团战场记录")]
    public class TroopBattlefieldNote: NoteBase
    {
        public TroopBfEntity bf;
        public TroopEntity allyTroop;
        public TroopEntity enemyTroop;
        public SquadEntity curSquad;
        public SquadEntity selectedSquad;
        public GridPoint curPoint;
        public readonly List<SquadEntity> liveSquads = new ();
        
        protected override void Init()
        {
            
        }
    }
}