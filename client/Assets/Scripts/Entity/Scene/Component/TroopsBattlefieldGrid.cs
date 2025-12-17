using System.Collections.Generic;
using FastGameDev.Utility.Math;

namespace Game
{
    public class TroopsBattlefieldGrid
    {
        private readonly SimplePerlinNoise mPerlin;
        
        /// <summary>
        /// 1: 普通; 2: 困难; 0: 无法通过
        /// </summary>
        /// <param name="point"></param>
        public int this[GridPoint point] => mPerlin.Get(point.X, point.Y) switch
        {
            < .65f => 1,
            < .9f => 2,
            _ => 0
        };
        
        public TroopsBattlefieldGrid()
        {
            const int scale = 5;
            mPerlin = new SimplePerlinNoise(scale);
        }
    }
}