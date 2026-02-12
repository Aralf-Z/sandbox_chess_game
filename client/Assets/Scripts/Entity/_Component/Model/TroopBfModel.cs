using System.Collections.Generic;
using FastGameDev.Core;
using FastGameDev.Entity;
using UnityEngine;

namespace Game
{
    public class TroopBfModel: ComponentBase
        , IGetEntity
    {
        private Dictionary<GridPoint, TroopBfTileEntity> mTiles = new ();
        
        public WorldModel Model { get; private set; }
        
        protected override void OnAdded()
        {
            const float length = BattlefieldDefine.TROOP_BF_GRID_LENGTH;
            const float x0 = - (length - 1) / 2f;
            const float y0 = - (length - 1) / 2f;

            Model = Host.Get<WorldModel>();
            Model.name = "troops_battlefield";
            Model.Load();
            
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
                    tile.Model.Transform.SetParent(Model.Transform);
                    tile.Model.Transform.localPosition = new Vector3(x0 + i, y0 + j, 0); 
                    mTiles[point] = tile;
                }
            }
        }
        
        public Vector3 GetWorldPosition(GridPoint point)
        {
            const float length = BattlefieldDefine.TROOP_BF_GRID_LENGTH;
            const float x0 = - (length - 1) / 2f;
            const float y0 = - (length - 1) / 2f;

            return Model.Transform.position + new Vector3(x0 + point.X - 1, y0 + point.Y - 1, 0);
        }
    }
}