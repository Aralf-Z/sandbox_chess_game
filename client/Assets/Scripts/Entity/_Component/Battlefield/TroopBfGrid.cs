using System.Collections.Generic;
using FastGameDev.Entity;
using FastGameDev.Utility.Math;

namespace Game
{
    public class TroopBfGrid: ComponentBase
    {
        private readonly SimplePerlinNoise mPerlin;
        
        public int this[GridPoint point] => mPerlin.Get(point.X, point.Y) switch
        {
            < .65f => BattlefieldDefine.TROOP_BF_TILE_ID_PREFIX + 1,
            < .8f => BattlefieldDefine.TROOP_BF_TILE_ID_PREFIX + 2,
            _ => BattlefieldDefine.TROOP_BF_TILE_ID_PREFIX + 3
        };
        
        public TroopBfGrid()
        {
            const int scale = 5;
            mPerlin = new SimplePerlinNoise(scale);
        }
    }
}