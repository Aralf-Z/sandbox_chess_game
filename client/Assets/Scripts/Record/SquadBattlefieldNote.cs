using FastGameDev.Note;
using FastGameDev.Utility.Inspector;

namespace Game
{
    [Inspectable("小队战场记录")]
    public class SquadBattlefieldNote: NoteBase
    {
        public SquadBfEntity bf;
        public SquadEntity allySquad;
        public SquadEntity enemySquad;
        
        protected override void Init()
        {
            
        }
    }
}