using System.Collections.Generic;
using GameDev.Note;
using GameDev.Utility.Inspector;

namespace Game
{
    [Inspectable("军团战场记录")]
    public class TroopBattleNote: NoteBase
    {
        public TroopBfGrid grid;
        
        public TroopInfo allyInfo;
        public TroopContext allyCtx;

        public TroopInfo enemyInfo;
        public TroopContext enemyCtx;

        public SquadBattleAspect currentSquad;
        public SquadBattleAspect selectedSquad;
        
        public GridPoint currentPoint;
        
        public readonly List<SquadBattleAspect> liveSquads = new ();
        
        protected override void Init()
        {
            
        }
    }
}