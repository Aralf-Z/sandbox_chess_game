using System;
using System.Buffers;
using System.Collections.Generic;
using FastGameDev.Core;
using FastGameDev.Entity;
using UnityEngine;

namespace Game
{
    public sealed class TroopsBattlefieldEntity: MonoEntityBase
        , IGetRecord
    {
        private const string kNormalTile = "tile_normal";
        private const string kTipTile = "tip_tile";
        private const string kOnSelectedTip = "tip_tile_on_select";

        private Dictionary<GridPoint, SpriteRenderer> mTiles;
        private readonly List<TroopsBattlefieldTipTileEntity> mTipTileEntities = new List<TroopsBattlefieldTipTileEntity>();
        private GameObject mOnSelectTipTile;

        protected override string Tag =>　"TroopsBattlefield";
        
        protected override void Init(int configId)
        {
            //tiles gen
            var tile = this.Module().Asset.LoadSync<GameObject>(kNormalTile);

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

            //tileEntity set
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
            var prefab = this.Module().Asset.LoadSync<GameObject>(kOnSelectedTip);
            mOnSelectTipTile = Instantiate(prefab, transform);
            var spriteRenderer = mOnSelectTipTile.GetComponent<SpriteRenderer>();
            spriteRenderer.sortingOrder = SpriteOrderDefine.LEGION_BATTLEFIELD_TIP_TILE;
            mOnSelectTipTile.SetActive(false);
        }

        public void Enter()
        {
            SetSquadPosition();
            RefreshSquadPosition();
        }
        
        private void SetSquadPosition()
        {
            const int tilesMaxLength = BattlefieldDefine.GRID_LENGTH * BattlefieldDefine.GRID_LENGTH;

            var record = this.Record().Get<TroopsBattlefieldRecord>();
            var random = new System.Random();
            var allyTiles = ArrayPool<GridPoint>.Shared.Rent(tilesMaxLength);
            var enemyTiles = ArrayPool<GridPoint>.Shared.Rent(tilesMaxLength);
            var atCount = 0;
            var etCount = 0;
            
            record.squads.Clear();
            
            try
            {
                for (var x = 1; x <= BattlefieldDefine.GRID_LENGTH; x++)
                {
                    for (var y = 1; y <= BattlefieldDefine.GRID_LENGTH; y++)
                    {
                        var position = new GridPoint(x, y);
                        if (x <= BattlefieldDefine.ALLY_ENEMY_ROW_DIVISION)
                        {
                            if (Grid[position] != BattlefieldDefine.TILE_TYPE_BLOCK)
                                allyTiles[atCount++] = position;
                        }
                        else
                        {
                            if (Grid[position] != BattlefieldDefine.TILE_TYPE_BLOCK)
                                enemyTiles[etCount++] = position;
                        }
                    }
                }
                foreach (var squad in record.allyTroop.Setup.squads)
                {
                    var index = random.Next(atCount);
                    var point = allyTiles[index];
                    squad.Context.gridPoint = point;
                    record.squads[point] = squad;
                    allyTiles[index] = allyTiles[atCount--];
                }
                foreach (var squad in record.enemyTroop.Setup.squads)
                {
                    var index = random.Next(etCount);
                    var point = enemyTiles[index];
                    squad.Context.gridPoint = point;
                    record.squads[point] = squad;
                    enemyTiles[index] = enemyTiles[etCount--];
                }
            }
            finally
            {
                ArrayPool<GridPoint>.Shared.Return(allyTiles,true);
                ArrayPool<GridPoint>.Shared.Return(enemyTiles, true);
            }
        }
        
        //更新地块，更新所有队伍位置
        private void RefreshSquadPosition()
        {
            var record = this.Record().Get<TroopsBattlefieldRecord>();
            foreach (var (point, entity) in record.squads)
            {
                entity.transform.position = WorldPosition(point);
            }
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

        public TroopsBattlefieldGrid Grid { get; private set; }
    }
}