using System.Collections.Generic;
using GameDev.Core;
using GameDev.Entity;
using UnityEngine;

namespace Game
{
    public class TroopBfModel: ComponentBase
        , IGetSystem
        , IGetEntity
        , IGetNote
        , IGetModule
    {
        public WorldModel Model { get; private set; }
        
        private Dictionary<GridPoint, WorldModel> mTiles = new ();
        
        private GameObject mTipTile;

        protected override void OnAdded()
        {
            Model = Host.Get<WorldModel>();
            Model.Evt_OnLoaded += OnModelLoaded;
            this.System().Get<TroopBattleSystem>().Evt_OnCurrentPointChanged += UpdateSelectedTile;
        }

        protected override void OnRemoved()
        {
            Model.Evt_OnLoaded -= OnModelLoaded;
            this.System().Get<TroopBattleSystem>().Evt_OnCurrentPointChanged -= UpdateSelectedTile;
        }
        
        private void OnModelLoaded()
        {
            const float length = BattlefieldDefine.TROOP_BF_GRID_LENGTH;
            const float x0 = - (length - 1) / 2f;
            const float y0 = - (length - 1) / 2f;
            
            Model = Host.Get<WorldModel>();
            var grid = Host.Get<TroopBfGrid>();
            
            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    var x1 = i + 1;
                    var y1 = j + 1;
                    var point = new GridPoint(x1, y1);
                    var id = grid[point];
                    var tile = EntityFactory.RequireTroopBfTile(id);
                    var model = tile.Get<WorldModel>();
                    var info = model.Go.GetComponent<TroopBfTileInfo>();
                    
                    model.Transform.SetParent(Model.Transform);
                    model.Transform.localPosition = new Vector3(x0 + i, y0 + j, 0);
                    model.Go.name = $"({x1},{y1})";
                    info.point = point;
                    
                    mTiles[point] = model;
                }
            }
            
            var prefab = this.Module().Asset.LoadSync<GameObject>("tip_tile_on_select");
            
            mTipTile = Object.Instantiate(prefab, Model.Transform);
        }

        private void UpdateSelectedTile()
        {
            var note = this.Note().Get<TroopBattleNote>();
            mTipTile.transform.position = GetWorldPosition(note.currentPoint);
        }
        
        public Vector3 GetWorldPosition(GridPoint point)
        {
            return mTiles.GetValueOrDefault(point)?.Position ?? Vector3.zero;
        }
    }
}