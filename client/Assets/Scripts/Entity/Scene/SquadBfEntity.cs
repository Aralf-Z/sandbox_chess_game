using System.Collections.Generic;
using FastGameDev.Entity;
using UnityEngine;

namespace Game
{
    public class SquadBfEntity: EntityBase
        , IWorldModel
    {
        private readonly Dictionary<GridPoint, SquadBfTileEntity> mTiles = new();
        
        protected override string Tag => "squad_battlefield";
        
        protected override void Init(int config)
        {
            Model = AddBuiltInComponent<WorldModel>();
            Model.name = Tag;
            Model.Load();
            
            for (var x = 0; x < BattlefieldDefine.SQUAD_BF_COL_COUNT; x++)
            {
                for (var y = 0; y < BattlefieldDefine.SQUAD_BF_ROW_COUNT; y++)
                {
                    var tileConfig = SquadBfTileEntity.GetConfig(x, y);
                    var tile = Entity.Require<SquadBfTileEntity>(tileConfig);
                    mTiles[new GridPoint(x, y)] = tile;
                }
            }
        }

        public void SetSquads(SquadEntity ally, SquadEntity enemy)
        {
            
        }

        public WorldModel Model { get; private set; }
    }
}