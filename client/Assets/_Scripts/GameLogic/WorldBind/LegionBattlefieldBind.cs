// using System;
// using System.Collections.Generic;
// using Game.Core.Interface;
// using UnityEngine;
// using ZToolKit;
// using GameDevKit.PureCSharp.ObjectPool;
// using Object = UnityEngine.Object;
//
// namespace Game.Logic.WorldBind
// {
//     public sealed class LegionBattlefieldBind: GameObjectBind
//     {
//         private const string kNormalTile = "tile_normal";
//         private const string kReachableTipTile = "tip_tile_reachable";
//         private const string kUnreachableTipTile = "tip_tile_unreachable";
//         
//         private readonly Dictionary<GridPos, SpriteRenderer> mTiles =  new Dictionary<GridPos, SpriteRenderer>();
//         private readonly ObjectPool<ReachableTipTile> mReachableTipTilePool = new ();
//         private readonly ObjectPool<UnreachableTipTile> mUnreachableTipTilePool = new ();
//         private readonly GameObject mOnSelectTipTile;
//         
//         public LegionBattlefieldBind()
//         {
//             var tile = ResTool.Load<GameObject>(kNormalTile);
//             
//             SelfGo = new GameObject("LegionBattlefield");
//             for (var i = 1; i <= ILegionBattlefieldGrid.TROOP_BF_GRID_LENGTH; i++)
//             {
//                 for (var j = 1; j <= ILegionBattlefieldGrid.TROOP_BF_GRID_LENGTH; j++)
//                 {
//                     var position = new GridPos(i, j);
//                     var gt = Object.Instantiate(tile, SelfGo.transform);
//                     var renderer = gt.GetComponent<SpriteRenderer>();
//                     var worldPos = WorldPosition(position);
//                     gt.name = $"{i}_{j}";
//                     gt.transform.position = new Vector3(worldPos.x, worldPos.y, 0);
//                     renderer.sortingOrder = SpriteOrderDefine.TROOP_BATTLEFIELD_TILE;
//                     mTiles.Add(position, renderer);
//                 }
//             }
//
//             var prefab = ResTool.Load<GameObject>("tip_tile_on_select");
//             mOnSelectTipTile = Object.Instantiate(prefab, SelfGo.transform);
//             var spriteRenderer = mOnSelectTipTile.GetComponent<SpriteRenderer>();
//             spriteRenderer.sortingOrder = SpriteOrderDefine.TROOP_BATTLEFIELD_TIP_TILE;
//             mOnSelectTipTile.SetActive(false);
//         }
//
//         public void RefreshTiles(ILegionBattlefieldGrid grid)
//         {
//             //无遮挡地形(白色)、困难地形（绿色）、遮挡地形（深黑色）
//             foreach (var kv in mTiles)
//             {
//                 var pos = kv.Key;
//                 var renderer = kv.Value;
//                 var type = grid[pos];
//                 renderer.color = type switch
//                 {
//                     EmTileType.Normal => Color.white,
//                     EmTileType.Tough => Color.green,
//                     EmTileType.Block => Color.black,
//                     _ => throw new ArgumentOutOfRangeException()
//                 };
//             }
//         }
//
//         public void OnCurSquadMoveTips(List<(GridPos position, bool isReachable)> reachable)
//         {
//             //可到达位置淡蓝色，可到达位置+1淡红色
//             mReachableTipTilePool.ClearLiving();
//             mUnreachableTipTilePool.ClearLiving();
//
//             foreach (var info in reachable)
//             {
//                 TipTile tile = info.isReachable ? mReachableTipTilePool.Require() : mUnreachableTipTilePool.Require();
//                 var worldPos = WorldPosition(info.position);
//                 tile.GameObject.name = $"tip_{info.position}";
//                 tile.GameObject.transform.SetParent(SelfGo.transform);
//                 tile.GameObject.transform.position = new Vector3(worldPos.x, worldPos.y, 0);
//                 if(tile is ReachableTipTile reachableTipTile)
//                     reachableTipTile.TileClicked.gridPosition = (info.position);
//             }
//         }
//
//         public void OnSelectSquadTips(GridPos position)
//         {
//             var onSelectWorldPos = WorldPosition(position);
//             mOnSelectTipTile.transform.position = new Vector3(onSelectWorldPos.x, onSelectWorldPos.y, 0);
//             mOnSelectTipTile.SetActive(true);
//         }
//         
//         public (float x, float y) WorldPosition (GridPos position)
//         {
//             const float offset = ILegionBattlefieldGrid.TROOP_BF_GRID_LENGTH / 2f + 1;
//             return (position.X - offset + Position.x, position.Y - offset + Position.y);
//         }
//
//         private abstract class TipTile
//         {
//             public GameObject GameObject {get; protected set;}
//             public SpriteRenderer Renderer {get; protected set;}
//         }
//         
//         private class ReachableTipTile: TipTile,
//             IHaveClickedBind,
//             IObject<ReachableTipTile>
//         {
//             public TileClicked TileClicked { get; private set;}
//             public IClicked Clicked => TileClicked;
//             
//             bool IObject<ReachableTipTile>.IsCollected { get; set; }
//             void IObject<ReachableTipTile>.OnNew()
//             {
//                 GameObject = Object.Instantiate(ResTool.Load<GameObject>(kReachableTipTile));
//                 Renderer = GameObject.GetComponent<SpriteRenderer>();
//                 TileClicked = GameObject.GetComponent<TileClicked>();
//                 Renderer.sortingOrder = SpriteOrderDefine.TROOP_BATTLEFIELD_TIP_TILE;
//                 
//             }
//
//             void IObject<ReachableTipTile>.OnRequire()
//             {
//                 GameObject.SetActive(true);
//             }
//
//             void IObject<ReachableTipTile>.OnRecycle()
//             {
//                 GameObject.SetActive(false);
//             }
//         }
//         
//         private class UnreachableTipTile: TipTile,
//             IObject<UnreachableTipTile>
//         {
//             bool IObject<UnreachableTipTile>.IsCollected { get; set; }
//             void IObject<UnreachableTipTile>.OnNew()
//             {
//                 GameObject = Object.Instantiate(ResTool.Load<GameObject>(kUnreachableTipTile));
//                 Renderer = GameObject.GetComponent<SpriteRenderer>();
//                 Renderer.sortingOrder = SpriteOrderDefine.TROOP_BATTLEFIELD_TIP_TILE;
//             }
//
//             void IObject<UnreachableTipTile>.OnRequire()
//             {
//                 GameObject.SetActive(true);
//             }
//
//             void IObject<UnreachableTipTile>.OnRecycle()
//             {
//                 GameObject.SetActive(false);
//             }
//         }
//     }
// }