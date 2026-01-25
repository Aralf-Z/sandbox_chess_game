using System.Collections.Generic;
using FastGameDev.Entity;

namespace Game
{
    public class TroopSetup: ComponentBase
    {
        public readonly List<SquadEntity> squads = new List<SquadEntity>();
    }
}