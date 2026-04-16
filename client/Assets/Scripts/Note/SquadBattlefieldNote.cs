using GameDev.Note;
using GameDev.Utility.Inspector;

namespace Game
{
    [Inspectable("小队战场记录")]
    public class SquadBattlefieldNote: NoteBase
    {
        public Entity bf;
        public Entity allySquad;
        public Entity enemySquad;
        
        protected override void Init()
        {
            
        }
    }
}