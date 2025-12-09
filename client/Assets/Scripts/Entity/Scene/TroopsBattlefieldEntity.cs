using System;
using System.Collections.Generic;
using FastGameDev;
using FastGameDev.Core;
using FastGameDev.Entity;
using UnityEngine;

namespace Game
{
    public sealed class TroopsBattlefieldEntity: MonoEntityBase
    , IHaveGrid
    {
        private const string kNormalTile = "tile_normal";
        private const string kTipTile = "tip_tile";
        private const string kOnSelectedTip = "tip_tile_on_select";

        private Dictionary<GridPoint, SpriteRenderer> mTiles;
        private readonly List<TroopsBattlefieldTipTileEntity> mTipTileEntities = new List<TroopsBattlefieldTipTileEntity>();
        private GameObject mOnSelectTipTile;

        protected override void Init(int configId)
        {
            //tiles gen
            var tile = this.Asset().LoadSync<GameObject>(kNormalTile);

            mTiles = new Dictionary<GridPoint, SpriteRenderer>();
            for (var i = 1; i <= BattlefieldDefine.GRID_LENGTH; i++)
            {
                for (var j = 1; j <= BattlefieldDefine.GRID_LENGTH; j++)
                {
                    var position = new GridPoint(i, j);
                    var go = Instantiate(tile, transform);
                    var re = go.GetComponent<SpriteRenderer>();
                    var worldPos = WorldPosition(position);
                    go.name = $"{i}_{j}";
                    go.transform.position = new Vector3(worldPos.x, worldPos.y, 0);
                    re.sortingOrder = SpriteOrderDefine.LEGION_BATTLEFIELD_TILE;
                    mTiles.Add(position, re);
                }
            }

            //tileInfo set
            Grid = new TroopsBattlefieldGrid();
            foreach (var (point, render) in mTiles)
            {
                var type = Grid[point];
                render.color = type switch//1: 普通; 2: 困难; 0: 无法通过
                {
                    1 => Color.white,
                    2 => Color.green,
                    0 => Color.black,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            
            //tip
            var prefab = this.Asset().LoadSync<GameObject>(kOnSelectedTip);
            mOnSelectTipTile = Instantiate(prefab, transform);
            var spriteRenderer = mOnSelectTipTile.GetComponent<SpriteRenderer>();
            spriteRenderer.sortingOrder = SpriteOrderDefine.LEGION_BATTLEFIELD_TIP_TILE;
            mOnSelectTipTile.SetActive(false);
        }
        
        protected override void OnUpdate(float dt)
        {
            
        }

        protected override void OnFixedUpdate(float fdt)
        {
            
        }

        public void OnSelectPoint(GridPoint point)
        {
            var onSelectWorldPos = WorldPosition(point);
            mOnSelectTipTile.transform.position = new Vector3(onSelectWorldPos.x, onSelectWorldPos.y, 0);
            mOnSelectTipTile.SetActive(true);
        }
        
        public void OnCurSquadMoveTips(List<(GridPoint point, bool isReachable)> reachable)
        {
            //可到达位置淡蓝色，可到达位置+1淡红色
            this.Entity().RecycleMonoEntity(mTipTileEntities);
            mTipTileEntities.Clear();

            foreach (var info in reachable)
            {
                var tip = this.Entity().RequireMonoEntity<TroopsBattlefieldTipTileEntity>(kTipTile);
                var worldPos = WorldPosition(info.point);
                tip.gameObject.name = $"tip_{info.point}";
                tip.gameObject.transform.SetParent(transform);
                tip.gameObject.transform.position = new Vector3(worldPos.x, worldPos.y, 0);
                tip.point = info.point;
                mTipTileEntities.Add(tip);
            }
        }
        
        public Vector2 WorldPosition(GridPoint point)
        {
            const float offset = BattlefieldDefine.GRID_LENGTH / 2f + 1;
            var rootPosition = transform.position;
            return new Vector2(point.X - offset + rootPosition.x, point.Y - offset + rootPosition.y);
        }

        public IGrid Grid { get; private set; }
    }
}