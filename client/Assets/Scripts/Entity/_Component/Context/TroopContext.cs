using System.Collections.Generic;
using GameDev.Entity;

namespace Game
{
    public class TroopContext: ComponentBase
    {
        public readonly Dictionary<GridPoint, SquadEntity> squads = new ();
    }
}