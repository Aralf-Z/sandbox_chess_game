// using System.Collections.Generic;
// using Game.Core.Combat;
// using Game.Core.Interface;
// using GameDevKit.PureCSharp.Math;
//
// namespace Game.Logic
// {
//     public class PerlinLegionBattlefieldGrid:
//         ILegionBattlefieldGrid
//     {
//         private readonly SimplePerlinNoise mPerlin;
//         
//         public Dictionary<ISquad, GridPos> SquadPositions { get; } =  new Dictionary<ISquad, GridPos>();
//         public Dictionary<GridPos, ISquad> PositionSquad { get; } = new Dictionary<GridPos, ISquad>();
//
//         public EmTileType this[GridPos pos] => mPerlin.Get(pos.X, pos.Y) switch
//         {
//             <.65f => EmTileType.Normal,
//             <.9f => EmTileType.Tough,
//             _ => EmTileType.Block,
//         };
//
//         public void SquadMove(ISquad squad, GridPos position)
//         {
//             var originalPosition = SquadPositions[squad];
//             PositionSquad.Remove(originalPosition);
//             PositionSquad[position] = squad;
//             SquadPositions[squad] = position;
//         }
//
//         public PerlinLegionBattlefieldGrid(int seed, int scale = 5)
//         {
//             mPerlin = new SimplePerlinNoise(seed, scale);
//         }
//         
//         public PerlinLegionBattlefieldGrid(int scale = 5)
//         {
//             mPerlin = new SimplePerlinNoise(scale);
//         }
//     }
// }