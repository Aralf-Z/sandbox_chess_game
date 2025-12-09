// using System.Buffers;
// using System.Collections.Generic;
// using Game.Core.Combat;
// using Game.Core.Framework;
// using Game.Core.Interface;
// using Game.Logic.WorldBind;
// using UnityEngine;
// using GameDevKit.PureCSharp.ObjectPool;
//
// namespace Game.Logic
// {
//     public sealed class LegionBattlefield:
//         ILegionBattlefield
//     {
//         private readonly GameObject mRoot;
//         private readonly LegionBattlefieldBind mBfBind;
//         private readonly LegionBfCameraBind mSelfCamera;
//         private readonly SquadPool mSquadPool = new SquadPool();
//         private readonly Dictionary<ISquad, SquadEntity> mSquadsMap = new Dictionary<ISquad, SquadEntity>();
//         
//         public LegionBattlefield()
//         {
//             mRoot = new GameObject("LegionBattlefieldMap");
//             mBfBind = new LegionBattlefieldBind();
//             mSelfCamera = new LegionBfCameraBind();
//             
//             mBfBind.SelfGo.transform.SetParent(mRoot.transform);
//             mSelfCamera.Camera.transform.SetParent(mRoot.transform);
//             
//             mRoot.transform.position = new Vector2(-100, 0);
//
//             CameraBind.Enabled = false;
//         }
//         
//         public ILegionBattlefieldGrid LegionBattlefieldGrid { get; private set; }
//         public IObjectBind ObjectBind => mBfBind;
//         public ICameraBind CameraBind => mSelfCamera;
//         
//         public void Enter()
//         {
//             LegionBattlefieldGrid = new PerlinLegionBattlefieldGrid();
//             SetSquadPosition();
//             RefreshWorldBind();
//         }
//         
//         public void Exit()
//         {
//             mSquadPool.ClearLiving();
//             LegionBattlefieldGrid = null;
//         }
//         
//         private void SetSquadPosition()
//         {
//             const int tilesMaxLength = ILegionBattlefieldGrid.GRID_LENGTH * ILegionBattlefieldGrid.GRID_LENGTH;
//
//             var bfm = Mod.Battlefield;
//             var random = new System.Random();
//             var allyTiles = ArrayPool<GridPos>.Shared.Rent(tilesMaxLength);
//             var enemyTiles = ArrayPool<GridPos>.Shared.Rent(tilesMaxLength);
//             var atCount = 0;
//             var etCount = 0;
//             
//             LegionBattlefieldGrid.PositionSquad.Clear();
//             try
//             {
//                 for (var x = 1; x <= ILegionBattlefieldGrid.GRID_LENGTH; x++)
//                 {
//                     for (var y = 1; y <= ILegionBattlefieldGrid.GRID_LENGTH; y++)
//                     {
//                         var position = new GridPos(x, y);
//                         if (x <= ILegionBattlefieldGrid.ALLY_ENEMY_ROW_DIVISION)
//                         {
//                             if (LegionBattlefieldGrid[position] is not EmTileType.Block)
//                                 allyTiles[atCount++] = position;
//                         }
//                         else
//                         {
//                             if (LegionBattlefieldGrid[position] is not EmTileType.Block)
//                                 enemyTiles[etCount++] = position;
//                         }
//                     }
//                 }
//                 foreach (var squad in bfm.allyLegion.Squads.AllSquads.Keys)
//                 {
//                     var index = random.Next(atCount);
//                     var gridPos = allyTiles[index];
//                     LegionBattlefieldGrid.SquadPositions[squad] = gridPos;
//                     LegionBattlefieldGrid.PositionSquad[gridPos] = squad;
//                     allyTiles[index] = allyTiles[atCount--];
//                 }
//                 foreach (var squad in bfm.enemyLegion.Squads.AllSquads.Keys)
//                 {
//                     var index = random.Next(etCount);
//                     var gridPos = enemyTiles[index];
//                     LegionBattlefieldGrid.SquadPositions[squad] = gridPos;
//                     LegionBattlefieldGrid.PositionSquad[gridPos] = squad;
//                     enemyTiles[index] = enemyTiles[etCount--];
//                 }
//             }
//             finally
//             {
//                 ArrayPool<GridPos>.Shared.Return(allyTiles,true);
//                 ArrayPool<GridPos>.Shared.Return(enemyTiles, true);
//             }
//         }
//         
//         private void RefreshWorldBind()
//         {
//             mSquadPool.ClearLiving();
//             mBfBind.RefreshTiles(LegionBattlefieldGrid);
//             mSquadsMap.Clear();
//             foreach (var kv in LegionBattlefieldGrid.SquadPositions)
//             {
//                 var tgo = mSquadPool.Get();
//                 mSquadsMap.Add(kv.Key, tgo);
//                 tgo.SetSquad(kv.Key);
//                 RefreshSquadPosition(kv.Key, kv.Value);
//             }
//         }
//         
//         public void RefreshSquadPosition(ISquad squad, GridPos position)
//         {
//             var squadE = mSquadsMap[squad];
//             squadE.ObjectBind.Position = mBfBind.WorldPosition(position);
//         }
//
//         public ISquadEntity GetSquadEntity(ISquad squad)
//         {
//             return mSquadsMap[squad];
//         }
//
//         public void RefreshSelectedTips()
//         {
//             if (Mod.Battlefield.IsTheCurTheSelected)
//             {
//                 mBfBind.OnCurSquadMoveTips(ReachableSearch(Mod.Battlefield.curMovingSquad));
//             }
//
//             var gridPos = LegionBattlefieldGrid.SquadPositions[Mod.Battlefield.selectedSquad];
//             mBfBind.OnSelectSquadTips(gridPos);
//             mSelfCamera.Position = mBfBind.WorldPosition(gridPos);
//         }
//         
//         private List<(GridPos position, bool isReachable)> ReachableSearch(ISquad squad)
//         {
//             const int maxCost = 9999;
//             var pos = LegionBattlefieldGrid.SquadPositions[squad];
//             var checkedMap = new Dictionary<GridPos, int>(){[pos] = 0};
//             var movement = (int)squad.Resource[EmResAttri.Movement];
//             var result = new List<(GridPos pos, bool isReachable)>(movement * 4);
//             var curCheck = new List<GridPos>(){pos};
//             var tempCheck = new List<GridPos>();
//             for (var i = 1; i <= movement + 1; i++)//要获得移动力+1的单元格
//             {
//                 foreach (var cur in curCheck)
//                 {
//                     if(checkedMap[cur] > movement)
//                         continue;
//                     var p1 = new GridPos(cur.X + 1, cur.Y);
//                     var p2 = new GridPos(cur.X - 1, cur.Y);
//                     var p3 = new GridPos(cur.X, cur.Y + 1);
//                     var p4 = new GridPos(cur.X, cur.Y - 1);
//                     AddNoChecked(p1); AddNoChecked(p2); AddNoChecked(p3); AddNoChecked(p4);
//                 }
//                 curCheck.Clear();
//                 foreach (var check in tempCheck)
//                 { curCheck.Add(check); }
//                 tempCheck.Clear();
//
//                 foreach (var thePos in curCheck)
//                 {
//                     var selfCost = CheckMovementCost(thePos);
//                     var nei1Cost = checkedMap.GetValueOrDefault(thePos + new GridPos( 1, 0), maxCost);
//                     var nei2Cost = checkedMap.GetValueOrDefault(thePos + new GridPos(-1, 0), maxCost);
//                     var nei3Cost = checkedMap.GetValueOrDefault(thePos + new GridPos( 0, 1), maxCost);
//                     var nei4Cost = checkedMap.GetValueOrDefault(thePos + new GridPos( 0,-1), maxCost);
//                     var min1Cost = nei1Cost < nei2Cost ? nei1Cost : nei2Cost;
//                     var min2Cost = nei3Cost < nei4Cost ? nei3Cost : nei4Cost;
//                     var neiCost = min1Cost < min2Cost ? min1Cost : min2Cost;
//                     var sumCost = neiCost + selfCost;
//                     var reachable = sumCost <= movement;
//                     checkedMap.Add(thePos, sumCost);
//                     result.Add((thePos, reachable));
//                 }
//             }
//             
//             return result;
//             
//             //地块三种：无遮挡地形（移动力消耗1）、困难地形（移动力消耗2）、遮挡地形（无法通过）；
//             //特殊地块：敌方占领地块无法通过，友方占领的地块移动力消耗*2；
//             int CheckMovementCost(GridPos checkPos)
//             {
//                 var specialCost = 1;
//                 if (LegionBattlefieldGrid.PositionSquad.TryGetValue(checkPos, out var tarSquad))
//                 {
//                     specialCost = tarSquad.Legion == squad.Legion ? 2 : maxCost;
//                 }
//                 
//                 return (int)LegionBattlefieldGrid[checkPos] * specialCost;
//             }
//
//             void AddNoChecked(GridPos checkPos)
//             {
//                 if(tempCheck.Contains(checkPos) || checkedMap.ContainsKey(checkPos))
//                     return;
//                 if(checkPos.X is < 1 or > ILegionBattlefieldGrid.GRID_LENGTH)
//                     return;
//                 if(checkPos.Y is < 1 or > ILegionBattlefieldGrid.GRID_LENGTH)
//                     return;
//                 tempCheck.Add(checkPos);
//             }
//         }
//         
//         private class SquadPool
//         {
//             private ObjectPool<SquadEntity> mPool = new ();
//
//             public SquadEntity Get()
//             {
//                 var e = mPool.Require();
//                 
//                 if (e.ObjectBind == null)
//                 { 
//                     var gobind = new SquadBind("black_warrior");
//                     e.SetObjectBind(gobind);
//                 }
//                 
//                 return e;
//             }
//
//             public void ClearLiving()
//             {
//                 mPool.ClearLiving();
//             }
//         }
//     }
// }