using System.Collections.Generic;

namespace Game
{
    public class TroopsContext
    {
        private readonly Dictionary<GridPoint, SquadEntity> mSquads = new Dictionary<GridPoint, SquadEntity>();

        public SquadEntity this[GridPoint point]
        {
            get => mSquads.GetValueOrDefault(point, null);
            set => mSquads[point] = value;
        }
        
        public GridPoint gridPoint;
    }
}