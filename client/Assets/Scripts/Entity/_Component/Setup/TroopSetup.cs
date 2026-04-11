using System.Collections.Generic;
using GameDev.Entity;

namespace Game
{
    public class TroopSetup: ComponentBase
    {
        public readonly List<Entity> squads = new List<Entity>();
    }
}