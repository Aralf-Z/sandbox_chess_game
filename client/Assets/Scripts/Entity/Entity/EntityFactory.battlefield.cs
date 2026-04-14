using GameDev.Entity;
using UnityEngine;

namespace Game
{
    public static partial class EntityFactory
    {
        public static Entity RequireSquadBf()
        {
            var bf = game.Entity.Require<Entity>();
            var model = bf.Add<WorldModel>();
            var selfModel = bf.Add<SquadBfModel>();

            model.name = "squad_battlefield";
            model.TryLoad();
            model.Transform.position = new Vector3(100, 100, 0);
            
            return bf;
        }
        
        public static Entity RequireTroopBf()
        {
            var bf = game.Entity.Require<Entity>();
            var grid = bf.Add<TroopBfGrid>();
            var model = bf.Add<WorldModel>();
            var selfModel = bf.Add<TroopBfModel>();

            model.name = "troop_battlefield";
            model.TryLoad();
            model.Transform.position = new Vector3(0, 0, 0);
            
            return bf;
        }

        public static Entity RequireTroopBfTile(int tileId)
        {
            var tile = game.Entity.Require<Entity>();
            
            var model = tile.Add<WorldModel>();
            var selfModel = tile.Add<TroopBfTileModel>();

            model.name = game.Tables.TbTroopBfTile[tileId].Asset;
            model.TryLoad();
            
            return tile;
        }
    }
}