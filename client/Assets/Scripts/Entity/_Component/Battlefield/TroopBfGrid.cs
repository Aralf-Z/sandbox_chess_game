using System.Collections.Generic;
using GameDev.Entity;
using GameDev.Utility.Math;

namespace Game
{
    public class TroopBfGrid: ComponentBase
    {
        private readonly SimplePerlinNoise mPerlin;
        
        public int this[GridPoint point] => mPerlin.Get(point.X, point.Y) switch
        {
            < .65f => 80001,
            < .8f => 80002,
            _ => 80003
        };
        
        public TroopBfGrid()
        {
            const int scale = 5;
            mPerlin = new SimplePerlinNoise(scale);
        }
    }
}