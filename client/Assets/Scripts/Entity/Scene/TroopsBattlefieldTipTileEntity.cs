using FastGameDev.Entity;
using UnityEngine;

namespace Game
{
    public class TroopsBattlefieldTipTileEntity: MonoEntityBase
    {
        public GridPoint point;
        
        protected override void Init(int configId)
        {
            var renders = GetComponentsInChildren<Renderer>();
            foreach (var render in renders)
            {
                render.sortingOrder = SpriteOrderDefine.LEGION_BATTLEFIELD_TIP_TILE;
            }
        }

        protected override void OnUpdate(float dt)
        {
            
        }

        protected override void OnFixedUpdate(float fdt)
        {
            
        }
    }
}