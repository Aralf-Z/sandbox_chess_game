using System.Collections.Generic;

namespace Game
{
    public class TroopSquads: ISquads
    {
        public List<SquadEntity> AllSquads { get; } = new List<SquadEntity>();
    }
}