// using System.Collections.Generic;
// using Game.Core.Interface;
// using UnityEngine;
// using ZToolKit;
// using ZToolKit.UnityImpl;
//
// namespace Game.Logic.WorldBind
// {
//     public sealed class SquadBattlefieldBind:
//         GameObjectBind
//     {
//         private static readonly Dictionary<(int r, int c), Color> Colors = new Dictionary<(int r, int c), Color>()
//         {
//             [(0,0)] = Color.white,
//             [(1,1)] = "#55efc4".Hex2Color(),
//             [(1,2)] = "#81ecec".Hex2Color(),
//             [(1,3)] = "#74b9ff".Hex2Color(),
//             [(1,4)] = "#a29bfe".Hex2Color(),
//             [(1,5)] = "#e17055".Hex2Color(),
//             [(1,6)] = "#00b894".Hex2Color(),
//             [(2,1)] = "#00cec9".Hex2Color(),
//             [(2,2)] = "#0984e3".Hex2Color(),
//             [(2,3)] = "#6c5ce7".Hex2Color(),
//             [(2,4)] = "#b2bec3".Hex2Color(),
//             [(2,5)] = "#ffeaa7".Hex2Color(),
//             [(2,6)] = "#fab1a0".Hex2Color(),
//             [(3,1)] = "#ff7675".Hex2Color(),
//             [(3,2)] = "#fd79a8".Hex2Color(),
//             [(3,3)] = "#636e72".Hex2Color(),
//             [(3,4)] = "#fdcb6e".Hex2Color(),
//             [(3,5)] = "#d63031".Hex2Color(),
//             [(3,6)] = "#e84393".Hex2Color(),
//         };
//         
//         private const string kTileRes = "100_100";
//         
//         private readonly GameObject mAllyGrid;
//         private readonly Dictionary<(int x, int y), SpriteRenderer> mAllyTiles;
//         
//         private readonly GameObject mEnemyGrid;
//         private readonly Dictionary<(int x, int y), SpriteRenderer> mEnemyTiles;
//         
//         public SquadBattlefieldBind()
//         {
//             SelfGo = new GameObject("SquadMap");
//             
//             mAllyGrid = new GameObject("AllyGrid");
//             mEnemyGrid = new GameObject("EnemyGrid");
//             
//             mAllyGrid.transform.SetParent(SelfGo.transform);
//             mEnemyGrid.transform.SetParent(SelfGo.transform);
//             
//             mAllyGrid.transform.localPosition = new Vector3(4, 1.2f, 0);
//             mEnemyGrid.transform.localPosition = new Vector3(-4, 1.2f, 0);
//             
//             mAllyTiles = new Dictionary<(int x, int y), SpriteRenderer>();
//             mEnemyTiles = new Dictionary<(int x, int y), SpriteRenderer>();
//             
//             SpawnGrid(mAllyTiles, mAllyGrid.transform);
//             SpawnGrid(mEnemyTiles, mEnemyGrid.transform);
//             
//             mAllyGrid.transform.localRotation = Quaternion.Euler(0, 0, 90);
//             mEnemyGrid.transform.localRotation = Quaternion.Euler(0, 0, -90);
//         }
//
//         private void SpawnGrid(Dictionary<(int x, int y), SpriteRenderer> tiles, Transform root)
//         {
//             const float offset = ISquadGrid.TROOP_BF_GRID_LENGTH / 2f;
//             var sprite = ResTool.Load<Sprite>(kTileRes);
//             
//             for (var i = 0; i < ISquadGrid.TROOP_BF_GRID_LENGTH; i++)
//             {
//                 for (var j = 0; j < 6; j++)
//                 {
//                     var x = i + 1;
//                     var y = j + 1;
//                     var go = new GameObject($"({x}, {y})");
//                     var spriteRenderer = go.AddComponent<SpriteRenderer>();
//                     spriteRenderer.sprite = sprite;
//                     spriteRenderer.color = Colors[(0,0)];
//                     spriteRenderer.sortingOrder = SpriteOrderDefine.SQUAD_BATTLEFIELD_TILE;
//                     go.transform.SetParent(root);
//                     go.transform.localPosition = new Vector3(i - offset, j - offset, 0);
//                     go.transform.localScale = Vector3.one * .95f;
//                     tiles.Add((x,y), spriteRenderer);
//                 }
//             }
//         }
//         
//         // public void Set(int x, int y, Color color)
//         // {
//         //     mTiles[(x, y)].color = color;
//         // }
//     }
// }