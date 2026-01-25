using FastGameDev.Entity;
using UnityEngine;

namespace Game
{
    public class TroopBfTileEntity: EntityBase
        , IWorldModel
    {
        public GridPoint Point {get; private set;}
        
        protected override string Tag => "troop_tile";
        public WorldModel Model { get; private set; }

        protected override void Init(int config)
        {
            var id = config / 10000 + BattlefieldDefine.TROOP_BF_TILE_ID_PREFIX;
            var x = config % 10000 / 100;
            var y = config % 100;
            
            Point = new GridPoint(x, y);
            
            Model = Add<WorldModel>();
            Model.name = Tables.TbTroopBfTile[id].Asset;
            Model.Load();
            Model.Go.name = Point.ToString();
            
            var spriteRenderer = Model.Go.GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.sortingOrder = SpriteOrderDefine.SQUAD_BATTLEFIELD_TILE;
        }

        public static int GetConfig(int x, int y, int configId) => configId % 10000 * 10000 + x * 100 + y;
    }
}