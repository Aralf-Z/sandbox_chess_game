using System.Collections.Generic;
using GameDev.Note;
using GameDev.Utility.Inspector;

namespace Game
{
    [Inspectable("军团战场记录")]
    public class TroopBattlefieldNote: NoteBase
    {
        public Entity bf;
        public Entity allyTroop;
        public Entity enemyTroop;
        public Entity curSquad;
        public Entity selectedSquad;
        public GridPoint curPoint;
        public readonly List<Entity> liveSquads = new ();
        
        protected override void Init()
        {
            
        }
    }
}