using System.Collections.Generic;
using GameDev.Core;
using GameDev.Entity;
using UnityEngine;

namespace Game
{
    public class TroopBfModel: ComponentBase
        , IGetEntity
        , IGetNote
        , IGetModule
    {
        private Dictionary<GridPoint, TroopBfTileEntity> mTiles = new ();

        private WorldModel mModel;
        
        private GameObject mTipTile;
        
        protected override void OnHostReady()
        {
            const float length = BattlefieldDefine.TROOP_BF_GRID_LENGTH;
            const float x0 = - (length - 1) / 2f;
            const float y0 = - (length - 1) / 2f;
            
            var grid = Host.Get<TroopBfGrid>();
            
            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    var x1 = i + 1;
                    var y1 = j + 1;
                    var point = new GridPoint(x1, y1);
                    var id = grid[point];
                    var tileConfig = TroopBfTileEntity.GetConfig(x1, y1, id);
                    var tile = this.Entity().Require<TroopBfTileEntity>(tileConfig);
                    tile.Model.Transform.SetParent(mModel.Transform);
                    tile.Model.Transform.localPosition = new Vector3(x0 + i, y0 + j, 0); 
                    mTiles[point] = tile;
                }
            }

            var prefab = this.Module().Asset.LoadSync<GameObject>("tip_tile_on_select");
            mTipTile = Object.Instantiate(prefab, mModel.Transform);
        }

        public void UpdateSelectedTile()
        {
            var note = this.Note().Get<TroopBattlefieldNote>();
            mTipTile.transform.position = GetWorldPosition(note.curPoint);
        }
        
        public Vector3 GetWorldPosition(GridPoint point)
        {
            const float length = BattlefieldDefine.TROOP_BF_GRID_LENGTH;
            const float x0 = - (length - 1) / 2f;
            const float y0 = - (length - 1) / 2f;

            return mModel.Transform.position + new Vector3(x0 + point.X - 1, y0 + point.Y - 1, 0);
        }
    }
}