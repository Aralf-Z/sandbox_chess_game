using System;
using System.Buffers;
using System.Collections.Generic;
using FastGameDev.Core;
using FastGameDev.Entity;
using UnityEngine;

namespace Game
{
    public class TroopBfEntity: EntityBase
    , IWorldModel
    {
        private GameObject mOnSelectTipTile;

        protected override string Tag =>　"troop_battlefield";
        
        protected override void Init(int config)
        {
            Grid = AddBuiltInComponent<TroopBfGrid>();
            Model = AddBuiltInComponent<WorldModel>();
            SelfModel = AddBuiltInComponent<TroopBfModel>();
        }

        public void Enter()
        {
            RefreshSquadPosition();
        }
        
        //更新地块，更新所有队伍位置
        private void RefreshSquadPosition()
        {
            // var record = this.Record().Get<TroopBattlefieldRecord>();
            // foreach (var (point, entity) in record.characters)
            // {
            //     entity.transform.position = WorldPosition(point);
            // }
        }
        
        
        
        public void OnCurSquadMoveTips(List<(GridPoint point, bool isReachable)> reachable)
        {
            //可到达位置淡蓝色，可到达位置+1淡红色
            // this.Entity().RecycleMonoEntity(mTipTiles);
            // mTipTiles.Clear();
            //
            // foreach (var info in reachable)
            // {
            //     var tip = this.Entity().RequireMonoEntity<TroopBfTipTileEntity>(kTipTile);
            //     var worldPos = WorldPosition(info.point);
            //     tip.gameObject.name = $"tip_{info.point}";
            //     tip.gameObject.transform.SetParent(transform);
            //     tip.gameObject.transform.position = new Vector3(worldPos.x, worldPos.y, 0);
            //     tip.point = info.point;
            //     mTipTiles.Add(tip);
            // }
        }

        public TroopBfGrid Grid { get; private set; }
        public WorldModel Model { get; private set; }
        public TroopBfModel SelfModel { get; private set; }
    }
}