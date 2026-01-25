using FastGameDev.Entity;
using UnityEngine;

namespace Game
{
    public class TroopBfTipTileEntity: EntityBase
    , IWorldModel
    {
        public GridPoint point;
        
        protected override string Tag =>　"scene";
        
        protected override void Init(int config)
        {
            // var renders = GetComponentsInChildren<Renderer>();
            // foreach (var render in renders)
            // {
            //     render.sortingOrder = SpriteOrderDefine.TROOP_BATTLEFIELD_TIP_TILE;
            // }
        }

        public WorldModel Model { get; }
    }
}